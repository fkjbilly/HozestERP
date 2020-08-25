
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-14 10:05:20
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

namespace HozestERP.BusinessLogic.ManageProductionOrder
{
    public partial class XMProductionOrderService : IXMProductionOrderService
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
        public XMProductionOrderService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMProductionOrderService成员
        /// <summary>
        /// Insert into XMProductionOrder
        /// </summary>
        /// <param name="xmproductionorder">XMProductionOrder</param>
        public void InsertXMProductionOrder(XMProductionOrder xmproductionorder)
        {
            if (xmproductionorder == null)
                return;

            if (!this._context.IsAttached(xmproductionorder))

                this._context.XMProductionOrders.AddObject(xmproductionorder);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMProductionOrder
        /// </summary>
        /// <param name="xmproductionorder">XMProductionOrder</param>
        public void UpdateXMProductionOrder(XMProductionOrder xmproductionorder)
        {
            if (xmproductionorder == null)
                return;

            if (this._context.IsAttached(xmproductionorder))
                this._context.XMProductionOrders.Attach(xmproductionorder);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMProductionOrder list
        /// </summary>
        public List<XMProductionOrder> GetXMProductionOrderList()
        {
            var query = from p in this._context.XMProductionOrders
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据订单号查询生产单 （每个订单只允许出现一个生产单）
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        public XMProductionOrder GetXMProductionOrderInfoByOrderCode(string orderCode)
        {
            var query = from p in this._context.XMProductionOrders
                        where p.IsEnable == false
                        && p.OrderCode == orderCode
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xMProjectId"></param>
        /// <param name="NickId"></param>
        /// <param name="OrderStatusId"></param>
        /// <param name="PlatformTypeId"></param>
        /// <param name="StorageDateStart"></param>
        /// <param name="StorageDateEnd"></param>
        /// <param name="WantID"></param>
        /// <param name="SingleRow"></param>
        /// <param name="Mobile"></param>
        /// <param name="Address"></param>
        /// <param name="ManufacturersCode"></param>
        /// <returns></returns>
        public List<XMProductionOrder> GetXMProductionOrderInfoListSearch(int xMProjectId, int NickId, int OrderStatusId, int PlatformTypeId, string Begin, string End, string WantID, int SingleRow, string Mobile, string Address, string ManufacturersCode, int status)
        {
            DateTime StorageBeginTime = DateTime.Now;
            DateTime storageEndTime = DateTime.Now;
            if (Begin != "" && End != "")
            {
                StorageBeginTime = DateTime.Parse(Begin);
                storageEndTime = DateTime.Parse(End);
            }
            var query = from p in this._context.XMProductionOrders
                        join t in this._context.XMNicks
                        on p.NickID equals t.nick_id
                        where p.IsEnable == false
                        && t.isEnable
                        && (xMProjectId == -1 || t.ProjectId.Value == xMProjectId)
                        && (NickId == -1 || p.NickID == NickId)
                        && (OrderStatusId == -1 || p.Status == OrderStatusId)
                        && (PlatformTypeId == -1 || p.PlatformTypeId == PlatformTypeId)
                        && ((Begin == "" && End == "") || (p.EstimateStorageDate >= StorageBeginTime && p.EstimateStorageDate < storageEndTime))
                        && (WantID == "" || p.WantID.Contains(WantID))
                        && (SingleRow == -1 || p.SingleRowStatus == SingleRow)
                        && (Mobile == "" || p.Mobile.Contains(Mobile))
                        && (Address == "" || p.DeliveryAddress.Contains(Address))
                        && (status == -1 || p.Status == status)
                        select p;

            query = from p in query
                    join d in this._context.XMProductionOrderDetails on p.Id equals d.ProductionOrderID
                       into JoinedXMProductionOrderDetails
                    from d in JoinedXMProductionOrderDetails.DefaultIfEmpty()
                    where d.IsEnable == false
                    && d.ManufacturersCode.Contains(ManufacturersCode)
                    select p;
            query = query.Distinct().OrderByDescending(x => x.CreateDate);


            return query.ToList();
        }

        /// <summary>
        /// get to XMProductionOrder Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProductionOrder Page List</returns>
        public PagedList<XMProductionOrder> SearchXMProductionOrder(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProductionOrders
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMProductionOrder>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMProductionOrder by Id
        /// </summary>
        /// <param name="id">XMProductionOrder Id</param>
        /// <returns>XMProductionOrder</returns>   
        public XMProductionOrder GetXMProductionOrderById(int id)
        {
            var query = from p in this._context.XMProductionOrders
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMProductionOrder by Id
        /// </summary>
        /// <param name="Id">XMProductionOrder Id</param>
        public void DeleteXMProductionOrder(int id)
        {
            var xmproductionorder = this.GetXMProductionOrderById(id);
            if (xmproductionorder == null)
                return;

            if (!this._context.IsAttached(xmproductionorder))
                this._context.XMProductionOrders.Attach(xmproductionorder);

            this._context.DeleteObject(xmproductionorder);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMProductionOrder by Id
        /// </summary>
        /// <param name="Ids">XMProductionOrder Id</param>
        public void BatchDeleteXMProductionOrder(List<int> ids)
        {
            var query = from q in _context.XMProductionOrders
                        where ids.Contains(q.Id) && q.IsEnable == false
                        select q;
            var xmproductionorders = query.ToList();
            foreach (var item in xmproductionorders)
            {
                if (!_context.IsAttached(item))
                    _context.XMProductionOrders.Attach(item);

                _context.XMProductionOrders.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
