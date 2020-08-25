
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
    public partial class XMClaimInfoProductDetailsService: IXMClaimInfoProductDetailsService
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
    	public XMClaimInfoProductDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMClaimInfoProductDetailsService成员
        /// <summary>
        /// Insert into XMClaimInfoProductDetails
        /// </summary>
        /// <param name="xmclaiminfoproductdetails">XMClaimInfoProductDetails</param>
    	public void InsertXMClaimInfoProductDetails(XMClaimInfoProductDetails xmclaiminfoproductdetails)
    	{	
            if (xmclaiminfoproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmclaiminfoproductdetails))
    			
                this._context.XMClaimInfoProductDetails.AddObject(xmclaiminfoproductdetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMClaimInfoProductDetails
        /// </summary>
        /// <param name="xmclaiminfoproductdetails">XMClaimInfoProductDetails</param>
        public void UpdateXMClaimInfoProductDetails(XMClaimInfoProductDetails xmclaiminfoproductdetails)
        {
            if (xmclaiminfoproductdetails == null)
                return;
    
            if (this._context.IsAttached(xmclaiminfoproductdetails))
                this._context.XMClaimInfoProductDetails.Attach(xmclaiminfoproductdetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMClaimInfoProductDetails list
        /// </summary>
        public List<XMClaimInfoProductDetails> GetXMClaimInfoProductDetailsList()
        {		
            var query = from p in this._context.XMClaimInfoProductDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMClaimInfoProductDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMClaimInfoProductDetails Page List</returns>
        public PagedList<XMClaimInfoProductDetails> SearchXMClaimInfoProductDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMClaimInfoProductDetails
                        orderby p.ID
                        select p;
            return new PagedList<XMClaimInfoProductDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMClaimInfoProductDetails by ID
        /// </summary>
        /// <param name="id">XMClaimInfoProductDetails ID</param>
        /// <returns>XMClaimInfoProductDetails</returns>   
        public XMClaimInfoProductDetails GetXMClaimInfoProductDetailsByID(int id)
        {
            var query = from p in this._context.XMClaimInfoProductDetails
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMClaimInfoProductDetails by ID
        /// </summary>
        /// <param name="ID">XMClaimInfoProductDetails ID</param>
        public void DeleteXMClaimInfoProductDetails(int id)
        {
            var xmclaiminfoproductdetails = this.GetXMClaimInfoProductDetailsByID(id);
            if (xmclaiminfoproductdetails == null)
                return;
    
            if (!this._context.IsAttached(xmclaiminfoproductdetails))
                this._context.XMClaimInfoProductDetails.Attach(xmclaiminfoproductdetails);
    
            this._context.DeleteObject(xmclaiminfoproductdetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMClaimInfoProductDetails by ID
        /// </summary>
        /// <param name="IDs">XMClaimInfoProductDetails ID</param>
        public void BatchDeleteXMClaimInfoProductDetails(List<int> ids)
        {
    	   var query = from q in _context.XMClaimInfoProductDetails
                    where ids.Contains(q.ID)
                    select q;
            var xmclaiminfoproductdetailss = query.ToList();
            foreach (var item in xmclaiminfoproductdetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMClaimInfoProductDetails.Attach(item);  
    
                _context.XMClaimInfoProductDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
