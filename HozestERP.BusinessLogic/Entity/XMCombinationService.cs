
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:28:32
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

namespace HozestERP.BusinessLogic.Entity
{
    public partial class XMCombinationService: IXMCombinationService
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
    	public XMCombinationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMCombinationService成员
        /// <summary>
        /// Insert into XMCombination
        /// </summary>
        /// <param name="xmcombination">XMCombination</param>
    	public void InsertXMCombination(XMCombination xmcombination)
    	{	
            if (xmcombination == null)
                return;
    
            if (!this._context.IsAttached(xmcombination))
    			
                this._context.XMCombinations.AddObject(xmcombination);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMCombination
        /// </summary>
        /// <param name="xmcombination">XMCombination</param>
        public void UpdateXMCombination(XMCombination xmcombination)
        {
            if (xmcombination == null)
                return;
    
            if (this._context.IsAttached(xmcombination))
                this._context.XMCombinations.Attach(xmcombination);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMCombination list
        /// </summary>
        public List<XMCombination> GetXMCombinationList()
        {		
            var query = from p in this._context.XMCombinations
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMCombination Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMCombination Page List</returns>
        public PagedList<XMCombination> SearchXMCombination(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMCombinations
                        orderby p.ID
                        select p;
            return new PagedList<XMCombination>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMCombination by ID
        /// </summary>
        /// <param name="id">XMCombination ID</param>
        /// <returns>XMCombination</returns>   
        public XMCombination GetXMCombinationByID(int id)
        {
            var query = from p in this._context.XMCombinations
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMCombination by ID
        /// </summary>
        /// <param name="ID">XMCombination ID</param>
        public void DeleteXMCombination(int id)
        {
            var xmcombination = this.GetXMCombinationByID(id);
            if (xmcombination == null)
                return;
    
            if (!this._context.IsAttached(xmcombination))
                this._context.XMCombinations.Attach(xmcombination);
    
            this._context.DeleteObject(xmcombination);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMCombination by ID
        /// </summary>
        /// <param name="IDs">XMCombination ID</param>
        public void BatchDeleteXMCombination(List<int> ids)
        {
    	   var query = from q in _context.XMCombinations
                    where ids.Contains(q.ID)
                    select q;
            var xmcombinations = query.ToList();
            foreach (var item in xmcombinations)
            {
                if (!_context.IsAttached(item))
                    _context.XMCombinations.Attach(item);  
    
                _context.XMCombinations.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
