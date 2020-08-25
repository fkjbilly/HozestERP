
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-07-05 16:39:22
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

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class XMPaymentApplyService : IXMPaymentApplyService
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
        public XMPaymentApplyService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMPaymentApplyService成员
        /// <summary>
        /// Insert into XMPaymentApply
        /// </summary>
        /// <param name="xmpaymentapply">XMPaymentApply</param>
        public void InsertXMPaymentApply(XMPaymentApply xmpaymentapply)
        {
            if (xmpaymentapply == null)
                return;

            if (!this._context.IsAttached(xmpaymentapply))

                this._context.XMPaymentApplies.AddObject(xmpaymentapply);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMPaymentApply
        /// </summary>
        /// <param name="xmpaymentapply">XMPaymentApply</param>
        public void UpdateXMPaymentApply(XMPaymentApply xmpaymentapply)
        {
            if (xmpaymentapply == null)
                return;

            if (this._context.IsAttached(xmpaymentapply))
                this._context.XMPaymentApplies.Attach(xmpaymentapply);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMPaymentApply list
        /// </summary>
        public List<XMPaymentApply> GetXMPaymentApplyList()
        {
            var query = from p in this._context.XMPaymentApplies
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseNumber"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="isAudit"></param>
        /// <param name="FinancialStatus"></param>
        /// <param name="FinanceOkIsAudit"></param>
        /// <returns></returns>
        public List<XMPaymentApply> GetXMPaymentApply(string purchaseRef, string Requester, string begin, string end, int isAudit, int FinancialStatus, int FinanceOkIsAudit)
        {
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMPaymentApplies
                        join m in _context.CustomerInfoes
                        on p.ApplicantID equals m.CustomerID
                        join n in _context.XMPurchases
                        on p.PurchaseID equals n.Id into temp
                        from pn in temp.DefaultIfEmpty()
                       // join m in this._context.XMPurchases
                        //on p.PurchaseID equals m.Id
                        where p.IsEnable == false
                        //&& (purchaseNumber == "" || m.PurchaseNumber.Contains(purchaseNumber))
                        &&(purchaseRef==""|| pn.PurchaseNumber.Contains(purchaseRef))
                        && (Requester == "" || m.FullName.Contains(Requester))
                       && ((begin == "" && end == "") || (p.RequstDate >= purBeginTime && p.RequstDate < purEndTime))
                         && (isAudit == -1 || p.IsAudit.Value.Equals(isAudit == 0 ? false : true))
                          && (FinancialStatus == -1 || p.FinancialStatus.Value.Equals(FinancialStatus == 0 ? false : true))
                            && (FinanceOkIsAudit == -1 || p.FinancialConfirm.Value.Equals(FinanceOkIsAudit == 0 ? false : true))
                        orderby p.RequstDate descending
                        select p;

            return query.ToList();
        }


        /// <summary>
        /// get to XMPaymentApply Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPaymentApply Page List</returns>
        public PagedList<XMPaymentApply> SearchXMPaymentApply(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPaymentApplies
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMPaymentApply>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMPaymentApply by Id
        /// </summary>
        /// <param name="id">XMPaymentApply Id</param>
        /// <returns>XMPaymentApply</returns>   
        public XMPaymentApply GetXMPaymentApplyById(int id)
        {
            var query = from p in this._context.XMPaymentApplies
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseID"></param>
        /// <returns></returns>
        public XMPaymentApply GetXMPaymentApplyByPurchaseID(int purchaseID)
        {
            var query = from p in this._context.XMPaymentApplies
                        where p.IsEnable == false && p.PurchaseID == purchaseID
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 获取采购单对应的应付账单信息
        /// </summary>
        /// <param name="purchaseID"></param>
        /// <returns></returns>
        public List<XMPaymentApply> GetXMPaymentApplysByPurchaseID(int purchaseID)
        {
            var query = from p in this._context.XMPaymentApplies
                        where p.IsEnable == false && p.PurchaseID == purchaseID
                        select p;
            return query.ToList();
        }

        public List<XMPaymentApply> GetXMPaymentApplyListByPurchaseID(int purchaseID)
        {
            var query = from p in this._context.XMPaymentApplies
                        where p.IsEnable == false && p.PurchaseID == purchaseID
                        select p;

            return query.ToList();
        }

        /// <summary>
        /// delete XMPaymentApply by Id
        /// </summary>
        /// <param name="Id">XMPaymentApply Id</param>
        public void DeleteXMPaymentApply(int id)
        {
            var xmpaymentapply = this.GetXMPaymentApplyById(id);
            if (xmpaymentapply == null)
                return;

            if (!this._context.IsAttached(xmpaymentapply))
                this._context.XMPaymentApplies.Attach(xmpaymentapply);

            this._context.DeleteObject(xmpaymentapply);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMPaymentApply by Id
        /// </summary>
        /// <param name="Ids">XMPaymentApply Id</param>
        public void BatchDeleteXMPaymentApply(List<int> ids)
        {
            var query = from q in _context.XMPaymentApplies
                        where ids.Contains(q.Id) && q.IsEnable == false
                        select q;
            var xmpaymentapplys = query.ToList();
            foreach (var item in xmpaymentapplys)
            {
                if (!_context.IsAttached(item))
                    _context.XMPaymentApplies.Attach(item);

                _context.XMPaymentApplies.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
