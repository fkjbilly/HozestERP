using HozestERP.WebApi.Message;
using HozestERP.WebApi.SQl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HozestERP.WebApi.Manager
{
    public class SearchOrderStatusManager : IDisposable
    {
        public UtilManager _utilManager;
        public UtilManager CurUtilManager
        {
            get
            {
                if (_utilManager == null)
                {
                    _utilManager = new UtilManager();
                }
                return _utilManager;
            }
        }
        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="orderCodeList">订单编号数组</param>
        /// <returns></returns>
        public List<ErpOrderStatusList> GetXMOrderStatus(List<RequestOrderStatusList> orderStatusList, Header header)
        {
            var baseProductbag = new System.Collections.Concurrent.ConcurrentBag<RequestOrderStatusList>();
            var baseProductDictionary = new System.Collections.Concurrent.ConcurrentDictionary<string, List<string>>();//存储每个订单号和五道编码对应的拆分后的erp商品编码
            #region 如果传回的商品编号中有组合商品的商品编号，则将组合商品拆分为基础商品数组
            orderStatusList.AsParallel().ForAll(m =>
            {
                setProductNum(m, baseProductbag, baseProductDictionary);
            });
            #endregion
            var MerchantCodeList = baseProductbag.Select(m => m.PlatformMerchantCode).ToList();
            var OrderCodeList = baseProductbag.Select(m => m.OrderCode).ToList();
            var sqlMerchantCodeList = string.Join("','", MerchantCodeList);
            var sqlOrderNoList = string.Join("','", OrderCodeList);
            var sql = string.Format(@"select a.PlatformMerchantCode,a.OrderNo as OrderCode,b.IsDelivery,c.LogisticsName,b.LogisticsNumber 
from XM_Delivery_Details a join XM_Delivery b on b.Id = a.DeliveryId left join XM_CompanyCustom c on b.LogisticsId = c.LogisticsId where a.PlatformMerchantCode in ('{0}') and a.OrderNo in ('{1}') and b.IsEnabled = 0", sqlMerchantCodeList, sqlOrderNoList);//插入主表的sql语句
            var dt = SqlDataHelper.GetDatatableBySql(sql);
            var ErpOrderStatusList = CurUtilManager.ToEntity<ErpOrderStatusList>(dt);
            var returnEntity = returnOrderStatus(orderStatusList, baseProductDictionary, ErpOrderStatusList.ToList());
            #region 判断传入的订单号和商品编号是否都找到对应的订单信息
            var returnOrderList = returnEntity.Select(m => new 
            {
                Code = m.OrderCode + "_" + m.PlatformMerchantCode
            }).Select(m=>m.Code).ToList();
            var returnorderList = orderStatusList.Select(m => new
            {
                Code = m.OrderCode + "_" + m.PlatformMerchantCode
            }).Select(m => m.Code).ToList();

            var ExceptList = returnorderList.Except(returnOrderList).ToList();
            if (ExceptList.Count > 0)
            {
                header.IsSuccess = false;
                header.Message = string.Format("这些订单号和商品编号组合{0}在ERP中无法找到对应的订单状态信息", string.Join(",", ExceptList));
            }
            #endregion
            return returnEntity;
        }
        /// <summary>
        /// 将组合商品拆分成基础商品信息
        /// </summary>
        public void setProductNum(RequestOrderStatusList m, System.Collections.Concurrent.ConcurrentBag<RequestOrderStatusList> productList,System.Collections.Concurrent.ConcurrentDictionary<string, List<string>> baseProductDictionary)
        {
            var ProductList = this.GetXMProductListByzuheCode(m.PlatformMerchantCode, 508);//判断是否是组合商品，是的话将会拆分成组成商品的基础商品信息
            var erpPlatformMerchantCodelist = new List<string>();
            if (ProductList.Count != 0)
            {
                foreach (var elem in ProductList)
                {
                    var entity = new RequestOrderStatusList();
                    entity.OrderCode = m.OrderCode;
                    entity.PlatformMerchantCode = elem.PlatformMerchantCode; //料号（商品编码,对应供应商那边）
                    erpPlatformMerchantCodelist.Add(elem.PlatformMerchantCode);
                    productList.Add(entity);
                }
            }
            else {
                productList.Add(m);
                //erpPlatformMerchantCodelist.Add(m.PlatformMerchantCode);
            }
            var keyvalue = m.OrderCode + "," + m.PlatformMerchantCode;
            if (!baseProductDictionary.Keys.Contains(keyvalue))
                baseProductDictionary.TryAdd(keyvalue, erpPlatformMerchantCodelist);
        }
        /// <summary>
        /// 寻找商品表中的商品信息
        /// </summary>
        public List<XMProductNew> GetXMProductListByPlatFormMerchantCode(string PlatFormMerchantCode, int PlatformTypeId)
        {
            var sql = string.Format(@"select a.Id,a.ProductId,a.PlatformTypeId,a.PlatformMerchantCode,a.ProductTypeId,a.PlatformInventory,
                                a.strUrl,a.Images,a.Costprice,a.Saleprice,a.TCostprice,a.TDateTimeStart,a.TDateTimeEnd,a.IsMainPush,
b.BrandTypeId, b.ProductName,b.ManufacturersCode,b.Specifications,b.ManufacturersInventory,b.WarningQuantity,b.ProductColors,
b.ProductUnit,b.IsPremiums,b.IsEnable,b.CreateID,b.CreateDate,b.UpdateID,b.UpdateDate,a.TemporaryManufacturersCode
                               from XM_ProductDetails a join XM_Product b on a.ProductId = b.Id 
                               where  a.IsEnable = 0 and a.PlatformMerchantCode = '{0}' and a.PlatformTypeId = {1}", PlatFormMerchantCode, PlatformTypeId);
            //先去找对应平台没有则找通用平台
            var dt = SqlDataHelper.GetDatatableBySql(sql);
            var resultArray = CurUtilManager.ToEntity<XMProductNew>(dt);
            return resultArray.ToList();
        }

        /// <summary>
        ///寻找组合产品中对应的erp供应商产品
        /// </summary>
        public List<XMProductNew> GetXMProductListByzuheCode(string PlatFormMerchantCode, int PlatformTypeId)
        {
            var sql = string.Format(@"select s.Id,a.Count,s.BrandTypeId,s.ProductName,s.ManufacturersCode,s.Specifications,
                                s.ManufacturersInventory,s.WarningQuantity,s.ProductColors,s.ProductUnit,s.IsPremiums, s.IsEnable,
                                s.CreateID, s.CreateDate, s.UpdateID,s.UpdateDate
                               from XM_Product s join XM_Product_Combination a on a.ProductId = s.Id 
                               join XM_Combination b on a.CombinationID = b.ID join XM_CombinationDetails p on b.ID = p.ProductId
                               where  a.IsEnabled = 0 and s.IsEnable = 0 and b.IsEnabled = 0 and p.IsEnable = 0 and p.PlatformMerchantCode = '{0}' and p.PlatformTypeId = {1}", PlatFormMerchantCode, PlatformTypeId);

            var dt = SqlDataHelper.GetDatatableBySql(sql);
            var resultArray = CurUtilManager.ToEntity<XMProductNew>(dt);

            List<XMProductNew> list = new List<XMProductNew>();
            if (resultArray.ToList() != null && resultArray.ToList().Count > 0)
            {
                foreach (XMProductNew info in resultArray.ToList())
                {
                    var sqldetail = string.Format("select * from XM_ProductDetails where ProductId = {0} and IsEnable = 0", info.Id);
                    var detaildt = SqlDataHelper.GetDatatableBySql(sqldetail);
                    var detail = CurUtilManager.ToEntity<XMProductDetails>(detaildt);
                    var Detail = detail.Where(p => p.PlatformTypeId == PlatformTypeId).ToList();
                    if (Detail != null && Detail.Count() > 0)
                    {
                        XMProductDetails q = Detail[Detail.Count() - 1];
                        info.Id = q.Id;
                        info.ProductId = q.ProductId;
                        info.PlatformTypeId = q.PlatformTypeId;
                        info.PlatformMerchantCode = q.PlatformMerchantCode;
                        info.ProductTypeId = q.ProductTypeId;
                        info.PlatformInventory = q.PlatformInventory;
                        info.strUrl = q.strUrl;
                        info.Images = q.Images;
                        info.Costprice = q.Costprice;
                        info.Saleprice = q.Saleprice;
                        info.TCostprice = q.TCostprice;
                        info.TDateTimeStart = q.TDateTimeStart;
                        info.TDateTimeEnd = q.TDateTimeEnd;
                        info.IsMainPush = q.IsMainPush;
                        info.TManufacturersCode = q.TemporaryManufacturersCode;
                        list.Add(info);
                    }
                }
            }
            return list;
        }
        public List<ErpOrderStatusList> returnOrderStatus(List<RequestOrderStatusList> orderStatusList, System.Collections.Concurrent.ConcurrentDictionary<string, List<string>> baseProductDictionary, List<ErpOrderStatusList> erpOrderStatusList)
        {
            var erpOrderStatusBag = new System.Collections.Concurrent.ConcurrentBag<ErpOrderStatusList>();
            orderStatusList.AsParallel().ForAll(m =>
            {
                erpOrderStatusBag.Add(isErpOrderStatus(erpOrderStatusList, m, baseProductDictionary));
            });
            //erpOrderStatusList.AsParallel().ForAll(m =>
            //{
            //    erpOrderStatusBag.Add(isErpOrderStatus(orderStatusList, m));
            //});
            var list = erpOrderStatusBag.Where(m=>m.OrderCode != string.Empty && m.PlatformMerchantCode != string.Empty).ToList();
            return list;
        }
        /// <summary>
        /// 得到每个请求的货物的发货状态
        /// </summary>
        /// <param name="orderStatusList">erp中相关的请求物品的发货信息</param>
        /// <param name="erpOrderStatus">五道发送的请求信息</param>
        /// <param name="baseProductDictionar">记录组合商品的信息</param>
        /// <returns></returns>
        public ErpOrderStatusList isErpOrderStatus(List<ErpOrderStatusList> orderStatusList, RequestOrderStatusList erpOrderStatus, System.Collections.Concurrent.ConcurrentDictionary<string, List<string>> baseProductDictionar)
        {
            var keyvalue = erpOrderStatus.OrderCode + "," + erpOrderStatus.PlatformMerchantCode;
            if (baseProductDictionar.Keys.Contains(keyvalue) && baseProductDictionar[keyvalue].Count != 0)//如果是拆分的组合商品
            {
                var entity = new ErpOrderStatusList() { OrderCode= erpOrderStatus.OrderCode,PlatformMerchantCode = erpOrderStatus.PlatformMerchantCode};
                var PlatformMerchantCodeList = baseProductDictionar[keyvalue];
                var allEntity = orderStatusList.Where(m => PlatformMerchantCodeList.Contains(m.PlatformMerchantCode) && m.OrderCode == erpOrderStatus.OrderCode).ToList();
                if (allEntity.Count > 0)
                {
                    entity.IsDelivery = !allEntity.Where(m => m.IsDelivery == false).Any();//如果有一单没有发货则整个组合商品就是未发货状态
                    var firLogistics = allEntity.FirstOrDefault();//如果都发货则回传第一个发货单号
                    entity.LogisticsName = entity.IsDelivery ? firLogistics.LogisticsName : string.Empty;
                    entity.LogisticsNumber = entity.IsDelivery ? firLogistics.LogisticsNumber : string.Empty;
                    return entity;
                }
                else {
                    entity.OrderCode = string.Empty;
                    entity.PlatformMerchantCode = string.Empty;
                    //entity.IsDelivery = false;
                    //entity.LogisticsName = string.Empty;
                    //entity.LogisticsNumber = string.Empty;
                    return entity;
                }
            }
            else {//非组合商品
                var allEntity = orderStatusList.Where(m => m.PlatformMerchantCode == erpOrderStatus.PlatformMerchantCode && m.OrderCode == erpOrderStatus.OrderCode).ToList();
                var entity = new ErpOrderStatusList() { OrderCode = erpOrderStatus.OrderCode, PlatformMerchantCode = erpOrderStatus.PlatformMerchantCode };
                if (allEntity.Count > 0)
                {
                    return allEntity.FirstOrDefault();
                }
                else {
                    entity.OrderCode = string.Empty;
                    entity.PlatformMerchantCode = string.Empty;
                    //entity.IsDelivery = false;
                    //entity.LogisticsName = string.Empty;
                    //entity.LogisticsNumber = string.Empty;
                    return entity;
                }
            }
        }

        public string CancelOrder(List<string> orderCodeList)
        {
            var errorstr = string.Empty;
            try
            {
                var sqlOrderCodeList = string.Join("','", orderCodeList);
                var sql = string.Format(@"select ID, OrderCode , IsAudit from XM_OrderInfo where OrderCode in ('{0}')", sqlOrderCodeList);
                var dt = SqlDataHelper.GetDatatableBySql(sql);
                var ErpErpOrderInfoList = CurUtilManager.ToEntity<ErpOrderInfo>(dt);
                #region 判断是否所有传入的订单号都找得到对应的订单信息
                var ErpErpOrderCodeList = ErpErpOrderInfoList.Select(m => m.OrderCode).ToList();
                var ExceptList = orderCodeList.Except(ErpErpOrderCodeList).ToList();
                if (ExceptList.Count > 0)
                    return string.Format("这些订单号{0}在ERP中无法找到对应的订单信息", string.Join(",", ExceptList));
                #endregion
                var notdeleteList = ErpErpOrderInfoList.Where(m => m.IsIsAudit == true).Select(m => m.OrderCode).ToList();
                if (notdeleteList.Count > 0)
                {
                    return string.Format("这些订单号{0}已经审核无法取消", string.Join(",", notdeleteList));
                }
                else
                {
                    var deleteIDList = ErpErpOrderInfoList.Select(m => m.ID).ToList();
                    var sqlwhereids = string.Join(",", deleteIDList);
                    var deleteSql = string.Format(@"delete from XM_OrderInfoProductDetails where OrderInfoID in ('{0}') delete from XM_OrderInfo where ID in ('{0}')", sqlwhereids);
                    SqlDataHelper.ExcuteBySql(deleteSql);
                }
            }catch(Exception ex)
            {
                InsertLog.Insert("取消订单接口报错:"+ex.Message,ex);
            }
            return errorstr;
        }
        public void Dispose()
        {
            System.GC.Collect();
        }
    }
}