
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
    public partial class XMPurchaseRejectedProductDetailsService: IXMPurchaseRejectedProductDetailsService
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
    	public XMPurchaseRejectedProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPurchaseRejectedProductDetailsService成员
        /// <summary>
        /// Insert into XMPurchaseRejectedProductDetails
        /// </summary>
        /// <param name="xmpurchaserejectedproductdetails">XMPurchaseRejectedProductDetails</param>
    	public void InsertXMPurchaseRejectedProductDetails(XMPurchaseRejectedProductDetails xmpurchaserejectedproductdetails)
    	{	
            if (xmpurchaserejectedproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmpurchaserejectedproductdetails))
    			
                this._context.XMPurchaseRejectedProductDetails.AddObject(xmpurchaserejectedproductdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPurchaseRejectedProductDetails
        /// </summary>
        /// <param name="xmpurchaserejectedproductdetails">XMPurchaseRejectedProductDetails</param>
        public void UpdateXMPurchaseRejectedProductDetails(XMPurchaseRejectedProductDetails xmpurchaserejectedproductdetails)
        {
            if (xmpurchaserejectedproductdetails == null)
                return;
    
            if (this._context.IsAttached(xmpurchaserejectedproductdetails))
                this._context.XMPurchaseRejectedProductDetails.Attach(xmpurchaserejectedproductdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPurchaseRejectedProductDetails list
        /// </summary>
        public List<XMPurchaseRejectedProductDetails> GetXMPurchaseRejectedProductDetailsList()
        {		
            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMPurchaseRejectedProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPurchaseRejectedProductDetails Page List</returns>
        public PagedList<XMPurchaseRejectedProductDetails> SearchXMPurchaseRejectedProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMPurchaseRejectedProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMPurchaseRejectedProductDetails by Id
        /// </summary>
        /// <param name="id">XMPurchaseRejectedProductDetails Id</param>
        /// <returns>XMPurchaseRejectedProductDetails</returns>   
        public XMPurchaseRejectedProductDetails GetXMPurchaseRejectedProductDetailsById(int id)
        {
            var query = from p in this._context.XMPurchaseRejectedProductDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPurchaseRejectedProductDetails by Id
        /// </summary>
        /// <param name="Id">XMPurchaseRejectedProductDetails Id</param>
        public void DeleteXMPurchaseRejectedProductDetails(int id)
        {
            var xmpurchaserejectedproductdetails = this.GetXMPurchaseRejectedProductDetailsById(id);
            if (xmpurchaserejectedproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmpurchaserejectedproductdetails))
                this._context.XMPurchaseRejectedProductDetails.Attach(xmpurchaserejectedproductdetails);
    
            this._context.DeleteObject(xmpurchaserejectedproductdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPurchaseRejectedProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMPurchaseRejectedProductDetails Id</param>
        public void BatchDeleteXMPurchaseRejectedProductDetails(List<int> ids)
        {
    	   var query = from q in _context.XMPurchaseRejectedProductDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmpurchaserejectedproductdetailss = query.ToList();
            foreach (var item in xmpurchaserejectedproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMPurchaseRejectedProductDetails.Attach(item);  
    
                _context.XMPurchaseRejectedProductDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
