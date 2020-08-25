
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
    public partial class XMOrderInfoProductDetailsService: IXMOrderInfoProductDetailsService
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
    	public XMOrderInfoProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMOrderInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMOrderInfoProductDetails
        /// </summary>
        /// <param name="xmorderinfoproductdetails">XMOrderInfoProductDetails</param>
    	public void InsertXMOrderInfoProductDetails(XMOrderInfoProductDetails xmorderinfoproductdetails)
    	{	
            if (xmorderinfoproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmorderinfoproductdetails))
    			
                this._context.XMOrderInfoProductDetails.AddObject(xmorderinfoproductdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMOrderInfoProductDetails
        /// </summary>
        /// <param name="xmorderinfoproductdetails">XMOrderInfoProductDetails</param>
        public void UpdateXMOrderInfoProductDetails(XMOrderInfoProductDetails xmorderinfoproductdetails)
        {
            if (xmorderinfoproductdetails == null)
                return;
    
            if (this._context.IsAttached(xmorderinfoproductdetails))
                this._context.XMOrderInfoProductDetails.Attach(xmorderinfoproductdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMOrderInfoProductDetails list
        /// </summary>
        public List<XMOrderInfoProductDetails> GetXMOrderInfoProductDetailsList()
        {		
            var query = from p in this._context.XMOrderInfoProductDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMOrderInfoProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMOrderInfoProductDetails Page List</returns>
        public PagedList<XMOrderInfoProductDetails> SearchXMOrderInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMOrderInfoProductDetails
                        orderby p.ID
                        select p;
            return new PagedList<XMOrderInfoProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="id">XMOrderInfoProductDetails ID</param>
        /// <returns>XMOrderInfoProductDetails</returns>   
        public XMOrderInfoProductDetails GetXMOrderInfoProductDetailsByID(int id)
        {
            var query = from p in this._context.XMOrderInfoProductDetails
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="ID">XMOrderInfoProductDetails ID</param>
        public void DeleteXMOrderInfoProductDetails(int id)
        {
            var xmorderinfoproductdetails = this.GetXMOrderInfoProductDetailsByID(id);
            if (xmorderinfoproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmorderinfoproductdetails))
                this._context.XMOrderInfoProductDetails.Attach(xmorderinfoproductdetails);
    
            this._context.DeleteObject(xmorderinfoproductdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMOrderInfoProductDetails by ID
        /// </summary>
        /// <param name="IDs">XMOrderInfoProductDetails ID</param>
        public void BatchDeleteXMOrderInfoProductDetails(List<int> ids)
        {
    	   var query = from q in _context.XMOrderInfoProductDetails
                    where ids.Contains(q.ID)
                    select q;
            var xmorderinfoproductdetailss = query.ToList();
            foreach (var item in xmorderinfoproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMOrderInfoProductDetails.Attach(item);  
    
                _context.XMOrderInfoProductDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
