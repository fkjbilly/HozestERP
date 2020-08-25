
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
    public partial class XMProductCombinationService: IXMProductCombinationService
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
    	public XMProductCombinationService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMProductCombinationService成员
        /// <summary>
        /// Insert into XMProductCombination
        /// </summary>
        /// <param name="xmproductcombination">XMProductCombination</param>
    	public void InsertXMProductCombination(XMProductCombination xmproductcombination)
    	{	
            if (xmproductcombination == null)
                return;
    
            if (!this._context.IsAttached(xmproductcombination))
    			
                this._context.XMProductCombinations.AddObject(xmproductcombination);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMProductCombination
        /// </summary>
        /// <param name="xmproductcombination">XMProductCombination</param>
        public void UpdateXMProductCombination(XMProductCombination xmproductcombination)
        {
            if (xmproductcombination == null)
                return;
    
            if (this._context.IsAttached(xmproductcombination))
                this._context.XMProductCombinations.Attach(xmproductcombination);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMProductCombination list
        /// </summary>
        public List<XMProductCombination> GetXMProductCombinationList()
        {		
            var query = from p in this._context.XMProductCombinations
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMProductCombination Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProductCombination Page List</returns>
        public PagedList<XMProductCombination> SearchXMProductCombination(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProductCombinations
                        orderby p.ID
                        select p;
            return new PagedList<XMProductCombination>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMProductCombination by ID
        /// </summary>
        /// <param name="id">XMProductCombination ID</param>
        /// <returns>XMProductCombination</returns>   
        public XMProductCombination GetXMProductCombinationByID(int id)
        {
            var query = from p in this._context.XMProductCombinations
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMProductCombination by ID
        /// </summary>
        /// <param name="ID">XMProductCombination ID</param>
        public void DeleteXMProductCombination(int id)
        {
            var xmproductcombination = this.GetXMProductCombinationByID(id);
            if (xmproductcombination == null)
                return;
    
            if (!this._context.IsAttached(xmproductcombination))
                this._context.XMProductCombinations.Attach(xmproductcombination);
    
            this._context.DeleteObject(xmproductcombination);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMProductCombination by ID
        /// </summary>
        /// <param name="IDs">XMProductCombination ID</param>
        public void BatchDeleteXMProductCombination(List<int> ids)
        {
    	   var query = from q in _context.XMProductCombinations
                    where ids.Contains(q.ID)
                    select q;
            var xmproductcombinations = query.ToList();
            foreach (var item in xmproductcombinations)
            {
                if (!_context.IsAttached(item))
                    _context.XMProductCombinations.Attach(item);  
    
                _context.XMProductCombinations.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
