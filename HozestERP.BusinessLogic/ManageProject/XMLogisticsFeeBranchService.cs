
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-07-27 15:27:46
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
using System.Linq.Expressions;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMLogisticsFeeBranchService: IXMLogisticsFeeBranchService
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
    	public XMLogisticsFeeBranchService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion

    	
        #region IXMLogisticsFeeBranchService成员
        /// <summary>
        /// Insert into XMLogisticsFeeBranch
        /// </summary>
        /// <param name="xmlogisticsfeebranch">XMLogisticsFeeBranch</param>
    	public void InsertXMLogisticsFeeBranch(XMLogisticsFeeBranch xmlogisticsfeebranch)
    	{	
            if (xmlogisticsfeebranch == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticsfeebranch))
    			
                this._context.XMLogisticsFeeBranches.AddObject(xmlogisticsfeebranch);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMLogisticsFeeBranch
        /// </summary>
        /// <param name="xmlogisticsfeebranch">XMLogisticsFeeBranch</param>
        public void UpdateXMLogisticsFeeBranch(XMLogisticsFeeBranch xmlogisticsfeebranch)
        {
            if (xmlogisticsfeebranch == null)
                return;
    
            if (this._context.IsAttached(xmlogisticsfeebranch))
                this._context.XMLogisticsFeeBranches.Attach(xmlogisticsfeebranch);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMLogisticsFeeBranch list
        /// </summary>
        public IQueryable<XMLogisticsFeeBranchNew> GetXMLogisticsFeeBranchList()
        {
            var query = from p in this._context.XMLogisticsFeeBranches
                        join a in _context.XMProjects on p.ProjectID equals a.Id into temp
                        from ap in temp.DefaultIfEmpty()
                        select new XMLogisticsFeeBranchNew()
                        {
                            ID=p.ID,
                            Project = ap.ProjectName,
                            ProductCategoryID= (int)p.ProductCategoryID,
                            LogisticsID=(int)p.LogisticsID,
                            Fee=(decimal)p.Fee,
                        };
            return query;
        }
    
    	
        /// <summary>
        /// get to XMLogisticsFeeBranch Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMLogisticsFeeBranch Page List</returns>
        public PagedList<XMLogisticsFeeBranch> SearchXMLogisticsFeeBranch(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMLogisticsFeeBranches
                        orderby p.ID
                        select p;
            return new PagedList<XMLogisticsFeeBranch>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMLogisticsFeeBranch by ID
        /// </summary>
        /// <param name="id">XMLogisticsFeeBranch ID</param>
        /// <returns>XMLogisticsFeeBranch</returns>   
        public XMLogisticsFeeBranch GetXMLogisticsFeeBranchByID(int id)
        {
            var query = from p in this._context.XMLogisticsFeeBranches
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMLogisticsFeeBranch by ID
        /// </summary>
        /// <param name="ID">XMLogisticsFeeBranch ID</param>
        public void DeleteXMLogisticsFeeBranch(int id, bool flag)
        {
            var xmlogisticsfeebranch = this.GetXMLogisticsFeeBranchByID(id);
            if (xmlogisticsfeebranch == null)
                return;
    
            if (!this._context.IsAttached(xmlogisticsfeebranch))
                this._context.XMLogisticsFeeBranches.Attach(xmlogisticsfeebranch);
    
            this._context.DeleteObject(xmlogisticsfeebranch);

            if(flag)
            {
                this._context.SaveChanges();
            }
        }
    	
    	/// <summary>
        /// Batch delete XMLogisticsFeeBranch by ID
        /// </summary>
        /// <param name="IDs">XMLogisticsFeeBranch ID</param>
        public void BatchDeleteXMLogisticsFeeBranch(List<int> ids)
        {
    	   var query = from q in _context.XMLogisticsFeeBranches
                    where ids.Contains(q.ID)
                    select q;
            var xmlogisticsfeebranchs = query.ToList();
            foreach (var item in xmlogisticsfeebranchs)
            {
                if (!_context.IsAttached(item))
                    _context.XMLogisticsFeeBranches.Attach(item);  
    
                _context.XMLogisticsFeeBranches.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        public XMLogisticsFeeBranch getSingle(Expression<Func<XMLogisticsFeeBranch, bool>> predicate)
        {
            XMLogisticsFeeBranch entity = _context.XMLogisticsFeeBranches.FirstOrDefault(predicate);
            return entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #endregion

    }
}
