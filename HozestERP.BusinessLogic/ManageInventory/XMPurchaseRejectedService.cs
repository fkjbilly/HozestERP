
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
    public partial class XMPurchaseRejectedService : IXMPurchaseRejectedService
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
        public XMPurchaseRejectedService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMPurchaseRejectedService成员
        /// <summary>
        /// Insert into XMPurchaseRejected
        /// </summary>
        /// <param name="xmpurchaserejected">XMPurchaseRejected</param>
        public void InsertXMPurchaseRejected(XMPurchaseRejected xmpurchaserejected)
        {
            if (xmpurchaserejected == null)
                return;

            if (!this._context.IsAttached(xmpurchaserejected))

                this._context.XMPurchaseRejecteds.AddObject(xmpurchaserejected);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMPurchaseRejected
        /// </summary>
        /// <param name="xmpurchaserejected">XMPurchaseRejected</param>
        public void UpdateXMPurchaseRejected(XMPurchaseRejected xmpurchaserejected)
        {
            if (xmpurchaserejected == null)
                return;

            if (this._context.IsAttached(xmpurchaserejected))
                this._context.XMPurchaseRejecteds.Attach(xmpurchaserejected);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMPurchaseRejected list
        /// </summary>
        public List<XMPurchaseRejected> GetXMPurchaseRejectedList()
        {
            var query = from p in this._context.XMPurchaseRejecteds
                        where p.IsEnable == false
                        orderby p.Id descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        ///  get to XMPurchaseRejected by  PurchaseID
        /// </summary>
        /// <param name="purchaseID"></param>
        /// <returns></returns>
        public List<XMPurchaseRejected> GetXMPurchaseRejectedListByPurchaseID(int purchaseID)
        {
            var query = from p in this._context.XMPurchaseRejecteds
                        where p.IsEnable == false
                        && p.IsStoraged == false
                        && p.MId == purchaseID
                        && p.IsAudit == true
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refNumber"></param>
        /// <returns></returns>
        public XMPurchaseRejected GetXMPurchaseRejectedsByRef(string refNumber)
        {
            var query = from p in this._context.XMPurchaseRejecteds
                        where p.IsEnable == false
                         && p.IsStoraged == false
                         && p.Ref.Contains(refNumber)
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// get to XMPurchaseRejected by  StorageID
        /// </summary>
        /// <param name="storageID"></param>
        /// <returns></returns>
        public List<XMPurchaseRejected> GetXMPurchaseRejectedListByStorageID(int storageID)
        {
            var query = from p in this._context.XMPurchaseRejecteds
                        where p.IsEnable == false
                          && p.IsStoraged == true
                          && p.MId == storageID
                          && p.IsAudit == true
                          && p.BillStatus == 1000
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMPurchaseRejected Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPurchaseRejected Page List</returns>
        public PagedList<XMPurchaseRejected> SearchXMPurchaseRejected(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPurchaseRejecteds
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMPurchaseRejected>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rejectedCode"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="supplierId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<XMPurchaseRejected> GetXMPurchaseRejectedListByParm(string rejectedCode, string productName, string beginTime, string endTime, int supplierId, int status, string customerids, bool isStorage)
        {
            int?[] customerIdlist = Array.ConvertAll<string, int?>(customerids.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;

            bool isAudit = false;
            if (status != -1)
            {
                isAudit = status == 0 ? false : true;
            }
            if (beginTime != "" && endTime != "")
            {
                purBeginTime = DateTime.Parse(beginTime);
                purEndTime = DateTime.Parse(endTime);
            }
            if (string.IsNullOrEmpty(productName))
            {
                var query = from p in this._context.XMPurchaseRejecteds
                            where p.IsEnable == false
                            && ((beginTime == "" && endTime == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                            && (rejectedCode == "" || p.Ref.Contains(rejectedCode))
                            && (supplierId == -1 || p.SupplierId == supplierId)
                            && (status == -1 || p.IsAudit == isAudit)
                            && customerIdlist.Contains(p.BizUserId)
                            && p.IsStoraged == isStorage
                            orderby p.BizDt descending
                            select p;
                return query.ToList();
            }
            else
            {
                var query = from p in this._context.XMPurchaseRejecteds
                            where p.IsEnable == false
                            && ((beginTime == "" && endTime == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                            && (rejectedCode == "" || p.Ref.Contains(rejectedCode))
                            && (supplierId == -1 || p.SupplierId == supplierId)
                            && (status == -1 || p.IsAudit == isAudit)
                            && customerIdlist.Contains(p.BizUserId)
                            && p.IsStoraged == isStorage
                            select p;

                query = from p in query
                        join d in this._context.XMPurchaseRejectedProductDetails on p.Id equals d.PrId
                           into JoinedXMPurchaseRejectedDetails
                        from d in JoinedXMPurchaseRejectedDetails.DefaultIfEmpty()

                        join h in this._context.XMProducts on d.ProductId equals h.Id
                         into JoinedXMProducts
                        from h in JoinedXMProducts.DefaultIfEmpty()

                        where d.IsEnable == false
                         && h.ProductName.Contains(productName)
                        select p;
                query = query.Distinct().OrderByDescending(x => x.BizDt);
                return query.ToList();
            }
        }

        /// <summary>
        /// get a XMPurchaseRejected by Id
        /// </summary>
        /// <param name="id">XMPurchaseRejected Id</param>
        /// <returns>XMPurchaseRejected</returns>   
        public XMPurchaseRejected GetXMPurchaseRejectedById(int id)
        {
            var query = from p in this._context.XMPurchaseRejecteds
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMPurchaseRejected by Id
        /// </summary>
        /// <param name="Id">XMPurchaseRejected Id</param>
        public void DeleteXMPurchaseRejected(int id)
        {
            var xmpurchaserejected = this.GetXMPurchaseRejectedById(id);
            if (xmpurchaserejected == null)
                return;

            if (!this._context.IsAttached(xmpurchaserejected))
                this._context.XMPurchaseRejecteds.Attach(xmpurchaserejected);

            this._context.DeleteObject(xmpurchaserejected);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMPurchaseRejected by Id
        /// </summary>
        /// <param name="Ids">XMPurchaseRejected Id</param>
        public void BatchDeleteXMPurchaseRejected(List<int> ids)
        {
            var query = from q in _context.XMPurchaseRejecteds
                        where ids.Contains(q.Id)
                        select q;
            var xmpurchaserejecteds = query.ToList();
            foreach (var item in xmpurchaserejecteds)
            {
                if (!_context.IsAttached(item))
                    _context.XMPurchaseRejecteds.Attach(item);

                _context.XMPurchaseRejecteds.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
