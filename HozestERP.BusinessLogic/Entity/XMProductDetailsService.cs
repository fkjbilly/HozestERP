
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
    public partial class XMProductDetailsService: IXMProductDetailsService
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
    	public XMProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMProductDetailsService成员
        /// <summary>
        /// Insert into XMProductDetails
        /// </summary>
        /// <param name="xmproductdetails">XMProductDetails</param>
    	public void InsertXMProductDetails(XMProductDetails xmproductdetails)
    	{	
            if (xmproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmproductdetails))
    			
                this._context.XMProductDetails.AddObject(xmproductdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMProductDetails
        /// </summary>
        /// <param name="xmproductdetails">XMProductDetails</param>
        public void UpdateXMProductDetails(XMProductDetails xmproductdetails)
        {
            if (xmproductdetails == null)
                return;
    
            if (this._context.IsAttached(xmproductdetails))
                this._context.XMProductDetails.Attach(xmproductdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMProductDetails list
        /// </summary>
        public List<XMProductDetails> GetXMProductDetailsList()
        {		
            var query = from p in this._context.XMProductDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMProductDetails Page List</returns>
        public PagedList<XMProductDetails> SearchXMProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMProductDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMProductDetails by Id
        /// </summary>
        /// <param name="id">XMProductDetails Id</param>
        /// <returns>XMProductDetails</returns>   
        public XMProductDetails GetXMProductDetailsById(int id)
        {
            var query = from p in this._context.XMProductDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMProductDetails by Id
        /// </summary>
        /// <param name="Id">XMProductDetails Id</param>
        public void DeleteXMProductDetails(int id)
        {
            var xmproductdetails = this.GetXMProductDetailsById(id);
            if (xmproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmproductdetails))
                this._context.XMProductDetails.Attach(xmproductdetails);
    
            this._context.DeleteObject(xmproductdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMProductDetails by Id
        /// </summary>
        /// <param name="Ids">XMProductDetails Id</param>
        public void BatchDeleteXMProductDetails(List<int> ids)
        {
    	   var query = from q in _context.XMProductDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmproductdetailss = query.ToList();
            foreach (var item in xmproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMProductDetails.Attach(item);  
    
                _context.XMProductDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
