
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
    public partial class XMAllocateProductDetailsService: IXMAllocateProductDetailsService
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
    	public XMAllocateProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMAllocateProductDetailsService成员
        /// <summary>
        /// Insert into XMAllocateProductDetails
        /// </summary>
        /// <param name="xmallocateproductdetails">XMAllocateProductDetails</param>
    	public void InsertXMAllocateProductDetails(XMAllocateProductDetails xmallocateproductdetails)
    	{	
            if (xmallocateproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmallocateproductdetails))
    			
                this._context.XMAllocateProductDetails.AddObject(xmallocateproductdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMAllocateProductDetails
        /// </summary>
        /// <param name="xmallocateproductdetails">XMAllocateProductDetails</param>
        public void UpdateXMAllocateProductDetails(XMAllocateProductDetails xmallocateproductdetails)
        {
            if (xmallocateproductdetails == null)
                return;
    
            if (this._context.IsAttached(xmallocateproductdetails))
                this._context.XMAllocateProductDetails.Attach(xmallocateproductdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMAllocateProductDetails list
        /// </summary>
        public List<XMAllocateProductDetails> GetXMAllocateProductDetailsList()
        {		
            var query = from p in this._context.XMAllocateProductDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMAllocateProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMAllocateProductDetails Page List</returns>
        public PagedList<XMAllocateProductDetails> SearchXMAllocateProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMAllocateProductDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMAllocateProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMAllocateProductDetails by Id
        /// </summary>
        /// <param name="id">XMAllocateProductDetails Id</param>
        /// <returns>XMAllocateProductDetails</returns>   
        public XMAllocateProductDetails GetXMAllocateProductDetailsById(int id)
        {
            var query = from p in this._context.XMAllocateProductDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMAllocateProductDetails by Id
        /// </summary>
        /// <param name="Id">XMAllocateProductDetails Id</param>
        public void DeleteXMAllocateProductDetails(int id)
        {
            var xmallocateproductdetails = this.GetXMAllocateProductDetailsById(id);
            if (xmallocateproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmallocateproductdetails))
                this._context.XMAllocateProductDetails.Attach(xmallocateproductdetails);
    
            this._context.DeleteObject(xmallocateproductdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMAllocateProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMAllocateProductDetails Id</param>
        public void BatchDeleteXMAllocateProductDetails(List<int> ids)
        {
    	   var query = from q in _context.XMAllocateProductDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmallocateproductdetailss = query.ToList();
            foreach (var item in xmallocateproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMAllocateProductDetails.Attach(item);  
    
                _context.XMAllocateProductDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
