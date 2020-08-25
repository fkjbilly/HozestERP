
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
    public partial class XMNickIncludeAdveringFieldService : IXMNickIncludeAdveringFieldService
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
        public XMNickIncludeAdveringFieldService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMNickIncludeAdveringFieldService成员
        /// <summary>
        /// Insert into XMNickIncludeAdveringField
        /// </summary>
        /// <param name="xmnickincludeadveringfield">XMNickIncludeAdveringField</param>
        public void InsertXMNickIncludeAdveringField(XMNickIncludeAdveringField xmnickincludeadveringfield)
        {
            if (xmnickincludeadveringfield == null)
                return;

            if (!this._context.IsAttached(xmnickincludeadveringfield))

                this._context.XMNickIncludeAdveringFields.AddObject(xmnickincludeadveringfield);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMNickIncludeAdveringField
        /// </summary>
        /// <param name="xmnickincludeadveringfield">XMNickIncludeAdveringField</param>
        public void UpdateXMNickIncludeAdveringField(XMNickIncludeAdveringField xmnickincludeadveringfield)
        {
            if (xmnickincludeadveringfield == null)
                return;

            if (this._context.IsAttached(xmnickincludeadveringfield))
                this._context.XMNickIncludeAdveringFields.Attach(xmnickincludeadveringfield);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMNickIncludeAdveringField list
        /// </summary>
        public List<XMNickIncludeAdveringField> GetXMNickIncludeAdveringFieldList()
        {
            var query = from p in this._context.XMNickIncludeAdveringFields
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMNickIncludeAdveringField Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMNickIncludeAdveringField Page List</returns>
        public PagedList<XMNickIncludeAdveringField> SearchXMNickIncludeAdveringField(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMNickIncludeAdveringFields
                        orderby p.Id
                        select p;
            return new PagedList<XMNickIncludeAdveringField>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMNickIncludeAdveringField by Id
        /// </summary>
        /// <param name="id">XMNickIncludeAdveringField Id</param>
        /// <returns>XMNickIncludeAdveringField</returns>   
        public XMNickIncludeAdveringField GetXMNickIncludeAdveringFieldById(int id)
        {
            var query = from p in this._context.XMNickIncludeAdveringFields
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// get a XMNickIncludeAdveringField by nickId
        /// </summary>
        /// <param name="nickId">店铺ID</param>
        /// <returns></returns>
        public XMNickIncludeAdveringField GetXMNickIncludeAdvertingFieldByNickID(int nickId)
        {
            var query = from p in this._context.XMNickIncludeAdveringFields
                        where p.NickId.Equals(nickId)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMNickIncludeAdveringField by Id
        /// </summary>
        /// <param name="Id">XMNickIncludeAdveringField Id</param>
        public void DeleteXMNickIncludeAdveringField(int id)
        {
            var xmnickincludeadveringfield = this.GetXMNickIncludeAdveringFieldById(id);
            if (xmnickincludeadveringfield == null)
                return;

            if (!this._context.IsAttached(xmnickincludeadveringfield))
                this._context.XMNickIncludeAdveringFields.Attach(xmnickincludeadveringfield);

            this._context.DeleteObject(xmnickincludeadveringfield);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMNickIncludeAdveringField by Id
        /// </summary>
        /// <param name="Ids">XMNickIncludeAdveringField Id</param>
        public void BatchDeleteXMNickIncludeAdveringField(List<int> ids)
        {
            var query = from q in _context.XMNickIncludeAdveringFields
                        where ids.Contains(q.Id)
                        select q;
            var xmnickincludeadveringfields = query.ToList();
            foreach (var item in xmnickincludeadveringfields)
            {
                if (!_context.IsAttached(item))
                    _context.XMNickIncludeAdveringFields.Attach(item);

                _context.XMNickIncludeAdveringFields.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
