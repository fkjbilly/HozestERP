
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-09 11:02:52
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
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMOrderInfoProductDetailsService : IXMOrderInfoProductDetailsService
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
        public XMOrderInfoProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMOrderInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMOrderInfoProductDetails
        /// </summary>
        /// <param name="xmorderinfoproductdetails">XMOrderInfoProductDetails</param>
        public void InsertXMOrderInfoProductDetails(XMOrderInfoProductDetails xmorderinfoproductdetails)
        {
            if (xmorderinfoproductdetails == null)
                return;

            if (!this._context.IsAttached(xmorderinfoproductdetails))

                this._context.XMOrderInfoProductDetails.AddObject(xmorderinfoproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMOrderInfoProductDetails
        /// </summary>
        /// <param name="xmorderinfoproductdetails">XMOrderInfoProductDetails</param>
        public void UpdateXMOrderInfoProductDetails(XMOrderInfoProductDetails xmorderinfoproductdetails)
        {
            if (xmorderinfoproductdetails == null)
                return;

            if (this._context.IsAttached(xmorderinfoproductdetails))
                this._context.XMOrderInfoProductDetails.Attach(xmorderinfoproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMOrderInfoProductDetails list
        /// </summary>
        public List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsList(int OrderInfoID)
        {
            var query = from p in this._context.XMOrderInfoProductDetails
                        where p.OrderInfoID == OrderInfoID
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderInfoID"></param>
        /// <returns></returns>
        public List<SimpleInfoProductDetail> GetProductNameNum(int OrderInfoID)
        {
            var query = from p in this._context.XMOrderInfoProductDetails
                        where p.OrderInfoID == OrderInfoID
                        && p.IsEnable == false
                        select new SimpleInfoProductDetail
                        {
                            ProductName = p.ProductName,
                            ProductNum = p.ProductNum
                        };
            return query.ToList();
        }

        public List<ProductSalesData> GetProductSales(DateTime BeginDate, DateTime EndDate, int ProjectId, List<int?> NickIdList, List<ProductSalesData> GroupList, int WarehouseID, int ProvinceNameID)
        {
            if (GroupList != null)
            {
                var list = from p in GroupList
                           group p by new { p.ProductName, p.Manufacturers, p.Specifications, p.FactoryPrice, p.ProductNum } into g
                           select new ProductSalesData
                           {
                               ProductName = g.Key.ProductName,
                               Manufacturers = g.Key.Manufacturers,
                               Specifications = g.Key.Specifications,
                               FactoryPrice = g.Key.FactoryPrice,
                               ProductNum = g.Sum(p => p.ProductNum)
                           };
                return list.ToList();
            }
            else
            {
                List<string> ProvinceList = new List<string>();
                List<ProductSalesData> List = new List<ProductSalesData>();

                var provinceList = from p in this._context.ProvinceWarehouses
                                   where p.IsEnabled == false
                                   && (WarehouseID == -1 || p.WarehouseID == WarehouseID)
                                   select p.ProvinceName.Substring(0, 2);
                if (ProvinceNameID != -1)
                {
                    var ProvinceName = from p in this._context.ProvinceWarehouses
                                       where p.IsEnabled == false
                                       && p.ID == ProvinceNameID
                                       select p;
                    ProvinceList.Add(ProvinceName.SingleOrDefault().ProvinceName.Substring(0, 2));
                }
                else
                {
                    ProvinceList = provinceList.ToList();
                }

                var query = from p in this._context.XMOrderInfoProductDetails
                            join o in this._context.XMOrderInfoes
                            on p.OrderInfoID equals o.ID
                            join pId in this._context.XMNicks
                            on o.NickID equals pId.nick_id
                            where p.IsEnable == false
                            && o.IsEnable == false
                            && pId.isEnable == true
                            && pId.ProjectId == ProjectId
                            && NickIdList.Contains(o.NickID)//(NickId == -1 || o.NickID == NickId)
                            && o.DeliveryTime != null
                            && o.DeliveryTime >= BeginDate
                            && o.DeliveryTime <= EndDate
                            && ((o.NickID == 32 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == ""))
                       || o.NickID != 32)
                            select new ProductSalesData
                            {
                                ID = p.ID,
                                OrderInfoID = p.OrderInfoID,
                                PlatformMerchantCode = p.PlatformMerchantCode,
                                ProductName = p.ProductName,
                                ProductNum = p.ProductNum,
                                Specifications = p.Specifications,
                                NickID = o.NickID,
                                FactoryPrice = p.FactoryPrice,
                                ProjectID = pId.ProjectId,
                                PlatformTypeId = o.PlatformTypeId,
                                Manufacturers = "",
                                Province = o.Province,
                                DeliveryAddress = o.DeliveryAddress
                            };

                var list = from x in this._context.XMProducts
                           join a in this._context.XMProductDetails
                           on x.Id equals a.ProductId
                           from q in query
                           where x.IsEnable == false
                           && a.IsEnable == false
                           && x.IsPremiums == false
                           && a.PlatformMerchantCode == q.PlatformMerchantCode
                           && (a.PlatformTypeId == q.PlatformTypeId || a.PlatformTypeId==508)
                           select new ProductSalesData
                           {
                               ID = q.ID,
                               OrderInfoID = q.OrderInfoID,
                               PlatformMerchantCode = q.PlatformMerchantCode,
                               ProductName = q.ProductName,
                               ProductNum = q.ProductNum,
                               Specifications = q.Specifications,
                               NickID = q.NickID,
                               FactoryPrice = q.FactoryPrice,
                               ProjectID = q.ProjectID,
                               PlatformTypeId = q.PlatformTypeId,
                               Manufacturers = x.ManufacturersCode,
                               Province = q.Province,
                               DeliveryAddress = q.DeliveryAddress
                           };

                foreach (var Item in list)
                {
                    string address = "";
                    if (string.IsNullOrEmpty(Item.Province))
                    {
                        address = Item.DeliveryAddress.Substring(0, 2);
                    }
                    else
                    {
                        address = Item.Province.Substring(0, 2);
                    }

                    if (ProvinceList.Contains(address))
                    {
                        List.Add(Item);
                    }
                }

                return List.ToList();
            }
        }

        public List<ProductSalesData> GetNotShippedSales(string Begin, string End, int ProjectId, List<int?> NickIdList, List<ProductSalesData> GroupList, int WaitNotice, int Urgent, int CanDeliver, int AppointDeliveryTime, int remarks, DateTime PayBeginDate, DateTime PayEndDate)
        {
            if (GroupList != null)
            {
                var list = from p in GroupList
                           group p by new { p.ProductName, p.Manufacturers, p.Specifications, p.FactoryPrice, p.ProductNum } into g
                           select new ProductSalesData
                           {
                               ProductName = g.Key.ProductName,
                               Manufacturers = g.Key.Manufacturers,
                               Specifications = g.Key.Specifications,
                               FactoryPrice = g.Key.FactoryPrice,
                               ProductNum = g.Sum(p => p.ProductNum)
                           };
                return list.ToList();
            }
            else
            {
                string[] DeliveryStatue = { "WAIT_SELLER_SEND_GOODS", "DS_WAIT_SELLER_DELIVERY", "WAIT_SELLER_DELIVERY", "WAIT_SELLER_STOCK_OUT",
                                  "STATUS_10", "ORDER_TRUNED_TO_DO", "以接受", "10", "新", "已付款" };

                DateTime BeginDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;

                if (Begin != "")
                {
                    BeginDate = DateTime.Parse(Begin);
                }
                if (End != "")
                {
                    EndDate = DateTime.Parse(End).AddDays(1).AddSeconds(-1);
                }
                if (ProjectId == 2)                  //喜临门项目自用
                {
                    List<ProductSalesData> List = new List<ProductSalesData>();
                    #region
                    if (remarks == 0 && (WaitNotice == 1 || Urgent == 1 || CanDeliver == 1 || AppointDeliveryTime == 1))                                            //非异常备注(选择预约时间 或 等通知 或 加急 或能发就发)
                    {

                        var query = from p in this._context.XMOrderInfoProductDetails
                                    join o in this._context.XMOrderInfoes
                                    on p.OrderInfoID equals o.ID
                                    join pId in this._context.XMNicks
                                    on o.NickID equals pId.nick_id
                                    where p.IsEnable == false
                                    && o.IsEnable == false
                                    && pId.isEnable == true
                                    && pId.ProjectId == ProjectId
                                    && NickIdList.Contains(o.NickID)
                                    && p.IsAudit == true
                                    && o.IsAudit == true
                                    && ((o.NickID == 32 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == ""))
                                      || o.NickID != 32)
                                     && (
                                          (WaitNotice == 1 && o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/等通知") && o.CustomerServiceRemark.IndexOf("/等通知") != 0)
                                         || (Urgent == 1 && o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/加急") && o.CustomerServiceRemark.IndexOf("/加急") != 0)
                                         || (CanDeliver == 1 && o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/能发就发") && o.CustomerServiceRemark.IndexOf("/能发就发") != 0)
                                         || (AppointDeliveryTime == 1 && o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("当天发") && o.CustomerServiceRemark.IndexOf("当天发") != 0 && o.AppointDeliveryTime != null && o.AppointDeliveryTime >= BeginDate && o.AppointDeliveryTime <= EndDate)
                                        )
                                    && (p.IsSingleRow == null || p.IsSingleRow == false)
                                    && DeliveryStatue.Contains(o.OrderStatus)
                                    && o.PayDate >= PayBeginDate
                                    && o.PayDate <= PayEndDate
                                    select new ProductSalesData
                                    {
                                        ID = p.ID,
                                        OrderInfoID = p.OrderInfoID,
                                        PlatformMerchantCode = p.PlatformMerchantCode,
                                        ProductName = p.ProductName,
                                        ProductNum = p.ProductNum,
                                        Specifications = p.Specifications,
                                        NickID = o.NickID,
                                        FactoryPrice = p.FactoryPrice,
                                        ProjectID = pId.ProjectId,
                                        PlatformTypeId = o.PlatformTypeId,
                                        Manufacturers = "",
                                        Province = o.Province,
                                        DeliveryAddress = o.DeliveryAddress,
                                        OrderCode = o.OrderCode,
                                        OrderInfoCreateDate = o.OrderInfoCreateDate,
                                        PayDate = o.PayDate,
                                        BuyerMobile = o.Mobile
                                    };

                        var list = from x in this._context.XMProducts
                                   join a in this._context.XMProductDetails
                                   on x.Id equals a.ProductId
                                   from q in query
                                   where x.IsEnable == false
                                   && a.IsEnable == false
                                   && x.IsPremiums == false
                                   && a.PlatformMerchantCode == q.PlatformMerchantCode
                                   && (a.PlatformTypeId == q.PlatformTypeId || a.PlatformTypeId==508)
                                   select new ProductSalesData
                                   {
                                       ID = q.ID,
                                       OrderInfoID = q.OrderInfoID,
                                       PlatformMerchantCode = q.PlatformMerchantCode,
                                       ProductName = q.ProductName,
                                       ProductNum = q.ProductNum,
                                       Specifications = q.Specifications,
                                       NickID = q.NickID,
                                       FactoryPrice = q.FactoryPrice,
                                       ProjectID = q.ProjectID,
                                       PlatformTypeId = q.PlatformTypeId,
                                       Manufacturers = x.ManufacturersCode,
                                       Province = q.Province,
                                       DeliveryAddress = q.DeliveryAddress,
                                       OrderCode=q.OrderCode,
                                       OrderInfoCreateDate=q.OrderInfoCreateDate,
                                       PayDate=q.PayDate,
                                       BuyerMobile = q.BuyerMobile
                                   };

                        string psql = list.GetType().GetMethod("ToTraceString").Invoke(list, null).ToString();

                        List = list.Distinct().ToList();
                    }
                    #endregion
                    #region
                    if (remarks == 1 && (WaitNotice == 1 || Urgent == 1 || CanDeliver == 1 || AppointDeliveryTime == 1))              //
                    {
                        //所有满足订单
                        var queryAll = from p in this._context.XMOrderInfoProductDetails
                                       join o in this._context.XMOrderInfoes
                                       on p.OrderInfoID equals o.ID
                                       join pId in this._context.XMNicks
                                       on o.NickID equals pId.nick_id
                                       where p.IsEnable == false
                                       && o.IsEnable == false
                                       && pId.isEnable == true
                                       && pId.ProjectId == ProjectId
                                       && NickIdList.Contains(o.NickID)
                                       && p.IsAudit == true
                                       && o.IsAudit == true
                                       && ((o.NickID == 32 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == ""))
                                         || o.NickID != 32)
                                         && (p.IsSingleRow == null || p.IsSingleRow == false)
                                       && DeliveryStatue.Contains(o.OrderStatus)
                                       && o.PayDate >= PayBeginDate
                                       && o.PayDate <= PayEndDate
                                       select new ProductSalesData
                                       {
                                           ID = p.ID,
                                           OrderInfoID = p.OrderInfoID,
                                           PlatformMerchantCode = p.PlatformMerchantCode,
                                           ProductName = p.ProductName,
                                           ProductNum = p.ProductNum,
                                           Specifications = p.Specifications,
                                           NickID = o.NickID,
                                           FactoryPrice = p.FactoryPrice,
                                           ProjectID = pId.ProjectId,
                                           PlatformTypeId = o.PlatformTypeId,
                                           Manufacturers = "",
                                           Province = o.Province,
                                           DeliveryAddress = o.DeliveryAddress,
                                           OrderCode = o.OrderCode,
                                           OrderInfoCreateDate = o.OrderInfoCreateDate,
                                           PayDate = o.PayDate,
                                           BuyerMobile = o.Mobile
                                       };


                        //满足（预约时间 ||  等通知 || 能发就发 || 加急）
                        var queryParm = from p in this._context.XMOrderInfoProductDetails
                                        join o in this._context.XMOrderInfoes
                                        on p.OrderInfoID equals o.ID
                                        join pId in this._context.XMNicks
                                        on o.NickID equals pId.nick_id
                                        where p.IsEnable == false
                                        && o.IsEnable == false
                                        && pId.isEnable == true
                                        && pId.ProjectId == ProjectId
                                        && NickIdList.Contains(o.NickID)
                                        && p.IsAudit == true
                                        && o.IsAudit == true
                                        && ((o.NickID == 32 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == ""))
                                          || o.NickID != 32)
                                      && (
                                          (WaitNotice == 1 && o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/等通知") && o.CustomerServiceRemark.IndexOf("/等通知") != 0)
                                         || (Urgent == 1 && o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/加急") && o.CustomerServiceRemark.IndexOf("/加急") != 0)
                                         || (CanDeliver == 1 && o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/能发就发") && o.CustomerServiceRemark.IndexOf("/能发就发") != 0)
                                         || (AppointDeliveryTime == 1 && o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("当天发") && o.CustomerServiceRemark.IndexOf("当天发") != 0 && o.AppointDeliveryTime != null && o.AppointDeliveryTime >= BeginDate && o.AppointDeliveryTime <= EndDate)
                                        )
                                        && (p.IsSingleRow == null || p.IsSingleRow == false)
                                        && DeliveryStatue.Contains(o.OrderStatus)
                                        && o.PayDate >= PayBeginDate
                                        && o.PayDate <= PayEndDate
                                        select new ProductSalesData
                                        {
                                            ID = p.ID,
                                            OrderInfoID = p.OrderInfoID,
                                            PlatformMerchantCode = p.PlatformMerchantCode,
                                            ProductName = p.ProductName,
                                            ProductNum = p.ProductNum,
                                            Specifications = p.Specifications,
                                            NickID = o.NickID,
                                            FactoryPrice = p.FactoryPrice,
                                            ProjectID = pId.ProjectId,
                                            PlatformTypeId = o.PlatformTypeId,
                                            Manufacturers = "",
                                            Province = o.Province,
                                            DeliveryAddress = o.DeliveryAddress,
                                            OrderCode = o.OrderCode,
                                            OrderInfoCreateDate = o.OrderInfoCreateDate,
                                            PayDate = o.PayDate,
                                            BuyerMobile = o.Mobile
                                        };


                        //所有满足以上状态（预约时间&&  等通知&&  能发就发&&  加急）
                        var queryParm2 = from p in this._context.XMOrderInfoProductDetails
                                         join o in this._context.XMOrderInfoes
                                         on p.OrderInfoID equals o.ID
                                         join pId in this._context.XMNicks
                                         on o.NickID equals pId.nick_id
                                         where p.IsEnable == false
                                         && o.IsEnable == false
                                         && pId.isEnable == true
                                         && pId.ProjectId == ProjectId
                                         && NickIdList.Contains(o.NickID)
                                         && p.IsAudit == true
                                         && o.IsAudit == true
                                         && ((o.NickID == 32 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == ""))
                                           || o.NickID != 32)
                                          && (
                                               (o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/等通知") && o.CustomerServiceRemark.IndexOf("/等通知") != 0)
                                              || (o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/加急") && o.CustomerServiceRemark.IndexOf("/加急") != 0)
                                              || (o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/能发就发") && o.CustomerServiceRemark.IndexOf("/能发就发") != 0)
                                              || (o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("当天发") && o.CustomerServiceRemark.IndexOf("当天发") != 0)
                                             )
                                         && (p.IsSingleRow == null || p.IsSingleRow == false)
                                         && DeliveryStatue.Contains(o.OrderStatus)
                                         && o.PayDate >= PayBeginDate
                                         && o.PayDate <= PayEndDate
                                         select new ProductSalesData
                                         {
                                             ID = p.ID,
                                             OrderInfoID = p.OrderInfoID,
                                             PlatformMerchantCode = p.PlatformMerchantCode,
                                             ProductName = p.ProductName,
                                             ProductNum = p.ProductNum,
                                             Specifications = p.Specifications,
                                             NickID = o.NickID,
                                             FactoryPrice = p.FactoryPrice,
                                             ProjectID = pId.ProjectId,
                                             PlatformTypeId = o.PlatformTypeId,
                                             Manufacturers = "",
                                             Province = o.Province,
                                             DeliveryAddress = o.DeliveryAddress,
                                             OrderCode = o.OrderCode,
                                             OrderInfoCreateDate = o.OrderInfoCreateDate,
                                             PayDate = o.PayDate,
                                             BuyerMobile = o.Mobile
                                         };
                        var queryRemark = queryAll.Except(queryParm2);               //异常备注记录
                        var queryAndRemark = queryParm.Union(queryRemark);    //合并满足条件的查询记录和异常备注
                        var list = from x in this._context.XMProducts
                                   join a in this._context.XMProductDetails
                                   on x.Id equals a.ProductId
                                   from q in queryAndRemark
                                   where x.IsEnable == false
                                   && a.IsEnable == false
                                   && x.IsPremiums == false
                                   && a.PlatformMerchantCode == q.PlatformMerchantCode
                                   && (a.PlatformTypeId == q.PlatformTypeId || a.PlatformTypeId == 508)
                                   select new ProductSalesData
                                   {
                                       ID = q.ID,
                                       OrderInfoID = q.OrderInfoID,
                                       PlatformMerchantCode = q.PlatformMerchantCode,
                                       ProductName = q.ProductName,
                                       ProductNum = q.ProductNum,
                                       Specifications = q.Specifications,
                                       NickID = q.NickID,
                                       FactoryPrice = q.FactoryPrice,
                                       ProjectID = q.ProjectID,
                                       PlatformTypeId = q.PlatformTypeId,
                                       Manufacturers = x.ManufacturersCode,
                                       Province = q.Province,
                                       DeliveryAddress = q.DeliveryAddress,
                                       OrderCode = q.OrderCode,
                                       OrderInfoCreateDate = q.OrderInfoCreateDate,
                                       PayDate = q.PayDate,
                                       BuyerMobile = q.BuyerMobile
                                   };

                        string psql = list.GetType().GetMethod("ToTraceString").Invoke(list, null).ToString();

                        List = list.Distinct().ToList();

                    }
                    #endregion
                    #region
                    if (remarks == 1 && WaitNotice == 0 && Urgent == 0 && CanDeliver == 0 && AppointDeliveryTime == 0)                                   //异常备注
                    {
                        //所有满足订单
                        var queryAll = from p in this._context.XMOrderInfoProductDetails
                                       join o in this._context.XMOrderInfoes
                                       on p.OrderInfoID equals o.ID
                                       join pId in this._context.XMNicks
                                       on o.NickID equals pId.nick_id
                                       where p.IsEnable == false
                                       && o.IsEnable == false
                                       && pId.isEnable == true
                                       && pId.ProjectId == ProjectId
                                       && NickIdList.Contains(o.NickID)
                                       && p.IsAudit == true
                                       && o.IsAudit == true
                                       && ((o.NickID == 32 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == ""))
                                         || o.NickID != 32)
                                         && (p.IsSingleRow == null || p.IsSingleRow == false)
                                       && DeliveryStatue.Contains(o.OrderStatus)
                                       && o.PayDate >= PayBeginDate
                                       && o.PayDate <= PayEndDate
                                       select new ProductSalesData
                                       {
                                           ID = p.ID,
                                           OrderInfoID = p.OrderInfoID,
                                           PlatformMerchantCode = p.PlatformMerchantCode,
                                           ProductName = p.ProductName,
                                           ProductNum = p.ProductNum,
                                           Specifications = p.Specifications,
                                           NickID = o.NickID,
                                           FactoryPrice = p.FactoryPrice,
                                           ProjectID = pId.ProjectId,
                                           PlatformTypeId = o.PlatformTypeId,
                                           Manufacturers = "",
                                           Province = o.Province,
                                           DeliveryAddress = o.DeliveryAddress,
                                           OrderCode = o.OrderCode,
                                           OrderInfoCreateDate = o.OrderInfoCreateDate,
                                           PayDate = o.PayDate,
                                           BuyerMobile = o.Mobile
                                       };


                        //满足（预约时间  等通知  能发就发  加急）
                        var queryParm = from p in this._context.XMOrderInfoProductDetails
                                        join o in this._context.XMOrderInfoes
                                        on p.OrderInfoID equals o.ID
                                        join pId in this._context.XMNicks
                                        on o.NickID equals pId.nick_id
                                        where p.IsEnable == false
                                        && o.IsEnable == false
                                        && pId.isEnable == true
                                        && pId.ProjectId == ProjectId
                                        && NickIdList.Contains(o.NickID)
                                        && p.IsAudit == true
                                        && o.IsAudit == true
                                        && ((o.NickID == 32 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == ""))
                                          || o.NickID != 32)
                                         && (
                                              (o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/等通知") && o.CustomerServiceRemark.IndexOf("/等通知") != 0)
                                             || (o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/加急") && o.CustomerServiceRemark.IndexOf("/加急") != 0)
                                             || (o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("/能发就发") && o.CustomerServiceRemark.IndexOf("/能发就发") != 0)
                                             || (o.CustomerServiceRemark.Contains("小城") && o.CustomerServiceRemark.Substring(0, o.CustomerServiceRemark.IndexOf("小城") + 2).Contains("当天发") && o.CustomerServiceRemark.IndexOf("当天发") != 0)
                                            )
                                        && (p.IsSingleRow == null || p.IsSingleRow == false)
                                        && DeliveryStatue.Contains(o.OrderStatus)
                                        && o.PayDate >= PayBeginDate
                                        && o.PayDate <= PayEndDate
                                        select new ProductSalesData
                                        {
                                            ID = p.ID,
                                            OrderInfoID = p.OrderInfoID,
                                            PlatformMerchantCode = p.PlatformMerchantCode,
                                            ProductName = p.ProductName,
                                            ProductNum = p.ProductNum,
                                            Specifications = p.Specifications,
                                            NickID = o.NickID,
                                            FactoryPrice = p.FactoryPrice,
                                            ProjectID = pId.ProjectId,
                                            PlatformTypeId = o.PlatformTypeId,
                                            Manufacturers = "",
                                            Province = o.Province,
                                            DeliveryAddress = o.DeliveryAddress,
                                            OrderCode = o.OrderCode,
                                            OrderInfoCreateDate = o.OrderInfoCreateDate,
                                            PayDate = o.PayDate,
                                            BuyerMobile = o.Mobile
                                        };


                        var queryRemark = queryAll.Except(queryParm);

                        var list = from x in this._context.XMProducts
                                   join a in this._context.XMProductDetails
                                   on x.Id equals a.ProductId
                                   from q in queryRemark
                                   where x.IsEnable == false
                                   && a.IsEnable == false
                                   && x.IsPremiums == false
                                   && a.PlatformMerchantCode == q.PlatformMerchantCode
                                   && (a.PlatformTypeId == q.PlatformTypeId || a.PlatformTypeId==508)
                                   select new ProductSalesData
                                   {
                                       ID = q.ID,
                                       OrderInfoID = q.OrderInfoID,
                                       PlatformMerchantCode = q.PlatformMerchantCode,
                                       ProductName = q.ProductName,
                                       ProductNum = q.ProductNum,
                                       Specifications = q.Specifications,
                                       NickID = q.NickID,
                                       FactoryPrice = q.FactoryPrice,
                                       ProjectID = q.ProjectID,
                                       PlatformTypeId = q.PlatformTypeId,
                                       Manufacturers = x.ManufacturersCode,
                                       Province = q.Province,
                                       DeliveryAddress = q.DeliveryAddress,
                                       OrderCode = q.OrderCode,
                                       OrderInfoCreateDate = q.OrderInfoCreateDate,
                                       PayDate = q.PayDate,
                                       BuyerMobile = q.BuyerMobile
                                   };

                        string psql = list.GetType().GetMethod("ToTraceString").Invoke(list, null).ToString();

                        List = list.Distinct().ToList();

                    }
                    #endregion
                    return List;
                }
                else
                {
                    #region
                    var query = from p in this._context.XMOrderInfoProductDetails
                                join o in this._context.XMOrderInfoes
                                on p.OrderInfoID equals o.ID
                                join pId in this._context.XMNicks
                                on o.NickID equals pId.nick_id
                                where p.IsEnable == false
                                && o.IsEnable == false
                                && pId.isEnable == true
                                && pId.ProjectId == ProjectId
                                && NickIdList.Contains(o.NickID)
                                && p.IsAudit == true
                                && o.IsAudit == true
                                && ((o.NickID == 32 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == ""))
                                  || o.NickID != 32)
                                && (
                                  (WaitNotice == 1 && o.CustomerServiceRemark.Contains("/等通知"))
                                 || (Urgent == 1 && o.CustomerServiceRemark.Contains("/加急"))
                                 || (CanDeliver == 1 && o.CustomerServiceRemark.Contains("/能发就发"))
                                 || (AppointDeliveryTime == 1 && o.AppointDeliveryTime != null && o.AppointDeliveryTime >= BeginDate && o.AppointDeliveryTime <= EndDate)
                                 || (remarks == 1 && !o.CustomerServiceRemark.Contains("/等通知") && !o.CustomerServiceRemark.Contains("/加急") && !o.CustomerServiceRemark.Contains("/能发就发") && !o.CustomerServiceRemark.Contains("当天发"))
                                )
                                && (p.IsSingleRow == null || p.IsSingleRow == false)
                                && DeliveryStatue.Contains(o.OrderStatus)
                                && o.PayDate >= PayBeginDate
                                && o.PayDate <= PayEndDate
                                select new ProductSalesData
                                {
                                    ID = p.ID,
                                    OrderInfoID = p.OrderInfoID,
                                    PlatformMerchantCode = p.PlatformMerchantCode,
                                    ProductName = p.ProductName,
                                    ProductNum = p.ProductNum,
                                    Specifications = p.Specifications,
                                    NickID = o.NickID,
                                    FactoryPrice = p.FactoryPrice,
                                    ProjectID = pId.ProjectId,
                                    PlatformTypeId = o.PlatformTypeId,
                                    Manufacturers = "",
                                    Province = o.Province,
                                    DeliveryAddress = o.DeliveryAddress
                                };


                    var list = from x in this._context.XMProducts
                               join a in this._context.XMProductDetails
                               on x.Id equals a.ProductId
                               from q in query
                               where x.IsEnable == false
                               && a.IsEnable == false
                               && x.IsPremiums == false
                               && a.PlatformMerchantCode == q.PlatformMerchantCode
                               && (a.PlatformTypeId == q.PlatformTypeId || a.PlatformTypeId==508)
                               select new ProductSalesData
                               {
                                   ID = q.ID,
                                   OrderInfoID = q.OrderInfoID,
                                   PlatformMerchantCode = q.PlatformMerchantCode,
                                   ProductName = q.ProductName,
                                   ProductNum = q.ProductNum,
                                   Specifications = q.Specifications,
                                   NickID = q.NickID,
                                   FactoryPrice = q.FactoryPrice,
                                   ProjectID = q.ProjectID,
                                   PlatformTypeId = q.PlatformTypeId,
                                   Manufacturers = x.ManufacturersCode,
                                   Province = q.Province,
                                   DeliveryAddress = q.DeliveryAddress
                               };

                    string psql = list.GetType().GetMethod("ToTraceString").Invoke(list, null).ToString();

                    return list.Distinct().ToList();
                    #endregion
                }
            }
        }

        public List<ProductSalesData> GetWarehouseSales(DateTime BeginDate, DateTime EndDate, int ProjectId, List<int?> NickIdList, int WarehouseID, int ProvinceNameID)
        {
            List<ProductSalesData> List = new List<ProductSalesData>();

            var query = from p in this._context.XMOrderInfoProductDetails
                        join o in this._context.XMOrderInfoes
                        on p.OrderInfoID equals o.ID
                        join pId in this._context.XMNicks
                        on o.NickID equals pId.nick_id
                        where p.IsEnable == false
                        && o.IsEnable == false
                        && pId.isEnable == true
                        && pId.ProjectId == ProjectId
                        && NickIdList.Contains(o.NickID)//(NickId == -1 || o.NickID == NickId)
                        && o.DeliveryTime != null
                        && o.DeliveryTime >= BeginDate
                        && o.DeliveryTime <= EndDate
                        && ((o.NickID == 32 && (p.PlatformMerchantCode.StartsWith("CM") || p.PlatformMerchantCode == ""))
                   || o.NickID != 32)
                        select new ProductSalesData
                        {
                            ID = p.ID,
                            OrderInfoID = p.OrderInfoID,
                            PlatformMerchantCode = p.PlatformMerchantCode,
                            ProductName = p.ProductName,
                            ProductNum = p.ProductNum,
                            Specifications = p.Specifications,
                            NickID = o.NickID,
                            FactoryPrice = p.FactoryPrice,
                            ProjectID = pId.ProjectId,
                            PlatformTypeId = o.PlatformTypeId,
                            Manufacturers = "",
                            Province = o.Province,
                            DeliveryAddress = o.DeliveryAddress
                        };

            var list = from x in this._context.XMProducts
                       join a in this._context.XMProductDetails
                       on x.Id equals a.ProductId
                       from q in query
                       where x.IsEnable == false
                       && a.IsEnable == false
                       && x.IsPremiums == false
                       && a.PlatformMerchantCode == q.PlatformMerchantCode
                       && (a.PlatformTypeId == q.PlatformTypeId || a.PlatformTypeId==508)
                       select new ProductSalesData
                       {
                           ID = q.ID,
                           OrderInfoID = q.OrderInfoID,
                           PlatformMerchantCode = q.PlatformMerchantCode,
                           ProductName = q.ProductName,
                           ProductNum = q.ProductNum,
                           Specifications = q.Specifications,
                           NickID = q.NickID,
                           FactoryPrice = q.FactoryPrice,
                           ProjectID = q.ProjectID,
                           PlatformTypeId = q.PlatformTypeId,
                           Manufacturers = x.ManufacturersCode,
                           Province = q.Province,
                           DeliveryAddress = q.DeliveryAddress
                       };

            if (ProvinceNameID != -1)
            {
                var ProvinceName = from p in this._context.ProvinceWarehouses
                                   where p.IsEnabled == false
                                   && p.ID == ProvinceNameID
                                   select p;

                string provinceName = ProvinceName.SingleOrDefault().ProvinceName.Substring(0, 2);
                ProductSalesData Info = new ProductSalesData();
                Info.ProductName = provinceName == "黑龙" ? "黑龙江" : provinceName;
                Info.ProductNum = 0;
                var productList = list.Where(x => x.DeliveryAddress.Substring(0, 2) == provinceName || x.Province.Substring(0, 2) == provinceName);
                if (productList.Count() > 0)
                {
                    Info.ProductNum += productList.Sum(x => x.ProductNum);
                }
                List.Add(Info);
            }
            else
            {
                if (WarehouseID != -1)
                {
                    var provinceList = from p in this._context.ProvinceWarehouses
                                       where p.IsEnabled == false
                                       && p.WarehouseID == WarehouseID
                                       select p.ProvinceName.Substring(0, 2);

                    foreach (var ProvinceName in provinceList.ToList())
                    {
                        ProductSalesData Info = new ProductSalesData();
                        Info.ProductName = ProvinceName == "黑龙" ? "黑龙江" : ProvinceName;
                        Info.ProductNum = 0;
                        var productList = list.Where(x => x.DeliveryAddress.Substring(0, 2) == ProvinceName || x.Province.Substring(0, 2) == ProvinceName);
                        if (productList.Count() > 0)
                        {
                            Info.ProductNum += productList.Sum(x => x.ProductNum);
                        }
                        List.Add(Info);
                    }
                }
                else
                {
                    List<string> Group = new List<string>();
                    List<string> Name = new List<string>();
                    List<ProductSalesData> ProductList = new List<ProductSalesData>();

                    var WarehouseList = from p in this._context.CodeLists
                                        where p.Deleted == false
                                        && p.CodeTypeID == 227
                                        select p;

                    var warehouseList = from p in this._context.CodeLists
                                        join q in this._context.ProvinceWarehouses
                                        on p.CodeID equals q.WarehouseID
                                        where p.Deleted == false
                                        && p.CodeTypeID == 227
                                        && q.IsEnabled == false
                                        select new HighChart
                                        {
                                            Group = p.CodeName,
                                            Name = q.ProvinceName.Substring(0, 2)
                                        };

                    foreach (var info in warehouseList)
                    {
                        Group.Add(info.Group);
                        Name.Add(info.Name);
                    }

                    foreach (var item in list)
                    {
                        string address = "";
                        if (string.IsNullOrEmpty(item.Province))
                        {
                            address = item.DeliveryAddress.Substring(0, 2);
                        }
                        else
                        {
                            address = item.Province.Substring(0, 2);
                        }

                        ProductSalesData Info = new ProductSalesData();

                        if (Name.IndexOf(address) != -1)
                        {
                            Info.ProductName = Group[Name.IndexOf(address)];
                        }
                        Info.ProductNum = item.ProductNum;
                        ProductList.Add(Info);
                    }

                    foreach (var item in WarehouseList)
                    {
                        ProductSalesData Info = new ProductSalesData();
                        Info.ProductName = item.CodeName;
                        Info.ProductNum = 0;
                        var productList = ProductList.Where(x => x.ProductName == item.CodeName);
                        if (productList.Count() > 0)
                        {
                            Info.ProductNum += productList.Sum(x => x.ProductNum);
                        }
                        List.Add(Info);
                    }
                }
            }
            return List.ToList(); ;
        }

        /// <summary>
        /// 根据订单编码查询 商品信息
        /// </summary>
        public List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsListByOrderCode(string OrderCode)
        {

            var query = from p in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on p.OrderInfoID equals b.ID
                        where b.OrderCode.Contains(OrderCode)
                        && p.IsEnable == false
                        && b.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据支付宝数据查询数据
        /// </summary>
        /// <returns></returns>
        public List<XMAlipaymentAccount> GetXMOrderInfoProductDetailsListByOrderCode2(string OrderCode)
        {
            var query = from p in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                          on p.OrderInfoID equals b.ID
                        where b.OrderCode.Contains(OrderCode)
                           && p.IsEnable == false
                           && b.IsEnable == false
                        orderby b.OrderInfoCreateDate descending
                        select new XMAlipaymentAccount
                        {
                            ID = b.ID,
                            NickID = b.NickID,
                            PlatFormTypeId = b.PlatformTypeId,
                            OrderCode = b.OrderCode,
                            OrderID = b.ID,
                            ProductName = p.ProductName,
                            PlatformMerchantCode = p.PlatformMerchantCode,
                            Specifications = p.Specifications,
                            ProductNum = p.ProductNum
                        };
            return query.ToList();
        }

        /// <summary>
        /// 根据订单Id、商品编码查询
        /// </summary>
        public List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsListByPlatformMerchantCode(int OrderId, string PlatformMerchantCode)
        {
            var query = from p in this._context.XMOrderInfoProductDetails
                        where p.PlatformMerchantCode.Contains(PlatformMerchantCode)
                        && p.OrderInfoID == OrderId
                        && p.IsEnable == false
                        select p;
            return query.ToList();

        }

        /// <summary>
        /// 根据平台ID 商品编码  订单创建时间查询订单列表
        /// </summary>
        /// <returns></returns>
        public List<XMOrderInfoProductDetails> GetXMOrderInfoProductListByParms(string platformMerchantCode, DateTime? startDateTime, DateTime? endDateTime, int timeType, int PlatformTypeId)
        {
            IQueryable<XMOrderInfoProductDetails> query = null;
            if (timeType == 1)//创单时间
            {
                query = from p in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on p.OrderInfoID equals b.ID
                        where p.PlatformMerchantCode.Contains(platformMerchantCode)
                        && b.OrderInfoCreateDate >= startDateTime
                        && b.OrderInfoCreateDate <= endDateTime
                        && (PlatformTypeId == -1 || b.PlatformTypeId == PlatformTypeId)
                        //orderby b.OrderInfoCreateDate ascending
                        select p;
            }
            else if (timeType == 2)//付款时间
            {
                query = from p in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on p.OrderInfoID equals b.ID
                        where p.PlatformMerchantCode.Contains(platformMerchantCode)
                        && b.PayDate >= startDateTime
                        && b.PayDate <= endDateTime
                        && (PlatformTypeId == -1 || b.PlatformTypeId == PlatformTypeId)
                        //orderby b.PayDate ascending
                        select p;
            }
            else if (timeType == 3)//发货时间
            {
                query = from p in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on p.OrderInfoID equals b.ID
                        where p.PlatformMerchantCode.Contains(platformMerchantCode)
                        && b.DeliveryTime >= startDateTime
                        && b.DeliveryTime <= endDateTime
                        && (PlatformTypeId == -1 || b.PlatformTypeId == PlatformTypeId)
                        //orderby b.DeliveryTime ascending
                        select p;
            }
            else if (timeType == 4)//完成时间
            {
                query = from p in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on p.OrderInfoID equals b.ID
                        where p.PlatformMerchantCode.Contains(platformMerchantCode)
                        && b.CompletionTime >= startDateTime
                        && b.CompletionTime <= endDateTime
                        && (PlatformTypeId == -1 || b.PlatformTypeId == PlatformTypeId)
                        //orderby b.CompletionTime ascending
                        select p;
            }

            List<XMOrderInfoProductDetails> list = query.ToList();
            if (timeType == 1)//创单时间
            {
                list = list.OrderBy(x => x.XM_OrderInfo.OrderInfoCreateDate).ToList();
            }
            else if (timeType == 2)//付款时间
            {
                list = list.OrderBy(x => x.XM_OrderInfo.PayDate).ToList();
            }
            else if (timeType == 3)//发货时间
            {
                list = list.OrderBy(x => x.XM_OrderInfo.DeliveryTime).ToList();
            }
            else if (timeType == 4)//完成时间
            {
                list = list.OrderBy(x => x.XM_OrderInfo.CompletionTime).ToList();
            }

            return list;
        }

        /// <summary>
        /// 根据订单Id
        /// </summary>
        public List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsListByOrderId(int OrderId)
        {

            var query = from p in this._context.XMOrderInfoProductDetails
                        where p.OrderInfoID == OrderId
                        && p.IsEnable == false
                        select p;
            return query.ToList();

        }

        public List<WarningOrder> GetWarningOrderList()
        {
            List<WarningOrder> list = new List<WarningOrder>();
            DateTime start = DateTime.Now.AddDays(-7);

            var query = from p in _context.XMOrderInfoes
                        join m in _context.XMOrderInfoProductDetails on p.ID equals m.OrderInfoID into temp
                        from pm in temp.DefaultIfEmpty()
                        where p.IsEnable == false && pm.TManufacturersCode==null && p.CreateDate>= start
                        select new WarningOrder
                        {
                            orderCode=p.OrderCode,
                            reason="订单信息不完整"
                        };

            //if(query.Count()>0)
            //{
            //    list.AddRange(query.ToList());
            //}

            //var query1 = from p in _context.XMOrderInfoes
            //             join m in _context.XMOrderInfoProductDetails on p.ID equals m.OrderInfoID into temp
            //             from pm in temp.DefaultIfEmpty()
            //             where p.IsEnable == false && pm.PlatformMerchantCode.StartsWith("CM") && pm.ProductName.Contains("无产品")
            //             && p.PlatformTypeId==259 && p.CreateDate>= start
            //             select new WarningOrder
            //             {
            //                 orderCode = p.OrderCode,
            //                 reason = "无产品"
            //             };

            //if (query1.Count() > 0)
            //{
            //    list.AddRange(query1.ToList());
            //}

            return query.ToList();
        }

        public List<XMOrderInfoProductDetails> getXMOrderInfoListByBrandType(List<OrderInfoSalesDetails> List, int BrandType)
        {
            var query = from p in this._context.XMOrderInfoProductDetails
                        join q in List
                        on p.OrderInfoID equals q.ID
                        join a in this._context.XMProductDetails
                        on p.PlatformMerchantCode equals a.PlatformMerchantCode
                        join b in this._context.XMProducts
                        on a.ProductId equals b.Id
                        where p.IsEnable == false
                        && a.IsEnable == false
                        && b.IsEnable == false
                        && b.BrandTypeId == BrandType
                        select p;
            return query.ToList();
        }

        public List<OrderInfoSalesDetails> GetOrderInfoSalesDetailsListByBrandType(List<OrderInfoSalesDetails> List, int BrandType)
        {
            var query = from p in List
                        join a in this._context.XMProductDetails
                        on p.PlatformMerchantCode equals a.PlatformMerchantCode
                        join b in this._context.XMProducts
                        on a.ProductId equals b.Id
                        where a.IsEnable == false
                        && b.IsEnable == false
                        && b.BrandTypeId == BrandType
                        select p;
            return query.Distinct().ToList();
        }

        /// <summary>
        /// 产品明细
        /// </summary>
        /// <param name="PlatformTypeId"></param>
        /// <param name="nickIdList"></param>
        /// <param name="OrderInfoModifiedStart"></param>
        /// <param name="OrderInfoModifiedEnd"></param>
        /// <param name="OrderStatusId"></param>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        public List<OrderInfoSalesDetails> GetOrderInfoSalesDetailsList(int PlatformTypeId, List<int> nickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId)
        {
            //List<string> zt = new List<string> { "'WAIT_BUYER_PAY'", "'WAIT_SELLER_SEND_GOODS'", "'WAIT_BUYER_CONFIRM_GOODS'", "'TRADE_FINISHED'"//天猫选取2.3.5.7状态订单
            //, "'WAIT_SELLER_STOCK_OUT'", "'WAIT_GOODS_RECEIVE_CONFIRM'", "'WAIT_SELLER_DELIVERY'", "'FINISHED_L'"//京东1.4.6.7状态订单
            //, "'DS_WAIT_BUYER_PAY'", "'DS_WAIT_SELLER_DELIVERY'", "'DS_WAIT_BUYER_RECEIVE'", "'DS_DEAL_END_NORMAL'"//拍拍选取全部
            //, "'STATUS_1'", "'STATUS_10'", "'STATUS_22'", "'STATUS_25'"//唯品会选取2.3.5.7
            //, "'ORDER_WAIT_PAY'", "'ORDER_PAYED'", "'ORDER_TRUNED_TO_DO'", "'ORDER_OUT_OF_WH'", "'ORDER_RECEIVED'", "'ORDER_FINISH'"//1号店选取1.2.3.4.5.6
            //, "'新'", "'以接受'", "'已发货'"//亚马逊选取1.2.3
            //, "'10'", "'20'", "'21'", "'30'"};//苏宁易购选取1.2.3.4
            List<string> zt = new List<string> {  "WAIT_SELLER_SEND_GOODS",  "SELLER_CONSIGNED_PART", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_BUYER_SIGNED", "TRADE_FINISHED"//天猫
           ,"WAIT_SELLER_DELIVERY", "WAIT_SELLER_STOCK_OUT","SEND_TO_DISTRIBUTION_CENER", "DISTRIBUTION_CENTER_RECEIVED", "WAIT_GOODS_RECEIVE_CONFIRM","FINISHED_L"//京东
            , "DS_WAIT_SELLER_DELIVERY", "DS_WAIT_BUYER_RECEIVE", "DS_DEAL_END_NORMAL"//拍拍
            , "1", "10", "22", "25"//唯品会
            , "ORDER_PAYED", "ORDER_TRUNED_TO_DO", "ORDER_OUT_OF_WH", "ORDER_RECEIVED", "ORDER_FINISH"//1号店
            , "以接受", "已发货"//亚马逊
            , "10", "20","21", "30"//苏宁易
            ,"已付款","已发货","已完成"//通用状态
            };

            #region linq

            IQueryable<OrderInfoSalesDetails> query = null;

            #region 创单时间
            if (OrderStatusId == 1)//创单时间  
            {
                //左链接
                query = from a in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes on a.OrderInfoID equals b.ID into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()
                        join n in this._context.XMNicks on b.NickID equals n.nick_id
                        join x in _context.CodeLists
                        on b.PlatformTypeId equals x.CodeID into temp
                        from y in temp.DefaultIfEmpty()
                        where a.IsEnable.Value == false
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIdList.Contains(b.NickID.Value)
                        && zt.Contains(b.OrderStatus)
                        && (b.IsScalping == false || b.IsScalping == null)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.OrderInfoCreateDate >= OrderInfoModifiedStart && b.OrderInfoCreateDate < OrderInfoModifiedEnd))
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            OrderCode = b.OrderCode,
                            PlatformTypeId = b.PlatformTypeId,
                            DeliveryTime = b.DeliveryTime,
                            PayDate = b.PayDate,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            DetailsID = a.ID,
                            PlatformMerchantCode = a.PlatformMerchantCode,
                            ProductName = a.ProductName,
                            Specifications = a.Specifications,
                            ProductNum = a.ProductNum,
                            FactoryPrice = a.FactoryPrice == null ? 0 : a.FactoryPrice,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            PayPrice = b.PayPrice,
                            OrderPrice = b.OrderPrice,
                            SalesPrice = a.SalesPrice,
                            NickID = b.NickID,
                            PlatformTypeName = y.CodeName,
                            ProjectId = 0,
                            ProjectName = "",
                            NickName = n.nick,
                            ManufacturersCode = a.TManufacturersCode,
                            ProductId = 0,
                            MarkDate = b.OrderInfoCreateDate,
                            CompletionTime = b.CompletionTime
                        };

            }
            #endregion

            #region 付款时间
            if (OrderStatusId == 2)//付款时间  
            {
                //左链接
                query = from a in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on a.OrderInfoID equals b.ID into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()
                        join n in this._context.XMNicks on b.NickID equals n.nick_id
                        join x in _context.CodeLists
                        on b.PlatformTypeId equals x.CodeID into temp
                        from y in temp.DefaultIfEmpty()
                        where a.IsEnable.Value == false
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIdList.Contains(b.NickID.Value)
                        && zt.Contains(b.OrderStatus)
                        && (b.IsScalping == false || b.IsScalping == null)
                        && b.FinancialAudit == true
                       && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                       || (b.PayDate >= OrderInfoModifiedStart && b.PayDate < OrderInfoModifiedEnd))
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            OrderCode = b.OrderCode,
                            PlatformTypeId = b.PlatformTypeId,
                            DeliveryTime = b.DeliveryTime,
                            PayDate = b.PayDate,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            DetailsID = a.ID,
                            PlatformMerchantCode = a.PlatformMerchantCode,
                            ProductName = a.ProductName,
                            Specifications = a.Specifications,
                            ProductNum = a.ProductNum,
                            FactoryPrice = a.FactoryPrice == null ? 0 : a.FactoryPrice,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            PayPrice = b.PayPrice,
                            OrderPrice = b.OrderPrice,
                            SalesPrice = a.SalesPrice,
                            NickID = b.NickID,
                            PlatformTypeName = y.CodeName,
                            ProjectId = 0,
                            ProjectName = "",
                            NickName = n.nick,
                            ManufacturersCode = a.TManufacturersCode,
                            ProductId = 0,
                            MarkDate = b.PayDate,
                            CompletionTime = b.CompletionTime
                        };

            }
            #endregion

            #region 发货时间
            if (OrderStatusId == 3)//发货时间  
            {
                List<string> ztstatus = new List<string> {
                     "SELLER_CONSIGNED_PART", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_BUYER_SIGNED", "TRADE_FINISHED"//天猫
                    ,"WAIT_SELLER_STOCK_OUT","SEND_TO_DISTRIBUTION_CENER", "DISTRIBUTION_CENTER_RECEIVED", "WAIT_GOODS_RECEIVE_CONFIRM","FINISHED_L"//京东
                    , "DS_WAIT_BUYER_RECEIVE", "DS_DEAL_END_NORMAL"//拍拍
                    , "22","25"//唯品会和唯评会MP
                    , "ORDER_TRUNED_TO_DO","ORDER_OUT_OF_WH", "ORDER_RECEIVED", "ORDER_FINISH"//1号店
                    , "已发货"//亚马逊
                    ,"20","21","30"//苏宁易购
                    ,"已发货","已完成"//通用状态
                };

                //左链接
                query = from a in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on a.OrderInfoID equals b.ID into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()
                        join n in this._context.XMNicks on b.NickID equals n.nick_id
                        join x in _context.CodeLists
                        on b.PlatformTypeId equals x.CodeID into temp
                        from y in temp.DefaultIfEmpty()
                        where a.IsEnable.Value == false
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIdList.Contains(b.NickID.Value)
                        && ztstatus.Contains(b.OrderStatus)
                            && b.FinancialAudit == true
                        && (b.IsScalping == false || b.IsScalping == null)
                       && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                       || (b.DeliveryTime >= OrderInfoModifiedStart && b.DeliveryTime < OrderInfoModifiedEnd))
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            OrderCode = b.OrderCode,
                            PlatformTypeId = b.PlatformTypeId,
                            DeliveryTime = b.DeliveryTime,
                            PayDate = b.PayDate,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            DetailsID = a.ID,
                            PlatformMerchantCode = a.PlatformMerchantCode,
                            ProductName = a.ProductName,
                            Specifications = a.Specifications,
                            ProductNum = a.ProductNum,
                            FactoryPrice = a.FactoryPrice == null ? 0 : a.FactoryPrice,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            PayPrice = b.PayPrice,
                            OrderPrice = b.OrderPrice,
                            SalesPrice = a.SalesPrice,
                            NickID = b.NickID,
                            PlatformTypeName = y.CodeName,
                            ProjectId = 0,
                            ProjectName = "",
                            NickName = n.nick,
                            ManufacturersCode = a.TManufacturersCode,
                            ProductId = 0,
                            MarkDate = b.DeliveryTime,
                            CompletionTime = b.CompletionTime
                        };

            }
            #endregion

            #region 完成时间
            if (OrderStatusId == 4)//完成时间  
            {
                List<string> ztstatus = new List<string> {
                      "TRADE_FINISHED"//天猫
                    , "FINISHED_L"//京东
                    , "DS_DEAL_END_NORMAL"//拍拍
                    , "25"//唯品会和唯评会MP
                    , "ORDER_FINISH"//1号店
                    , "已发货"//亚马逊
                    ,"30"//苏宁易购
                    ,"已完成"//通用状态
                };
                //左链接
                query = from a in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on a.OrderInfoID equals b.ID into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()
                        join n in this._context.XMNicks on b.NickID equals n.nick_id
                        join x in _context.CodeLists
                        on b.PlatformTypeId equals x.CodeID into temp
                        from y in temp.DefaultIfEmpty()
                        where a.IsEnable.Value == false
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIdList.Contains(b.NickID.Value)
                        && ztstatus.Contains(b.OrderStatus)
                        && b.FinancialAudit == true
                        && (b.IsScalping == false || b.IsScalping == null)
                       && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                       || (b.CompletionTime >= OrderInfoModifiedStart && b.CompletionTime < OrderInfoModifiedEnd))
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            OrderCode = b.OrderCode,
                            PlatformTypeId = b.PlatformTypeId,
                            DeliveryTime = b.DeliveryTime,
                            PayDate = b.PayDate,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            DetailsID = a.ID,
                            PlatformMerchantCode = a.PlatformMerchantCode,
                            ProductName = a.ProductName,
                            Specifications = a.Specifications,
                            ProductNum = a.ProductNum,
                            FactoryPrice = a.FactoryPrice == null ? 0 : a.FactoryPrice,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            PayPrice = b.PayPrice,
                            OrderPrice = b.OrderPrice,
                            SalesPrice = a.SalesPrice,
                            NickID = b.NickID,
                            PlatformTypeName = y.CodeName,
                            ProjectId = 0,
                            ProjectName = "",
                            NickName = n.nick,
                            ManufacturersCode = a.TManufacturersCode,
                            ProductId = 0,
                            MarkDate = b.CompletionTime,
                            CompletionTime= b.CompletionTime
                        };

            }
            #endregion

            #region 注释掉的联接产品，筛选厂家编码
            //query = from p in query
            //        join c in this._context.XMProductDetails on new { p.PlatformMerchantCode, p.PlatformTypeId } equals new { c.PlatformMerchantCode, c.PlatformTypeId } into cJoin
            //        from cInfo in cJoin.DefaultIfEmpty()

            //        join d in this._context.XMProducts on cInfo.ProductId equals d.Id
            //        into dJoin
            //        from dInfo in dJoin.DefaultIfEmpty()

            //        join e in this._context.XMNicks on p.NickID equals e.nick_id
            //        into eJoin
            //        from eInfo in eJoin.DefaultIfEmpty()

            //        join f in this._context.XMProjects on eInfo.ProjectId equals f.Id
            //        into fJoin
            //        from fInfo in fJoin.DefaultIfEmpty()

            //        join g in this._context.CodeLists on p.PlatformTypeId equals g.CodeID
            //        into gJoin
            //        from gInfo in gJoin.DefaultIfEmpty()

            //        where cInfo.IsEnable == false
            //        && dInfo.IsEnable == false
            //        && eInfo.isEnable == true
            //        && fInfo.IsEnable == true
            //        && gInfo.Deleted == false
            //        && (dInfo.ManufacturersCode.Contains(ManufacturersCode) || ManufacturersCode == "")
            //        select new OrderInfoSalesDetails
            //            {
            //                ID = p.ID,
            //                OrderCode = p.OrderCode,
            //                PlatformTypeId = p.PlatformTypeId,
            //                DeliveryTime = p.DeliveryTime,
            //                PayDate = p.PayDate,
            //                OrderInfoCreateDate = p.OrderInfoCreateDate,
            //                DetailsID = p.DetailsID,
            //                PlatformMerchantCode = p.PlatformMerchantCode,
            //                ProductName = p.ProductName,
            //                Specifications = p.Specifications,
            //                ProductNum = p.ProductNum,
            //                FactoryPrice = p.FactoryPrice,
            //                ReceivablePrice = p.ReceivablePrice,
            //                DistributePrice = p.DistributePrice,
            //                PayPrice = p.PayPrice,
            //                OrderPrice = p.OrderPrice,
            //                SalesPrice = p.SalesPrice,
            //                NickID = p.NickID,
            //                PlatformTypeName = gInfo.CodeName,
            //                ProjectId = eInfo.ProjectId,
            //                ProjectName = fInfo.ProjectName,
            //                NickName = eInfo.nick,
            //                ManufacturersCode = dInfo.ManufacturersCode,
            //                ProductId = cInfo.ProductId,
            //                MarkDate = p.MarkDate
            //            };
            #endregion

            #region jj
            //query = from p in query
            //        join c in this._context.XMProducts
            //        on p.ProductId equals c.Id
            //        into cJoin
            //        from cInfo in cJoin.DefaultIfEmpty()
            //        where cInfo.IsEnable == false
            //        && cInfo.ManufacturersCode.Contains(ManufacturersCode)
            //        select new OrderInfoSalesDetails
            //        {
            //            ID = p.ID,
            //            OrderCode = p.OrderCode,
            //            PlatformTypeId = p.PlatformTypeId,
            //            DeliveryTime = p.DeliveryTime,
            //            PayDate = p.PayDate,
            //            OrderInfoCreateDate = p.OrderInfoCreateDate,
            //            DetailsID = p.DetailsID,
            //            PlatformMerchantCode = p.PlatformMerchantCode,
            //            ProductName = p.ProductName,
            //            Specifications = p.Specifications,
            //            ProductNum = p.ProductNum,
            //            FactoryPrice = p.FactoryPrice,
            //            ReceivablePrice = p.ReceivablePrice,
            //            DistributePrice = p.DistributePrice,
            //            PayPrice = p.PayPrice,
            //            OrderPrice = p.OrderPrice,
            //            SalesPrice = p.SalesPrice,
            //            NickID = p.NickID,
            //            PlatformTypeName = "",
            //            ProjectId = p.ProjectId,
            //            ProjectName = p.ProjectName,
            //            NickName = "",
            //            ManufacturersCode = cInfo.ManufacturersCode,
            //            ProductId = p.ProductId
            //        };

            //query = from p in query
            //        join d in this._context.XMNicks on p.NickID equals d.nick_id
            //        //into cJoin
            //        //from cInfo in cJoin.DefaultIfEmpty()
            //        where d.isEnable == true
            //        select new OrderInfoSalesDetails
            //        {
            //            ID = p.ID,
            //            OrderCode = p.OrderCode,
            //            PlatformTypeId = p.PlatformTypeId,
            //            DeliveryTime = p.DeliveryTime,
            //            PayDate = p.PayDate,
            //            OrderInfoCreateDate = p.OrderInfoCreateDate,
            //            DetailsID = p.DetailsID,
            //            PlatformMerchantCode = p.PlatformMerchantCode,
            //            ProductName = p.ProductName,
            //            Specifications = p.Specifications,
            //            ProductNum = p.ProductNum,
            //            FactoryPrice = p.FactoryPrice,
            //            ReceivablePrice = p.ReceivablePrice,
            //            DistributePrice = p.DistributePrice,
            //            PayPrice = p.PayPrice,
            //            OrderPrice = p.OrderPrice,
            //            SalesPrice = p.SalesPrice,
            //            NickID = d.nick_id,
            //            PlatformTypeName = "",
            //            ProjectId = d.ProjectId,
            //            ProjectName = "",
            //            NickName = d.nick,
            //            ManufacturersCode = p.ManufacturersCode,
            //            ProductId = p.ProductId
            //        };


            //query = from p in query
            //        join d in this._context.XMProjects on p.ProjectId equals d.Id
            //        into cJoin
            //        from cInfo in cJoin.DefaultIfEmpty()
            //        where cInfo.IsEnable == true
            //        select new OrderInfoSalesDetails
            //        {
            //            ID = p.ID,
            //            OrderCode = p.OrderCode,
            //            PlatformTypeId = p.PlatformTypeId,
            //            DeliveryTime = p.DeliveryTime,
            //            PayDate = p.PayDate,
            //            OrderInfoCreateDate = p.OrderInfoCreateDate,
            //            DetailsID = p.DetailsID,
            //            PlatformMerchantCode = p.PlatformMerchantCode,
            //            ProductName = p.ProductName,
            //            Specifications = p.Specifications,
            //            ProductNum = p.ProductNum,
            //            FactoryPrice = p.FactoryPrice,
            //            ReceivablePrice = p.ReceivablePrice,
            //            DistributePrice = p.DistributePrice,
            //            PayPrice = p.PayPrice,
            //            OrderPrice = p.OrderPrice,
            //            SalesPrice = p.SalesPrice,
            //            NickID = p.NickID,
            //            PlatformTypeName = "",
            //            ProjectId = p.ProjectId,
            //            ProjectName = cInfo.ProjectName,
            //            NickName = p.NickName,
            //            ManufacturersCode = p.ManufacturersCode,
            //            ProductId = p.ProductId
            //        };
            //query = from p in query
            //        join d in this._context.CodeLists on p.PlatformTypeId equals d.CodeID
            //        //into cJoin
            //        //from cInfo in cJoin.DefaultIfEmpty()
            //        where d.Deleted == false
            //        select new OrderInfoSalesDetails
            //        {
            //            ID = p.ID,
            //            OrderCode = p.OrderCode,
            //            PlatformTypeId = p.PlatformTypeId,
            //            DeliveryTime = p.DeliveryTime,
            //            PayDate = p.PayDate,
            //            OrderInfoCreateDate = p.OrderInfoCreateDate,
            //            DetailsID = p.DetailsID,
            //            PlatformMerchantCode = p.PlatformMerchantCode,
            //            ProductName = p.ProductName,
            //            Specifications = p.Specifications,
            //            ProductNum = p.ProductNum,
            //            FactoryPrice = p.FactoryPrice,
            //            ReceivablePrice = p.ReceivablePrice,
            //            DistributePrice = p.DistributePrice,
            //            PayPrice = p.PayPrice,
            //            OrderPrice = p.OrderPrice,
            //            SalesPrice = p.SalesPrice,
            //            NickID = p.NickID,
            //            PlatformTypeName = d.CodeName,
            //            ProjectId = p.ProjectId,
            //            ProjectName = p.ProjectName,
            //            NickName = p.NickName,
            //            ManufacturersCode = p.ManufacturersCode,
            //            ProductId = p.ProductId
            //        };

            #endregion

            //筛选呼噜噜订单
            query = from p in query
                    join c in this._context.XMOrderInfoProductDetails
                    on p.ID equals c.OrderInfoID
                    into JoinedEmpDept
                    from c in JoinedEmpDept.DefaultIfEmpty()
                    where (p.NickID == 32 && (c == null || c.PlatformMerchantCode == null || c.PlatformMerchantCode == "" || c.PlatformMerchantCode.StartsWith("CM")))
                    || p.NickID != 32
                    select p;

            string psql = query.Distinct().GetType().GetMethod("ToTraceString").Invoke(query.Distinct(), null).ToString();

            return new List<OrderInfoSalesDetails>(query.Distinct()).ToList();

            #endregion
        }

        /// <summary>
        /// 产品明细
        /// </summary>
        /// <param name="PlatformTypeId"></param>
        /// <param name="nickIdList"></param>
        /// <param name="OrderInfoModifiedStart"></param>
        /// <param name="OrderInfoModifiedEnd"></param>
        /// <param name="OrderStatusId"></param>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        public List<OrderInfoSalesDetails> GetOrderInfoSalesDetailsListToExport(int PlatformTypeId, List<int> nickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId)
        {
          
            List<string> zt = new List<string> {  "WAIT_SELLER_SEND_GOODS",  "SELLER_CONSIGNED_PART", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_BUYER_SIGNED", "TRADE_FINISHED"//天猫
           ,"WAIT_SELLER_DELIVERY", "WAIT_SELLER_STOCK_OUT","SEND_TO_DISTRIBUTION_CENER", "DISTRIBUTION_CENTER_RECEIVED", "WAIT_GOODS_RECEIVE_CONFIRM","FINISHED_L"//京东
            , "DS_WAIT_SELLER_DELIVERY", "DS_WAIT_BUYER_RECEIVE", "DS_DEAL_END_NORMAL"//拍拍
            , "1", "10", "22", "25"//唯品会
            , "ORDER_PAYED", "ORDER_TRUNED_TO_DO", "ORDER_OUT_OF_WH", "ORDER_RECEIVED", "ORDER_FINISH"//1号店
            , "以接受", "已发货"//亚马逊
            , "10", "20","21", "30"//苏宁易
            ,"已付款","已发货","已完成"//通用状态
            };

            #region linq

            IQueryable<OrderInfoSalesDetails> query = null;

            #region 创单时间
            if (OrderStatusId == 1)//创单时间  
            {
                //左链接
                query = from a in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes on a.OrderInfoID equals b.ID into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()
                        join n in this._context.XMNicks on b.NickID equals n.nick_id
                        join x in _context.CodeLists
                        on b.PlatformTypeId equals x.CodeID into temp
                        from y in temp.DefaultIfEmpty()
                        where a.IsEnable.Value == false
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIdList.Contains(b.NickID.Value)
                        && zt.Contains(b.OrderStatus)
                        && (b.IsScalping == false || b.IsScalping == null)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.OrderInfoCreateDate >= OrderInfoModifiedStart && b.OrderInfoCreateDate < OrderInfoModifiedEnd))
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            OrderCode = b.OrderCode,
                            PlatformTypeId = b.PlatformTypeId,
                            DeliveryTime = b.DeliveryTime,
                            PayDate = b.PayDate,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            DetailsID = a.ID,
                            PlatformMerchantCode = a.PlatformMerchantCode,
                            ProductName = a.ProductName,
                            Specifications = a.Specifications,
                            ProductNum = a.ProductNum,
                            FactoryPrice = a.FactoryPrice == null ? 0 : a.FactoryPrice,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            PayPrice = b.PayPrice,
                            OrderPrice = b.OrderPrice,
                            SalesPrice = a.SalesPrice,
                            NickID = b.NickID,
                            PlatformTypeName = y.CodeName,
                            ProjectId = 0,
                            ProjectName = "",
                            NickName = n.nick,
                            ManufacturersCode = a.TManufacturersCode,
                            ProductId = 0,
                            MarkDate = b.OrderInfoCreateDate,
                            CompletionTime = b.CompletionTime
                        };

            }
            #endregion

            #region 付款时间
            if (OrderStatusId == 2)//付款时间  
            {
                //左链接
                query = from a in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on a.OrderInfoID equals b.ID into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()
                        join n in this._context.XMNicks on b.NickID equals n.nick_id
                        join x in _context.CodeLists
                        on b.PlatformTypeId equals x.CodeID into temp
                        from y in temp.DefaultIfEmpty()
                        where a.IsEnable.Value == false
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIdList.Contains(b.NickID.Value)
                        && zt.Contains(b.OrderStatus)
                        && (b.IsScalping == false || b.IsScalping == null)
                        && b.FinancialAudit == true
                       && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                       || (b.PayDate >= OrderInfoModifiedStart && b.PayDate < OrderInfoModifiedEnd))
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            OrderCode = b.OrderCode,
                            PlatformTypeId = b.PlatformTypeId,
                            DeliveryTime = b.DeliveryTime,
                            PayDate = b.PayDate,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            DetailsID = a.ID,
                            PlatformMerchantCode = a.PlatformMerchantCode,
                            ProductName = a.ProductName,
                            Specifications = a.Specifications,
                            ProductNum = a.ProductNum,
                            FactoryPrice = a.FactoryPrice == null ? 0 : a.FactoryPrice,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            PayPrice = b.PayPrice,
                            OrderPrice = b.OrderPrice,
                            SalesPrice = a.SalesPrice,
                            NickID = b.NickID,
                            PlatformTypeName = y.CodeName,
                            ProjectId = 0,
                            ProjectName = "",
                            NickName = n.nick,
                            ManufacturersCode = a.TManufacturersCode,
                            ProductId = 0,
                            MarkDate = b.PayDate,
                            CompletionTime = b.CompletionTime
                        };

            }
            #endregion

            #region 发货时间
            if (OrderStatusId == 3)//发货时间  
            {
                List<string> ztstatus = new List<string> {
                     "SELLER_CONSIGNED_PART", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_BUYER_SIGNED", "TRADE_FINISHED"//天猫
                    ,"WAIT_SELLER_STOCK_OUT","SEND_TO_DISTRIBUTION_CENER", "DISTRIBUTION_CENTER_RECEIVED", "WAIT_GOODS_RECEIVE_CONFIRM","FINISHED_L"//京东
                    , "DS_WAIT_BUYER_RECEIVE", "DS_DEAL_END_NORMAL"//拍拍
                    , "22","25"//唯品会和唯评会MP
                    , "ORDER_TRUNED_TO_DO","ORDER_OUT_OF_WH", "ORDER_RECEIVED", "ORDER_FINISH"//1号店
                    , "已发货"//亚马逊
                    ,"20","21","30"//苏宁易购
                    ,"已发货","已完成"//通用状态
                };

                //左链接
                query = from a in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on a.OrderInfoID equals b.ID into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()
                        join n in this._context.XMNicks on b.NickID equals n.nick_id
                        join x in _context.CodeLists
                        on b.PlatformTypeId equals x.CodeID into temp
                        from y in temp.DefaultIfEmpty()
                        where a.IsEnable.Value == false
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIdList.Contains(b.NickID.Value)
                        && ztstatus.Contains(b.OrderStatus)
                            && b.FinancialAudit == true
                        && (b.IsScalping == false || b.IsScalping == null)
                       && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                       || (b.DeliveryTime >= OrderInfoModifiedStart && b.DeliveryTime < OrderInfoModifiedEnd))
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            OrderCode = b.OrderCode,
                            PlatformTypeId = b.PlatformTypeId,
                            DeliveryTime = b.DeliveryTime,
                            PayDate = b.PayDate,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            DetailsID = a.ID,
                            PlatformMerchantCode = a.PlatformMerchantCode,
                            ProductName = a.ProductName,
                            Specifications = a.Specifications,
                            ProductNum = a.ProductNum,
                            FactoryPrice = a.FactoryPrice == null ? 0 : a.FactoryPrice,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            PayPrice = b.PayPrice,
                            OrderPrice = b.OrderPrice,
                            SalesPrice = a.SalesPrice,
                            NickID = b.NickID,
                            PlatformTypeName = y.CodeName,
                            ProjectId = 0,
                            ProjectName = "",
                            NickName = n.nick,
                            ManufacturersCode = a.TManufacturersCode,
                            ProductId = 0,
                            MarkDate = b.DeliveryTime,
                            CompletionTime = b.CompletionTime
                        };

            }
            #endregion

            #region 完成时间
            if (OrderStatusId == 4)//完成时间  
            {
                List<string> ztstatus = new List<string> {
                      "TRADE_FINISHED"//天猫
                    , "FINISHED_L"//京东
                    , "DS_DEAL_END_NORMAL"//拍拍
                    , "25"//唯品会和唯评会MP
                    , "ORDER_FINISH"//1号店
                    , "已发货"//亚马逊
                    ,"30"//苏宁易购
                    ,"已完成"//通用状态
                };
                //左链接
                query = from a in this._context.XMOrderInfoProductDetails
                        join b in this._context.XMOrderInfoes
                        on a.OrderInfoID equals b.ID into JoinedAB
                        from b in JoinedAB.DefaultIfEmpty()
                        join n in this._context.XMNicks on b.NickID equals n.nick_id
                        join x in _context.CodeLists
                        on b.PlatformTypeId equals x.CodeID into temp
                        from y in temp.DefaultIfEmpty()
                        where a.IsEnable.Value == false
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIdList.Contains(b.NickID.Value)
                        && ztstatus.Contains(b.OrderStatus)
                        && b.FinancialAudit == true
                        && (b.IsScalping == false || b.IsScalping == null)
                       && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                       || (b.CompletionTime >= OrderInfoModifiedStart && b.CompletionTime < OrderInfoModifiedEnd))
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            OrderCode = b.OrderCode,
                            PlatformTypeId = b.PlatformTypeId,
                            DeliveryTime = b.DeliveryTime,
                            PayDate = b.PayDate,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            DetailsID = a.ID,
                            PlatformMerchantCode = a.PlatformMerchantCode,
                            ProductName = a.ProductName,
                            Specifications = a.Specifications,
                            ProductNum = a.ProductNum,
                            FactoryPrice = a.FactoryPrice == null ? 0 : a.FactoryPrice,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            PayPrice = b.PayPrice,
                            OrderPrice = b.OrderPrice,
                            SalesPrice = a.SalesPrice,
                            NickID = b.NickID,
                            PlatformTypeName = y.CodeName,
                            ProjectId = 0,
                            ProjectName = "",
                            NickName = n.nick,
                            ManufacturersCode = a.TManufacturersCode,
                            ProductId = 0,
                            MarkDate = b.CompletionTime,
                            CompletionTime = b.CompletionTime
                        };

            }
            #endregion

            //筛选呼噜噜订单
            query = from p in query
                    join c in this._context.XMOrderInfoProductDetails
                    on p.ID equals c.OrderInfoID
                    into JoinedEmpDept
                    from c in JoinedEmpDept.DefaultIfEmpty()
                    where (p.NickID == 32 && (c == null || c.PlatformMerchantCode == null || c.PlatformMerchantCode == "" || c.PlatformMerchantCode.StartsWith("CM")))
                    || p.NickID != 32
                    select p;

            string psql = query.Distinct().GetType().GetMethod("ToTraceString").Invoke(query.Distinct(), null).ToString();

            return new List<OrderInfoSalesDetails>(query.Distinct()).ToList();

            #endregion
        }

        /// <summary>
        /// get to XMOrderInfoProductDetails Page List
        /// </summary>s
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfoProductDetails Page List</returns>
        public PagedList<XMOrderInfoProductDetails> SearchXMOrderInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOrderInfoProductDetails
                        orderby p.ID
                        select p;
            return new PagedList<XMOrderInfoProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="id">XMOrderInfoProductDetails ID</param>
        /// <returns>XMOrderInfoProductDetails</returns>   
        public XMOrderInfoProductDetails GetXMOrderInfoProductDetailsByID(int id)
        {
            var query = from p in this._context.XMOrderInfoProductDetails
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="ID">XMOrderInfoProductDetails ID</param>
        public void DeleteXMOrderInfoProductDetails(int id)
        {
            var xmorderinfoproductdetails = this.GetXMOrderInfoProductDetailsByID(id);
            if (xmorderinfoproductdetails == null)
                return;

            if (!this._context.IsAttached(xmorderinfoproductdetails))
                this._context.XMOrderInfoProductDetails.Attach(xmorderinfoproductdetails);

            this._context.DeleteObject(xmorderinfoproductdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfoProductDetails ID</param>
        public void BatchDeleteXMOrderInfoProductDetails(List<int> ids)
        {
            var query = from q in _context.XMOrderInfoProductDetails
                        where ids.Contains(q.ID)
                        select q;
            var xmorderinfoproductdetailss = query.ToList();
            foreach (var item in xmorderinfoproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMOrderInfoProductDetails.Attach(item);

                _context.XMOrderInfoProductDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 查询发生退货的商品
        /// </summary>
        /// <param name="platform">平台id</param>
        /// <param name="nickIdList">店铺id</param>
        /// <param name="OrderCode">订单号</param>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="timeType">时间类型</param>
        /// <returns></returns>
        public List<XMBackProductDetails> GetBackProductDetails(int platform, List<int> nickIdList, string OrderCode, DateTime? BeginDate, DateTime? EndDate, int timeType)
        {

              var  query = from p in _context.XMApplications
                        join s in _context.XMApplicationExchanges on p.ID equals s.ApplicationId into gs
                        from gsi in gs.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (platform == -1 || p.PlatformTypeId == platform)
                        && nickIdList.Contains(p.NickId.Value)
                        && (OrderCode == null || p.OrderCode.Contains(OrderCode))
                        && p.FinishTime >= BeginDate && p.FinishTime < EndDate
                        && new int[] { 5, 6, 7 }.Contains((int)p.ApplicationType)
                        && gsi.IsApplication.Value.Equals(2)
                        select new XMBackProductDetails
                        {
                            ApplicationNo=p.ApplicationNo,
                            ApplicationType = p.ApplicationType,
                            CreateDate = p.CreateDate,
                            OrderCode = p.OrderCode,
                            PlatformTypeId = p.PlatformTypeId,
                            NickId = p.NickId,
                            Amount = p.Amount,
                            PlatformMerchantCode = gsi.PlatformMerchantCode,
                            ProductName = gsi.ProductName,
                            Specifications = gsi.Specifications,
                            ProductNum = gsi.ProductNum,
                            FactoryPrice = gsi.FactoryPrice,
                        };
            if (timeType == 3)                                        //发货时间
            {
                query = from p in _context.XMApplications
                        join s in _context.XMApplicationExchanges on p.ID equals s.ApplicationId into gs
                        from gsi in gs.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (platform == -1 || p.PlatformTypeId == platform)
                        && nickIdList.Contains(p.NickId.Value)
                        && (OrderCode == null || p.OrderCode.Contains(OrderCode))
                        && p.FinishTime >= BeginDate && p.FinishTime < EndDate
                        && new int[] { 5, 6, 7 }.Contains((int)p.ApplicationType)
                        && gsi.IsApplication.Value.Equals(2)
                        select new XMBackProductDetails
                        {
                            ApplicationNo = p.ApplicationNo,
                            ApplicationType = p.ApplicationType,
                            CreateDate = p.CreateDate,
                            OrderCode = p.OrderCode,
                            PlatformTypeId = p.PlatformTypeId,
                            NickId = p.NickId,
                            Amount = p.Amount,
                            PlatformMerchantCode = gsi.PlatformMerchantCode,
                            ProductName = gsi.ProductName,
                            Specifications = gsi.Specifications,
                            ProductNum = gsi.ProductNum,
                            FactoryPrice = gsi.FactoryPrice,

                        };
            }
            else if (timeType == 4)                               //交易成功时间
            {
                query = from p in _context.XMApplications
                        join s in _context.XMApplicationExchanges on p.ID equals s.ApplicationId into gs
                        from gsi in gs.DefaultIfEmpty()
                        where p.IsEnable == false
                        && (platform == -1 || p.PlatformTypeId == platform)
                        && nickIdList.Contains(p.NickId.Value)
                        && (OrderCode == null || p.OrderCode.Contains(OrderCode))
                        && p.FinishTime >= BeginDate && p.FinishTime < EndDate
                        && new int[] { 5, 6, 7 }.Contains((int)p.ApplicationType)
                        && gsi.IsApplication.Value.Equals(2)
                        select new XMBackProductDetails
                        {
                            ApplicationNo = p.ApplicationNo,
                            ApplicationType = p.ApplicationType,
                            CreateDate = p.CreateDate,
                            OrderCode = p.OrderCode,
                            PlatformTypeId = p.PlatformTypeId,
                            NickId = p.NickId,
                            Amount = p.Amount,
                            PlatformMerchantCode = gsi.PlatformMerchantCode,
                            ProductName = gsi.ProductName,
                            Specifications = gsi.Specifications,
                            ProductNum = gsi.ProductNum,
                            FactoryPrice = gsi.FactoryPrice,
                        };

            }


            return query.ToList();
        }

        #endregion
    }
}
