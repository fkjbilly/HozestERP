
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-30 09:44:23
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
using HozestERP.Common;
using System.Data.Objects.SqlClient;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Transactions;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMDeliveryService : IXMDeliveryService
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
        public XMDeliveryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMDeliveryService成员
        /// <summary>
        /// Insert into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
        public void InsertXMDelivery(XMDelivery xmdelivery)
        {
            if (xmdelivery == null)
                return;

            if (!this._context.IsAttached(xmdelivery))

                this._context.XMDeliveries.AddObject(xmdelivery);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
        public void UpdateXMDelivery(XMDelivery xmdelivery)
        {
            if (xmdelivery == null)
                return;

            if (this._context.IsAttached(xmdelivery))
                this._context.XMDeliveries.Attach(xmdelivery);

            this._context.SaveChanges();
        }
        /// <summary>
        /// Update into XMDelivery
        /// </summary>
        /// <param name="xmdelivery">XMDelivery</param>
        public int UpdateXMDelivery(List<XMDelivery> xmdeliverylist)
        {
            foreach (var xmdelivery in xmdeliverylist)
            {
                if (xmdelivery == null)
                    continue;

                if (this._context.IsAttached(xmdelivery))
                    this._context.XMDeliveries.Attach(xmdelivery);
            }
            return this._context.SaveChanges();
        }
        /// <summary>
        /// get to XMDelivery list
        /// </summary>
        public List<XMDelivery> GetXMDeliveryList()
        {
            var query = from p in this._context.XMDeliveries
                        where p.IsEnabled == false
                        orderby p.PrintBatch descending
                        select p;
            return query.ToList();
        }
        public XMDelivery GetFirstXMDelivery()
        {
            var query = from p in this._context.XMDeliveries
                        where p.IsEnabled == false
                        orderby p.PrintBatch descending
                        select p;
            return query.FirstOrDefault();
        }
        public List<XMDelivery> GetXMOrderInfoListByDeliveryNumber(string DeliveryNumber)
        {
            var query = from p in this._context.XMDeliveries
                        where p.IsEnabled == false
                        && p.DeliveryNumber == DeliveryNumber
                        select p;
            return query.ToList();
        }

        public List<XMDelivery> GetXMDeliveryListByOrderCodeShipper(string OrderCode, int Shipper)
        {
            var query = from p in this._context.XMDeliveries
                        where p.IsEnabled == false
                        && p.OrderCode == OrderCode
                        && p.Shipper == Shipper
                        && p.DeliveryTypeId == 481
                        && p.IsDelivery != true
                        select p;
            return query.ToList();
        }

        public List<XMDelivery> GetXMDeliveryListByInfo(string OrderCode, int Shipper, int DeliveryTypeId)
        {
            var query = from p in this._context.XMDeliveries
                        where p.IsEnabled == false
                        && p.OrderCode == OrderCode
                        && p.Shipper == Shipper
                        && p.DeliveryTypeId == DeliveryTypeId
                        && p.IsDelivery != true
                        select p;
            return query.ToList();
        }

        public List<XMDelivery> GetXMOrderInfoListByCode(string OrderCode, string ManufacturersCode)
        {

            var query = from p in this._context.XMDeliveries
                        join q in this._context.XMDeliveryDetails
                        on p.Id equals q.DeliveryId
                        join d in this._context.XMProductDetails
                        on q.PlatformMerchantCode equals d.PlatformMerchantCode
                        join pr in this._context.XMProducts
                        on d.ProductId equals pr.Id
                        where p.IsEnabled == false
                        && d.IsEnable == false
                        && pr.IsEnable == false
                        && q.IsEnabled == false
                        && (OrderCode == "-1" || p.OrderCode == OrderCode)
                        && (ManufacturersCode == "-1" || pr.ManufacturersCode == ManufacturersCode)
                        select p;
            return query.ToList();
        }

        public List<XMDelivery> GetXMOrderInfoListByOrderCode(string OrderCode, List<string> DeliveryNumberList)
        {
            var query = from p in this._context.XMDeliveries
                        where p.OrderCode == OrderCode
                        && (p.DeliveryTypeId == 480 || p.DeliveryTypeId == 708)
                        && p.IsEnabled == false
                        && !DeliveryNumberList.Contains(p.DeliveryNumber)
                        select p;
            return query.ToList();
        }

        public List<string> GetXMDeliveryListByOrderCode(string OrderCode, List<string> DeliveryNumberList)
        {
            var query = from p in this._context.XMDeliveries
                        join d in this._context.XMDeliveryDetails
                        on p.Id equals d.DeliveryId into D
                        from d in D.DefaultIfEmpty()
                        where p.OrderCode == OrderCode
                        && (p.DeliveryTypeId == 480 || p.DeliveryTypeId == 708)
                        && p.IsEnabled == false
                        && DeliveryNumberList.Contains(p.DeliveryNumber)
                        && !d.PrdouctName.Contains("乳胶枕")
                        && !d.PrdouctName.Contains("U型枕")
                        && !d.PrdouctName.Contains("喜米")
                        select p.DeliveryNumber;
            return query.Distinct().ToList();
        }

        public List<XMDelivery> GetXMDeliveryListByOrderCode(string OrderCode, int DeliveryTypeId)
        {
            var query = from p in this._context.XMDeliveries
                        join d in this._context.XMDeliveryDetails
                        on p.Id equals d.DeliveryId into D
                        from d in D.DefaultIfEmpty()
                        where p.DeliveryTypeId == DeliveryTypeId
                        && p.IsEnabled == false
                        && d.IsEnabled == false
                        && d.OrderNo.Contains(OrderCode)
                        && p.IsDelivery != true
                        && p.PrintQuantity == 0
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMDelivery list
        /// </summary>
        public List<XMDeliveryNew> GetXMDeliveryList(string ordercode, string partno, string deliveryno)
        {
            var query = from p in this._context.XMDeliveries
                        from b in this._context.XMOrderInfoes
                        from c in this._context.XMOrderInfoProductDetails
                        where p.IsEnabled == false
                        & p.OrderCode.Equals(b.OrderCode)
                        & b.ID == c.OrderInfoID
                        & p.ProductNo.Equals(c.PlatformMerchantCode)
                        & (ordercode == "" || p.OrderCode.Contains(ordercode))
                        & (partno == "" || p.ProductNo.Contains(partno))
                        & (deliveryno == "" || p.DeliveryNumber.Contains(deliveryno))
                        select new XMDeliveryNew
                        {
                            Id = p.Id,
                            OrderId = b.ID,
                            DeliveryNumber = p.DeliveryNumber,
                            OrderCode = p.OrderCode,
                            ProductNo = p.ProductNo,
                            LogisticsId = p.LogisticsId,
                            LogisticsNumber = p.LogisticsNumber,
                            Price = p.Price,
                            IsDelivery = p.IsDelivery,
                            CreateId = p.CreateId,
                            CreateDate = p.CreateDate,
                            UpdateId = p.UpdateId,
                            UpdateDate = p.UpdateDate,
                            Remark = p.Remark,
                            IsEnabled = p.IsEnabled,
                            FullName = b.FullName,
                            Province = b.Province,
                            City = b.City,
                            County = b.County,
                            DeliveryAddress = b.DeliveryAddress,
                            DeliveryAddressSpare = b.DeliveryAddressSpare,
                            Mobile = b.Mobile,
                            Tel = b.Tel,
                            PlatformMerchantCode = c.PlatformMerchantCode,
                            ProductName = c.ProductName,
                            Specifications = c.Specifications,
                            ProductNum = c.ProductNum,
                            SalesPrice = c.SalesPrice
                        };

            #region  发货单表、订单表、订单明细、赠品表、赠品明细表 多表管理
            ////发货单表、订单表、赠品表
            //var query = from p in this._context.XMDeliveries
            //            join  b in this._context.XMOrderInfoes   on p.OrderCode equals b.OrderCode  
            //            into JoinedXMorder  from b in JoinedXMorder.DefaultIfEmpty() 
            //            join c in this._context.XMPremiums on p.OrderCode equals c.OrderCode  
            //            into JoinedXMPremiums  from c in JoinedXMPremiums.DefaultIfEmpty()
            //            where p.IsEnabled == false 
            //            && (ordercode == "" || p.OrderCode.Contains(ordercode))
            //            && (partno == "" || p.ProductNo.Contains(partno))
            //           && (deliveryno == "" || p.DeliveryNumber.Contains(deliveryno))
            //            select new XMDeliveryNew
            //            {
            //                Id = p.Id,
            //                OrderId = b.ID,
            //                PremiumsId=c.Id,
            //                DeliveryNumber = p.DeliveryNumber,
            //                OrderCode = p.OrderCode,
            //                ProductNo = p.ProductNo,
            //                LogisticsId = p.LogisticsId,
            //                LogisticsNumber = p.LogisticsNumber, 
            //                Price = p.Price,
            //                IsDelivery = p.IsDelivery,
            //                CreateId = p.CreateId,
            //                CreateDate = p.CreateDate,
            //                UpdateId = p.UpdateId,
            //                UpdateDate = p.UpdateDate,
            //                Remark = p.Remark,
            //                IsEnabled = p.IsEnabled,
            //                FullName = b.FullName,
            //                Province = b.Province,
            //                City = b.City,
            //                County = b.County,
            //                DeliveryAddress = b.DeliveryAddress,
            //                DeliveryAddressSpare = b.DeliveryAddressSpare,
            //                Mobile = b.Mobile,
            //                Tel = b.Tel,
            //                PlatformMerchantCode = "",
            //                ProductName = "",
            //                Specifications ="",
            //                ProductNum = -1,
            //                SalesPrice = -1
            //                //, 
            //                //XMPPlatformMerchantCode = "",
            //                //XMPProductName = "",
            //                //XMPSpecifications = "",
            //                //XMPProductNum = -1,
            //                //XMPFactoryPrice = -1
            //            };

            // //订单明细表
            //query = from p in query
            //            join  c in this._context.XMOrderInfoProductDetails on p.OrderId equals c.OrderInfoID into co
            //            from op in co.DefaultIfEmpty()    
            //            select new XMDeliveryNew
            //            {
            //                Id = p.Id,
            //                OrderId = p.OrderId,
            //                PremiumsId=p.PremiumsId,
            //                DeliveryNumber = p.DeliveryNumber,
            //                OrderCode = p.OrderCode,
            //                ProductNo = p.ProductNo,
            //                LogisticsId = p.LogisticsId,
            //                LogisticsNumber = p.LogisticsNumber,
            //                Price = p.Price,
            //                IsDelivery = p.IsDelivery,
            //                CreateId = p.CreateId,
            //                CreateDate = p.CreateDate,
            //                UpdateId = p.UpdateId,
            //                UpdateDate = p.UpdateDate,
            //                Remark = p.Remark,
            //                IsEnabled = p.IsEnabled,
            //                FullName = p.FullName,
            //                Province = p.Province,
            //                City = p.City,
            //                County = p.County,
            //                DeliveryAddress = p.DeliveryAddress,
            //                DeliveryAddressSpare = p.DeliveryAddressSpare,
            //                Mobile = p.Mobile,
            //                Tel = p.Tel,
            //                PlatformMerchantCode = op.PlatformMerchantCode!=null ? op.PlatformMerchantCode:"" ,
            //                ProductName = op.ProductName != null ? op.ProductName : "",
            //                Specifications = op.Specifications != null ? op.Specifications : "",
            //                ProductNum = op.ProductNum != null ? op.ProductNum : -1,
            //                SalesPrice = op.SalesPrice != null ? op.SalesPrice : -1 
            //                //,
            //                //XMPPlatformMerchantCode = p.XMPPlatformMerchantCode,
            //                //XMPProductName = p.XMPProductName,
            //                //XMPSpecifications = p.XMPSpecifications,
            //                //XMPProductNum = p.XMPProductNum,
            //                //XMPFactoryPrice =p.XMPFactoryPrice
            //            };

            ////赠品明细表
            //query = from p in query
            //        join d in this._context.XMPremiumsDetails on p.PremiumsId equals d.PremiumsId into pd
            //        from xpd in pd.DefaultIfEmpty()
            //        select new XMDeliveryNew
            //        {
            //            Id = p.Id,
            //            OrderId = p.OrderId,
            //            PremiumsId=p.PremiumsId,
            //            DeliveryNumber = p.DeliveryNumber,
            //            OrderCode = p.OrderCode,
            //            ProductNo = p.ProductNo,
            //            LogisticsId = p.LogisticsId,
            //            LogisticsNumber = p.LogisticsNumber,
            //            Price = p.Price,
            //            IsDelivery = p.IsDelivery,
            //            CreateId = p.CreateId,
            //            CreateDate = p.CreateDate,
            //            UpdateId = p.UpdateId,
            //            UpdateDate = p.UpdateDate,
            //            Remark = p.Remark,
            //            IsEnabled = p.IsEnabled,
            //            FullName = p.FullName,
            //            Province = p.Province,
            //            City = p.City,
            //            County = p.County,
            //            DeliveryAddress = p.DeliveryAddress,
            //            DeliveryAddressSpare = p.DeliveryAddressSpare,
            //            Mobile = p.Mobile,
            //            Tel = p.Tel,
            //            PlatformMerchantCode = p.PlatformMerchantCode==null ? xpd.PlatformMerchantCode:"",
            //            ProductName = p.ProductName == null ? xpd.PrdouctName : "",
            //            Specifications = p.Specifications == null ? xpd.PrdouctName : "",
            //            ProductNum = p.ProductNum == null ? xpd.ProductNum : -1,
            //            SalesPrice = p.SalesPrice == null ? xpd.FactoryPrice : -1
            //            //,
            //            //XMPPlatformMerchantCode = xpd.PlatformMerchantCode,
            //            //XMPProductName = xpd.PrdouctName,
            //            //XMPSpecifications = xpd.PrdouctName,
            //            //XMPProductNum = xpd.ProductNum,
            //            //XMPFactoryPrice = xpd.FactoryPrice
            //        };

            #endregion
            return query.ToList();
        }

        /// <summary>
        /// 根据时间 项目查询
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="ddXMProject"></param>
        /// <returns></returns>
        public List<XMDeliveryNew> GetXMDeliveryListByParm(string begin, string end, int ddXMProject)
        {
            DateTime CreateBeginDate = DateTime.Now;
            DateTime CreateEndDate = DateTime.Now;
            if (begin != "" && end != "")
            {
                CreateBeginDate = DateTime.Parse(begin);
                CreateEndDate = DateTime.Parse(end);
            }
            var query = from p in this._context.XMDeliveries
                        join t in this._context.XMOrderInfoes
                         on p.OrderCode equals t.OrderCode
                        join d in this._context.XMNicks
                        on t.NickID equals d.nick_id
                        where ((begin == "" && end == "") || (p.CreateDate >= CreateBeginDate && p.CreateDate < CreateEndDate))
                           && (ddXMProject == -1 || d.ProjectId == ddXMProject)
                           && p.Price != 0
                        orderby p.CreateDate descending
                        select new XMDeliveryNew
                        {
                            Id = p.Id,
                            //OrderId = b.ID,
                            //PremiumsId = c.Id,
                            DeliveryTypeId = p.DeliveryTypeId,
                            DeliveryNumber = p.DeliveryNumber,
                            Shipper = p.Shipper,
                            OrderCode = p.OrderCode,
                            ProductNo = p.ProductNo,
                            LogisticsId = p.LogisticsId,
                            LogisticsNumber = p.LogisticsNumber,
                            Price = p.Price,
                            IsDelivery = p.IsDelivery,
                            CreateId = p.CreateId,
                            CreateDate = p.CreateDate,
                            UpdateId = p.UpdateId,
                            UpdateDate = p.UpdateDate,
                            //Remark = p.Remark,
                            IsEnabled = p.IsEnabled,
                            PrintQuantity = p.PrintQuantity,
                            PrintBatch = p.PrintBatch,
                            PrintDateTime = p.PrintDateTime,
                            FullName = p.FullName,
                            Province = p.Province,
                            City = p.City,
                            County = p.County,
                            DeliveryAddress = p.DeliveryAddress,
                            //DeliveryAddressSpare = b.DeliveryAddressSpare,
                            Mobile = p.Mobile,
                            Tel = p.Tel,
                            IsShelve = p.IsShelve,
                            OrderRemarks = p.OrderRemarks,
                            NickID = d.nick_id
                            //OrderStatus = b.OrderStatus
                        };
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Printegin"></param>
        /// <param name="PrintEnd"></param>
        /// <returns></returns>
        public List<XMDelivery> GetXMDeliveryByPrintDate(int year, int month, string expressIDs)
        {
            int?[] expressIdlist = Array.ConvertAll<string, int?>(expressIDs.Split(','), delegate(string s) { return int.Parse(s); });
            var query = from p in this._context.XMDeliveries
                        where p.IsEnabled == false
                        && (p.PrintDateTime.Value.Year == year && p.PrintDateTime.Value.Month == month)
                        && expressIdlist.Contains(p.LogisticsId)
                        && p.LogisticsNumber != null
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据、订单号、商品编码、发货单号 查询
        /// </summary>
        ///  <param name="logisticsNumber">物流单号</param>
        /// <param name="ordercode">订单号</param>
        /// <param name="partno">商品编码</param>
        /// <param name="deliveryno">发货单号</param>
        /// <param name="ddPrintQuantity">是否打印</param>
        /// <param name="DeliveryTypeId">发货单类型</param>
        /// <param name="FullName">收货人姓名</param>
        /// <param name="MobileAndTel">电话</param>
        /// <param name="DeliveryAddress">收货地址</param>
        /// <param name="IsDelivery">是否发货</param>
        /// <param name="ddXMProject">项目名称</param>
        /// <param name="isPrint">是否打印发货单</param>
        /// <param name="logisticsCompany">物流公司</param>
        /// <returns></returns>
        public List<XMDeliveryNew> GetXMDeliverySearchList(string logisticsNumber, string ordercode, string manufacturersCode, string deliveryno, int ddPrintQuantity, int DeliveryTypeId,
            string FullName, string MobileAndTel, string DeliveryAddress, int IsDelivery, int ddXMProject, string PrintBatch, int Shipper, string Nick,
            string PrintBegin, string PrintEnd, string CreateBegin, string CreateEnd, int IsShelve, bool NoOrder, int isPrint, string verificationStatus, bool packageCheck, string logisticsCompany)
        {
            int?[] nicklist = Array.ConvertAll<string, int?>(Nick.Split(','), delegate(string s) { return int.Parse(s); });
            int nick_id = -1;
            if (nicklist.Count() > 0 && nicklist[0] != -1)
            {
                nick_id = int.Parse(nicklist[0].ToString());
            }
            DateTime PrintBeginDate = DateTime.Now;
            DateTime PrintEndDate = DateTime.Now;
            if (PrintBegin != "" && PrintEnd != "")
            {
                PrintBeginDate = DateTime.Parse(PrintBegin);
                PrintEndDate = DateTime.Parse(PrintEnd);
            }

            DateTime CreateBeginDate = DateTime.Now;
            DateTime CreateEndDate = DateTime.Now;
            if (CreateBegin != "" && CreateEnd != "")
            {
                CreateBeginDate = DateTime.Parse(CreateBegin);
                CreateEndDate = DateTime.Parse(CreateEnd);
            }

            int printbatch = 0;
            if (PrintBatch == "" || int.TryParse(PrintBatch, out printbatch) == false)
            {
                printbatch = -1;
            }
            else
            {
                printbatch = int.Parse(PrintBatch);
            }

            IQueryable<XMDeliveryNew> query;
            if (!NoOrder)
            {
                #region  发货单表、订单表、订单明细、赠品表、赠品明细表 多表管理

                //发货单表、订单表、赠品表
                query = from p in this._context.XMDeliveries

                        join d in this._context.XMDeliveryDetails on p.Id equals d.DeliveryId
                        into JoinedXMDeliveryDetails
                        from d in JoinedXMDeliveryDetails.DefaultIfEmpty()
                        //join a in this._context.XMProductDetails on d.PlatformMerchantCode equals a.PlatformMerchantCode
                        //into JoinedXMProductDetails
                        //from a in JoinedXMProductDetails.DefaultIfEmpty()
                        //join h in this._context.XMProducts on a.ProductId equals h.Id
                        //into JoinedXMProducts
                        //from h in JoinedXMProducts.DefaultIfEmpty()

                        join b in this._context.XMOrderInfoes on p.OrderCode equals b.OrderCode
                        into JoinedXMorder
                        from b in JoinedXMorder.DefaultIfEmpty()

                        join n in this._context.XMNicks on b.NickID equals n.nick_id
                        into JoinedXMNicks
                        from n in JoinedXMNicks.DefaultIfEmpty()

                        join m in _context.XMCompanyCustoms on SqlFunctions.StringConvert((decimal)p.LogisticsId).Trim() equals m.LogisticsId
                        into JoinedXMCompanyCustoms
                        from m in JoinedXMCompanyCustoms.DefaultIfEmpty()

                        where 
                        p.IsEnabled == false && 
                        (b == null || b.IsEnable == false)
                        && (n == null || n.isEnable == true)
                            //&& (manufacturersCode == "" || h.ManufacturersCode.Contains(manufacturersCode))
                        && (logisticsNumber == "" || p.LogisticsNumber.Contains(logisticsNumber))
                        && (logisticsCompany=="" || m.LogisticsName.IndexOf(logisticsCompany) >=0)
                        && (deliveryno == "" || p.DeliveryNumber.Contains(deliveryno))
                        && (DeliveryTypeId == -1 || p.DeliveryTypeId.Value == DeliveryTypeId)
                        && (FullName == "" || p.FullName.Contains(FullName))
                        && (p.Mobile.Contains(MobileAndTel) || p.Tel.Contains(MobileAndTel))
                        && (p.DeliveryAddress.Contains(DeliveryAddress) || b.DeliveryAddressSpare.Contains(DeliveryAddress))
                        && (IsDelivery == -1 || p.IsDelivery.Value.Equals(IsDelivery == 0 ? false : true))
                        && (ddXMProject == -1 || ddXMProject == 99 || n.ProjectId.Value == ddXMProject)
                        && (printbatch == -1 || p.PrintBatch == printbatch)
                        && (Shipper == -1 || p.Shipper == Shipper)
                        && (IsShelve == -1 || (IsShelve == 0 && (p.IsShelve == null || p.IsShelve == false)) || (IsShelve == 1 && (p.IsShelve != null && p.IsShelve == true)))
                        && (nick_id == -1 || nicklist.Contains(b.NickID))
                        && ((PrintBegin == "" && PrintEnd == "") || (p.PrintDateTime >= PrintBeginDate && p.PrintDateTime < PrintEndDate))
                        && ((CreateBegin == "" && CreateEnd == "") || (p.CreateDate >= CreateBeginDate && p.CreateDate < CreateEndDate))
                        && (ddPrintQuantity == -1 || (ddPrintQuantity == 0 && p.PrintQuantity == 0) || (ddPrintQuantity == 1 && p.PrintQuantity >= 1))
                        && p.OrderCode.Contains(ordercode)
                        //&& (verificationStatus == "-1" || p.VerificationStatus == verificationStatus)
                        orderby p.DeliveryNumber descending
                        select new XMDeliveryNew
                        {
                            Id = p.Id,
                            DeliveryTypeId = p.DeliveryTypeId,
                            DeliveryNumber = p.DeliveryNumber,
                            Shipper = p.Shipper,
                            OrderCode = p.OrderCode,
                            ProductNo = p.ProductNo,
                            LogisticsId = p.LogisticsId,
                            LogisticsNumber = p.LogisticsNumber,
                            Price = p.Price,
                            IsDelivery = p.IsDelivery,
                            CreateId = p.CreateId,
                            CreateDate = p.CreateDate,
                            UpdateId = p.UpdateId,
                            UpdateDate = p.UpdateDate,
                            IsEnabled = p.IsEnabled,
                            PlatformMerchantCode = d.PlatformMerchantCode,
                            ProductName = d.PrdouctName,
                            ProductNum = d.ProductNum,
                            Specifications = d.Specifications,
                            PrintQuantity = p.PrintQuantity,
                            PrintBatch = p.PrintBatch,
                            PrintDateTime = p.PrintDateTime,
                            FullName = p.FullName,
                            Province = p.Province,
                            City = p.City,
                            County = p.County,
                            DeliveryAddress = p.DeliveryAddress,
                            Mobile = p.Mobile,
                            Tel = p.Tel,
                            IsShelve = p.IsShelve,
                            OrderRemarks = p.OrderRemarks,
                            IsPrint=p.IsPrint,
                            IsLogisticsInfoLate=p.IsLogisticsInfoLate,
                            projectId=n.ProjectId,
                            VerificationStatus = p.VerificationStatus
                        };

                #endregion
            }
            else
            {
                #region  无订单号的发货单

                query = from p in this._context.XMDeliveries
                        join m in _context.XMCompanyCustoms on SqlFunctions.StringConvert((decimal)p.LogisticsId).Trim() equals m.LogisticsId
                        into JoinedXMCompanyCustoms
                        from m in JoinedXMCompanyCustoms.DefaultIfEmpty()
                        where p.IsEnabled == false
                        && (logisticsNumber == "" || p.LogisticsNumber.Contains(logisticsNumber))
                        && (logisticsCompany == "" || m.LogisticsName.IndexOf(logisticsCompany) >= 0)
                        && (deliveryno == "" || p.DeliveryNumber.Contains(deliveryno))
                        && (DeliveryTypeId == -1 || p.DeliveryTypeId.Value == DeliveryTypeId)
                        && (FullName == "" || p.FullName.Contains(FullName))
                        && (p.Mobile.Contains(MobileAndTel) || p.Tel.Contains(MobileAndTel))
                        && p.DeliveryAddress.Contains(DeliveryAddress)
                        && (IsDelivery == -1 || p.IsDelivery.Value.Equals(IsDelivery == 0 ? false : true))
                        && (printbatch == -1 || p.PrintBatch == printbatch)
                        && (Shipper == -1 || p.Shipper == Shipper)
                        && (IsShelve == -1 || (IsShelve == 0 && (p.IsShelve == null || p.IsShelve == false)) || (IsShelve == 1 && (p.IsShelve != null && p.IsShelve == true)))
                        && ((PrintBegin == "" && PrintEnd == "") || (p.PrintDateTime >= PrintBeginDate && p.PrintDateTime < PrintEndDate))
                        && ((CreateBegin == "" && CreateEnd == "") || (p.CreateDate >= CreateBeginDate && p.CreateDate < CreateEndDate))
                        && (ddPrintQuantity == -1 || (ddPrintQuantity == 0 && p.PrintQuantity == 0) || (ddPrintQuantity == 1 && p.PrintQuantity >= 1))
                        && p.OrderCode.Contains(ordercode)
                        && p.OrderCode.StartsWith("NoOrder")
                        orderby p.DeliveryNumber descending
                        select new XMDeliveryNew
                        {
                            Id = p.Id,
                            DeliveryTypeId = p.DeliveryTypeId,
                            DeliveryNumber = p.DeliveryNumber,
                            Shipper = p.Shipper,
                            OrderCode = p.OrderCode,
                            ProductNo = p.ProductNo,
                            LogisticsId = p.LogisticsId,
                            LogisticsNumber = p.LogisticsNumber,
                            Price = p.Price,
                            IsDelivery = p.IsDelivery,
                            CreateId = p.CreateId,
                            CreateDate = p.CreateDate,
                            UpdateId = p.UpdateId,
                            UpdateDate = p.UpdateDate,
                            IsEnabled = p.IsEnabled,
                            PrintQuantity = p.PrintQuantity,
                            PrintBatch = p.PrintBatch,
                            PrintDateTime = p.PrintDateTime,
                            FullName = p.FullName,
                            Province = p.Province,
                            City = p.City,
                            County = p.County,
                            DeliveryAddress = p.DeliveryAddress,
                            Mobile = p.Mobile,
                            Tel = p.Tel,
                            IsShelve = p.IsShelve,
                            OrderRemarks = p.OrderRemarks,
                            IsPrint=p.IsPrint,
                            IsLogisticsInfoLate = p.IsLogisticsInfoLate,
                            projectId =null,
                        };

                #endregion
            }

            if(isPrint!=-1)
            {
                if(isPrint==1)
                {
                    query = query.Where(a => (bool)a.IsPrint);
                }
            }

            if (manufacturersCode != "")
            {
                var lists= manufacturersCode.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                query = from p in query
                        join d in this._context.XMDeliveryDetails on p.Id equals d.DeliveryId
                        into JoinedXMDeliveryDetails
                        from d in JoinedXMDeliveryDetails.DefaultIfEmpty()

                        join a in this._context.XMProductDetails on d.PlatformMerchantCode equals a.PlatformMerchantCode
                        into JoinedXMProductDetails
                        from a in JoinedXMProductDetails.DefaultIfEmpty()

                        join h in this._context.XMProducts on a.ProductId equals h.Id
                        into JoinedXMProducts
                        from h in JoinedXMProducts.DefaultIfEmpty()

                        where d.IsEnabled == false
                        && (manufacturersCode == "" || lists.Contains(h.ManufacturersCode))
                        select p;
                query = query.Distinct().OrderByDescending(x => x.DeliveryNumber);
            }

            if(packageCheck)
            {
                var query1 = from p in (from n in _context.XMOrderInfoes
                                        join m in _context.XMOrderInfoProductDetails
                                        on n.ID equals m.OrderInfoID
                                        join a in _context.XMProductDetails
                                        on m.PlatformMerchantCode equals a.PlatformMerchantCode
                                        join b in _context.XMProducts
                                        on a.ProductId equals b.Id
                                        where !(bool)n.IsEnable && (bool)n.IsAudit && !(bool)m.IsEnable && !(bool)b.IsEnable && !(bool)a.IsEnable
                                        select new
                                        {
                                            OrderCode = n.OrderCode,
                                            ManufacturersCode = b.ManufacturersCode
                                        })
                             group p by new { p.OrderCode, p.ManufacturersCode } into g
                             let count = g.Count()
                             where count == 1 && g.Key.ManufacturersCode == "10601139"
                             select g.Key.OrderCode;

                List<string> ordercodes = query1.ToList();

                query = query.Where(a => query1.Contains(a.OrderCode));
            }

            return query.ToList();
        }

        /// <summary>
        /// get to XMDelivery Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDelivery Page List</returns>
        public PagedList<XMDelivery> SearchXMDelivery(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMDeliveries
                        orderby p.Id
                        select p;
            return new PagedList<XMDelivery>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMDelivery by Id
        /// </summary>
        /// <param name="id">XMDelivery Id</param>
        /// <returns>XMDelivery</returns>   
        public XMDelivery GetXMDeliveryById(int id)
        {
            var query = from p in this._context.XMDeliveries
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public XMDelivery GetXMDeliveryByInvoiceInfo(int InvoiceInfoID)
        {
            var query = from p in this._context.XMDeliveries
                        join d in this._context.XMDeliveryDetails
                        on p.Id equals d.DeliveryId
                        where p.IsEnabled == false
                        && d.IsEnabled == false
                        && d.InvoiceInfoID == InvoiceInfoID
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns> 
        public List<XMDelivery> GetXMDeliveryByListIds(List<int> Ids)
        {
            var query = from p in this._context.XMDeliveries
                        where Ids.Contains(p.Id)
                        && p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据Id集合查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public List<XMDeliveryNew> GetXMDeliverySearchListById(List<int> Ids)
        {

            //发货单表、订单表、赠品表
            var query = from p in this._context.XMDeliveries
                        join cl in this._context.CodeLists on p.DeliveryTypeId equals cl.CodeID
                        join b in this._context.XMOrderInfoes on p.OrderCode equals b.OrderCode
                        into JoinedXMorder
                        from b in JoinedXMorder.DefaultIfEmpty()
                        where p.IsEnabled == false
                        && Ids.Contains(p.Id)
                        && b.IsEnable == false
                        orderby cl.DisplayOrder
                        select new XMDeliveryNew
                        {
                            Id = p.Id,
                            OrderId = b.ID,
                            //PremiumsId = c.Id,
                            DeliveryTypeId = p.DeliveryTypeId,
                            DeliveryNumber = p.DeliveryNumber,
                            OrderCode = p.OrderCode,
                            ProductNo = p.ProductNo,
                            LogisticsId = p.LogisticsId,
                            LogisticsNumber = p.LogisticsNumber,
                            Price = p.Price,
                            IsDelivery = p.IsDelivery,
                            CreateId = p.CreateId,
                            CreateDate = p.CreateDate,
                            UpdateId = p.UpdateId,
                            UpdateDate = p.UpdateDate,
                            Remark = p.Remark,
                            IsEnabled = p.IsEnabled,
                            PrintQuantity = p.PrintQuantity,
                            PrintBatch = p.PrintBatch,
                            PrintDateTime = p.PrintDateTime,
                            FullName = b.FullName,
                            Province = b.Province,
                            City = b.City,
                            County = b.County,
                            DeliveryAddress = b.DeliveryAddress,
                            DeliveryAddressSpare = b.DeliveryAddressSpare,
                            Mobile = b.Mobile,
                            Tel = b.Tel
                        };

            return query.ToList();
        }

        /// <summary>
        /// 根据订单号  商品厂家编码查询
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="PlatformMerchantCode">厂家编码</param>
        /// <returns></returns> 
        public List<XMDelivery> GetXMDeliveryByOrderCodeandPartNo(string OrderCode, string PlatformMerchantCode)
        {
            var query = from p in this._context.XMDeliveries
                        join q in this._context.XMDeliveryDetails
                        on p.Id equals q.DeliveryId
                        join c in this._context.XMProducts
                        on q.ProductlId equals c.Id
                        where q.OrderNo.Contains(OrderCode)
                        && c.ManufacturersCode.Equals(PlatformMerchantCode)
                        && p.IsEnabled == false
                        && q.IsEnabled == false
                        && c.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// delete XMDelivery by Id
        /// </summary>
        /// <param name="Id">XMDelivery Id</param>
        public void DeleteXMDelivery(int id)
        {
            var xmdelivery = this.GetXMDeliveryById(id);
            if (xmdelivery == null)
                return;

            if (!this._context.IsAttached(xmdelivery))
                this._context.XMDeliveries.Attach(xmdelivery);

            this._context.DeleteObject(xmdelivery);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMDelivery by Id
        /// </summary>
        /// <param name="Ids">XMDelivery Id</param>
        public void BatchDeleteXMDelivery(List<int> ids)
        {
            var query = from q in _context.XMDeliveries
                        where ids.Contains(q.Id)
                        select q;
            var xmdeliverys = query.ToList();
            foreach (var item in xmdeliverys)
            {
                if (!_context.IsAttached(item))
                    _context.XMDeliveries.Attach(item);

                _context.XMDeliveries.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 发货单物流信息延迟判断
        /// </summary>
        public void DeliveryLogisticsCheck()
        {
            DateTime now = DateTime.Now;
            DateTime currentTime = now.AddDays(-10);

            var query = from p in _context.XMDeliveries
                        join m in _context.XMCompanyCustoms on SqlFunctions.StringConvert((decimal)p.LogisticsId).Trim() equals m.LogisticsId
                        into JoinedXMCompanyCustoms
                        from m in JoinedXMCompanyCustoms.DefaultIfEmpty()
                        where p.LogisticsId != null && !string.IsNullOrEmpty(p.LogisticsNumber)
                        && !(bool)p.IsEnabled && (bool)p.IsDelivery && p.PrintDateTime != null && p.PrintDateTime >= currentTime
                        select new
                        {
                            id=p.Id,
                            logisticsNumber = p.LogisticsNumber,
                            code = m.Code,
                            printDateTime = (DateTime)p.PrintDateTime
                        };

            foreach (var item in query)
            {
                string result = string.Empty;
                string url = "https://www.kuaidi100.com/query?type=" + item.code + "&postid=" + item.logisticsNumber;
                //string url = "https://www.kuaidi100.com/query?type=zhongtong&postid=537483958023";
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 30000;
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream myStream = res.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.UTF8);
                StringBuilder sb = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    sb.Append(sr.ReadLine());
                }

                result = sb.ToString();

                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                string status = jo["status"].Value<string>();
                string data = jo["data"].ToString();
                if (status == "200" && string.IsNullOrEmpty(data) && (now - item.printDateTime).TotalHours > 48)
                {
                    var query1 = from p in this._context.XMDeliveries
                                where p.Id.Equals(item.id)
                                select p;

                    XMDelivery entity = query1.SingleOrDefault();
                    if(entity!=null)
                    {
                        entity.IsLogisticsInfoLate = true;
                    }
                }
                else if(status == "200" && !string.IsNullOrEmpty(data))
                {
                    var query1 = from p in this._context.XMDeliveries
                                 where p.Id.Equals(item.id)
                                 select p;

                    XMDelivery entity = query1.SingleOrDefault();
                    if (entity != null)
                    {
                        entity.IsLogisticsInfoLate = false;
                    }
                }
            }

            _context.SaveChanges();
        }

        #endregion

        /// <summary>
        /// 根据订单号、是否发货、未打印 查询 
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="IsDelivery">是否发货：0：未发货，1 :已发货</param>
        /// <param name="PrintQuantity">打印次数 ：0：未打印</param>
        /// <returns></returns>
        public List<XMDelivery> GetXMDeliverySearchByOrderCodeList(string OrderCode, int IsDelivery, int PrintQuantity)
        {
            var query = from q in _context.XMDeliveries
                        join d in _context.XMDeliveryDetails
                        on q.Id equals d.DeliveryId
                        where d.OrderNo.Contains(OrderCode) // q.OrderCode.Equals(OrderCode)
                        && (IsDelivery == -1 || q.IsDelivery.Value.Equals(IsDelivery == 0 ? false : true))
                        && q.PrintQuantity.Value == 0
                        select q;
            return query.ToList();
        }

        /// <summary>
        /// get to XMDelivery list
        /// </summary>
        public List<XMDelivery> GetXMDeliveryById(int[] ids)
        {
            var query = from p in this._context.XMDeliveries
                        where ids.Contains(p.Id)
                        && p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据订单号、发货单类型查询
        /// </summary>
        /// <param name="OrderCode">订单号</param>
        /// <param name="DeliveryTypeId">发货单类型</param>
        /// <returns></returns>
        public List<XMDelivery> GetXMDeliveryByOrderCodeAndDeliveryTypeId(string OrderCode, int DeliveryTypeId)
        {
            var query = from p in this._context.XMDeliveries
                        where p.OrderCode == OrderCode
                        && p.DeliveryTypeId == DeliveryTypeId
                        && p.IsEnabled == false
                        select p;
            return query.ToList();
        }



        /// <summary>
        /// 根据物流单号查询
        /// </summary>
        /// <param name="logisticsNumber"></param>
        /// <returns></returns>
        public List<XMDelivery> GetXMDeliveryListByLogisticsNumber(string logisticsNumber)
        {
            var query = from p in this._context.XMDeliveries
                        where p.LogisticsNumber == logisticsNumber
                         && p.IsEnabled == false
                        select p;
            return query.ToList();
        }

        public List<XMDelivery> GetXMDeliveryListPrice(DateTime begin, DateTime end, int ProjectId, int NickID, int PlatformTypeId)
        {
            var query = from p in this._context.XMDeliveries
                        join t in this._context.XMOrderInfoes
                          on p.OrderCode equals t.OrderCode
                        join d in this._context.XMNicks
                        on t.NickID equals d.nick_id
                        where p.IsEnabled == false
                        && t.IsEnable == false
                        && d.isEnable == true
                        && p.PrintDateTime >= begin
                        && p.PrintDateTime <= end
                        && (PlatformTypeId == -1 || t.PlatformTypeId == PlatformTypeId)
                        && d.ProjectId == ProjectId
                        && (NickID == -1 || d.nick_id == NickID)
                        && p.LogisticsNumber != null
                        && p.LogisticsId != null
                        select p;
            return query.ToList();
        }

        public XMNick getNoOrderNickInfo(string orderCode)
        {
            var query = from p in _context.XMDeliveries
                        join m in _context.XMPremiums on p.OrderCode equals m.OrderCode into temp
                        from pm in temp.DefaultIfEmpty()
                        join n in _context.XMNicks on pm.NoOrderNickId equals n.nick_id into temp1
                        from pn in temp1.DefaultIfEmpty()
                        where p.OrderCode == orderCode
                        select pn;


            return query.SingleOrDefault();
        }

        public XMDelivery GetXMDeliveryByLogisticsNumber(string logisticsNumber)
        {
            var query = from p in _context.XMDeliveries
                        where p.LogisticsNumber == logisticsNumber && p.IsEnabled == false
                        select p;

            return query.SingleOrDefault();
        }

        /// <summary>
        /// 导出发货清单
        /// </summary>
        ///  <param name="logisticsNumber">物流单号</param>
        /// <param name="ordercode">订单号</param>
        /// <param name="partno">商品编码</param>
        /// <param name="deliveryno">发货单号</param>
        /// <param name="ddPrintQuantity">是否打印</param>
        /// <param name="DeliveryTypeId">发货单类型</param>
        /// <param name="FullName">收货人姓名</param>
        /// <param name="MobileAndTel">电话</param>
        /// <param name="DeliveryAddress">收货地址</param>
        /// <param name="IsDelivery">是否发货</param>
        /// <param name="ddXMProject">项目名称</param>
        /// <returns></returns>
        public List<XMDeliveryNew> GetXMDeliveryExportList(string logisticsNumber, string ordercode, string manufacturersCode, string deliveryno, int ddPrintQuantity, int DeliveryTypeId,
            string FullName, string MobileAndTel, string DeliveryAddress, int IsDelivery, int ddXMProject, string PrintBatch, int Shipper, int Nick,
            string PrintBegin, string PrintEnd, string CreateBegin, string CreateEnd, int IsShelve, bool NoOrder)
        {
            int printbatch = 0;
            if (PrintBatch == "" || int.TryParse(PrintBatch, out printbatch) == false)
            {
                printbatch = -1;
            }
            else
            {
                printbatch = int.Parse(PrintBatch);
            }
            string sql = "select XM_Delivery.County, XM_Delivery.City, XM_Delivery.Province, XM_OrderInfo.NickID, XM_Delivery.LogisticsId, XM_Delivery.CreateDate, XM_Delivery.Id, XM_Delivery.DeliveryNumber, XM_Delivery.OrderCode,XM_OrderInfo.WantID,XM_Delivery.FullName,XM_Delivery.Mobile "
                            + " ,XM_Delivery.DeliveryAddress,XM_Delivery_Details.PrdouctName as ProductName,XM_Delivery_Details.PlatformMerchantCode "
                            + " ,XM_Delivery_Details.Specifications,XM_Delivery_Details.ProductNum,XM_OrderInfo.OrderInfoCreateDate,"
                            + " XM_OrderInfo.PayDate,XM_OrderInfo.CustomerServiceRemark,XM_OrderInfo.Remark as orderRemark,XM_OrderInfo.DistributePrice,"
                            + " XM_Nick.nick ,XM_Delivery.LogisticsNumber,XM_Delivery.LogisticsId"
                            + " from XM_Delivery "
                            + " inner join  dbo.XM_Delivery_Details "
                            + " on XM_Delivery.Id = XM_Delivery_Details.DeliveryId "
                            + " inner join XM_OrderInfo "
                            + " on XM_Delivery.OrderCode = XM_OrderInfo.OrderCode "
                            + " inner join XM_Nick "
                            + " on XM_OrderInfo.NickID = XM_Nick.nick_id "
                            + " where XM_Delivery.IsEnabled=0 and XM_Delivery_Details.IsEnabled=0 and XM_OrderInfo.IsEnable=0 "
                            + " and XM_Delivery_Details.PlatformMerchantCode like '%" + manufacturersCode + "%' "
                            + " and (XM_Delivery.LogisticsNumber like '%" + logisticsNumber + "%' or  XM_Delivery.LogisticsNumber is null)"
                            + " and XM_Delivery.DeliveryNumber like '%" + deliveryno + "%' "
                            + " and (" + DeliveryTypeId + "=-1 or XM_Delivery.DeliveryTypeId =" + DeliveryTypeId + ") "
                            + " and XM_Delivery.FullName like '%" + FullName + "%' "
                            + " and XM_Delivery.Mobile like '%" + MobileAndTel + "%' "
                            + " and XM_Delivery.DeliveryAddress like '%" + DeliveryAddress + "%' "
                            //+ " and XM_Delivery.IsDelivery=" + IsDelivery + " "//去掉未发货才能导出的限制
                            + " and (" + ddXMProject + " = -1 or " + ddXMProject + " = 99 or XM_Nick.ProjectId=" + ddXMProject + ") "
                            + " and (" + printbatch + " = -1 or XM_Delivery.PrintBatch = " + printbatch + ")"
                            + " and (" + Shipper + " = -1 or XM_Delivery.Shipper =" + Shipper + ")"
                            + " and (" + Nick + " = -1 or " + Nick + " = 99 or XM_OrderInfo.NickID = " + Nick + ") "
                            + " and (('" + PrintBegin + "'='' and '" + PrintEnd + "'='') or (XM_Delivery.PrintDateTime>='" + PrintBegin + "' and XM_Delivery.PrintDateTime<'" + PrintEnd + "')) "
                            + " and (('" + CreateBegin + "'='' and '" + CreateEnd + "'='') or (XM_Delivery.CreateDate>='" + CreateBegin + "' and XM_Delivery.CreateDate<'" + CreateEnd + "')) "
                            + " and XM_Delivery.OrderCode like '%" + ordercode + "%' ";
            var queryFalse = this._context.ExecuteStoreQuery<XMDeliveryNew>(sql);//.ToList();
            return queryFalse.ToList();
        }
    }
}
