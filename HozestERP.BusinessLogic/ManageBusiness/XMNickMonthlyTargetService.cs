
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-12-22 09:49:10
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMNickMonthlyTargetService : IXMNickMonthlyTargetService
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
        public XMNickMonthlyTargetService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMNickMonthlyTargetService成员
        /// <summary>
        /// Insert into XMNickMonthlyTarget
        /// </summary>
        /// <param name="xmnickmonthlytarget">XMNickMonthlyTarget</param>
        public void InsertXMNickMonthlyTarget(XMNickMonthlyTarget xmnickmonthlytarget)
        {
            if (xmnickmonthlytarget == null)
                return;

            if (!this._context.IsAttached(xmnickmonthlytarget))

                this._context.XMNickMonthlyTargets.AddObject(xmnickmonthlytarget);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMNickMonthlyTarget
        /// </summary>
        /// <param name="xmnickmonthlytarget">XMNickMonthlyTarget</param>
        public void UpdateXMNickMonthlyTarget(XMNickMonthlyTarget xmnickmonthlytarget)
        {
            if (xmnickmonthlytarget == null)
                return;

            if (this._context.IsAttached(xmnickmonthlytarget))
                this._context.XMNickMonthlyTargets.Attach(xmnickmonthlytarget);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMNickMonthlyTarget list
        /// </summary>
        public List<XMNickMonthlyTarget> GetXMNickMonthlyTargetList()
        {
            var query = from p in this._context.XMNickMonthlyTargets
                        where p.IsEnable == false
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }

        public List<XMNickMonthlyTarget> GetXMNickMonthlyTargetListByAudit(DateTime begin, DateTime end)
        {
            var query = from p in this._context.XMNickMonthlyTargets
                        where p.IsEnable == false
                        && p.IsAudit == true
                        && p.DateTime >= begin
                        && p.DateTime < end
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据店铺ID 年份 查询月度目标值
        /// </summary>
        /// <param name="year"></param>
        /// <param name="nickID"></param>
        /// <returns></returns>
        public List<XMNickMonthlyTarget> GetXMNickMonthlyTargetListByYear(int year, int nickID)
        {
            var query = from p in this._context.XMNickMonthlyTargets
                        where p.IsEnable == false
                        && p.DateTime.Year == year && p.NickId == nickID
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }



        /// <summary>
        /// get to XMNickMonthlyTarget Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMNickMonthlyTarget Page List</returns>
        public PagedList<XMNickMonthlyTarget> SearchXMNickMonthlyTarget(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMNickMonthlyTargets
                        where p.IsEnable == false
                        orderby p.ID
                        select p;
            return new PagedList<XMNickMonthlyTarget>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMNickMonthlyTarget by ID
        /// </summary>
        /// <param name="id">XMNickMonthlyTarget ID</param>
        /// <returns>XMNickMonthlyTarget</returns>   
        public XMNickMonthlyTarget GetXMNickMonthlyTargetByID(int id)
        {
            var query = from p in this._context.XMNickMonthlyTargets
                        where p.ID.Equals(id) && p.IsEnable == false
                        orderby p.CreateDate descending
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMNickMonthlyTarget by ID
        /// </summary>
        /// <param name="ID">XMNickMonthlyTarget ID</param>
        public void DeleteXMNickMonthlyTarget(int id)
        {
            var xmnickmonthlytarget = this.GetXMNickMonthlyTargetByID(id);
            if (xmnickmonthlytarget == null)
                return;

            if (!this._context.IsAttached(xmnickmonthlytarget))
                this._context.XMNickMonthlyTargets.Attach(xmnickmonthlytarget);

            this._context.DeleteObject(xmnickmonthlytarget);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMNickMonthlyTarget by ID
        /// </summary>
        /// <param name="IDs">XMNickMonthlyTarget ID</param>
        public void BatchDeleteXMNickMonthlyTarget(List<int> ids)
        {
            var query = from q in _context.XMNickMonthlyTargets
                        where ids.Contains(q.ID)
                        select q;
            var xmnickmonthlytargets = query.ToList();
            foreach (var item in xmnickmonthlytargets)
            {
                if (!_context.IsAttached(item))
                    _context.XMNickMonthlyTargets.Attach(item);

                _context.XMNickMonthlyTargets.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
