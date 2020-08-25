
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
    public partial class XMStorageProductDetailsService: IXMStorageProductDetailsService
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
    	public XMStorageProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMStorageProductDetailsService成员
        /// <summary>
        /// Insert into XMStorageProductDetails
        /// </summary>
        /// <param name="xmstorageproductdetails">XMStorageProductDetails</param>
    	public void InsertXMStorageProductDetails(XMStorageProductDetails xmstorageproductdetails)
    	{	
            if (xmstorageproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmstorageproductdetails))
    			
                this._context.XMStorageProductDetails.AddObject(xmstorageproductdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMStorageProductDetails
        /// </summary>
        /// <param name="xmstorageproductdetails">XMStorageProductDetails</param>
        public void UpdateXMStorageProductDetails(XMStorageProductDetails xmstorageproductdetails)
        {
            if (xmstorageproductdetails == null)
                return;
    
            if (this._context.IsAttached(xmstorageproductdetails))
                this._context.XMStorageProductDetails.Attach(xmstorageproductdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMStorageProductDetails list
        /// </summary>
        public List<XMStorageProductDetails> GetXMStorageProductDetailsList()
        {		
            var query = from p in this._context.XMStorageProductDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMStorageProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMStorageProductDetails Page List</returns>
        public PagedList<XMStorageProductDetails> SearchXMStorageProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMStorageProductDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMStorageProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMStorageProductDetails by Id
        /// </summary>
        /// <param name="id">XMStorageProductDetails Id</param>
        /// <returns>XMStorageProductDetails</returns>   
        public XMStorageProductDetails GetXMStorageProductDetailsById(int id)
        {
            var query = from p in this._context.XMStorageProductDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMStorageProductDetails by Id
        /// </summary>
        /// <param name="Id">XMStorageProductDetails Id</param>
        public void DeleteXMStorageProductDetails(int id)
        {
            var xmstorageproductdetails = this.GetXMStorageProductDetailsById(id);
            if (xmstorageproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmstorageproductdetails))
                this._context.XMStorageProductDetails.Attach(xmstorageproductdetails);
    
            this._context.DeleteObject(xmstorageproductdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMStorageProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMStorageProductDetails Id</param>
        public void BatchDeleteXMStorageProductDetails(List<int> ids)
        {
    	   var query = from q in _context.XMStorageProductDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmstorageproductdetailss = query.ToList();
            foreach (var item in xmstorageproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMStorageProductDetails.Attach(item);  
    
                _context.XMStorageProductDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
