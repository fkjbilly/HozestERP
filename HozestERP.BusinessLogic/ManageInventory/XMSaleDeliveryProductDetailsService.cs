
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-05-09 16:59:21
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMSaleDeliveryProductDetailsService : IXMSaleDeliveryProductDetailsService
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
        public XMSaleDeliveryProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMSaleDeliveryProductDetailsService成员
        /// <summary>
        /// Insert into XMSaleDeliveryProductDetails
        /// </summary>
        /// <param name="xmsaledeliveryproductdetails">XMSaleDeliveryProductDetails</param>
        public void InsertXMSaleDeliveryProductDetails(XMSaleDeliveryProductDetails xmsaledeliveryproductdetails)
        {
            if (xmsaledeliveryproductdetails == null)
                return;

            if (!this._context.IsAttached(xmsaledeliveryproductdetails))

                this._context.XMSaleDeliveryProductDetails.AddObject(xmsaledeliveryproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMSaleDeliveryProductDetails
        /// </summary>
        /// <param name="xmsaledeliveryproductdetails">XMSaleDeliveryProductDetails</param>
        public void UpdateXMSaleDeliveryProductDetails(XMSaleDeliveryProductDetails xmsaledeliveryproductdetails)
        {
            if (xmsaledeliveryproductdetails == null)
                return;

            if (this._context.IsAttached(xmsaledeliveryproductdetails))
                this._context.XMSaleDeliveryProductDetails.Attach(xmsaledeliveryproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMSaleDeliveryProductDetails list
        /// </summary>
        public List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryProductDetailsList()
        {
            var query = from p in this._context.XMSaleDeliveryProductDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 无订单销售出库单查询
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="WareHousesList"></param>
        /// <returns></returns>
        public List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryListJDSelf(DateTime begin, DateTime end, List<int> WareHousesList)
        {
            var query = from p in this._context.XMSaleDeliveries
                        join d in this._context.XMSaleDeliveryProductDetails
                        on p.Id equals d.SaleDeliveryId
                        where p.IsEnable == false
                        && d.IsEnable == false
                        && p.IsAudit == true
                        && p.BillStatus != 0
                        && WareHousesList.Contains(p.WareHouseId)
                        && p.BizDt >= begin
                        && p.BizDt < end
                        && p.OrderInfoID == 0
                        orderby p.Id descending
                        select d;
            return query.ToList();
        }

        public List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryListOtherProject(DateTime begin, DateTime end, List<int> WareHousesList)
        {
            var query = from p in this._context.XMSaleDeliveries
                        join d in this._context.XMSaleDeliveryProductDetails
                        on p.Id equals d.SaleDeliveryId
                        where p.IsEnable == false
                        && d.IsEnable == false
                        && p.IsAudit == true
                        && p.BillStatus != 0
                        && WareHousesList.Contains(p.WareHouseId)
                        && p.BizDt >= begin
                        && p.BizDt < end
                        orderby p.Id descending
                        select d;
            return query.ToList();
        }

        /// <summary>
        /// get to XMSaleDeliveryProductDetails list
        /// </summary>
        public List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryProductDetailsBySaleDeliveryID(int saleDeliveryID)
        {
            var query = from p in this._context.XMSaleDeliveryProductDetails
                        where p.IsEnable == false && p.SaleDeliveryId == saleDeliveryID
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="wareHousesID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        public List<XMSaleDeliveryProductDetails> GetXMSaleDeliveryProductDetailsByParm(DateTime startDate, DateTime endDate, int wareHousesID, string PlatformMerchantCode)
        {
            var query = from p in this._context.XMSaleDeliveryProductDetails
                        join t in this._context.XMSaleDeliveries
                         on p.SaleDeliveryId equals t.Id
                        where p.IsEnable == false
                        && (t.BizDt >= startDate && t.BizDt < endDate)
                        && t.WareHouseId == wareHousesID
                        && p.PlatformMerchantCode == PlatformMerchantCode
                        && t.BillStatus == 1000
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMSaleDeliveryProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleDeliveryProductDetails Page List</returns>
        public PagedList<XMSaleDeliveryProductDetails> SearchXMSaleDeliveryProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSaleDeliveryProductDetails
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMSaleDeliveryProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMSaleDeliveryProductDetails by Id
        /// </summary>
        /// <param name="id">XMSaleDeliveryProductDetails Id</param>
        /// <returns>XMSaleDeliveryProductDetails</returns>   
        public XMSaleDeliveryProductDetails GetXMSaleDeliveryProductDetailsById(int id)
        {
            var query = from p in this._context.XMSaleDeliveryProductDetails
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="platformMerchantCode"></param>
        /// <param name="saleDeliveryId"></param>
        /// <returns></returns>
        public XMSaleDeliveryProductDetails GetXMSaleDeliveryProductDetailsByParm(string platformMerchantCode, int saleDeliveryId)
        {
            var query = from p in this._context.XMSaleDeliveryProductDetails
                        where p.IsEnable == false && p.SaleDeliveryId == saleDeliveryId && p.PlatformMerchantCode == platformMerchantCode
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMSaleDeliveryProductDetails by Id
        /// </summary>
        /// <param name="Id">XMSaleDeliveryProductDetails Id</param>
        public void DeleteXMSaleDeliveryProductDetails(int id)
        {
            var xmsaledeliveryproductdetails = this.GetXMSaleDeliveryProductDetailsById(id);
            if (xmsaledeliveryproductdetails == null)
                return;

            if (!this._context.IsAttached(xmsaledeliveryproductdetails))
                this._context.XMSaleDeliveryProductDetails.Attach(xmsaledeliveryproductdetails);

            this._context.DeleteObject(xmsaledeliveryproductdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMSaleDeliveryProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMSaleDeliveryProductDetails Id</param>
        public void BatchDeleteXMSaleDeliveryProductDetails(List<int> ids)
        {
            var query = from q in _context.XMSaleDeliveryProductDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmsaledeliveryproductdetailss = query.ToList();
            foreach (var item in xmsaledeliveryproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMSaleDeliveryProductDetails.Attach(item);

                _context.XMSaleDeliveryProductDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
