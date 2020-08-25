
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
    public partial class XMSaleInfoService : IXMSaleInfoService
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
        public XMSaleInfoService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMSaleInfoService成员
        /// <summary>
        /// Insert into XMSaleInfo
        /// </summary>
        /// <param name="xmsaleinfo">XMSaleInfo</param>
        public void InsertXMSaleInfo(XMSaleInfo xmsaleinfo)
        {
            if (xmsaleinfo == null)
                return;

            if (!this._context.IsAttached(xmsaleinfo))

                this._context.XMSaleInfoes.AddObject(xmsaleinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMSaleInfo
        /// </summary>
        /// <param name="xmsaleinfo">XMSaleInfo</param>
        public void UpdateXMSaleInfo(XMSaleInfo xmsaleinfo)
        {
            if (xmsaleinfo == null)
                return;

            if (this._context.IsAttached(xmsaleinfo))
                this._context.XMSaleInfoes.Attach(xmsaleinfo);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMSaleInfo list
        /// </summary>
        public List<XMSaleInfo> GetXMSaleInfoList()
        {
            var query = from p in this._context.XMSaleInfoes
                        where p.IsEnable == false
                        orderby p.Id descending
                        select p;
            return query.ToList();
        }

        public List<XMSaleInfo> GetXMSaleInfoListByRef(string Ref)
        {
            var query = from p in this._context.XMSaleInfoes
                        where p.IsEnable == false
                        && p.Ref.Contains(Ref)
                        orderby p.Ref descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMSaleInfo Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMSaleInfo Page List</returns>
        public PagedList<XMSaleInfo> SearchXMSaleInfo(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMSaleInfoes
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMSaleInfo>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saleCode"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<XMSaleInfo> GetXMSaleInfoListByParm(string saleCode, string begin, string end, int status, string customerName, string customerids, int projectID)
        {
            int?[] customerIdlist = Array.ConvertAll<string, int?>(customerids.Split(','), delegate(string s) { return int.Parse(s); });
            DateTime purBeginTime = DateTime.Now;
            DateTime purEndTime = DateTime.Now;
            bool isAudit = false;
            if (status != -1)
            {
                isAudit = status == 0 ? false : true;
            }
            if (begin != "" && end != "")
            {
                purBeginTime = DateTime.Parse(begin);
                purEndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMSaleInfoes
                        where p.IsEnable == false
                        && ((begin == "" && end == "") || (p.BizDt >= purBeginTime && p.BizDt < purEndTime))
                        && (saleCode == "" || p.Ref.Contains(saleCode))
                         && (status == -1 || p.FinancialStatus == isAudit)
                         && (projectID == -1 || p.ProjectId == projectID)
                         && (customerName == "" || p.CustomerName.Contains(customerName))
                         && customerIdlist.Contains(p.BizUserId)
                        orderby p.BizDt descending
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// get a XMSaleInfo by Id
        /// </summary>
        /// <param name="id">XMSaleInfo Id</param>
        /// <returns>XMSaleInfo</returns>   
        public XMSaleInfo GetXMSaleInfoById(int id)
        {
            var query = from p in this._context.XMSaleInfoes
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMSaleInfo by Id
        /// </summary>
        /// <param name="Id">XMSaleInfo Id</param>
        public void DeleteXMSaleInfo(int id)
        {
            var xmsaleinfo = this.GetXMSaleInfoById(id);
            if (xmsaleinfo == null)
                return;

            if (!this._context.IsAttached(xmsaleinfo))
                this._context.XMSaleInfoes.Attach(xmsaleinfo);

            this._context.DeleteObject(xmsaleinfo);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMSaleInfo by Id
        /// </summary>
        /// <param name="Ids">XMSaleInfo Id</param>
        public void BatchDeleteXMSaleInfo(List<int> ids)
        {
            var query = from q in _context.XMSaleInfoes
                        where ids.Contains(q.Id)
                        select q;
            var xmsaleinfos = query.ToList();
            foreach (var item in xmsaleinfos)
            {
                if (!_context.IsAttached(item))
                    _context.XMSaleInfoes.Attach(item);

                _context.XMSaleInfoes.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
