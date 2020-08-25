
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
    public partial class XMPurchaseService: IXMPurchaseService
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
    	public XMPurchaseService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPurchaseService成员
        /// <summary>
        /// Insert into XMPurchase
        /// </summary>
        /// <param name="xmpurchase">XMPurchase</param>
    	public void InsertXMPurchase(XMPurchase xmpurchase)
    	{	
            if (xmpurchase == null)
                return;
    
            if (!this._context.IsAttached(xmpurchase))
    			
                this._context.XMPurchases.AddObject(xmpurchase);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPurchase
        /// </summary>
        /// <param name="xmpurchase">XMPurchase</param>
        public void UpdateXMPurchase(XMPurchase xmpurchase)
        {
            if (xmpurchase == null)
                return;
    
            if (this._context.IsAttached(xmpurchase))
                this._context.XMPurchases.Attach(xmpurchase);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPurchase list
        /// </summary>
        public List<XMPurchase> GetXMPurchaseList()
        {		
            var query = from p in this._context.XMPurchases
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMPurchase Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPurchase Page List</returns>
        public PagedList<XMPurchase> SearchXMPurchase(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPurchases
                        orderby p.Id
                        select p;
            return new PagedList<XMPurchase>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMPurchase by Id
        /// </summary>
        /// <param name="id">XMPurchase Id</param>
        /// <returns>XMPurchase</returns>   
        public XMPurchase GetXMPurchaseById(int id)
        {
            var query = from p in this._context.XMPurchases
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPurchase by Id
        /// </summary>
        /// <param name="Id">XMPurchase Id</param>
        public void DeleteXMPurchase(int id)
        {
            var xmpurchase = this.GetXMPurchaseById(id);
            if (xmpurchase == null)
                return;
    
            if (!this._context.IsAttached(xmpurchase))
                this._context.XMPurchases.Attach(xmpurchase);
    
            this._context.DeleteObject(xmpurchase);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPurchase by Id
        /// </summary>
        /// <param name="Ids">XMPurchase Id</param>
        public void BatchDeleteXMPurchase(List<int> ids)
        {
    	   var query = from q in _context.XMPurchases
                    where ids.Contains(q.Id)
                    select q;
            var xmpurchases = query.ToList();
            foreach (var item in xmpurchases)
            {
                if (!_context.IsAttached(item))
                    _context.XMPurchases.Attach(item);  
    
                _context.XMPurchases.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
