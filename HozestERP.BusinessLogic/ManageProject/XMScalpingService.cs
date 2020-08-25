
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-01-08 09:34:21
** 修改人:
** 修改日期:
** 描 述: 接口实现类
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using HozestERP.Common;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMScalpingService : IXMScalpingService
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
        public XMScalpingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMScalpingService成员
        /// <summary>
        /// Insert into XMScalping
        /// </summary>
        /// <param name="xmscalping">XMScalping</param>
        public void InsertXMScalping(XMScalping xmscalping)
        {
            if (xmscalping == null)
                return;

            if (!this._context.IsAttached(xmscalping))

                this._context.XMScalpings.AddObject(xmscalping);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMScalping
        /// </summary>
        /// <param name="xmscalping">XMScalping</param>
        public void UpdateXMScalping(XMScalping xmscalping)
        {
            if (xmscalping == null)
                return;

            if (this._context.IsAttached(xmscalping))
                this._context.XMScalpings.Attach(xmscalping);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMScalping list
        /// </summary>
        public List<XMScalping> GetXMScalpingList()
        {
            var query = from p in this._context.XMScalpings
                        where p.IsEnable.Value == false
                        select p;
            return query.ToList();
        }



        /// <summary>
        /// 根据订单号查询
        /// </summary>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public List<XMScalping> GetXMScalpingByOrderCode(string OrderCode)
        {

            var query = from p in this._context.XMScalpings
                        where p.OrderCode == OrderCode
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();

        }


        /// <summary>
        /// 根据刷单Id查询
        /// </summary>
        /// <param name="ScalpingId">刷单Id</param>
        /// <returns></returns>
        public List<XMScalping> GetXMScalpingByScalpingId(int ScalpingId)
        {

            var query = from p in this._context.XMScalpings
                        where p.ScalpingApplication == ScalpingId
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();

        }




        /// <summary>
        /// 根据刷单Id查询 (List<int>) //并判断刷单单号不等于null
        /// </summary>
        /// <param name="ScalpingId">刷单Id</param>
        /// <returns></returns>
        public List<XMScalping> GetXMScalpingByIDs(List<int> IDs)
        {
            var query = from p in this._context.XMScalpings
                        where IDs.Contains(p.ID)
                            //&& (p.ScalpingApplication!=null)
                        && p.IsAbnormal.Value == false
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();

        }

        /// <summary>
        /// 根据刷单Id、订单号 查询
        /// </summary>
        /// <param name="ScalpingId">刷单Id</param>
        /// <returns></returns>
        public List<XMScalping> GetXMScalpingList(int ScalpingId, string OrderCode)
        {

            var query = from p in this._context.XMScalpings
                        where p.ScalpingApplication == ScalpingId
                        && p.OrderCode.Equals(OrderCode)
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();


        }


        /// <summary>
        ///  刷单记录明细：根据订单付款时间 、返现状态：已返现
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickIdList">店铺集合</param>
        /// <param name="OrderInfoModifiedStart">订单付款开始时间</param>
        /// <param name="OrderInfoModifiedEnd">订单付款结束时间</param>
        /// <param name="CashBackStatus">返现状态：已返现</param>
        /// <param name="OrderStatusId">时间类型</param>
        /// <returns></returns>
        public List<OrderInfoSalesDetails> GetXMScalpingDetailsList(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd, int OrderStatusId)
        {
            IQueryable<OrderInfoSalesDetails> query = null;

            #region 创单时间
            //左链接
            query = from a in this._context.XMScalpings
                    join b in this._context.XMOrderInfoes
                    on a.OrderCode equals b.OrderCode into JoinedAB
                    from b in JoinedAB.DefaultIfEmpty()

                    join e in this._context.XMNicks on b.NickID equals e.nick_id
                    into eJoin
                    from eInfo in eJoin.DefaultIfEmpty()

                    join f in this._context.XMProjects on eInfo.ProjectId equals f.Id
                    into fJoin
                    from fInfo in fJoin.DefaultIfEmpty()

                    where a.IsAbnormal.Value == false
                    && eInfo.isEnable == true
                    && fInfo.IsEnable == true
                    && a.IsEnable.Value == false
                    && b.FinancialAudit == true
                    && b.IsEnable.Value == false
                    && NickIdList.Contains(b.NickID.Value)
                    && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                    && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                    || (b.OrderInfoCreateDate >= OrderInfoModifiedStart && b.OrderInfoCreateDate < OrderInfoModifiedEnd))
                    orderby b.OrderInfoCreateDate descending
                    select new OrderInfoSalesDetails
                    {
                        ID = b.ID,
                        PlatformTypeId = b.PlatformTypeId,
                        NickID = b.NickID,
                        OrderCode = b.OrderCode,
                        OrderInfoCreateDate = b.OrderInfoCreateDate,
                        PayDate = b.PayDate,
                        DeliveryTime = b.DeliveryTime,
                        CompletionTime = b.CompletionTime,
                        WantID = a.WantID,
                        ProductName = a.ProductName,
                        SalesPrice = a.SalePrice,
                        Fee = a.Fee,
                        OrderPrice = a.Fee + a.Deduction,
                        Deduction = a.Deduction,
                        ProjectName = fInfo.ProjectName,
                        NickName = eInfo.nick,
                        MarkDate = b.OrderInfoCreateDate
                    };
            #endregion

            return query.ToList();
        }

        public decimal getScalpingCost(int PlatformTypeId, List<int> NickIdList, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd)
        {
            var query= from a in this._context.XMScalpings
                       join b in this._context.XMOrderInfoes
                       on a.OrderCode equals b.OrderCode into JoinedAB
                       from b in JoinedAB.DefaultIfEmpty()

                       join e in this._context.XMNicks on b.NickID equals e.nick_id
                       into eJoin
                       from eInfo in eJoin.DefaultIfEmpty()

                       join f in this._context.XMProjects on eInfo.ProjectId equals f.Id
                       into fJoin
                       from fInfo in fJoin.DefaultIfEmpty()

                       where a.IsAbnormal.Value == false
                       && eInfo.isEnable == true
                       && fInfo.IsEnable == true
                       && a.IsEnable.Value == false
                       && b.FinancialAudit == true
                       && b.IsEnable.Value == false
                       && NickIdList.Contains(b.NickID.Value)
                       && (PlatformTypeId == -1 || b.PlatformTypeId.Value == PlatformTypeId)
                       && ((OrderInfoModifiedStart == null && OrderInfoModifiedEnd == null)
                       || (b.OrderInfoCreateDate >= OrderInfoModifiedStart && b.OrderInfoCreateDate < OrderInfoModifiedEnd))
                       orderby b.OrderInfoCreateDate descending
                       select new OrderInfoSalesDetails
                       {
                           ID = b.ID,
                           PlatformTypeId = b.PlatformTypeId,
                           NickID = b.NickID,
                           OrderCode = b.OrderCode,
                           OrderInfoCreateDate = b.OrderInfoCreateDate,
                           PayDate = b.PayDate,
                           DeliveryTime = b.DeliveryTime,
                           CompletionTime = b.CompletionTime,
                           WantID = a.WantID,
                           ProductName = a.ProductName,
                           SalesPrice = a.SalePrice,
                           Fee = a.Fee,
                           OrderPrice = a.Fee + a.Deduction,
                           Deduction = a.Deduction,
                           ProjectName = fInfo.ProjectName,
                           NickName = eInfo.nick,
                           MarkDate = b.OrderInfoCreateDate
                       };

            decimal? cost = query.Select(a => a.OrderPrice).Sum();

            return Math.Round((cost == null ? 0 : (decimal)cost),2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickId">店铺Id</param>
        /// <param name="OrderCode">订单编号</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMScalping Page List</returns>
        public List<XMScalping> SearchXMScalping(int PlatformTypeId, List<int> NickId, string ScalpingCode, string OrderCode, int IsAbnormal, DateTime? orderCreateStart, DateTime? orderCreateEnd)
        {

            IQueryable<XMScalping> query = null;

            bool IsAbnormalB = true;
            if (IsAbnormal == 1)
            {
                IsAbnormalB = true;
            }
            if (IsAbnormal == 0)
            {
                IsAbnormalB = false;
            }

            if (NickId.Count > 1)
            {

                query = from p in this._context.XMScalpings
                        //join b in this._context.XMScalpingApplications
                        //on p.ScalpingApplication equals b.ScalpingId
                        where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && (IsAbnormal == -1 || p.IsAbnormal.Value == IsAbnormalB)
                        && NickId.Contains(p.NickId.Value)
                            //&& (NickId == -1 || p.NickId == NickId)
                            //&& b.ScalpingCode.Contains(ScalpingCode)
                        && p.OrderCode.Contains(OrderCode)
                        && p.OrderInfoCreateDate >= orderCreateStart && p.OrderInfoCreateDate < orderCreateEnd
                        && p.IsEnable.Value == false
                        orderby p.ID descending
                        select p;
            }
            else
            {
                int nickId = NickId[0];
                query = from p in this._context.XMScalpings
                        //join b in this._context.XMScalpingApplications
                        //on p.ScalpingApplication equals b.ScalpingId
                        where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && (IsAbnormal == -1 || p.IsAbnormal.Value == IsAbnormalB)
                        && (nickId == -1 || p.NickId == nickId)
                        && p.OrderCode.Contains(OrderCode)
                         && p.OrderInfoCreateDate >= orderCreateStart && p.OrderInfoCreateDate < orderCreateEnd
                        && p.IsEnable.Value == false
                        orderby p.ID descending
                        select p;
            }
            if (ScalpingCode != "")
            {
                query = from p in query
                        join e in this._context.XMScalpingApplications on p.ScalpingApplication equals e.ScalpingId
                        //into eJon
                        //from eInfo in eJon.DefaultIfEmpty()
                        where e.ScalpingCode.Contains(ScalpingCode)
                        orderby p.ID descending
                        select p;
            }
            return query.ToList();
        }

        /// <summary>
        /// 已付款刷单查询
        /// </summary>
        /// <param name="PlatformTypeId">平台类型</param>
        /// <param name="NickId">店铺Id</param>
        /// <param name="OrderCode">订单编号</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMScalping Page List</returns>
        public List<XMScalping> SearchXMScalpingYFK(int PlatformTypeId, List<int> NickId, string ScalpingCode, string OrderCode, int IsAbnormal, DateTime? orderCreateStart, DateTime? orderCreateEnd)
        {

            IQueryable<XMScalping> query = null;

            bool IsAbnormalB = true;
            if (IsAbnormal == 1)
            {
                IsAbnormalB = true;
            }
            if (IsAbnormal == 0)
            {
                IsAbnormalB = false;
            }

            if (NickId.Count > 1)
            {

                query = from p in this._context.XMScalpings
                        join b in this._context.XMOrderInfoes
                        on p.OrderCode equals b.OrderCode
                        where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && (IsAbnormal == -1 || p.IsAbnormal.Value == IsAbnormalB)
                        && NickId.Contains(p.NickId.Value)
                        && p.OrderCode.Contains(OrderCode)
                        && p.OrderInfoCreateDate >= orderCreateStart && p.OrderInfoCreateDate < orderCreateEnd
                        && p.IsEnable.Value == false
                        && (b.OrderStatus == "WAIT_SELLER_SEND_GOODS" || b.OrderStatus == "SELLER_CONSIGNED_PART" || b.OrderStatus == "WAIT_BUYER_CONFIRM_GOODS"
                        || b.OrderStatus == "TRADE_BUYER_SIGNED" || b.OrderStatus == "TRADE_FINISHED" || b.OrderStatus == "WAIT_SELLER_STOCK_OUT"
                        || b.OrderStatus == "SEND_TO_DISTRIBUTION_CENER" || b.OrderStatus == "DISTRIBUTION_CENTER_RECEIVED" || b.OrderStatus == "WAIT_GOODS_RECEIVE_CONFIRM"
                        || b.OrderStatus == "RECEIPTS_CONFIRM" || b.OrderStatus == "WAIT_SELLER_DELIVERY"
                        || b.OrderStatus == "FINISHED_L")
                        orderby p.ID descending
                        select p;

            }
            else
            {
                int nickId = NickId[0];
                query = from p in this._context.XMScalpings
                        join b in this._context.XMOrderInfoes
                        on p.OrderCode equals b.OrderCode
                        where (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && (IsAbnormal == -1 || p.IsAbnormal.Value == IsAbnormalB)
                        && (nickId == -1 || p.NickId == nickId)
                        && p.OrderCode.Contains(OrderCode)
                        && p.OrderInfoCreateDate >= orderCreateStart && p.OrderInfoCreateDate < orderCreateEnd
                        && p.IsEnable.Value == false
                        && (b.OrderStatus == "WAIT_SELLER_SEND_GOODS" || b.OrderStatus == "SELLER_CONSIGNED_PART" || b.OrderStatus == "WAIT_BUYER_CONFIRM_GOODS"
                        || b.OrderStatus == "TRADE_BUYER_SIGNED" || b.OrderStatus == "TRADE_FINISHED" || b.OrderStatus == "WAIT_SELLER_STOCK_OUT"
                        || b.OrderStatus == "SEND_TO_DISTRIBUTION_CENER" || b.OrderStatus == "DISTRIBUTION_CENTER_RECEIVED" || b.OrderStatus == "WAIT_GOODS_RECEIVE_CONFIRM"
                        || b.OrderStatus == "RECEIPTS_CONFIRM" || b.OrderStatus == "WAIT_SELLER_DELIVERY"
                        || b.OrderStatus == "FINISHED_L")
                        orderby p.ID descending
                        select p;

            }
            if (ScalpingCode != "")
            {

                query = from p in query
                        join e in this._context.XMScalpingApplications on p.ScalpingApplication equals e.ScalpingId
                        //into eJon
                        //from eInfo in eJon.DefaultIfEmpty()
                        where e.ScalpingCode.Contains(ScalpingCode)
                        orderby p.ID descending
                        select p;
            }

            return query.ToList();
        }

        /// <summary>
        /// get a XMScalping by ID
        /// </summary>
        /// <param name="id">XMScalping ID</param>
        /// <returns>XMScalping</returns>   
        public XMScalping GetXMScalpingByID(int id)
        {
            var query = from p in this._context.XMScalpings
                        where p.ID.Equals(id)
                        && p.IsEnable.Value == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMScalping by ID
        /// </summary>
        /// <param name="ID">XMScalping ID</param>
        public void DeleteXMScalping(int id)
        {
            var xmscalping = this.GetXMScalpingByID(id);
            if (xmscalping == null)
                return;

            if (!this._context.IsAttached(xmscalping))
                this._context.XMScalpings.Attach(xmscalping);

            this._context.DeleteObject(xmscalping);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMScalping by ID
        /// </summary>
        /// <param name="IDs">XMScalping ID</param>
        public void BatchDeleteXMScalping(List<int> ids)
        {
            var query = from q in _context.XMScalpings
                        where ids.Contains(q.ID)
                        select q;
            var xmscalpings = query.ToList();
            foreach (var item in xmscalpings)
            {
                if (!_context.IsAttached(item))
                    _context.XMScalpings.Attach(item);

                _context.XMScalpings.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 刷单批量打印查询
        /// </summary>
        /// <param name="id">XMScalping ID</param>
        /// <returns>XMScalping</returns>   
        public List<XMOrderInfo> GetXMOrderinfoShudan(int[] ids)
        {
            var query = from p in this._context.XMOrderInfoes
                        join b in this._context.XMScalpings
                        on p.OrderCode equals b.OrderCode
                        where ids.Contains(b.ID)
                        && p.IsEnable.Value == false
                        select p;
            return query.ToList();
        }

        #endregion
    }
}
