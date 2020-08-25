
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMPurchaseRejectedProductDetailsService : IXMPurchaseRejectedProductDetailsService
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
        public XMPurchaseRejectedProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMPurchaseRejectedProductDetailsService成员
        /// <summary>
        /// Insert into XMPurchaseRejectedProductDetails
        /// </summary>
        /// <param name="xmpurchaserejectedproductdetails">XMPurchaseRejectedProductDetails</param>
        public void InsertXMPurchaseRejectedProductDetails(XMPurchaseRejectedProductDetails xmpurchaserejectedproductdetails)
        {
            if (xmpurchaserejectedproductdetails == null)
                return;

            if (!this._context.IsAttached(xmpurchaserejectedproductdetails))

                this._context.XMPurchaseRejectedProductDetails.AddObject(xmpurchaserejectedproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMPurchaseRejectedProductDetails
        /// </summary>
        /// <param name="xmpurchaserejectedproductdetails">XMPurchaseRejectedProductDetails</param>
        public void UpdateXMPurchaseRejectedProductDetails(XMPurchaseRejectedProductDetails xmpurchaserejectedproductdetails)
        {
            if (xmpurchaserejectedproductdetails == null)
                return;

            if (this._context.IsAttached(xmpurchaserejectedproductdetails))
                this._context.XMPurchaseRejectedProductDetails.Attach(xmpurchaserejectedproductdetails);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMPurchaseRejectedProductDetails list
        /// </summary>
        public List<XMPurchaseRejectedProductDetails> GetXMPurchaseRejectedProductDetailsList()
        {
            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rejectedCode"></param>
        /// <param name="productName"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="supplierId"></param>
        /// <param name="status"></param>
        /// <param name="customerids"></param>
        /// <param name="isStorage"></param>
        /// <returns></returns>
        public List<PurchaseRejectedDetail> GetXMPurchaseRejectedProductDetailsListByParm(string rejectedCode, string productName, string beginTime, string endTime, int supplierId, int status, string customerids, bool isStorage)
        {
            int?[] customerIdlist = Array.ConvertAll<string, int?>(customerids.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (beginTime != "" && endTime != "")
            {
                purBeginTime = DateTime.Parse(beginTime);
                purEndTime = DateTime.Parse(endTime);
            }
            bool isAudit = false;
            if (status != -1)
            {
                isAudit = status == 0 ? false : true;
            }

            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        join t in this._context.XMPurchaseRejecteds
                        on p.PrId equals t.Id
                        join d in this._context.XMProducts
                        on p.ProductId equals d.Id
                        where p.IsEnable == false
                        && t.IsEnable == false
                        && (rejectedCode == "" || t.Ref.Contains(rejectedCode))
                        && (productName == "" || d.ProductName.Contains(productName))
                        && (supplierId == -1 || t.SupplierId == supplierId)
                        && ((beginTime == "" && endTime == "") || (t.BizDt >= purBeginTime && t.BizDt < purEndTime))
                        && customerIdlist.Contains(t.BizUserId)
                        && (status == -1 || t.IsAudit == isAudit)
                        && t.IsStoraged == isStorage
                        orderby t.BizDt descending
                        select new PurchaseRejectedDetail
                        {
                            Id = p.Id,
                            PrId = t.Id,
                            Ref = t.Ref,
                            ProductId = p.ProductId,
                            SupplierId = t.SupplierId,
                            BizUserId = t.BizUserId,
                            PlatformMerchantCode = p.PlatformMerchantCode,
                            RejectionProductPrice = p.RejectionProductPrice,
                            RejectionCount = p.RejectionCount,
                            RejectionMoney = p.RejectionMoney,
                            EmitFactory = t.EmitFactory,
                            CreateID = p.CreateID,
                            CreateDate = p.CreateDate,
                            BillStatus = p.BillStatus
                        };
            return query.ToList();
        }

        /// <summary>
        /// 已出库的退货商品列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="wdID"></param>
        /// <param name="PlatformMerchantCode"></param>
        /// <returns></returns>
        public List<XMPurchaseRejectedProductDetails> GetXMPurchaseRejectedProductDetailsListByParm(DateTime startDate, DateTime endDate, int wdID, string PlatformMerchantCode)
        {
            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        join t in this._context.XMPurchaseRejecteds
                        on p.PrId equals t.Id
                        join d in this._context.XMStorages
                         on t.MId equals d.Id
                        where p.IsEnable == false
                        && (t.BizDt >= startDate && t.BizDt < endDate)
                        && t.IsStoraged == true
                        && d.WareHouseId == wdID
                        && p.PlatformMerchantCode == PlatformMerchantCode
                        && t.BillStatus == 1000
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMPurchaseRejectedProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPurchaseRejectedProductDetails Page List</returns>
        public PagedList<XMPurchaseRejectedProductDetails> SearchXMPurchaseRejectedProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMPurchaseRejectedProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMPurchaseRejectedProductDetails by Id
        /// </summary>
        /// <param name="id">XMPurchaseRejectedProductDetails Id</param>
        /// <returns>XMPurchaseRejectedProductDetails</returns>   
        public XMPurchaseRejectedProductDetails GetXMPurchaseRejectedProductDetailsById(int id)
        {
            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        public List<XMPurchaseRejectedProductDetails> GetXMPurchaseRejectedProductDetailsByRejectedByParm(int purchaseId, string platformMerchantCode)
        {
            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        join t in this._context.XMPurchaseRejecteds
                        on p.PrId equals t.Id
                        where p.IsEnable == false
                        && t.MId == purchaseId
                        && p.PlatformMerchantCode == platformMerchantCode
                        && t.IsAudit == true
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rejectedID"></param>
        /// <returns></returns>
        public List<XMPurchaseRejectedProductDetails> GetXMPurchaseRejectedProductDetailsByRejectedID(int rejectedID)
        {
            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        where p.PrId == rejectedID && p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// delete XMPurchaseRejectedProductDetails by Id
        /// </summary>
        /// <param name="Id">XMPurchaseRejectedProductDetails Id</param>
        public void DeleteXMPurchaseRejectedProductDetails(int id)
        {
            var xmpurchaserejectedproductdetails = this.GetXMPurchaseRejectedProductDetailsById(id);
            if (xmpurchaserejectedproductdetails == null)
                return;

            if (!this._context.IsAttached(xmpurchaserejectedproductdetails))
                this._context.XMPurchaseRejectedProductDetails.Attach(xmpurchaserejectedproductdetails);

            this._context.DeleteObject(xmpurchaserejectedproductdetails);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMPurchaseRejectedProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMPurchaseRejectedProductDetails Id</param>
        public void BatchDeleteXMPurchaseRejectedProductDetails(List<int> ids)
        {
            var query = from q in _context.XMPurchaseRejectedProductDetails
                        where ids.Contains(q.Id)
                        select q;
            var xmpurchaserejectedproductdetailss = query.ToList();
            foreach (var item in xmpurchaserejectedproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMPurchaseRejectedProductDetails.Attach(item);

                _context.XMPurchaseRejectedProductDetails.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
