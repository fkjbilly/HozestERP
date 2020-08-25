
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-03-23 15:30:21
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

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMAdvertingFieldService : IXMAdvertingFieldService
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
        public XMAdvertingFieldService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMAdvertingFieldService成员
        /// <summary>
        /// Insert into XMAdvertingField
        /// </summary>
        /// <param name="xmadvertingfield">XMAdvertingField</param>
        public void InsertXMAdvertingField(XMAdvertingField xmadvertingfield)
        {
            if (xmadvertingfield == null)
                return;

            if (!this._context.IsAttached(xmadvertingfield))

                this._context.XMAdvertingFields.AddObject(xmadvertingfield);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMAdvertingField
        /// </summary>
        /// <param name="xmadvertingfield">XMAdvertingField</param>
        public void UpdateXMAdvertingField(XMAdvertingField xmadvertingfield)
        {
            if (xmadvertingfield == null)
                return;

            if (this._context.IsAttached(xmadvertingfield))
                this._context.XMAdvertingFields.Attach(xmadvertingfield);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMAdvertingField list
        /// </summary>
        public List<XMAdvertingField> GetXMAdvertingFieldList()
        {
            var query = from p in this._context.XMAdvertingFields
                        select p;
            return query.ToList();
        }


        /// <summary>
        /// get to XMAdvertingField Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAdvertingField Page List</returns>
        public PagedList<XMAdvertingField> SearchXMAdvertingField(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAdvertingFields
                        orderby p.Id
                        select p;
            return new PagedList<XMAdvertingField>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMAdvertingField by Id
        /// </summary>
        /// <param name="id">XMAdvertingField Id</param>
        /// <returns>XMAdvertingField</returns>   
        public XMAdvertingField GetXMAdvertingFieldById(int id)
        {
            var query = from p in this._context.XMAdvertingFields
                        where p.Id.Equals(id) && p.IsDelete == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMAdvertingField by Id
        /// </summary>
        /// <param name="Id">XMAdvertingField Id</param>
        public void DeleteXMAdvertingField(int id)
        {
            var xmadvertingfield = this.GetXMAdvertingFieldById(id);
            if (xmadvertingfield == null)
                return;

            if (!this._context.IsAttached(xmadvertingfield))
                this._context.XMAdvertingFields.Attach(xmadvertingfield);

            this._context.DeleteObject(xmadvertingfield);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMAdvertingField by Id
        /// </summary>
        /// <param name="Ids">XMAdvertingField Id</param>
        public void BatchDeleteXMAdvertingField(List<int> ids)
        {
            var query = from q in _context.XMAdvertingFields
                        where ids.Contains(q.Id)
                        select q;
            var xmadvertingfields = query.ToList();
            foreach (var item in xmadvertingfields)
            {
                if (!_context.IsAttached(item))
                    _context.XMAdvertingFields.Attach(item);

                _context.XMAdvertingFields.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
