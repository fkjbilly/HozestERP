
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-09-19 13:36:11
** 修改人:
** 修改日期:
** 描 述: 接口实现类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using HozestERP.BusinessLogic.Caching;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using System.Transactions;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class XMDeliveryProductInventoryService : IXMDeliveryProductInventoryService
    {
        #region Fields
        /// <summary>
        /// Object context
        /// </summary>
        private readonly HozestERPObjectContext _context;
        /// <summary>
        /// Cache manager
        /// </summary>
        private readonly ICacheManager _cacheManager;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public XMDeliveryProductInventoryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMDeliveryProductInventoryService成员
        /// <summary>
        /// Insert into XMDeliveryProductInventory
        /// </summary>
        /// <param name="xmdeliveryproductinventory">XMDeliveryProductInventory</param>
        public void InsertXMDeliveryProductInventory(XMDeliveryProductInventory xmdeliveryproductinventory)
        {
            if (xmdeliveryproductinventory == null)
                return;

            if (!this._context.IsAttached(xmdeliveryproductinventory))

                this._context.XMDeliveryProductInventories.AddObject(xmdeliveryproductinventory);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMDeliveryProductInventory
        /// </summary>
        /// <param name="xmdeliveryproductinventory">XMDeliveryProductInventory</param>
        public void UpdateXMDeliveryProductInventory(XMDeliveryProductInventory xmdeliveryproductinventory)
        {
            if (xmdeliveryproductinventory == null)
                return;

            if (this._context.IsAttached(xmdeliveryproductinventory))
                this._context.XMDeliveryProductInventories.Attach(xmdeliveryproductinventory);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMDeliveryProductInventory list
        /// </summary>
        public List<XMDeliveryProductInventory> GetXMDeliveryProductInventoryList()
        {
            var query = from p in this._context.XMDeliveryProductInventories
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMDeliveryProductInventory> GetXMDeliveryProductInventoryListByParam(List<int?> NickIds, int Year, int Month)
        {
            var query = from p in this._context.XMDeliveryProductInventories
                        where p.IsEnable == false
                        && NickIds.Contains(p.NickId)
                        && p.Year == Year
                        && p.Month == Month
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMDeliveryProductInventory Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDeliveryProductInventory Page List</returns>
        public PagedList<XMDeliveryProductInventory> SearchXMDeliveryProductInventory(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMDeliveryProductInventories
                        orderby p.ID
                        select p;
            return new PagedList<XMDeliveryProductInventory>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMDeliveryProductInventory by ID
        /// </summary>
        /// <param name="id">XMDeliveryProductInventory ID</param>
        /// <returns>XMDeliveryProductInventory</returns>   
        public XMDeliveryProductInventory GetXMDeliveryProductInventoryByID(int id)
        {
            var query = from p in this._context.XMDeliveryProductInventories
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMDeliveryProductInventory by ID
        /// </summary>
        /// <param name="ID">XMDeliveryProductInventory ID</param>
        public void DeleteXMDeliveryProductInventory(int id)
        {
            var xmdeliveryproductinventory = this.GetXMDeliveryProductInventoryByID(id);
            if (xmdeliveryproductinventory == null)
                return;

            if (!this._context.IsAttached(xmdeliveryproductinventory))
                this._context.XMDeliveryProductInventories.Attach(xmdeliveryproductinventory);

            this._context.DeleteObject(xmdeliveryproductinventory);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMDeliveryProductInventory by ID
        /// </summary>
        /// <param name="IDs">XMDeliveryProductInventory ID</param>
        public void BatchDeleteXMDeliveryProductInventory(List<int> ids)
        {
            var query = from q in _context.XMDeliveryProductInventories
                        where ids.Contains(q.ID)
                        select q;
            var xmdeliveryproductinventorys = query.ToList();
            foreach (var item in xmdeliveryproductinventorys)
            {
                if (!_context.IsAttached(item))
                    _context.XMDeliveryProductInventories.Attach(item);

                _context.XMDeliveryProductInventories.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 每月1号0点统计发出商品库存
        /// </summary>
        public void TimingDeliveryProductInventory()
        {
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            DateTime date = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/30 00:00:00");

            if (day == 1 && hour == 0)
            {
                var list = GetXMDeliveryProductInventoryList();
                list = list.Where(x => x.CreateDate >= date).ToList();
                if (list.Count == 0)
                {
                    ToAddDeliveryProductInventory(date);
                }
            }

            //DateTime date = DateTime.Parse("2017/4/23 14:00:00");
            //var list = GetXMDeliveryProductInventoryList();
            //list = list.Where(x => x.CreateDate >= date).ToList();
            //if (list.Count == 0)
            //{
            //    ToAddDeliveryProductInventory(date);
            //}
        }

        public void ToAddDeliveryProductInventory(DateTime date)
        {
            try
            {
                int UserId = 0;
                if (HozestERPContext.Current.User != null)
                {
                    UserId = HozestERPContext.Current.User.CustomerID;
                }
                else
                {
                    string UserName = "admin";
                    List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);
                    if (customer.Count > 0)
                    {
                        UserId = customer[0].CustomerID;
                    }
                }

                DateTime end = date;
                DateTime begin = date.AddMonths(-1);
                int Month = begin.Month;
                int Year = begin.Year;
                List<XMDeliveryProductInventory> OrderProduceList = new List<XMDeliveryProductInventory>();

                #region 订单生成

                //在途库存明细
                var DeliveryListNotShipped = IoC.Resolve<IXMOrderInfoService>().GetrderInfoProductDetailsListNotShipped(begin, end);
                //订单已发货
                var DeliveryList = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoListByDeliveryTime(begin, end);
                if (DeliveryList != null && DeliveryList.Count > 0)
                {
                    //订单已完成
                    var CompletionList = DeliveryList.Where(x => x.CompletionTime != null && x.CompletionTime >= begin && x.CompletionTime < end).ToList();

                    var NickGroup = DeliveryList.GroupBy(x => x.NickID).ToList();
                    foreach (var Item in NickGroup)
                    {
                        var NickList = Item.ToList();
                        if (NickList != null && NickList.Count > 0)
                        {
                            var nickList = CompletionList.Where(x => x.NickID == NickList[0].NickID).ToList();
                            var DeliveryGroup = ToGetProductDetailsList(NickList);
                            var deliveryGroup = ToGetProductDetailsList(nickList);
                            if (DeliveryGroup.Count > 0)
                            {
                                var ProductGroup = DeliveryGroup.GroupBy(x => x.TManufacturersCode).ToList();
                                foreach (var item in ProductGroup)
                                {
                                    var ProductList = item.ToList();
                                    if (ProductList != null && ProductList.Count > 0)
                                    {
                                        XMDeliveryProductInventory one = new XMDeliveryProductInventory();
                                        var productGroup = deliveryGroup.Where(x => x.TManufacturersCode == ProductList[0].TManufacturersCode).ToList();
                                        one.NickId = NickList[0].NickID;
                                        one.Year = Year;
                                        one.Month = Month;
                                        one.ManufacturersCode = ProductList[0].TManufacturersCode;
                                        one.ProductName = ProductList[0].ProductName;
                                        one.Specifications = ProductList[0].Specifications;
                                        //剩余库存
                                        one.SurplusInventory = DeliveryListNotShipped.Where(x => x.Manufacturers == one.ManufacturersCode).Sum(x => x.ProductNum);
                                        //入库
                                        one.StorageCount = ProductList.Sum(x => x.ProductNum);
                                        one.StorageAmount = ProductList.Sum(x => x.SalesPrice);
                                        //出库
                                        one.DeliveryCount = productGroup.Sum(x => x.ProductNum);
                                        one.DeliveryAmount = productGroup.Sum(x => x.SalesPrice);
                                        //库存
                                        one.InventoryCount = one.StorageCount - one.DeliveryCount;
                                        one.InventoryAmount = one.StorageAmount - one.DeliveryAmount;

                                        one.IsEnable = false;
                                        one.CreateDate = one.UpdateDate = DateTime.Now;
                                        one.CreateID = one.UpdateID = UserId;

                                        OrderProduceList.Add(one);
                                    }
                                }

                            }
                        }
                    }
                }

                #endregion

                #region 退换货生成

                List<XMApplication> ApplicationList = new List<XMApplication>();
                List<int?> ApplicationType = new List<int?>();
                ApplicationType.Add(5);//先退货后退款
                ApplicationType.Add(7);//先退款后退货
                var applicationList1 = IoC.Resolve<IXMApplicationService>().GetXMApplicationListByReturnTime(begin, end, ApplicationType);
                var applicationList2 = IoC.Resolve<IXMApplicationService>().GetXMApplicationListByFinishTime(begin, end, 6);//换货
                ApplicationList.AddRange(applicationList1);
                ApplicationList.AddRange(applicationList2);

                var DetailList = ToGetApplicationDetailsList(ApplicationList, 1);//换货新增的产品
                var detailList = ToGetApplicationDetailsList(ApplicationList, 2);//退货旧产品
                OrderProduceList = ToUpdateOrderProduceList(DetailList, true, OrderProduceList, Year, Month, UserId);
                OrderProduceList = ToUpdateOrderProduceList(detailList, false, OrderProduceList, Year, Month, UserId);

                #endregion

                foreach (var Info in OrderProduceList)
                {
                    IoC.Resolve<IXMDeliveryProductInventoryService>().InsertXMDeliveryProductInventory(Info);
                }
            }
            catch (Exception ex) 
            {

            }
        }

        public List<XMOrderInfoProductDetails> ToGetProductDetailsList(List<XMOrderInfo> list)
        {
            List<XMOrderInfoProductDetails> List = new List<XMOrderInfoProductDetails>();
            foreach (var Info in list)
            {
                if (Info.XM_OrderInfoProductDetails != null && Info.XM_OrderInfoProductDetails.Count > 0)
                {
                    foreach (var item in Info.XM_OrderInfoProductDetails)
                    {
                        if (Info.PlatformTypeId == 259 && !item.PlatformMerchantCode.StartsWith("CM"))
                        {
                            continue;
                        }

                        XMOrderInfoProductDetails one = new XMOrderInfoProductDetails();
                        one.ID = Info.ID;
                        if (!string.IsNullOrEmpty(item.TManufacturersCode))
                        {
                            var Product = IoC.Resolve<IXMProductDetailsService>().GetXMProductListByTManufacturersCode(item.TManufacturersCode);
                            if (Product != null && Product.Count > 0)
                            {
                                one.TManufacturersCode = Product[0].ManufacturersCode;
                            }
                        }
                        if (one.TManufacturersCode == null)
                        {
                            var product = IoC.Resolve<IXMProductService>().GetXMProductListByPlatformMerchantCode(item.PlatformMerchantCode, -1);
                            if (product != null && product.Count > 0)
                            {
                                one.TManufacturersCode = product[0].ManufacturersCode;
                            }
                        }
                        one.Specifications = item.Specifications;
                        one.ProductName = item.ProductName;
                        one.ProductNum = item.ProductNum;
                        one.SalesPrice = item.SalesPrice;
                        List.Add(one);
                    }
                }
            }
            return List;
        }

        public List<XMProductNew> ToGetApplicationDetailsList(List<XMApplication> list, int IsApplication)
        {
            List<XMProductNew> List = new List<XMProductNew>();
            foreach (var Info in list)
            {
                var DetailList = IoC.Resolve<IXMApplicationExchangeService>().GetXMApplicationExchangeByAppID(Info.ID);
                if (DetailList != null && DetailList.Count > 0)
                {
                    foreach (var item in DetailList)
                    {
                        if (item.IsApplication != IsApplication)
                        {
                            continue;
                        }
                        XMProductNew one = new XMProductNew();
                        var Product = IoC.Resolve<IXMProductService>().GetXMProductListByPlatformMerchantCode(item.PlatformMerchantCode, -1);
                        if (Product != null && Product.Count > 0)
                        {
                            one.ManufacturersCode = Product[0].ManufacturersCode;
                        }
                        var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(Info.OrderCode);
                        if (OrderInfo != null)
                        {
                            one.NickId = OrderInfo.NickID;
                        }
                        one.Specifications = item.Specifications;
                        one.ProductName = item.ProductName;
                        one.count = item.ProductNum;
                        one.Saleprice = item.SalesPrice;
                        List.Add(one);
                    }
                }
            }
            return List;
        }

        public List<XMDeliveryProductInventory> ToUpdateOrderProduceList(List<XMProductNew> list, bool IsAdd, List<XMDeliveryProductInventory> OrderProduceList, int Year, int Month, int UserId)
        {
            var NickGroup = list.GroupBy(x => x.NickId).ToList();
            foreach (var Item in NickGroup)
            {
                var NickList = Item.ToList();
                if (NickList != null && NickList.Count > 0)
                {
                    var nickList = OrderProduceList.Where(x => x.NickId == NickList[0].NickId).ToList();
                    var ProductGroup = NickList.GroupBy(x => x.ManufacturersCode).ToList();
                    foreach (var item in ProductGroup)
                    {
                        var ProductList = item.ToList();
                        if (ProductList != null && ProductList.Count > 0)
                        {
                            int Count = (int)ProductList.Sum(x => x.count);
                            decimal Amount = (decimal)ProductList.Sum(x => x.Saleprice);

                            if (!IsAdd)
                            {
                                Count = -Count;
                                Amount = -Amount;
                            }

                            var productGroup = nickList.Where(x => x.ManufacturersCode == ProductList[0].ManufacturersCode).ToList();
                            if (productGroup != null && productGroup.Count > 0)
                            {
                                //入库
                                productGroup[0].StorageCount += Count;
                                productGroup[0].StorageAmount += Amount;
                                //出库
                                productGroup[0].DeliveryCount += Count;
                                productGroup[0].DeliveryAmount += +Amount;
                            }
                            else
                            {
                                XMDeliveryProductInventory one = new XMDeliveryProductInventory();
                                one.NickId = NickList[0].NickId;
                                one.Year = Year;
                                one.Month = Month;
                                one.ManufacturersCode = ProductList[0].ManufacturersCode;
                                one.ProductName = ProductList[0].ProductName;
                                one.Specifications = ProductList[0].Specifications;

                                //入库
                                one.StorageCount = Count;
                                one.StorageAmount = Amount;
                                //出库
                                one.DeliveryCount = Count;
                                one.DeliveryAmount = Amount;
                                //库存
                                one.InventoryCount = one.StorageCount - one.DeliveryCount;
                                one.InventoryAmount = one.StorageAmount - one.DeliveryAmount;

                                one.IsEnable = false;
                                one.CreateDate = one.UpdateDate = DateTime.Now;
                                one.CreateID = one.UpdateID = UserId;

                                OrderProduceList.Add(one);
                            }
                        }
                    }
                }
            }

            return OrderProduceList;
        }

        #endregion
    }
}
