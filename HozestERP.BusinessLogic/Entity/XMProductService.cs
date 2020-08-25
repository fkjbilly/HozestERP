
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
    public partial class XMProductService: IXMProductService
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
    	public XMProductService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMProductService成员
        /// <summary>
        /// Insert into XMProduct
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
    	public void InsertXMProduct(XMProduct xmproduct)
    	{	
            if (xmproduct == null)
                return;
    
            if (!this._context.IsAttached(xmproduct))
    			
                this._context.XMProducts.AddObject(xmproduct);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMProduct
        /// </summary>
        /// <param name="xmproduct">XMProduct</param>
        public void UpdateXMProduct(XMProduct xmproduct)
        {
            if (xmproduct == null)
                return;
    
            if (this._context.IsAttached(xmproduct))
                this._context.XMProducts.Attach(xmproduct);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMProduct list
        /// </summary>
        public List<XMProduct> GetXMProductList()
        {		
            var query = from p in this._context.XMProducts
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMProduct Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProduct Page List</returns>
        public PagedList<XMProduct> SearchXMProduct(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProducts
                        orderby p.Id
                        select p;
            return new PagedList<XMProduct>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMProduct by Id
        /// </summary>
        /// <param name="id">XMProduct Id</param>
        /// <returns>XMProduct</returns>   
        public XMProduct GetXMProductById(int id)
        {
            var query = from p in this._context.XMProducts
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMProduct by Id
        /// </summary>
        /// <param name="Id">XMProduct Id</param>
        public void DeleteXMProduct(int id)
        {
            var xmproduct = this.GetXMProductById(id);
            if (xmproduct == null)
                return;
    
            if (!this._context.IsAttached(xmproduct))
                this._context.XMProducts.Attach(xmproduct);
    
            this._context.DeleteObject(xmproduct);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMProduct by Id
        /// </summary>
        /// <param name="Ids">XMProduct Id</param>
        public void BatchDeleteXMProduct(List<int> ids)
        {
    	   var query = from q in _context.XMProducts
                    where ids.Contains(q.Id)
                    select q;
            var xmproducts = query.ToList();
            foreach (var item in xmproducts)
            {
                if (!_context.IsAttached(item))
                    _context.XMProducts.Attach(item);  
    
                _context.XMProducts.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
