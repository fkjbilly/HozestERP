
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
    public partial class XMDeliveryDetailsService: IXMDeliveryDetailsService
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
    	public XMDeliveryDetailsService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMDeliveryDetailsService成员
        /// <summary>
        /// Insert into XMDeliveryDetails
        /// </summary>
        /// <param name="xmdeliverydetails">XMDeliveryDetails</param>
    	public void InsertXMDeliveryDetails(XMDeliveryDetails xmdeliverydetails)
    	{	
            if (xmdeliverydetails == null)
                return;
    
            if (!this._context.IsAttached(xmdeliverydetails))
    			
                this._context.XMDeliveryDetails.AddObject(xmdeliverydetails);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMDeliveryDetails
        /// </summary>
        /// <param name="xmdeliverydetails">XMDeliveryDetails</param>
        public void UpdateXMDeliveryDetails(XMDeliveryDetails xmdeliverydetails)
        {
            if (xmdeliverydetails == null)
                return;
    
            if (this._context.IsAttached(xmdeliverydetails))
                this._context.XMDeliveryDetails.Attach(xmdeliverydetails);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMDeliveryDetails list
        /// </summary>
        public List<XMDeliveryDetails> GetXMDeliveryDetailsList()
        {		
            var query = from p in this._context.XMDeliveryDetails
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMDeliveryDetails Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMDeliveryDetails Page List</returns>
        public PagedList<XMDeliveryDetails> SearchXMDeliveryDetails(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMDeliveryDetails
                        orderby p.Id
                        select p;
            return new PagedList<XMDeliveryDetails>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMDeliveryDetails by Id
        /// </summary>
        /// <param name="id">XMDeliveryDetails Id</param>
        /// <returns>XMDeliveryDetails</returns>   
        public XMDeliveryDetails GetXMDeliveryDetailsById(int id)
        {
            var query = from p in this._context.XMDeliveryDetails
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMDeliveryDetails by Id
        /// </summary>
        /// <param name="Id">XMDeliveryDetails Id</param>
        public void DeleteXMDeliveryDetails(int id)
        {
            var xmdeliverydetails = this.GetXMDeliveryDetailsById(id);
            if (xmdeliverydetails == null)
                return;
    
            if (!this._context.IsAttached(xmdeliverydetails))
                this._context.XMDeliveryDetails.Attach(xmdeliverydetails);
    
            this._context.DeleteObject(xmdeliverydetails);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMDeliveryDetails by Id
        /// </summary>
        /// <param name="Ids">XMDeliveryDetails Id</param>
        public void BatchDeleteXMDeliveryDetails(List<int> ids)
        {
    	   var query = from q in _context.XMDeliveryDetails
                    where ids.Contains(q.Id)
                    select q;
            var xmdeliverydetailss = query.ToList();
            foreach (var item in xmdeliverydetailss)
            {
                if (!_context.IsAttached(item))
                    _context.XMDeliveryDetails.Attach(item);  
    
                _context.XMDeliveryDetails.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
