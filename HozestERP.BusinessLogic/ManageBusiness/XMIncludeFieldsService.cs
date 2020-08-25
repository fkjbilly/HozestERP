
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-02-29 09:08:41
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
    public partial class XMIncludeFieldsService : IXMIncludeFieldsService
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
        public XMIncludeFieldsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMIncludeFieldsService成员
        /// <summary>
        /// Insert into XMIncludeFields
        /// </summary>
        /// <param name="xmincludefields">XMIncludeFields</param>
        public void InsertXMIncludeFields(XMIncludeFields xmincludefields)
        {
            if (xmincludefields == null)
                return;

            if (!this._context.IsAttached(xmincludefields))

                this._context.XMIncludeFields.AddObject(xmincludefields);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMIncludeFields
        /// </summary>
        /// <param name="xmincludefields">XMIncludeFields</param>
        public void UpdateXMIncludeFields(XMIncludeFields xmincludefields)
        {
            if (xmincludefields == null)
                return;

            if (this._context.IsAttached(xmincludefields))
                this._context.XMIncludeFields.Attach(xmincludefields);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMIncludeFields list
        /// </summary>
        public List<XMIncludeFields> GetXMIncludeFieldsList()
        {
            var query = from p in this._context.XMIncludeFields
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public XMIncludeFields GetXMIncludeFieldsListByProjectID(int projectID)
        {
            var query = from p in this._context.XMIncludeFields
                        where p.ProjectId == projectID
                        select p;
            return query.SingleOrDefault();
        }
        /// <summary>
        /// 根据部门ID获取预算字段集合
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public XMIncludeFields GetXMIncludeFieldsListByDepartmentID(int departmentID)
        {
            var query = from p in this._context.XMIncludeFields
                        where p.DepartmentId == departmentID
                        select p;
            return query.SingleOrDefault();
        }

        public XMIncludeFields GetXMIncludeFieldsListByNickID(int nickID)
        {
            var query = from p in this._context.XMIncludeFields
                        where p.NickId== nickID
                        select p;
            return query.SingleOrDefault();
        }


        /// <summary>
        /// get to XMIncludeFields Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMIncludeFields Page List</returns>
        public PagedList<XMIncludeFields> SearchXMIncludeFields(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMIncludeFields
                        orderby p.Id
                        select p;
            return new PagedList<XMIncludeFields>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMIncludeFields by Id
        /// </summary>
        /// <param name="id">XMIncludeFields Id</param>
        /// <returns>XMIncludeFields</returns>   
        public XMIncludeFields GetXMIncludeFieldsById(int id)
        {
            var query = from p in this._context.XMIncludeFields
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMIncludeFields by Id
        /// </summary>
        /// <param name="Id">XMIncludeFields Id</param>
        public void DeleteXMIncludeFields(int id)
        {
            var xmincludefields = this.GetXMIncludeFieldsById(id);
            if (xmincludefields == null)
                return;

            if (!this._context.IsAttached(xmincludefields))
                this._context.XMIncludeFields.Attach(xmincludefields);

            this._context.DeleteObject(xmincludefields);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMIncludeFields by Id
        /// </summary>
        /// <param name="Ids">XMIncludeFields Id</param>
        public void BatchDeleteXMIncludeFields(List<int> ids)
        {
            var query = from q in _context.XMIncludeFields
                        where ids.Contains(q.Id)
                        select q;
            var xmincludefieldss = query.ToList();
            foreach (var item in xmincludefieldss)
            {
                if (!_context.IsAttached(item))
                    _context.XMIncludeFields.Attach(item);

                _context.XMIncludeFields.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
