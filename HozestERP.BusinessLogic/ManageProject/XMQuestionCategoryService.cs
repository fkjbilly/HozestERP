
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2016-04-08 09:49:03
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
    public partial class XMQuestionCategoryService : IXMQuestionCategoryService
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
        public XMQuestionCategoryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }

        #endregion

        #region IXMQuestionCategoryService成员
        /// <summary>
        /// Insert into XMQuestionCategory
        /// </summary>
        /// <param name="xmquestioncategory">XMQuestionCategory</param>
        public void InsertXMQuestionCategory(XMQuestionCategory xmquestioncategory)
        {
            if (xmquestioncategory == null)
                return;

            if (!this._context.IsAttached(xmquestioncategory))

                this._context.XMQuestionCategories.AddObject(xmquestioncategory);

            this._context.SaveChanges();
        }

        /// <summary>
        /// Update into XMQuestionCategory
        /// </summary>
        /// <param name="xmquestioncategory">XMQuestionCategory</param>
        public void UpdateXMQuestionCategory(XMQuestionCategory xmquestioncategory)
        {
            if (xmquestioncategory == null)
                return;

            if (this._context.IsAttached(xmquestioncategory))
                this._context.XMQuestionCategories.Attach(xmquestioncategory);

            this._context.SaveChanges();
        }

        /// <summary>
        /// get to XMQuestionCategory list
        /// </summary>
        public List<XMQuestionCategory> GetXMQuestionCategoryList()
        {
            var query = from p in this._context.XMQuestionCategories
                        select p;
            return query.ToList();
        }
        /// <summary>
        /// 查询所有为父节点的问题类型列表
        /// </summary>
        /// <returns></returns>
        public List<XMQuestionCategory> GetXMQuestionCategoryPrarentList(int parentId)
        {
            var query = from p in this._context.XMQuestionCategories
                        where p.ParentId == parentId && p.IsDeleted == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// 根据父节点ID 查询问题类型列表
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public List<XMQuestionCategory> GetXMQuestionCategoryByParentID(int parentID)
        {
            var query = from p in this._context.XMQuestionCategories
                        where p.ParentId == parentID && p.IsDeleted == false
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to XMQuestionCategory Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMQuestionCategory Page List</returns>
        public PagedList<XMQuestionCategory> SearchXMQuestionCategory(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMQuestionCategories
                        orderby p.Id
                        select p;
            return new PagedList<XMQuestionCategory>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }

        /// <summary>
        /// get a XMQuestionCategory by Id
        /// </summary>
        /// <param name="id">XMQuestionCategory Id</param>
        /// <returns>XMQuestionCategory</returns>   
        public XMQuestionCategory GetXMQuestionCategoryById(int id)
        {
            var query = from p in this._context.XMQuestionCategories
                        where p.Id.Equals(id) && p.IsDeleted == false
                        select p;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// 删除问题类型信息
        /// </summary>
        /// <param name="id">XM_FinancialField identifier</param>
        public void MarkQuestionCategoryAsDeleted(int id)
        {
            var category = GetXMQuestionCategoryById(id);
            if (category != null)
            {
                category.IsDeleted = true;
                UpdateXMQuestionCategory(category);
            }
        }

        /// <summary>
        /// delete XMQuestionCategory by Id
        /// </summary>
        /// <param name="Id">XMQuestionCategory Id</param>
        public void DeleteXMQuestionCategory(int id)
        {
            var xmquestioncategory = this.GetXMQuestionCategoryById(id);
            if (xmquestioncategory == null)
                return;

            if (!this._context.IsAttached(xmquestioncategory))
                this._context.XMQuestionCategories.Attach(xmquestioncategory);

            this._context.DeleteObject(xmquestioncategory);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Batch delete XMQuestionCategory by Id
        /// </summary>
        /// <param name="Ids">XMQuestionCategory Id</param>
        public void BatchDeleteXMQuestionCategory(List<int> ids)
        {
            var query = from q in _context.XMQuestionCategories
                        where ids.Contains(q.Id)
                        select q;
            var xmquestioncategorys = query.ToList();
            foreach (var item in xmquestioncategorys)
            {
                if (!_context.IsAttached(item))
                    _context.XMQuestionCategories.Attach(item);

                _context.XMQuestionCategories.DeleteObject(item);
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
