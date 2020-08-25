
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-01-04 17:32:53
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
    public partial class XMNickAchieveValueService : IXMNickAchieveValueService
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
        public XMNickAchieveValueService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMNickAchieveValueService成员
        /// <summary>
        /// Insert into XMNickAchieveValue
        /// </summary>
        /// <param name="xmnickachievevalue">XMNickAchieveValue</param>
        public void InsertXMNickAchieveValue(XMNickAchieveValue xmnickachievevalue)
        {
            if (xmnickachievevalue == null)
                return;

            if (!this._context.IsAttached(xmnickachievevalue))

                this._context.XMNickAchieveValue.AddObject(xmnickachievevalue);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMNickAchieveValue
        /// </summary>
        /// <param name="xmnickachievevalue">XMNickAchieveValue</param>
        public void UpdateXMNickAchieveValue(XMNickAchieveValue xmnickachievevalue)
        {
            if (xmnickachievevalue == null)
                return;

            if (this._context.IsAttached(xmnickachievevalue))
                this._context.XMNickAchieveValue.Attach(xmnickachievevalue);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMNickAchieveValue list
        /// </summary>
        public List<XMNickAchieveValue> GetXMNickAchieveValueList()
        {
            var query = from p in this._context.XMNickAchieveValue
                        where p.IsEnable == false
                        orderby  p.CreateDate descending
                        select p;
            return query.ToList();
        }

        public List<XMNickAchieveValue> GetXMNickAchieveValueListByData(List<int> nickIds, DateTime? OrderInfoModifiedStart, DateTime? OrderInfoModifiedEnd)
        {
            var query = from p in this._context.XMNickAchieveValue
                        where p.IsEnable == false
                        && nickIds.Contains(p.NickId)
                        && p.DateTime >= OrderInfoModifiedStart
                        && p.DateTime <= OrderInfoModifiedEnd
                        orderby p.CreateDate descending
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NickID"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int GetXMNickAchieveValueListAll(int NickID, DateTime dateTime)
        {
            var query = from p in this._context.XMNickAchieveValue
                        where p.IsEnable == false && p.NickId == NickID
                         && p.DateTime.Equals(dateTime)
                        select p;
            return query.Count();
        }


        /// <summary>
        /// get to XMNickAchieveValue Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XM_NickAchieveValue Page List</returns>
        public PagedList<XMNickAchieveValue> SearchXMNickAchieveValue(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMNickAchieveValue
                        where p.IsEnable == false
                        orderby p.Id
                        select p;
            return new PagedList<XMNickAchieveValue>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMNickAchieveValue by Id
        /// </summary>
        /// <param name="id">XMNickAchieveValue Id</param>
        /// <returns>XMNickAchieveValue</returns>   
        public XMNickAchieveValue GetXMNickAchieveValueById(int id)
        {
            var query = from p in this._context.XMNickAchieveValue
                        where p.Id.Equals(id) && p.IsEnable == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMNickAchieveValue by Id
        /// </summary>
        /// <param name="Id">XMNickAchieveValue Id</param>
        public void DeleteXMNickAchieveValue(int id)
        {
            var xmnickachievevalue = this.GetXMNickAchieveValueById(id);
            if (xmnickachievevalue == null)
                return;

            if (!this._context.IsAttached(xmnickachievevalue))
                this._context.XMNickAchieveValue.Attach(xmnickachievevalue);

            this._context.DeleteObject(xmnickachievevalue);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMNickAchieveValue by Id
        /// </summary>
        /// <param name="Ids">XMNickAchieveValue Id</param>
        public void BatchDeleteXMNickAchieveValue(List<int> ids)
        {
            var query = from q in _context.XMNickAchieveValue
                        where ids.Contains(q.Id)
                        select q;
            var xm_nickachievevalues = query.ToList();
            foreach (var item in xm_nickachievevalues)
            {
                if (!_context.IsAttached(item))
                    _context.XMNickAchieveValue.Attach(item);

                _context.XMNickAchieveValue.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
