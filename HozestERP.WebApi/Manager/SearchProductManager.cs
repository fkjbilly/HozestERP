using HozestERP.WebApi.Message;
using HozestERP.WebApi.SQl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HozestERP.WebApi.Manager
{
    public class SearchProductManager : IDisposable
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
        /// <param name="manufacturersCodeList">商品编码数据</param>
        /// <param name="pageSize">每页获取条数</param>
        /// <param name="pageNum">获取页码</param>
        /// <returns></returns>
        public List<ErpProductList> GetXMProduct(List<string> manufacturersCodeList, TotalHeader header)
        {
            var sqlWhere = string.Join("','", manufacturersCodeList);
            var sqlProduct = string.Format(@"select a.PlatformMerchantCode,a.Saleprice,b.ProductName,b.ProductUnit,b.ProductWeight 
from dbo.XM_ProductDetails a join dbo.XM_Product b on a.ProductId = b.Id where a.PlatformMerchantCode in ('{0}') and b.IsEnable = 0 and a.IsEnable = 0", sqlWhere);//查询语句
            var sqlComProduct = string.Format(@"select a.PlatformMerchantCode,a.Saleprice,b.ProductName,b.ProductWeight 
from dbo.XM_CombinationDetails a join dbo.XM_Combination b on a.ProductId = b.ID where a.PlatformMerchantCode in ('{0}') and b.IsEnabled = 0 and a.IsEnable = 0", sqlWhere);//查询语句
            var dtProduct = SqlDataHelper.GetDatatableBySql(sqlProduct);
            var dtComProduct = SqlDataHelper.GetDatatableBySql(sqlComProduct);
            var dtProductList = CurUtilManager.ToEntity<ErpProductList>(dtProduct);
            var dtComProductList = CurUtilManager.ToEntity<ErpProductList>(dtComProduct);
            dtComProductList.AsParallel().ForAll(m =>
            {
                GetProductChild(m);
            });
            var ErpProductList = dtProductList.Concat(dtComProductList);
            #region 判断传入的商品编号是否都找得到对应的商品信息
            var ErpPlatformMerchantCodeList = ErpProductList.Select(m => m.PlatformMerchantCode).ToList();
            var ExceptList = manufacturersCodeList.Except(ErpPlatformMerchantCodeList).ToList();
            if (ExceptList.Count > 0)
            {
                header.IsSuccess = false;
                header.Message = string.Format("这些商品编号{0}在ERP中无法找到对应的商品信息", string.Join(",", ExceptList));
            }
            #endregion
            return ErpProductList.ToList();
        }
        public void GetProductChild(ErpProductList m)
        {
            var ProductList  = this.GetXMProductListByzuheCode(m.PlatformMerchantCode, 508);// base.ProjectService.GetXMProductListByJDId(SkuId.ToString());
            if (ProductList.Count != 0)
            {
                m.ProductChildList = new List<ErpProductChildList>();
                foreach (var elem in ProductList)
                {
                    var entity = new ErpProductChildList();
                    entity.PlatformMerchantCode = elem.PlatformMerchantCode; //料号（商品编码,对应供应商那边）
                    entity.ProductName = elem.ProductName;//产品名称
                    entity.ProductNum = elem.count;//产品数量
                    m.ProductChildList.Add(entity);
                }
            }
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
        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="pageSize">每页获取条数</param>
        /// <param name="pageNum">获取页码</param>
        /// <returns></returns>
        public List<ErpProductList> GetXMProduct(int pageSize, int pageNum,ref int total)
        {
            try
            {
                // var sql = string.Format(@"select top {0} a.Id,b.ManufacturersCode,a.Saleprice,b.ProductName,b.ProductUnit,b.Specifications 
                //from dbo.XM_ProductDetails a join dbo.XM_Product b on a.ProductId = b.Id
                //where a.Id  not in 
                //(select top {1} c.Id from dbo.XM_ProductDetails c join dbo.XM_Product d on c.ProductId = d.Id order by c.Id) 
                //order by a.Id ", pageSize, pageSize * (pageNum - 1));//插入主表的sql语句
                var sqlProduct = @"select a.Id,a.PlatformMerchantCode,a.Saleprice,b.ProductName,b.ProductUnit,b.ProductWeight 
from dbo.XM_ProductDetails a join dbo.XM_Product b on a.ProductId = b.Id where b.IsEnable = 0 and a.IsEnable = 0";//插入主表的sql语句
                var sqlComProduct = @"select a.ID,a.PlatformMerchantCode,a.Saleprice,b.ProductName,b.ProductWeight 
from dbo.XM_CombinationDetails a join dbo.XM_Combination b on a.ProductId = b.ID where b.IsEnabled = 0 and a.IsEnable = 0";//插入主表的sql语句
                                                                        
                var dtProduct = SqlDataHelper.GetDatatableBySql(sqlProduct);
                var dtComProduct = SqlDataHelper.GetDatatableBySql(sqlComProduct);
                var dtProductList = CurUtilManager.ToEntity<ErpProductList>(dtProduct);
                var dtComProductList = CurUtilManager.ToEntity<ErpProductList>(dtComProduct);
                dtComProductList.AsParallel().ForAll(m =>
                {
                    GetProductChild(m);
                });
                //foreach(var elem in dtComProductList)
                //{
                //    GetProductChild(elem);
                //}
                var ErpProductList = dtProductList.Concat(dtComProductList).OrderBy(m=>m.PlatformMerchantCode);
                total = ErpProductList.Count() ;
                return ErpProductList.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            }catch(Exception ex)
            {
                return null;
            }
        }

        public bool ValidationSecretKey(RequestProductApi requestProductApi)
        {
            var SecretKey = requestProductApi.SecretKey;
            requestProductApi.SecretKey = null;
            var objectJson = JsonConvert.SerializeObject(requestProductApi);
            var SecretKey1 = CurUtilManager.MD5Encrypt(string.Format("{0}Hozest88582", objectJson));//获取参数加密的字符串
            if (SecretKey.Equals(SecretKey1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Dispose()
        {
            System.GC.Collect();
        }
    }
}