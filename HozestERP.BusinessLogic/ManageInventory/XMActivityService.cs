
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-07-14 10:23:29
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
    public partial class XMActivityService : IXMActivityService
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
        public XMActivityService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMActivityService成员
        /// <summary>
        /// Insert into XMActivity
        /// </summary>
        /// <param name="xmactivity">XMActivity</param>
        public void InsertXMActivity(XMActivity xmactivity)
        {
            if (xmactivity == null)
                return;

            if (!this._context.IsAttached(xmactivity))

                this._context.XMActivities.AddObject(xmactivity);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMActivity
        /// </summary>
        /// <param name="xmactivity">XMActivity</param>
        public void UpdateXMActivity(XMActivity xmactivity)
        {
            if (xmactivity == null)
                return;

            if (this._context.IsAttached(xmactivity))
                this._context.XMActivities.Attach(xmactivity);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMActivity list
        /// </summary>
        public List<XMActivity> GetXMActivityList()
        {
            var query = from p in this._context.XMActivities
                        where p.IsEnable == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityTypeID"></param>
        /// <returns></returns>
        public List<XMActivity> GetXMActivityListByactivityTypeID(int activityTypeID)
        {
            var query = from p in this._context.XMActivities
                        where p.IsEnable == false
                        && p.ActivityTypeID == activityTypeID
                        select p;
            return query.ToList();
        }

        /// <summary>
        ///  get to XMActivity list by parm
        /// </summary>
        /// <param name="activityTypeID"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public List<XMActivity> GetXMActivityListByParm(int activityTypeID, string begin, string end, string productName, int projectID, int nickID)
        {
            DateTime BeginTime = DateTime.Now;
            DateTime EndTime = DateTime.Now;
            if (begin != "" && end != "")
            {
                BeginTime = DateTime.Parse(begin);
                EndTime = DateTime.Parse(end);
            }
            var query = from p in this._context.XMActivities
                        join m in this._context.XMProducts
                         on p.ProductId equals m.Id
                        where p.IsEnable == false
                        && (activityTypeID == -1 || p.ActivityTypeID == activityTypeID)
                           && ((begin == "" && end == "") || (p.ActivityDate >= BeginTime && p.ActivityDate < EndTime))
                           && (productName == "" || m.ProductName.Contains(productName))
                           && (projectID == -1 || p.ProjectId == projectID)
                           && (nickID == -1 || p.NickId == nickID)
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMActivity Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMActivity Page List</returns>
        public PagedList<XMActivity> SearchXMActivity(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMActivities
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMActivity>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMActivity by Id
        /// </summary>
        /// <param name="id">XMActivity Id</param>
        /// <returns>XMActivity</returns>   
        public XMActivity GetXMActivityById(int id)
        {
            var query = from p in this._context.XMActivities
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="activtyDate"></param>
        /// <param name="platformMerchantCode"></param>
        /// <returns></returns>
        public XMActivity GetXMActivityByParm(DateTime activtyDate, string platformMerchantCode)
        {
            var query = from p in this._context.XMActivities
                        where p.IsEnable == false
                        && p.ActivityDate == activtyDate
                        && p.PlatformMerchantCode == platformMerchantCode
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMActivity by Id
        /// </summary>
        /// <param name="Id">XMActivity Id</param>
        public void DeleteXMActivity(int id)
        {
            var xmactivity = this.GetXMActivityById(id);
            if (xmactivity == null)
                return;

            if (!this._context.IsAttached(xmactivity))
                this._context.XMActivities.Attach(xmactivity);

            this._context.DeleteObject(xmactivity);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMActivity by Id
        /// </summary>
        /// <param name="Ids">XMActivity Id</param>
        public void BatchDeleteXMActivity(List<int> ids)
        {
            var query = from q in _context.XMActivities
                        where ids.Contains(q.Id)
                        select q;
            var xmactivitys = query.ToList();
            foreach (var item in xmactivitys)
            {
                if (!_context.IsAttached(item))
                    _context.XMActivities.Attach(item);

                _context.XMActivities.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
