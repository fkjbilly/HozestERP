
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
    public partial class XMPurchaseProductDetailsService: IXMPurchaseProductDetailsService
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
    	public XMPurchaseProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPurchaseProductDetailsService成员
        /// <summary>
        /// Insert into XMPurchaseProductDetails
        /// </summary>
        /// <param name="xmpurchaseproductdetails">XMPurchaseProductDetails</param>
    	public void InsertXMPurchaseProductDetails(XMPurchaseProductDetails xmpurchaseproductdetails)
    	{	
            if (xmpurchaseproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmpurchaseproductdetails))
    			
                this._context.XMPurchaseProductDetails.AddObject(xmpurchaseproductdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPurchaseProductDetails
        /// </summary>
        /// <param name="xmpurchaseproductdetails">XMPurchaseProductDetails</param>
        public void UpdateXMPurchaseProductDetails(XMPurchaseProductDetails xmpurchaseproductdetails)
        {
            if (xmpurchaseproductdetails == null)
                return;
    
            if (this._context.IsAttached(xmpurchaseproductdetails))
                this._context.XMPurchaseProductDetails.Attach(xmpurchaseproductdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPurchaseProductDetails list
        /// </summary>
        public List<XMPurchaseProductDetails> GetXMPurchaseProductDetailsList()
        {		
            var query = from p in this._context.XMPurchaseProductDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMPurchaseProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPurchaseProductDetails Page List</returns>
        public PagedList<XMPurchaseProductDetails> SearchXMPurchaseProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPurchaseProductDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMPurchaseProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMPurchaseProductDetails by Id
        /// </summary>
        /// <param name="id">XMPurchaseProductDetails Id</param>
        /// <returns>XMPurchaseProductDetails</returns>   
        public XMPurchaseProductDetails GetXMPurchaseProductDetailsById(int id)
        {
            var query = from p in this._context.XMPurchaseProductDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPurchaseProductDetails by Id
        /// </summary>
        /// <param name="Id">XMPurchaseProductDetails Id</param>
        public void DeleteXMPurchaseProductDetails(int id)
        {
            var xmpurchaseproductdetails = this.GetXMPurchaseProductDetailsById(id);
            if (xmpurchaseproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmpurchaseproductdetails))
                this._context.XMPurchaseProductDetails.Attach(xmpurchaseproductdetails);
    
            this._context.DeleteObject(xmpurchaseproductdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPurchaseProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMPurchaseProductDetails Id</param>
        public void BatchDeleteXMPurchaseProductDetails(List<int> ids)
        {
    	   var query = from q in _context.XMPurchaseProductDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmpurchaseproductdetailss = query.ToList();
            foreach (var item in xmpurchaseproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMPurchaseProductDetails.Attach(item);  
    
                _context.XMPurchaseProductDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
