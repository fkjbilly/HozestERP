
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
    public partial class XMFinancialFieldService : IXMFinancialFieldService
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
        public XMFinancialFieldService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMFinancialFieldService成员
        /// <summary>
        /// Insert into XMFinancialField
        /// </summary>
        /// <param name="xmfinancialfield">XMFinancialField</param>
        public void InsertXMFinancialField(XMFinancialField xmfinancialfield)
        {
            if (xmfinancialfield == null)
                return;

            if (!this._context.IsAttached(xmfinancialfield))

                this._context.XMFinancialFields.AddObject(xmfinancialfield);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMFinancialField
        /// </summary>
        /// <param name="xmfinancialfield">XMFinancialField</param>
        public void UpdateXMFinancialField(XMFinancialField xmfinancialfield)
        {
            if (xmfinancialfield == null)
                return;

            if (this._context.IsAttached(xmfinancialfield))
                this._context.XMFinancialFields.Attach(xmfinancialfield);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMFinancialField list
        /// </summary>
        public List<XMFinancialField> GetXMFinancialFieldList()
        {
            var query = from p in this._context.XMFinancialFields
                        where p.Deleted == false
                        select p;
            return query.ToList();
        }

        public List<XMFinancialField> GetBudgetSettingListByData(string Name)
        {
            var query = from p in this._context.XMFinancialFields
                        where p.Deleted == false
                        && p.ParentID == 70//营业费用
                        && p.FieldName.Contains(Name)
                        select p;
            return query.ToList();
        }

        public XMFinancialField GetBudgetSettingByID(int id)
        {
            var query = from p in this._context.XMFinancialFields
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// get to XMFinancialField Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMFinancialField Page List</returns>
        public PagedList<XMFinancialField> SearchXMFinancialField(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMFinancialFields
                        where p.Deleted == false
                        orderby p.Id
                        select p;
            return new PagedList<XMFinancialField>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
        /// <summary>
        /// 根据父节点ID查询
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public List<XMFinancialField> GetXMFinancialFieldByParentID(int parentID)
        {
            var query = from p in this._context.XMFinancialFields
                        where p.ParentID == parentID 
                        && p.Deleted == false
                        orderby p.DisplayOrder
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 查询综管部预算字段集合
        /// </summary>
        /// <returns></returns>
        public List<XMFinancialField> GetXMManagerFinancialFileldList()
        {
            var query = from p in this._context.XMFinancialFields
                        where p.IsManagementField == true && p.Deleted == false
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 根据父节点ID 查询综管部子节点
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<XMFinancialField> GetXMMangerFinancialFieldListByParentID(int parentId)
        {
            var query = from p in this._context.XMFinancialFields
                        where p.IsManagementField == true
                        && p.ParentID == parentId
                        && p.Deleted == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 删除字段信息
        /// </summary>
        /// <param name="id">XM_FinancialField identifier</param>
        public void MarkFieldAsDeleted(int id)
        {
            var field = GetXMFinancialFieldById(id);
            if (field != null)
            {
                field.Deleted = true;
                UpdateXMFinancialField(field);
            }
        }

        /// <summary>
        /// get a XMFinancialField by Id
        /// </summary>
        /// <param name="id">XMFinancialField Id</param>
        /// <returns>XMFinancialField</returns>   
        public XMFinancialField GetXMFinancialFieldById(int id)
        {
            var query = from p in this._context.XMFinancialFields
                        where p.Id.Equals(id) && p.Deleted == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// delete XMFinancialField by Id
        /// </summary>
        /// <param name="Id">XMFinancialField Id</param>
        public void DeleteXMFinancialField(int id)
        {
            var xmfinancialfield = this.GetXMFinancialFieldById(id);
            if (xmfinancialfield == null)
                return;

            if (!this._context.IsAttached(xmfinancialfield))
                this._context.XMFinancialFields.Attach(xmfinancialfield);

            this._context.DeleteObject(xmfinancialfield);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMFinancialField by Id
        /// </summary>
        /// <param name="Ids">XMFinancialField Id</param>
        public void BatchDeleteXMFinancialField(List<int> ids)
        {
            var query = from q in _context.XMFinancialFields
                        where ids.Contains(q.Id) && q.Deleted == false
                        select q;
            var xmfinancialfields = query.ToList();
            foreach (var item in xmfinancialfields)
            {
                if (!_context.IsAttached(item))
                    _context.XMFinancialFields.Attach(item);

                _context.XMFinancialFields.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
