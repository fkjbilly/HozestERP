
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageApplication;
using HozestERP.Common;
using HozestERP.BusinessLogic.ManageProtal;
using System.Data.SqlClient;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMOrderInfoService : IXMOrderInfoService
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
        public XMOrderInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMOrderInfoService成员
        /// <summary>
        /// Insert into XMOrderInfo
        /// </summary>
        /// <param name="xmorderinfo">XMOrderInfo</param>
        public void InsertXMOrderInfo(XMOrderInfo xmorderinfo)
        {
            if (xmorderinfo == null)
                return;

            if (!this._context.IsAttached(xmorderinfo))

                this._context.XMOrderInfoes.AddObject(xmorderinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMOrderInfo
        /// </summary>
        /// <param name="xmorderinfo">XMOrderInfo</param>
        public void UpdateXMOrderInfo(XMOrderInfo xmorderinfo)
        {
            if (xmorderinfo == null)
                return;

            if (this._context.IsAttached(xmorderinfo))
                this._context.XMOrderInfoes.Attach(xmorderinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMOrderInfo list
        /// </summary>
        public List<XMOrderInfo> GetXMOrderInfoList()
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }


        public List<XMOrderInfo> GetXMOrderInfoListBySingleRow(List<XMOrderInfo> list, int SingleRow, string ManufacturersCode,int CodeContain)
        {
            #region 先过滤掉没有无订单产品信息的数据
            var orderInfoIdList = list.Select(m => (int?)m.ID).ToList();//得到所有的订单ID

            IEnumerable<XMOrderInfoProductDetails> query2;

            query2 = from q in this._context.XMOrderInfoProductDetails
                    where orderInfoIdList.Contains(q.OrderInfoID)
                    select q;

            var ProductArray = query2.ToArray();//产品详细

            var orderInfoProductIdList = ProductArray.GroupBy(m => m.OrderInfoID).Select(m => m.Key).ToList();//有物品详情的订单ID

            var ids = orderInfoIdList.Intersect(orderInfoProductIdList).ToList();

            list = list.Where(m => ids.Contains(m.ID)).ToList();
            #endregion
            if (SingleRow == -1 && ManufacturersCode == "")
            {
                return list;
            }
            else
            {
                IEnumerable<XMOrderInfo> MList= null;
                if (ManufacturersCode != "")
                {
                    var lists = ManufacturersCode.Split(new string[] { ","}, StringSplitOptions.RemoveEmptyEntries);
                    if (CodeContain==1)
                    {
                        MList = from p in list
                                join q in this._context.XMOrderInfoProductDetails
                                on p.ID equals q.OrderInfoID
                                where p.IsEnable == false
                                && q.IsEnable == false
                                && lists.Contains(q.TManufacturersCode)
                                select p;

                    }
                    else if(CodeContain == 0)
                    {
                        MList = from p in list
                                join q in this._context.XMOrderInfoProductDetails
                                on p.ID equals q.OrderInfoID
                                where p.IsEnable == false
                                && q.IsEnable == false
                                && !lists.Contains(q.TManufacturersCode)
                                select p;
                    }
                }
                else
                {
                    MList = list;
                }


                if (SingleRow == -1)
                {
                    return MList.Distinct().ToList();
                }
                else
                {
                    IEnumerable<XMOrderInfo> query1;
                    
                    query1 = from p in MList
                             where p.IsEnable == false
                             select p;
                    var MListArray = query1.ToArray();
                 
                    var ProductDetailsArray = ProductArray.Where(q=>q.IsEnable == false).ToArray();//根据获取到的XMOrderInfo中的数据的ID过滤获取XMOrderInfoProductDetails的数据

                    IEnumerable <XMOrderInfo> query;
                    if (SingleRow == 1)//已排单
                    {
                        var SingleRowOrderInfoids = ProductDetailsArray.GroupBy(m=>m.OrderInfoID).Select(m=>new {
                            OrderInfoID = m.Key,
                            NoSingleRows = m.Select(s=>s.IsSingleRow).Where(s => s == null  || s == false).Count()//判断一个订单中的未排单货物数量
                        }).Where(m=>m.NoSingleRows == 0).Select(m=>m.OrderInfoID).ToList();//获取订单中所有物品都已排单的订单号

                        var SingleIDArray = MListArray.Join(ProductDetailsArray.Where(m=>SingleRowOrderInfoids.Contains(m.OrderInfoID)), s => s.ID, s => s.OrderInfoID, (s, s1) => new
                        {
                            s.NickID,
                            s.ID,
                            s1.PlatformMerchantCode
                        }).Where(m=>m.NickID != 32 || (m.NickID == 32 && m.PlatformMerchantCode.StartsWith("CM"))).Select(m=>m.ID).Distinct().ToList();

                        query = MListArray.Where(m => SingleIDArray.Contains(m.ID)).AsEnumerable();

                        //var dd = from p in MList
                        //        join q in this._context.XMOrderInfoProductDetails
                        //        on p.ID equals q.OrderInfoID
                        //        where p.IsEnable == false
                        //        && q.IsEnable == false
                        //        && q.IsSingleRow == true
                        //        && (p.NickID != 32
                        //        || (p.NickID == 32 && q.PlatformMerchantCode.StartsWith("CM")))
                        //        select p;
                    }
                    else if (SingleRow == 2)//部分排单
                    {

                        var SomeSingleRowOrderInfoids = ProductDetailsArray.GroupBy(m => m.OrderInfoID).Select(m => new {
                            OrderInfoID = m.Key,
                            SingleRows = m.Select(s => s.IsSingleRow).Where(s => s == true).Count(),//判断一个订单中的排单货物数量
                            NoSingleRows = m.Select(s => s.IsSingleRow).Where(s => s == null || s == false).Count()//判断一个订单中的未排单货物数量
                        }).Where(m => m.NoSingleRows > 0 && m.SingleRows > 0).Select(m => m.OrderInfoID).ToList();//获取订单中所有物品都已排单的订单号

                        var SingleIDArray = MListArray.Join(ProductDetailsArray.Where(m => SomeSingleRowOrderInfoids.Contains(m.OrderInfoID)), s => s.ID, s => s.OrderInfoID, (s, s1) => new
                        {
                            s.NickID,
                            s.ID,
                            s1.ProductName,
                            s1.PlatformMerchantCode
                        }).Where(m => (m.NickID != 32 || (m.NickID == 32 && m.PlatformMerchantCode.StartsWith("CM"))) && (!m.ProductName.Contains("床笠") && !m.ProductName.Contains("运费") && !m.ProductName.Contains("邮费"))).Select(m => m.ID).ToList();

                        query = MListArray.Where(m => SingleIDArray.Contains(m.ID)).AsEnumerable();
                        //query = from p in MList
                        //        join q in this._context.XMOrderInfoProductDetails
                        //        on p.ID equals q.OrderInfoID
                        //        where p.IsEnable == false
                        //        && q.IsEnable == false
                        //        && q.IsSingleRow == true
                        //        && (p.NickID != 32
                        //        || (p.NickID == 32 && q.PlatformMerchantCode.StartsWith("CM")))
                        //        && (!q.ProductName.Contains("床笠") && !q.ProductName.Contains("运费") && !q.ProductName.Contains("邮费"))
                        //        select p;

                        //query = from p in query
                        //        join q in this._context.XMOrderInfoProductDetails
                        //        on p.ID equals q.OrderInfoID
                        //        where p.IsEnable == false
                        //        && q.IsEnable == false
                        //        && (q.IsSingleRow == null || q.IsSingleRow == false)
                        //        && (p.NickID != 32
                        //        || (p.NickID == 32 && q.PlatformMerchantCode.StartsWith("CM")))
                        //        && (!q.ProductName.Contains("床笠") && !q.ProductName.Contains("运费") && !q.ProductName.Contains("邮费"))
                        //        select p;
                    }
                    else//未排单
                    {
                        var SingleRowOrderInfoids = ProductDetailsArray.GroupBy(m => m.OrderInfoID).Select(m => new {
                            OrderInfoID = m.Key,
                            RowsCount = m.Select(s => s.IsSingleRow).Count(),
                            SingleRows = m.Select(s => s.IsSingleRow).Where(s => s == null || s == false).Count(),//判断一个订单中的排单货物数量
                        }).Where(m => m.RowsCount == m.SingleRows ).Select(m => m.OrderInfoID).ToList();//获取订单中所有物品都未排单的订单号

                        var SingleIDArray = MListArray.Join(ProductDetailsArray.Where(m => SingleRowOrderInfoids.Contains(m.OrderInfoID)), s => s.ID, s => s.OrderInfoID, (s, s1) => new
                        {
                            s.NickID,
                            s.ID,
                            s1.ProductName,
                            s1.PlatformMerchantCode
                        }).Where(m => m.NickID != 32 || (m.NickID == 32 && m.PlatformMerchantCode.StartsWith("CM"))).Select(m => m.ID).ToList();

                        query = MListArray.Where(m => SingleIDArray.Contains(m.ID)).AsEnumerable();
                        //query = from p in MList
                        //        join q in this._context.XMOrderInfoProductDetails
                        //        on p.ID equals q.OrderInfoID
                        //        where p.IsEnable == false
                        //        && q.IsEnable == false
                        //        && (q.IsSingleRow == null || q.IsSingleRow == false)
                        //        && (p.NickID != 32
                        //        || (p.NickID == 32 && q.PlatformMerchantCode.StartsWith("CM")))
                        //        select p;
                    }
                    return query.Distinct().ToList();
                }
            }
        }

        public List<int> GetVPHXMOrderInfoListByDateTime(DateTime Begin, DateTime End)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.IsEnable == false
                        && p.IsOurOrder == true
                        && p.PlatformTypeId == 259//唯品会
                        && p.CreateDate >= Begin
                        && p.CreateDate < End
                            //&& p.OrderCode == "16051517565159"
                        && p.OrderStatus == "22"//已发货
                        select p.ID;
            return query.ToList();
        }

        public List<XMOrderInfo> GetXMOrderInfoListByFullNameAndPlatformMerchantCode(string fullName, string[] platformMerchantCode)
        {
            string[] orderStatus = { "LOCKED", "TRADE_CANCELED"}; //京东订单状态

            var query = from p in _context.XMOrderInfoes
                        join m in _context.XMOrderInfoProductDetails
                        on p.ID equals m.OrderInfoID
                        join a in _context.XMProductDetails
                        on m.PlatformMerchantCode equals a.PlatformMerchantCode
                        join b in _context.XMProducts
                        on a.ProductId equals b.Id
                        where p.FullName== fullName && platformMerchantCode.Contains(b.ManufacturersCode)
                        && !(bool)p.IsEnable && !(bool)m.IsEnable && (!(bool)m.IsSingleRow||m.IsSingleRow==null) &&p.CustomerServiceRemark.IndexOf("等通知")<0
                        && !orderStatus.Contains(p.OrderStatus)
                        select p;

            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <param name="type">1 一般订单 2 京东订单</param>
        /// <returns></returns>
        public List<XMOrderInfoNew> getXMOrderInfoListByOrderCode(string OrderCode,int type)
        {
            switch(type)
            {
                case 1:
                    var query = from p in this._context.XMOrderInfoes
                                where p.IsEnable == false
                                && p.OrderCode.Contains(OrderCode)
                                select new XMOrderInfoNew
                                {
                                    Mobile = p.Mobile,
                                    OrderCode = p.OrderCode,
                                    PlatformTypeId = p.PlatformTypeId,
                                    NickID = p.NickID,
                                    FullName = p.FullName
                                };
                    return query.ToList();

                case 2:
                    var query1 = from p in _context.XMPurchases
                                join m in
                                (from a in _context.XMPurchaseProductDetails
                                 join b in _context.XMProducts
                                 on a.ProductId equals b.Id into temp
                                 from a_temp in temp.DefaultIfEmpty()
                                 select new
                                 {
                                     PurchaseID = a.PurchaseId,
                                     NickID = a_temp.NickId,
                                     PlatformTypeId = a.PlatformTypeId
                                 }) on p.Id equals m.PurchaseID into temp1
                                from p_temp1 in temp1.DefaultIfEmpty()
                                where p.PurchaseNumber== OrderCode && p_temp1.NickID!=null
                                 group new {p.Tel,p.PurchaseNumber, p_temp1 .PlatformTypeId, p_temp1 .NickID,p.Contact}
                                by new { p.Tel, p.PurchaseNumber, p_temp1.PlatformTypeId, p_temp1.NickID, p.Contact } into g
                                 select new XMOrderInfoNew
                                {
                                    Mobile=g.Key.Tel,
                                    OrderCode=g.Key.PurchaseNumber,
                                    PlatformTypeId= g.Key.PlatformTypeId,
                                    NickID= g.Key.NickID,
                                    FullName= g.Key.Contact
                                 };
                    return query1.ToList();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 用于安装单输入订单号提示
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public List<XMOrderInfoNew> getXMOrderInfoListByOrderCodeForXMInstallationList(string OrderCode)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.IsEnable == false
                        && p.OrderCode.Contains(OrderCode)
                        select new XMOrderInfoNew
                        {
                            Mobile = p.Mobile,
                            OrderCode = p.OrderCode,
                            WantID = p.WantID,
                            NickID = p.NickID,
                            FullName = p.FullName,
                            DeliveryAddress = p.DeliveryAddress
                        };
            return query.ToList();
        }

        /// <summary>
        /// 获得静默统计列表
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public List<XMOrderInfo> GetJingMoTongJiByParm(string Name, DateTime StartDate, DateTime EndDate)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.IsEnable == false
                        && p.CustomerServiceRemark.Contains("客服 " + Name + "/静默")
                        && p.OrderInfoCreateDate >= StartDate
                        && p.OrderInfoCreateDate <= EndDate
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="PlatformTypeId"></param>
        /// <param name="nickIds"></param>
        /// <returns></returns>
        public List<XMOrderInfo> GetCustomerSaleMoneyParm(int CustomerId, DateTime StartDate, DateTime EndDate, int PlatformTypeId, List<int> nickIds)
        {
            string[] DeliveryStatue = { "TRADE_CLOSED", "TRADE_CANCELED", "STATUS_97", "ORDER_CANCEL",
                                  "已取消", "40" };
            var query = from p in this._context.XMOrderInfoes
                        join n in this._context.XMNicks
                          on p.NickID equals n.nick_id
                        where p.IsEnable == false
                        && n.isEnable == true
                        && nickIds.Contains(p.NickID.Value)
                        && (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && p.IsOurOrder == true
                        && p.PayDate >= StartDate
                        && p.PayDate < EndDate
                        && p.BelongsServiceId == CustomerId
                        && !DeliveryStatue.Contains(p.OrderStatus)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 订单审核通过
        /// </summary>
        /// <returns></returns>
        public List<XMOrderInfo> GetXMOrderInfoListByDetails(List<int> NickId)
        {

            var query = from p in this._context.XMOrderInfoes
                        join c in this._context.XMOrderInfoProductDetails
                        on p.ID equals c.OrderInfoID
                        where c.IsAudit == true
                        && (c.IsSingleRow != true || c.IsSingleRow == null)
                        && NickId.Contains(p.NickID.Value)
                        select p;
            return query.ToList();
        }

        public List<XMOrderInfo> GetXMOrderListByParm(int ProjectId, int NickId, int PlatformTypeId)
        {
            string[] DeliveryStatue = { "WAIT_SELLER_SEND_GOODS", "DS_WAIT_SELLER_DELIVERY", "WAIT_SELLER_DELIVERY", "WAIT_SELLER_STOCK_OUT",
                                  "STATUS_10", "ORDER_TRUNED_TO_DO", "以接受", "10", "已付款" };

            DateTime begin = DateTime.Parse(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
            DateTime end = begin.AddDays(1);
            string appointDeliveryTime1 = begin.Month.ToString() + "月" + begin.Day.ToString() + "日当天发";
            string appointDeliveryTime2 = begin.Month.ToString() + "月" + begin.Day.ToString() + "号当天发";

            DateTime date = DateTime.Parse("2016-06-30 00:00:00");
            List<int?> nickList = new List<int?>();

            var NickList = from p in this._context.XMNicks
                           where p.isEnable == true
                           && p.ProjectId == ProjectId
                           select p.nick_id;

            foreach (int item in NickList)
            {
                nickList.Add(item);
            }

            var query = from p in this._context.XMOrderInfoes
                        join q in this._context.XMOrderInfoProductDetails
                        on p.ID equals q.OrderInfoID
                        join n in this._context.XMNicks
                        on p.NickID equals n.nick_id
                        where p.IsEnable == false
                        && q.IsEnable == false
                        && n.isEnable == true
                        && (ProjectId == -1 || nickList.Contains(p.NickID))
                        && (NickId == -1 || NickId == 99 || p.NickID == NickId)
                        && (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && p.IsOurOrder == true
                        && p.IsAudit == true
                        && p.CreateDate > date
                        && DeliveryStatue.Contains(p.OrderStatus)
                        && (p.CustomerServiceRemark.IndexOf("/能发就发") != -1
                           || p.CustomerServiceRemark.IndexOf("/加急") != -1
                           || p.CustomerServiceRemark.IndexOf(appointDeliveryTime1) != -1
                           || p.CustomerServiceRemark.IndexOf(appointDeliveryTime2) != -1
                           || (p.AppointDeliveryTime != null
                               && p.AppointDeliveryTime >= begin
                               && p.AppointDeliveryTime < end))
                            //&& p.FinancialAudit == true
                        && (q.IsSingleRow == false || q.IsSingleRow == null)
                        && q.IsAudit == true
                        && n.ProjectId == 2
                        select p;
            return query.ToList().Distinct().ToList();
        }

        /// <summary>
        /// 根据订单号查询
        /// </summary>
        public List<XMOrderInfo> GetXMOrderInfoListByOrderEqs(string ordercode)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.OrderCode.Equals(ordercode)
                         && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        public List<XMOrderInfo> GetXMOrderInfoListByDeliveryTime(DateTime Begin, DateTime End)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.IsEnable == false
                        && p.DeliveryTime != null
                        && p.DeliveryTime >= Begin
                        && p.DeliveryTime < End
                        && p.FinancialAudit == true
                        && (p.IsScalping == false || p.IsScalping == null)
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// 查找再途库存明细
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        public List<XMOrderInfoProductDetails> GetrderInfoProductDetailsListNotShipped(DateTime Begin, DateTime End)
        {
            List<string> zt = new List<string> {"WAIT_BUYER_CONFIRM_GOODS"//天猫选取5状态订单
            , "WAIT_GOODS_RECEIVE_CONFIRM"//京东4状态订单
            , "DS_WAIT_BUYER_RECEIVE"//拍拍选取3
            , "STATUS_22"//唯品会选取5
            , "ORDER_OUT_OF_WH"//1号店选取4
            , "已发货"//亚马逊选取3
            , "20"};//苏宁易购选取2
            DateTime srarttime = DateTime.Parse("2017-01-01 00:00:00");//默认2017年之后的订单
            var query = from p in this._context.XMOrderInfoes
                        join op in this._context.XMOrderInfoProductDetails
                        on p.ID equals op.OrderInfoID
                        where p.IsEnable == false
                        && p.DeliveryTime != null
                        && p.DeliveryTime >= srarttime
                        && p.DeliveryTime < Begin
                        && p.CompletionTime == null
                        && p.FinancialAudit == true
                        && (p.IsScalping == false || p.IsScalping == null)
                        && zt.Contains(p.OrderStatus)
                        select op;
            return query.ToList();
        }

        /// <summary>
        /// 9.9大礼包
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="NickID"></param>
        /// <returns></returns>
        public List<XMOrderInfo> GetXMOrderInfoListByCreateDateNickID(DateTime Begin, int NickID)
        {
            var query = from p in this._context.XMOrderInfoes
                        join q in this._context.XMOrderInfoProductDetails
                        on p.ID equals q.OrderInfoID
                        where p.IsEnable == false
                        && p.CreateDate != null
                        && p.CreateDate >= Begin
                        && p.NickID == NickID
                        && q.PlatformMerchantCode == "10628752419"//9.9大礼包
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 查询订单明细
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型</param>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        public List<OrderInfoSalesDetails> getXMOrderInfoList(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId, string ManufacturersCode)
        {
            IQueryable<OrderInfoSalesDetails> query = null;
            List<string> zt = new List<string> {  "WAIT_SELLER_SEND_GOODS",  "SELLER_CONSIGNED_PART", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_BUYER_SIGNED", "TRADE_FINISHED"//天猫
           ,"WAIT_SELLER_DELIVERY", "WAIT_SELLER_STOCK_OUT","SEND_TO_DISTRIBUTION_CENER", "DISTRIBUTION_CENTER_RECEIVED", "WAIT_GOODS_RECEIVE_CONFIRM","FINISHED_L"//京东
            , "DS_WAIT_SELLER_DELIVERY", "DS_WAIT_BUYER_RECEIVE", "DS_DEAL_END_NORMAL"//拍拍
            , "1", "10", "22", "25"//唯品会
            , "ORDER_PAYED", "ORDER_TRUNED_TO_DO", "ORDER_OUT_OF_WH", "ORDER_RECEIVED", "ORDER_FINISH"//1号店
            , "以接受", "已发货"//亚马逊
            , "10", "20","21", "30"//苏宁易
            ,"已付款","已发货","已完成"//通用状态
            };

            #region 创单时间
            if (OrderStatusId == 1)//创单时间 （必要条件：未删除、排除刷单数据）
            {
                query = from b in this._context.XMOrderInfoes
                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.OrderInfoCreateDate >= OrderInfoModifiedStart && b.OrderInfoCreateDate < OrderInfoModifiedEnd))
                        && zt.Contains(b.OrderStatus)
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            PlatformTypeId = b.PlatformTypeId,
                            NickID = b.NickID,
                            OrderCode = b.OrderCode,
                            WantID = b.WantID,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            PayDate = b.PayDate,
                            DeliveryTime = b.DeliveryTime,
                            CompletionTime = b.CompletionTime,
                            FullName = b.FullName,
                            Mobile = b.Mobile,
                            Tel = b.Tel,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            PayPrice = b.PayPrice,
                            SalesPrice = 0,
                            ProjectId = 0,
                            ProjectName = "",
                            PlatformTypeName = "",
                            NickName = "",
                            MarkDate = b.OrderInfoCreateDate
                        };

            }
            #endregion

            #region 付款时间
            if (OrderStatusId == 2)//付款时间 （必要条件：未删除、排除刷单数据）
            {
                query = from b in this._context.XMOrderInfoes
                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.PayDate >= OrderInfoModifiedStart && b.PayDate < OrderInfoModifiedEnd))
                        && zt.Contains(b.OrderStatus)
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            PlatformTypeId = b.PlatformTypeId,
                            NickID = b.NickID,
                            OrderCode = b.OrderCode,
                            WantID = b.WantID,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            PayDate = b.PayDate,
                            DeliveryTime = b.DeliveryTime,
                            CompletionTime = b.CompletionTime,
                            FullName = b.FullName,
                            Mobile = b.Mobile,
                            Tel = b.Tel,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            PayPrice = b.PayPrice,
                            SalesPrice = 0,
                            ProjectId = 0,
                            ProjectName = "",
                            PlatformTypeName = "",
                            NickName = "",
                            MarkDate = b.PayDate
                        };

            }
            #endregion

            #region 发货时间
            if (OrderStatusId == 3)//发货时间 （必要条件：未删除、排除刷单数据）发货时间只选择订单状态为发货或者完成的订单
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
                query = from b in this._context.XMOrderInfoes
                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.DeliveryTime >= OrderInfoModifiedStart && b.DeliveryTime < OrderInfoModifiedEnd))
                        && ztstatus.Contains(b.OrderStatus)
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            PlatformTypeId = b.PlatformTypeId,
                            NickID = b.NickID,
                            OrderCode = b.OrderCode,
                            WantID = b.WantID,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            PayDate = b.PayDate,
                            DeliveryTime = b.DeliveryTime,
                            CompletionTime = b.CompletionTime,
                            FullName = b.FullName,
                            Mobile = b.Mobile,
                            Tel = b.Tel,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            PayPrice = b.PayPrice,
                            SalesPrice = 0,
                            ProjectId = 0,
                            ProjectName = "",
                            PlatformTypeName = "",
                            NickName = "",
                            MarkDate = b.DeliveryTime
                        };

            }
            #endregion

            #region 完成时间
            if (OrderStatusId == 4)//完成时间 （必要条件：未删除、排除刷单数据）交易完成时间只选择订单状态为完成的订单
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
                query = from b in this._context.XMOrderInfoes
                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.CompletionTime >= OrderInfoModifiedStart && b.CompletionTime < OrderInfoModifiedEnd))
                        && zt.Contains(b.OrderStatus)
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            PlatformTypeId = b.PlatformTypeId,
                            NickID = b.NickID,
                            OrderCode = b.OrderCode,
                            WantID = b.WantID,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            PayDate = b.PayDate,
                            DeliveryTime = b.DeliveryTime,
                            CompletionTime = b.CompletionTime,
                            FullName = b.FullName,
                            Mobile = b.Mobile,
                            Tel = b.Tel,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            PayPrice = b.PayPrice,
                            SalesPrice = 0,
                            ProjectId = 0,
                            ProjectName = "",
                            PlatformTypeName = "",
                            NickName = "",
                            MarkDate = b.CompletionTime
                        };

            }
            #endregion

            query = from p in query
                    join d in this._context.XMNicks on p.NickID equals d.nick_id
                    into cJoin
                    from cInfo in cJoin.DefaultIfEmpty()
                    where cInfo.isEnable == true
                    && p.NickID != 29
                    select new OrderInfoSalesDetails
                    {
                        ID = p.ID,
                        PlatformTypeId = p.PlatformTypeId,
                        NickID = p.NickID,
                        OrderCode = p.OrderCode,
                        WantID = p.WantID,
                        OrderInfoCreateDate = p.OrderInfoCreateDate,
                        PayDate = p.PayDate,
                        DeliveryTime = p.DeliveryTime,
                        CompletionTime = p.CompletionTime,
                        FullName = p.FullName,
                        Mobile = p.Mobile,
                        Tel = p.Tel,
                        DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                        ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                        PayPrice = p.PayPrice,
                        SalesPrice = 0,
                        ProjectId = cInfo.ProjectId,
                        ProjectName = "",
                        PlatformTypeName = "",
                        NickName = cInfo.nick,
                        MarkDate = p.MarkDate
                    };


            query = from p in query
                    join d in this._context.XMProjects on p.ProjectId equals d.Id
                    into cJoin
                    from cInfo in cJoin.DefaultIfEmpty()
                    where cInfo.IsEnable == true
                    select new OrderInfoSalesDetails
                    {
                        ID = p.ID,
                        PlatformTypeId = p.PlatformTypeId,
                        NickID = p.NickID,
                        OrderCode = p.OrderCode,
                        WantID = p.WantID,
                        OrderInfoCreateDate = p.OrderInfoCreateDate,
                        PayDate = p.PayDate,
                        DeliveryTime = p.DeliveryTime,
                        CompletionTime = p.CompletionTime,
                        FullName = p.FullName,
                        Mobile = p.Mobile,
                        Tel = p.Tel,
                        DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                        ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                        PayPrice = p.PayPrice,
                        SalesPrice = 0,
                        ProjectId = p.ProjectId,
                        ProjectName = cInfo.ProjectName,
                        PlatformTypeName = "",
                        NickName = p.NickName,
                        MarkDate = p.MarkDate
                    };
            query = from p in query
                    join d in this._context.CodeLists on p.PlatformTypeId equals d.CodeID
                    into cJoin
                    from cInfo in cJoin.DefaultIfEmpty()
                    where cInfo.Deleted == false
                    orderby p.OrderInfoCreateDate
                    select new OrderInfoSalesDetails
                    {
                        ID = p.ID,
                        PlatformTypeId = p.PlatformTypeId,
                        NickID = p.NickID,
                        OrderCode = p.OrderCode,
                        WantID = p.WantID,
                        OrderInfoCreateDate = p.OrderInfoCreateDate,
                        PayDate = p.PayDate,
                        DeliveryTime = p.DeliveryTime,
                        CompletionTime = p.CompletionTime,
                        FullName = p.FullName,
                        Mobile = p.Mobile,
                        Tel = p.Tel,
                        DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                        ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                        PayPrice = p.PlatformTypeId == 251 ? (p.PayPrice + p.DistributePrice) : p.PayPrice,
                        SalesPrice = 0,
                        ProjectId = p.ProjectId,
                        ProjectName = p.ProjectName,
                        PlatformTypeName = cInfo.CodeName,
                        NickName = p.NickName,
                        MarkDate = p.MarkDate
                    };

            //筛选呼噜噜订单
            query = from p in query
                    join c in this._context.XMOrderInfoProductDetails
                    on p.ID equals c.OrderInfoID
                    into JoinedEmpDept
                    from c in JoinedEmpDept.DefaultIfEmpty()
                    where (p.NickID == 32 && (c == null || c.PlatformMerchantCode == null || c.PlatformMerchantCode == "" || c.PlatformMerchantCode.StartsWith("CM")))
                    || p.NickID != 32
                    select p;

            return new List<OrderInfoSalesDetails>(query.Distinct().ToList());
        }

        /// <summary>
        /// 查询订单明细
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型</param>
        /// <param name="ManufacturersCode">厂家编码</param>
        /// <returns></returns>
        public List<OrderInfoSalesDetails> getXMOrderInfoListToExport(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId, string ManufacturersCode)
        {
            IQueryable<OrderInfoSalesDetails> query = null;
            List<string> zt = new List<string> {  "WAIT_SELLER_SEND_GOODS",  "SELLER_CONSIGNED_PART", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_BUYER_SIGNED", "TRADE_FINISHED"//天猫
           ,"WAIT_SELLER_DELIVERY", "WAIT_SELLER_STOCK_OUT","SEND_TO_DISTRIBUTION_CENER", "DISTRIBUTION_CENTER_RECEIVED", "WAIT_GOODS_RECEIVE_CONFIRM","FINISHED_L"//京东
            , "DS_WAIT_SELLER_DELIVERY", "DS_WAIT_BUYER_RECEIVE", "DS_DEAL_END_NORMAL"//拍拍
            , "1", "10", "22", "25"//唯品会
            , "ORDER_PAYED", "ORDER_TRUNED_TO_DO", "ORDER_OUT_OF_WH", "ORDER_RECEIVED", "ORDER_FINISH"//1号店
            , "以接受", "已发货"//亚马逊
            , "10", "20","21", "30"//苏宁易
            ,"已付款","已发货","已完成"//通用状态
            };

            #region 创单时间
            if (OrderStatusId == 1)//创单时间 （必要条件：未删除、排除刷单数据）
            {
                query = from b in this._context.XMOrderInfoes
                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.OrderInfoCreateDate >= OrderInfoModifiedStart && b.OrderInfoCreateDate < OrderInfoModifiedEnd))
                        && zt.Contains(b.OrderStatus)
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            PlatformTypeId = b.PlatformTypeId,
                            NickID = b.NickID,
                            OrderCode = b.OrderCode,
                            WantID = b.WantID,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            PayDate = b.PayDate,
                            DeliveryTime = b.DeliveryTime,
                            CompletionTime = b.CompletionTime,
                            FullName = b.FullName,
                            Mobile = b.Mobile,
                            Tel = b.Tel,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            PayPrice = b.PayPrice,
                            SalesPrice = 0,
                            ProjectId = 0,
                            ProjectName = "",
                            PlatformTypeName = "",
                            NickName = "",
                            MarkDate = b.OrderInfoCreateDate
                        };

            }
            #endregion

            #region 付款时间
            if (OrderStatusId == 2)//付款时间 （必要条件：未删除、排除刷单数据）
            {
                query = from b in this._context.XMOrderInfoes
                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.PayDate >= OrderInfoModifiedStart && b.PayDate < OrderInfoModifiedEnd))
                        && zt.Contains(b.OrderStatus)
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            PlatformTypeId = b.PlatformTypeId,
                            NickID = b.NickID,
                            OrderCode = b.OrderCode,
                            WantID = b.WantID,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            PayDate = b.PayDate,
                            DeliveryTime = b.DeliveryTime,
                            CompletionTime = b.CompletionTime,
                            FullName = b.FullName,
                            Mobile = b.Mobile,
                            Tel = b.Tel,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            PayPrice = b.PayPrice,
                            SalesPrice = 0,
                            ProjectId = 0,
                            ProjectName = "",
                            PlatformTypeName = "",
                            NickName = "",
                            MarkDate = b.PayDate
                        };

            }
            #endregion

            #region 发货时间
            if (OrderStatusId == 3)//发货时间 （必要条件：未删除、排除刷单数据）发货时间只选择订单状态为发货或者完成的订单
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
                query = from b in this._context.XMOrderInfoes
                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.DeliveryTime >= OrderInfoModifiedStart && b.DeliveryTime < OrderInfoModifiedEnd))
                        && ztstatus.Contains(b.OrderStatus)
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            PlatformTypeId = b.PlatformTypeId,
                            NickID = b.NickID,
                            OrderCode = b.OrderCode,
                            WantID = b.WantID,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            PayDate = b.PayDate,
                            DeliveryTime = b.DeliveryTime,
                            CompletionTime = b.CompletionTime,
                            FullName = b.FullName,
                            Mobile = b.Mobile,
                            Tel = b.Tel,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            PayPrice = b.PayPrice,
                            SalesPrice = 0,
                            ProjectId = 0,
                            ProjectName = "",
                            PlatformTypeName = "",
                            NickName = "",
                            MarkDate = b.DeliveryTime
                        };

            }
            #endregion

            #region 完成时间
            if (OrderStatusId == 4)//完成时间 （必要条件：未删除、排除刷单数据）交易完成时间只选择订单状态为完成的订单
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
                query = from b in this._context.XMOrderInfoes
                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && b.FinancialAudit == true
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.CompletionTime >= OrderInfoModifiedStart && b.CompletionTime < OrderInfoModifiedEnd))
                        && zt.Contains(b.OrderStatus)
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            PlatformTypeId = b.PlatformTypeId,
                            NickID = b.NickID,
                            OrderCode = b.OrderCode,
                            WantID = b.WantID,
                            OrderInfoCreateDate = b.OrderInfoCreateDate,
                            PayDate = b.PayDate,
                            DeliveryTime = b.DeliveryTime,
                            CompletionTime = b.CompletionTime,
                            FullName = b.FullName,
                            Mobile = b.Mobile,
                            Tel = b.Tel,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            PayPrice = b.PayPrice,
                            SalesPrice = 0,
                            ProjectId = 0,
                            ProjectName = "",
                            PlatformTypeName = "",
                            NickName = "",
                            MarkDate = b.CompletionTime
                        };

            }
            #endregion

            query = from p in query
                    join d in this._context.XMNicks on p.NickID equals d.nick_id
                    into cJoin
                    from cInfo in cJoin.DefaultIfEmpty()
                    where cInfo.isEnable == true
                    && p.NickID != 29
                    select new OrderInfoSalesDetails
                    {
                        ID = p.ID,
                        PlatformTypeId = p.PlatformTypeId,
                        NickID = p.NickID,
                        OrderCode = p.OrderCode,
                        WantID = p.WantID,
                        OrderInfoCreateDate = p.OrderInfoCreateDate,
                        PayDate = p.PayDate,
                        DeliveryTime = p.DeliveryTime,
                        CompletionTime = p.CompletionTime,
                        FullName = p.FullName,
                        Mobile = p.Mobile,
                        Tel = p.Tel,
                        DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                        ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                        PayPrice = p.PayPrice,
                        SalesPrice = 0,
                        ProjectId = cInfo.ProjectId,
                        ProjectName = "",
                        PlatformTypeName = "",
                        NickName = cInfo.nick,
                        MarkDate = p.MarkDate
                    };


            query = from p in query
                    join d in this._context.XMProjects on p.ProjectId equals d.Id
                    into cJoin
                    from cInfo in cJoin.DefaultIfEmpty()
                    where cInfo.IsEnable == true
                    select new OrderInfoSalesDetails
                    {
                        ID = p.ID,
                        PlatformTypeId = p.PlatformTypeId,
                        NickID = p.NickID,
                        OrderCode = p.OrderCode,
                        WantID = p.WantID,
                        OrderInfoCreateDate = p.OrderInfoCreateDate,
                        PayDate = p.PayDate,
                        DeliveryTime = p.DeliveryTime,
                        CompletionTime = p.CompletionTime,
                        FullName = p.FullName,
                        Mobile = p.Mobile,
                        Tel = p.Tel,
                        DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                        ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                        PayPrice = p.PayPrice,
                        SalesPrice = 0,
                        ProjectId = p.ProjectId,
                        ProjectName = cInfo.ProjectName,
                        PlatformTypeName = "",
                        NickName = p.NickName,
                        MarkDate = p.MarkDate
                    };
            query = from p in query
                    join d in this._context.CodeLists on p.PlatformTypeId equals d.CodeID
                    into cJoin
                    from cInfo in cJoin.DefaultIfEmpty()
                    where cInfo.Deleted == false
                    orderby p.OrderInfoCreateDate
                    select new OrderInfoSalesDetails
                    {
                        ID = p.ID,
                        PlatformTypeId = p.PlatformTypeId,
                        NickID = p.NickID,
                        OrderCode = p.OrderCode,
                        WantID = p.WantID,
                        OrderInfoCreateDate = p.OrderInfoCreateDate,
                        PayDate = p.PayDate,
                        DeliveryTime = p.DeliveryTime,
                        CompletionTime = p.CompletionTime,
                        FullName = p.FullName,
                        Mobile = p.Mobile,
                        Tel = p.Tel,
                        DistributePrice = p.DistributePrice == null ? 0 : p.DistributePrice.Value,
                        ReceivablePrice = p.ReceivablePrice == null ? 0 : p.ReceivablePrice.Value,
                        PayPrice = p.PlatformTypeId == 251 ? (p.PayPrice + p.DistributePrice) : p.PayPrice,
                        SalesPrice = 0,
                        ProjectId = p.ProjectId,
                        ProjectName = p.ProjectName,
                        PlatformTypeName = cInfo.CodeName,
                        NickName = p.NickName,
                        MarkDate = p.MarkDate
                    };

            //筛选呼噜噜订单
            query = from p in query
                    join c in this._context.XMOrderInfoProductDetails
                    on p.ID equals c.OrderInfoID
                    into JoinedEmpDept
                    from c in JoinedEmpDept.DefaultIfEmpty()
                    where (p.NickID == 32 && (c == null || c.PlatformMerchantCode == null || c.PlatformMerchantCode == "" || c.PlatformMerchantCode.StartsWith("CM")))
                    || p.NickID != 32
                    select p;

            return new List<OrderInfoSalesDetails>(query.Distinct().ToList());
        }

        /// <summary>
        /// 实时平台费用（根据指定时间）
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型</param>
        /// <returns></returns>
        public List<OrderInfoSalesDetails> GetCWPlatformSpendingSearchListSSS(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId)
        {
            List<string> zt = new List<string> { "WAIT_BUYER_PAY", "WAIT_SELLER_SEND_GOODS", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_FINISHED"//天猫选取2.3.5.7状态订单
            , "WAIT_SELLER_STOCK_OUT", "WAIT_GOODS_RECEIVE_CONFIRM", "WAIT_SELLER_DELIVERY", "FINISHED_L"//京东1.4.6.7状态订单
            , "DS_WAIT_BUYER_PAY", "DS_WAIT_SELLER_DELIVERY", "DS_WAIT_BUYER_RECEIVE", "DS_DEAL_END_NORMAL"//拍拍选取全部
            , "STATUS_1", "STATUS_10", "STATUS_22", "STATUS_25"//唯品会选取2.3.5.7
            , "ORDER_WAIT_PAY", "ORDER_PAYED", "ORDER_TRUNED_TO_DO", "ORDER_OUT_OF_WH", "ORDER_RECEIVED", "ORDER_FINISH"//1号店选取1.2.3.4.5.6
            , "新", "以接受", "已发货"//亚马逊选取1.2.3
            , "10", "20", "21", "30"};//苏宁易购选取1.2.3.4
            //判断如果又完成时间的订单统计扣除点数 
            var query = from b in this._context.XMOrderInfoes
                        join n in this._context.XMNicks
                        on b.NickID equals n.nick_id
                        join d in this._context.XMDeductionSetUps
                        on new { b.PlatformTypeId, n.ProjectId } equals new { d.PlatformTypeId, d.ProjectId }
                        join c in this._context.CodeLists
                        on d.PlatformTypeId equals c.CodeID
                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.CompletionTime != null && b.CompletionTime >= OrderInfoModifiedStart && b.CompletionTime < OrderInfoModifiedEnd))
                            //&& zt.Contains(b.OrderStatus)
                        && d.SpeciesTypeId == 475
                        select new OrderInfoSalesDetails
                        {
                            ID = b.ID,
                            Remarks = c.CodeName,
                            PayPrice = ((b.PlatformTypeId == 251 ? (b.ReceivablePrice + b.DistributePrice) : b.PayPrice) * (d.Deduction == null ? 0 : d.Deduction.Value) / 100) == null ? 0 : (b.PlatformTypeId == 251 ? (b.ReceivablePrice + b.DistributePrice) : b.PayPrice) * (d.Deduction == null ? 0 : d.Deduction.Value) / 100,
                            MarkDate = b.CompletionTime
                        };

            return query.Distinct().ToList();
        }

        public List<XMOrderInfoProductDetails> getXMOrderInfoListByBrandType(List<OrderInfoSalesDetails> List, int BrandType)
        {
            var query = from q in List
                        join p in this._context.XMOrderInfoProductDetails
                        on q.ID equals p.OrderInfoID
                        join a in this._context.XMProductDetails
                        on p.PlatformMerchantCode equals a.PlatformMerchantCode
                        join b in this._context.XMProducts
                        on a.ProductId equals b.Id
                        where a.IsEnable == false
                        && b.IsEnable == false
                        && p.IsEnable == false
                        && b.BrandTypeId == BrandType
                        select p;

            return query.Distinct().ToList();
        }

        public List<OrderInfoSalesDetails> GetXMOrderInfoListByBrandType(List<OrderInfoSalesDetails> List, int BrandType)
        {
            var query = from q in List
                        join p in this._context.XMOrderInfoProductDetails
                        on q.ID equals p.OrderInfoID
                        join a in this._context.XMProductDetails
                        on p.PlatformMerchantCode equals a.PlatformMerchantCode
                        join b in this._context.XMProducts
                        on a.ProductId equals b.Id
                        where a.IsEnable == false
                        && b.IsEnable == false
                        && p.IsEnable == false
                        && b.BrandTypeId == BrandType
                        select q;
            return query.Distinct().ToList();
        }

        /// <summary>
        /// 实时平台费用（根据指定时间）详细
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型</param>
        /// <returns></returns>
        public List<OrderInfoSalesDetails> GetCWPlatformSpendingSearchListSSS2(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId)
        {
            List<string> zt = new List<string> { "WAIT_BUYER_PAY", "WAIT_SELLER_SEND_GOODS", "WAIT_BUYER_CONFIRM_GOODS", "TRADE_FINISHED"//天猫选取2.3.5.7状态订单
            , "WAIT_SELLER_STOCK_OUT", "WAIT_GOODS_RECEIVE_CONFIRM", "WAIT_SELLER_DELIVERY", "FINISHED_L"//京东1.4.6.7状态订单
            , "DS_WAIT_BUYER_PAY", "DS_WAIT_SELLER_DELIVERY", "DS_WAIT_BUYER_RECEIVE", "DS_DEAL_END_NORMAL"//拍拍选取全部
            , "STATUS_1", "STATUS_10", "STATUS_22", "STATUS_25"//唯品会选取2.3.5.7
            , "ORDER_WAIT_PAY", "ORDER_PAYED", "ORDER_TRUNED_TO_DO", "ORDER_OUT_OF_WH", "ORDER_RECEIVED", "ORDER_FINISH"//1号店选取1.2.3.4.5.6
            , "新", "以接受", "已发货"//亚马逊选取1.2.3
            , "10", "20", "21", "30"};//苏宁易购选取1.2.3.4
            //判断又完成时间的订单扣除平台点数
            var query = from b in this._context.XMOrderInfoes
                        join n in this._context.XMNicks
                        on b.NickID equals n.nick_id
                        join d in this._context.XMDeductionSetUps
                        on new { b.PlatformTypeId, n.ProjectId } equals new { d.PlatformTypeId, d.ProjectId }
                        join c in this._context.CodeLists
                        on d.PlatformTypeId equals c.CodeID

                        where b.IsEnable.Value == false
                        && (b.IsScalping == false || b.IsScalping == null)
                        && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(b.NickID.Value)
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.CompletionTime != null && b.CompletionTime >= OrderInfoModifiedStart && b.CompletionTime < OrderInfoModifiedEnd))
                            // && zt.Contains(b.OrderStatus)
                        && d.SpeciesTypeId == 475
                        group new
                        {
                            CodeID = c.CodeID,
                            CodeName = c.CodeName,
                            PayPrice = b.PayPrice == null ? 0 : b.PayPrice.Value,
                            ReceivablePrice = b.ReceivablePrice == null ? 0 : b.ReceivablePrice.Value,
                            DistributePrice = b.DistributePrice == null ? 0 : b.DistributePrice.Value,
                            Deduction = d.Deduction == null ? 0 : d.Deduction.Value
                        } by new { c.CodeID, c.CodeName } into i
                        select new OrderInfoSalesDetails
                        {
                            PlatformTypeId = i.Key.CodeID,
                            Remarks = i.Key.CodeName,
                            PayPrice = i.Sum(p => (p.CodeID == 251 ? (p.ReceivablePrice + p.DistributePrice) : p.PayPrice) * p.Deduction / 100 == null ? 0 : (p.CodeID == 251 ? (p.ReceivablePrice + p.DistributePrice) : p.PayPrice) * p.Deduction / 100)
                        };
            return query.ToList();

        }

        /// <summary>
        /// 查询订单赠品明细
        /// </summary>
        /// <param name="PlatformTypeId">平台Id</param>
        /// <param name="nickIds">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">开始时间</param>
        /// <param name="OrderInfoModifiedEnd">结束时间</param>
        /// <param name="OrderStatusId">时间类型</param> 
        /// <returns></returns>
        public List<OrderInfoSalesDetails> getXMOrderInfoAndPremiumsDetailsList(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId)
        {
            //IQueryable<OrderInfoSalesDetails> query = null;
            //左链接
            var Query = from p in this._context.XMPremiumsDetails
                        join b in this._context.XMPremiums on p.PremiumsId equals b.Id
                        into JoinedPB
                        from b in JoinedPB.DefaultIfEmpty()
                        where p.IsEnable.Value == false && b.IsEnable == false
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.CreateTime >= OrderInfoModifiedStart && b.CreateTime < OrderInfoModifiedEnd))
                        && b.PremiumsStatus == 7 && b.IsSingleRow == true
                        orderby b.CreateTime descending
                        select new OrderInfoSalesDetails
                        {
                            ID = 0,
                            PlatformTypeId = 0,
                            NickID = b.NoOrderNickId == null ? 0 : b.NoOrderNickId,
                            OrderCode = b.OrderCode,
                            OrderInfoCreateDate = null,
                            PayDate = null,
                            DeliveryTime = null,
                            CompletionTime = null,
                            FactoryPrice = p.FactoryPrice,
                            ProductNum = p.ProductNum,
                            WantID = b.WantId,
                            ProductName = p.PrdouctName,
                            PlatformMerchantCode = p.PlatformMerchantCode,
                            ProjectName = "",
                            NickName = "",
                            MarkDate = b.CreateTime
                        };

            var query = from c in Query
                        join e in this._context.XMOrderInfoes on c.OrderCode equals e.OrderCode
                        into JoineB
                        from e in JoineB.DefaultIfEmpty()

                        join nick in this._context.XMNicks on e.NickID equals nick.nick_id
                                            into eJoin
                        from eInfo in eJoin.DefaultIfEmpty()

                        join f in this._context.XMProjects on eInfo.ProjectId equals f.Id
                        into fJoin
                        from fInfo in fJoin.DefaultIfEmpty()

                        where e.IsEnable.Value == false
                        && eInfo.isEnable == true
                        && fInfo.IsEnable == true
                        && (e.IsScalping == false || e.IsScalping == null)
                        && e.FinancialAudit == true
                        && (PlatformTypeId == -1 || e.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(e.NickID.Value)
                        select new OrderInfoSalesDetails
                        {
                            ID = e.ID,
                            PlatformTypeId = e.PlatformTypeId,
                            NickID = e.NickID,
                            OrderCode = c.OrderCode,
                            OrderInfoCreateDate = e.OrderInfoCreateDate,
                            PayDate = e.PayDate,
                            DeliveryTime = e.DeliveryTime,
                            CompletionTime = e.CompletionTime,
                            FactoryPrice = c.FactoryPrice,
                            ProductNum = c.ProductNum,
                            WantID = c.WantID,
                            ProductName = c.ProductName,
                            PlatformMerchantCode = c.PlatformMerchantCode,
                            ProjectName = fInfo.ProjectName,
                            NickName = eInfo.nick,
                            MarkDate = c.MarkDate
                        };

            #region 无订单赠品成本

            var NoOrderQuery = from q in Query
                               join nick in this._context.XMNicks on q.NickID equals nick.nick_id
                                        into nJoin
                               from n in nJoin.DefaultIfEmpty()
                               where q.OrderCode.StartsWith("NoOrder")
                               && n.isEnable == true
                    && (PlatformTypeId == -1 || n.PlatformTypeId.Value == PlatformTypeId)
                    && q.NickID != null
                    && nickIds.Contains((int)q.NickID)
                               select new OrderInfoSalesDetails
                               {
                                   ID = q.ID,
                                   PlatformTypeId = q.PlatformTypeId,
                                   NickID = q.NickID,
                                   OrderCode = q.OrderCode,
                                   OrderInfoCreateDate = q.OrderInfoCreateDate,
                                   PayDate = q.PayDate,
                                   DeliveryTime = q.DeliveryTime,
                                   CompletionTime = q.CompletionTime,
                                   FactoryPrice = q.FactoryPrice,
                                   ProductNum = q.ProductNum,
                                   WantID = q.WantID,
                                   ProductName = q.ProductName,
                                   PlatformMerchantCode = q.PlatformMerchantCode,
                                   ProjectName = q.ProjectName,
                                   NickName = q.NickName,
                                   MarkDate = q.MarkDate
                               };

            #endregion

            List<OrderInfoSalesDetails> list = new List<OrderInfoSalesDetails>();
            list = query.ToList();
            list.AddRange(NoOrderQuery.ToList());

            return list;
        }

        /// <summary>
        /// 获取赠品成本
        /// </summary>
        /// <param name="PlatformTypeId"></param>
        /// <param name="nickIds"></param>
        /// <param name="OrderInfoModifiedStart"></param>
        /// <param name="OrderInfoModifiedEnd"></param>
        /// <param name="OrderStatusId"></param>
        /// <returns></returns>
        public decimal getPremiumsCost(int PlatformTypeId, List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd)
        {
            //平台id取不到，无法联查
            //var query123= from p in this._context.XMPremiumsDetails
            //              join b in this._context.XMPremiums on p.PremiumsId equals b.Id into temp
            //              from pb in temp.DefaultIfEmpty()
            //              join m in _context.XMOrderInfoes on pb.OrderCode equals m.OrderCode into temp1
            //              from pm in temp1.DefaultIfEmpty()
            //              join n in _context.XMNicks on pm.NickID equals n.nick_id into temp2
            //              from pn in temp2.DefaultIfEmpty()
            //              join o in _context.XMProjects on pn.ProjectId equals o.Id into temp3
            //              from po in temp3.DefaultIfEmpty()
            //              where !(bool)p.IsEnable && !(bool)pb.IsEnable && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
            //            || (pb.CreateTime >= OrderInfoModifiedStart && pb.CreateTime < OrderInfoModifiedEnd)) &&
            //            pb.PremiumsStatus==7 && (bool)pb.IsSingleRow && !(bool)pm.IsEnable && pn.isEnable && (bool)po.IsEnable &&
            //            (pm.IsScalping == false || pm.IsScalping == null) && (bool)pm.FinancialAudit && (PlatformTypeId == -1 || pm.PlatformTypeId.Value == PlatformTypeId)
            //            && 

            var Query = from p in this._context.XMPremiumsDetails
                        join b in this._context.XMPremiums on p.PremiumsId equals b.Id
                        into JoinedPB
                        from b in JoinedPB.DefaultIfEmpty()
                        where p.IsEnable.Value == false && b.IsEnable == false
                        && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                        || (b.CreateTime >= OrderInfoModifiedStart && b.CreateTime < OrderInfoModifiedEnd))
                        && b.PremiumsStatus == 7 && b.IsSingleRow == true
                        orderby b.CreateTime descending
                        select new OrderInfoSalesDetails
                        {
                            ID = 0,
                            PlatformTypeId = 0,
                            NickID = b.NoOrderNickId == null ? 0 : b.NoOrderNickId,
                            OrderCode = b.OrderCode,
                            OrderInfoCreateDate = null,
                            PayDate = null,
                            DeliveryTime = null,
                            CompletionTime = null,
                            FactoryPrice = p.FactoryPrice * p.ProductNum,
                            ProductNum = p.ProductNum,
                            WantID = b.WantId,
                            ProductName = p.PrdouctName,
                            PlatformMerchantCode = p.PlatformMerchantCode,
                            ProjectName = "",
                            NickName = "",
                            MarkDate = b.CreateTime
                        };

            var query = from c in Query
                        join e in this._context.XMOrderInfoes on c.OrderCode equals e.OrderCode
                        into JoineB
                        from e in JoineB.DefaultIfEmpty()

                        join nick in this._context.XMNicks on e.NickID equals nick.nick_id
                                            into eJoin
                        from eInfo in eJoin.DefaultIfEmpty()

                        join f in this._context.XMProjects on eInfo.ProjectId equals f.Id
                        into fJoin
                        from fInfo in fJoin.DefaultIfEmpty()

                        where e.IsEnable.Value == false
                        && eInfo.isEnable == true
                        && fInfo.IsEnable == true
                        && (e.IsScalping == false || e.IsScalping == null)
                        && e.FinancialAudit == true
                        && (PlatformTypeId == -1 || e.PlatformTypeId.Value == PlatformTypeId)
                        && nickIds.Contains(e.NickID.Value)
                        select new OrderInfoSalesDetails
                        {
                            ID = e.ID,
                            PlatformTypeId = e.PlatformTypeId,
                            NickID = e.NickID,
                            OrderCode = c.OrderCode,
                            OrderInfoCreateDate = e.OrderInfoCreateDate,
                            PayDate = e.PayDate,
                            DeliveryTime = e.DeliveryTime,
                            CompletionTime = e.CompletionTime,
                            FactoryPrice = c.FactoryPrice,
                            ProductNum = c.ProductNum,
                            WantID = c.WantID,
                            ProductName = c.ProductName,
                            PlatformMerchantCode = c.PlatformMerchantCode,
                            ProjectName = fInfo.ProjectName,
                            NickName = eInfo.nick,
                            MarkDate = c.MarkDate
                        };

            decimal? cost1 = query.Select(a => a.FactoryPrice).DefaultIfEmpty().Sum();

            #region 无订单赠品成本

            var NoOrderQuery = from q in Query
                               join nick in this._context.XMNicks on q.NickID equals nick.nick_id
                                        into nJoin
                               from n in nJoin.DefaultIfEmpty()
                               where q.OrderCode.StartsWith("NoOrder")
                               && n.isEnable == true
                    && (PlatformTypeId == -1 || n.PlatformTypeId.Value == PlatformTypeId)
                    && q.NickID != null
                    && nickIds.Contains((int)q.NickID)
                               select new OrderInfoSalesDetails
                               {
                                   ID = q.ID,
                                   PlatformTypeId = q.PlatformTypeId,
                                   NickID = q.NickID,
                                   OrderCode = q.OrderCode,
                                   OrderInfoCreateDate = q.OrderInfoCreateDate,
                                   PayDate = q.PayDate,
                                   DeliveryTime = q.DeliveryTime,
                                   CompletionTime = q.CompletionTime,
                                   FactoryPrice = q.FactoryPrice,
                                   ProductNum = q.ProductNum,
                                   WantID = q.WantID,
                                   ProductName = q.ProductName,
                                   PlatformMerchantCode = q.PlatformMerchantCode,
                                   ProjectName = q.ProjectName,
                                   NickName = q.NickName,
                                   MarkDate = q.MarkDate
                               };

            decimal? cost2 = NoOrderQuery.Select(a => a.FactoryPrice).DefaultIfEmpty().Sum();
            #endregion

            decimal total = (cost1 == null ? 0 : (decimal)cost1) + (cost2 == null ? 0 : (decimal)cost2);

            return total;
        }

        public bool AgreeMoveCargo(List<XMOrderInfoProductDetails> list, XMApplication ApplicationInfo)
        {
            bool moveCargo = false;
            if (ApplicationInfo == null)
            {
                var query = from p in list
                            join d in this._context.XMProducts
                            on p.TManufacturersCode equals d.ManufacturersCode
                            where p.IsEnable == false
                            && d.IsEnable == false
                            && d.IsMoveCargo != null
                            && d.IsMoveCargo == true
                            select p;

                if (query.ToList().Count > 0)
                {
                    moveCargo = true;
                }
                else//临时厂家编码
                {
                    query = from p in list
                            join d in this._context.XMProductDetails
                            on p.TManufacturersCode equals d.TemporaryManufacturersCode
                            join a in this._context.XMProducts
                            on d.ProductId equals a.Id
                            where p.IsEnable == false
                            && d.IsEnable == false
                            && a.IsEnable == false
                            && a.IsMoveCargo != null
                            && a.IsMoveCargo == true
                            select p;

                    if (query.ToList().Count > 0)
                    {
                        moveCargo = true;
                    }
                }
            }
            else
            {
                var List = IoC.Resolve<IXMApplicationExchangeService>().GetXMApplicationExchangeListByApplicationIDType(ApplicationInfo.ID, 1);
                if (List != null && List.Count > 0)
                {
                    var query = from p in List
                                join d in this._context.XMProductDetails
                                on p.PlatformMerchantCode equals d.PlatformMerchantCode
                                join a in this._context.XMProducts
                                on d.ProductId equals a.Id
                                where d.IsEnable == false
                                && a.IsEnable == false
                                && a.IsMoveCargo != null
                                && a.IsMoveCargo == true
                                select p;

                    if (query.ToList().Count > 0)
                    {
                        moveCargo = true;
                    }
                }
            }

            return moveCargo;
        }

        /// <summary>
        /// get to XMOrderInfo list
        /// </summary>
        public List<XMOrderInfo> GetXMOrderInfoList(int[] ids)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.IsEnable == false
                        && ids.Contains(p.ID)
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据订单Id集合 查询
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public List<XMOrderInfo> GetXMOrderInfoListByIds(List<int> Ids)
        {

            var query = from p in this._context.XMOrderInfoes
                        where p.IsEnable == false
                        && Ids.Contains(p.ID)
                        select p;
            return query.ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public List<XMOrderInfo> GetXMOrderInfoByOrderCodeList(List<string> OrderCodes)
        {
            var query = from p in this._context.XMOrderInfoes
                        where OrderCodes.Contains(p.OrderCode)
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据订单号查询(已确认收货订单)
        /// </summary>
        /// <param name="ordercode"></param>
        /// <returns></returns>
        public List<XMOrderInfoMapping> GetXMOrderByOrderCodeList(string ordercode)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.OrderCode.Contains(ordercode)
                            //&& (p.OrderStatus == "FINISHED_L" || p.OrderStatus == "TRADE_FINISHED" || p.OrderStatus == "ORDER_FINISH")//已确认收货订单
                        && p.IsEnable.Value == false
                        //orderby p.OrderCode descending
                        select new XMOrderInfoMapping
                       {
                           OrderCode = p.OrderCode,
                           WantID = p.WantID,
                           FullName = p.FullName
                       };
            return new List<XMOrderInfoMapping>(query);

        }

        /// <summary>
        /// get to XMOrderInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfo Page List</returns>
        public PagedList<XMOrderInfo> SearchXMOrderInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOrderInfoes
                        orderby p.ID
                        select p;
            return new PagedList<XMOrderInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMOrderInfo by ID
        /// </summary>
        /// <param name="id">XMOrderInfo ID</param>
        /// <returns>XMOrderInfo</returns>   
        public XMOrderInfo GetXMOrderInfoByID(int id)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        public XMOrderInfo GetXMOrderInfoByOrderCode(string OrderCode)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.OrderCode.Equals(OrderCode)
                        && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordercode"></param>
        /// <returns></returns>
        public List<XMOrderInfo> GetXMOrderByOrderCode2(string ordercode)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.OrderCode == ordercode
                        && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// delete XMOrderInfo by ID
        /// </summary>
        /// <param name="ID">XMOrderInfo ID</param>
        public void DeleteXMOrderInfo(int id)
        {
            var xmorderinfo = this.GetXMOrderInfoByID(id);
            if (xmorderinfo == null)
                return;

            if (!this._context.IsAttached(xmorderinfo))
                this._context.XMOrderInfoes.Attach(xmorderinfo);

            this._context.DeleteObject(xmorderinfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMOrderInfo by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfo ID</param>
        public void BatchDeleteXMOrderInfo(List<int> ids)
        {
            var query = from q in _context.XMOrderInfoes
                        where ids.Contains(q.ID)
                        select q;
            var xmorderinfos = query.ToList();
            foreach (var item in xmorderinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMOrderInfoes.Attach(item);

                _context.XMOrderInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// get to XMOrderInfo list
        /// </summary>
        public XMOrderInfo GetXMOrderAndOrderProductInfo(string ordercode, string jdid)
        {
            var query = from p in this._context.XMOrderInfoes
                        join b in this._context.XMNicks
                        on p.NickID equals b.nick_id
                        where p.IsEnable == false
                        && p.OrderCode.Equals(ordercode)
                        orderby p.DeliveryTime descending, p.OrderCode descending
                        select p;
            query = from p in query
                    join c in this._context.XMOrderInfoProductDetails
                    on p.ID equals c.OrderInfoID
                    into cJoin
                    from cInfo in cJoin.DefaultIfEmpty()
                    where cInfo.PlatformMerchantCode.Equals(jdid)
                    select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 根据订单号查询
        /// </summary>
        /// <param name="ordercode"></param>
        /// <returns></returns>
        public XMOrderInfo GetXMOrderByOrderCode(string ordercode)
        {
            var query = from p in this._context.XMOrderInfoes
                        //join b in this._context.XMNicks
                        //on p.NickID equals b.nick_id
                        where p.IsEnable == false
                        && p.OrderCode.Equals(ordercode)
                        orderby p.DeliveryTime descending, p.OrderCode descending
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 判断该订单是否刷单   true 是刷单  false 不是刷单
        /// </summary>
        /// <param name="ordercode"></param>
        /// <returns></returns>
        public bool JudgeIsScalpingOrder(int platformtypeid, int nickid, string ordercode, string remark, string CustomerServiceRemark, string wantid, string productname, decimal saleprice, DateTime? orderInfoCreateDate)
        {
            var query = from p in this._context.XMScalpings
                        where p.OrderCode.Equals(ordercode)
                        && p.IsEnable == false
                        select p;
            if (query.ToList().Count > 0)
            {
                return true;
            }
            else if (remark != null && remark != "" && ordercode != null && ordercode != "")
            {
                //关键字查询
                var codequery = from p in this._context.CodeLists
                                where p.CodeTypeID == 191
                                && p.Deleted == false
                                select p;
                var codeList = codequery.ToList();

                foreach (CodeList cl in codeList)
                {
                    if (remark.Contains(cl.CodeName))
                    {
                        var scalping = new XMScalping();
                        scalping.PlatformTypeId = platformtypeid;
                        scalping.NickId = nickid;
                        scalping.Type = 365;//PC端
                        scalping.OrderCode = ordercode;
                        scalping.OrderInfoCreateDate = orderInfoCreateDate;
                        scalping.WantID = wantid;
                        scalping.ProductName = productname;
                        scalping.SalePrice = saleprice;
                        scalping.IsEnable = false;
                        scalping.IsAbnormal = false;
                        if (HozestERPContext.Current.User != null)
                        {
                            scalping.CreateID = HozestERPContext.Current.User.CustomerID;
                            scalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                        }
                        else
                        {
                            string UserName = "admin";
                            List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                            if (customer.Count > 0)
                            {
                                scalping.CreateID = customer[0].CustomerID;
                                scalping.UpdateID = customer[0].CustomerID;
                            }
                        }
                        scalping.CreateDate = DateTime.Now;
                        scalping.UpdateDate = DateTime.Now;

                        //保存数据
                        if (!this._context.IsAttached(scalping))
                            this._context.XMScalpings.AddObject(scalping);
                        this._context.SaveChanges();

                        return true;
                    }
                }
            }
            else if (CustomerServiceRemark != null && CustomerServiceRemark != "" && ordercode != null && ordercode != "")
            {
                //关键字查询
                var codequery = from p in this._context.CodeLists
                                where p.CodeTypeID == 191
                                && p.Deleted == false
                                select p;
                var codeList = codequery.ToList();

                foreach (CodeList cl in codeList)
                {
                    if (CustomerServiceRemark.Contains(cl.CodeName))
                    {
                        var scalping = new XMScalping();
                        scalping.PlatformTypeId = platformtypeid;
                        scalping.NickId = nickid;
                        scalping.Type = 365;//PC端
                        scalping.OrderCode = ordercode;
                        scalping.WantID = wantid;
                        scalping.ProductName = productname;
                        scalping.SalePrice = saleprice;
                        scalping.IsEnable = false;
                        scalping.IsAbnormal = false;
                        if (HozestERPContext.Current.User != null)
                        {
                            scalping.CreateID = HozestERPContext.Current.User.CustomerID;
                            scalping.UpdateID = HozestERPContext.Current.User.CustomerID;
                        }
                        else
                        {
                            string UserName = "admin";
                            List<Customer> customer = IoC.Resolve<ICustomerService>().GetCustomerByUsernameList(UserName);

                            if (customer.Count > 0)
                            {
                                scalping.CreateID = customer[0].CustomerID;
                                scalping.UpdateID = customer[0].CustomerID;
                            }
                        }
                        scalping.CreateDate = DateTime.Now;
                        scalping.UpdateDate = DateTime.Now;

                        //保存数据
                        if (!this._context.IsAttached(scalping))
                            this._context.XMScalpings.AddObject(scalping);
                        this._context.SaveChanges();

                        return true;
                    }
                }

            }
            return false;
        }

        public string ReturnDistributeMethod(string DistributeMethod)
        {
            switch (DistributeMethod)
            {
                case "free":
                    return "卖家包邮";
                case "post":
                    return "平邮";
                case "express":
                    return "快递";
                case "ems":
                    return "EMS";
                case "virtual":
                    return "虚拟发货";
                case "25":
                    return "次日必达";
                case "26":
                    return "预约配送";
                default:
                    return DistributeMethod;
            }
        }

        public string ReturnPayMethod(string PayMethod)
        {
            switch (PayMethod)
            {
                case "fixed":
                    return "一口价";
                case "auction":
                    return "拍卖";
                case "guarantee_trade":
                    return "一口价、拍卖";
                case "auto_delivery":
                    return "自动发货";
                case "independent_simple_trade":
                    return "旺店入门版交易";
                case "independent_shop_trade":
                    return "旺店标准版交易";
                case "ec":
                    return "直冲";
                case "cod":
                    return "货到付款";
                case "fenxiao":
                    return "分销";
                case "game_equipment":
                    return "游戏装备";
                case "shopex_trade":
                    return "ShopEX交易";
                case "netcn_trade":
                    return "万网交易";
                case "external_trade":
                    return "统一外部交易";
                case "o2o_offlinetrade":
                    return "O2O交易";
                case "step":
                    return "万人团";
                case "nopaid":
                    return "无付款订单";
                case "pre_auth_type":
                    return "预授权0元购机交易";
                default:
                    return PayMethod;
            }
        }

        /// <summary>
        /// 根据订单OrderCode
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public List<XMOrderInfoMapping> GetXMOrderInfoByOrderCodeList(string OrderCode)
        {
            var query = from p in this._context.XMOrderInfoes
                        where p.OrderCode.Contains(OrderCode)
                        && p.IsEnable == false
                        select new XMOrderInfoMapping
                       {
                           OrderCode = p.OrderCode,
                           NickID = p.NickID,
                           PlatformTypeId = p.PlatformTypeId,
                           WantID = p.WantID,
                           PayPrice = p.PayPrice
                       };
            return new List<XMOrderInfoMapping>(query);
        }
        #endregion

        public List<AbnormalOrder> getUnusualOrder()
        {
            DateTime now = DateTime.Now;
            DateTime start = now.AddDays(-7);

            //var query = from p in _context.XMOrderInfoes
            //            join m in _context.XMOrderInfoProductDetails on p.ID equals m.OrderInfoID into temp
            //            from pm in temp.DefaultIfEmpty()
            //            join n in _context.XMProductDetails on new { p.PlatformTypeId, pm.PlatformMerchantCode } equals new { n.PlatformTypeId, n.PlatformMerchantCode } into temp1
            //            from pn in temp1.DefaultIfEmpty()
            //            join o in _context.XMNicks on p.PlatformTypeId equals o.PlatformTypeId into temp2
            //            from po in temp2.DefaultIfEmpty()
            //            join r in _context.XMCashBackApplications on p.OrderCode equals r.OrderCode into temp3
            //            from pr in temp3.DefaultIfEmpty()
            //            join s in _context.XMApplications on p.OrderCode equals s.OrderCode into temp4
            //            from ps in temp4.DefaultIfEmpty()
            //            join t in (from a in _context.XMPremiums
            //                       join b in _context.XMPremiumsDetails on a.Id equals b.PremiumsId
            //                       group new { a.OrderCode, b.FactoryPrice } by a.OrderCode into g
            //                       select new { ordercode = g.Key, price = g.Sum(x => x.FactoryPrice)==null?0: g.Sum(x => x.FactoryPrice) }) on p.OrderCode equals t.ordercode into temp5
            //            from pt in temp5.DefaultIfEmpty()
            //            where p.CreateDate> start && p.CreateDate<now && pn.MinPrice!=null
            //            group new { p.OrderCode, pn.MinPrice, po.ProjectId, pr.CashBackMoney, ps.Amount, pt.price } 
            //            by new { p.OrderCode, po.ProjectId, pr.CashBackMoney, ps.Amount, pt.price } into g1
            //            where (g1.Key.CashBackMoney==null?0: g1.Key.CashBackMoney) + (g1.Key.Amount==null?0: g1.Key.Amount) + (g1.Key.price==null?0: g1.Key.price) - (g1.Sum(y => y.MinPrice)==null?0: g1.Sum(y => y.MinPrice)) > 0
            //            select new AbnormalOrder
            //            {
            //                order=g1.Key.OrderCode,
            //                amountMinPrice = g1.Sum(y => y.MinPrice)==null?0: (decimal)g1.Sum(y => y.MinPrice),
            //                cashBackMoney = g1.Key.CashBackMoney==null?0: (decimal)g1.Key.CashBackMoney,
            //                price=g1.Key.price==null?0: (decimal)g1.Key.price,
            //                amount = g1.Key.Amount==null?0: (decimal)g1.Key.Amount,
            //                differencePrice = (g1.Key.CashBackMoney == null ? 0 : (decimal)g1.Key.CashBackMoney) + (g1.Key.Amount == null ? 0 : (decimal)g1.Key.Amount) + (g1.Key.price == null ? 0 : (decimal)g1.Key.price) - (g1.Sum(y => y.MinPrice) == null ? 0 : (decimal)g1.Sum(y => y.MinPrice))
            //            };
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@startTime", start), new SqlParameter("@endTime", now) };

            var query = from p in _context.ExecuteStoreQuery<AbnormalOrder>("exec dbo.UnusualOrder @startTime,@endTime", paras)
                    select p;

            return query.ToList();

        }
    }
}
