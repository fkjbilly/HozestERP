
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
    public partial class XMPurchaseRejectedService: IXMPurchaseRejectedService
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
    	public XMPurchaseRejectedService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMPurchaseRejectedService成员
        /// <summary>
        /// Insert into XMPurchaseRejected
        /// </summary>
        /// <param name="xmpurchaserejected">XMPurchaseRejected</param>
    	public void InsertXMPurchaseRejected(XMPurchaseRejected xmpurchaserejected)
    	{	
            if (xmpurchaserejected == null)
                return;
    
            if (!this._context.IsAttached(xmpurchaserejected))
    			
                this._context.XMPurchaseRejecteds.AddObject(xmpurchaserejected);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMPurchaseRejected
        /// </summary>
        /// <param name="xmpurchaserejected">XMPurchaseRejected</param>
        public void UpdateXMPurchaseRejected(XMPurchaseRejected xmpurchaserejected)
        {
            if (xmpurchaserejected == null)
                return;
    
            if (this._context.IsAttached(xmpurchaserejected))
                this._context.XMPurchaseRejecteds.Attach(xmpurchaserejected);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMPurchaseRejected list
        /// </summary>
        public List<XMPurchaseRejected> GetXMPurchaseRejectedList()
        {		
            var query = from p in this._context.XMPurchaseRejecteds
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMPurchaseRejected Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMPurchaseRejected Page List</returns>
        public PagedList<XMPurchaseRejected> SearchXMPurchaseRejected(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMPurchaseRejecteds
                        orderby p.Id
                        select p;
            return new PagedList<XMPurchaseRejected>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMPurchaseRejected by Id
        /// </summary>
        /// <param name="id">XMPurchaseRejected Id</param>
        /// <returns>XMPurchaseRejected</returns>   
        public XMPurchaseRejected GetXMPurchaseRejectedById(int id)
        {
            var query = from p in this._context.XMPurchaseRejecteds
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMPurchaseRejected by Id
        /// </summary>
        /// <param name="Id">XMPurchaseRejected Id</param>
        public void DeleteXMPurchaseRejected(int id)
        {
            var xmpurchaserejected = this.GetXMPurchaseRejectedById(id);
            if (xmpurchaserejected == null)
                return;
    
            if (!this._context.IsAttached(xmpurchaserejected))
                this._context.XMPurchaseRejecteds.Attach(xmpurchaserejected);
    
            this._context.DeleteObject(xmpurchaserejected);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMPurchaseRejected by Id
        /// </summary>
        /// <param name="Ids">XMPurchaseRejected Id</param>
        public void BatchDeleteXMPurchaseRejected(List<int> ids)
        {
    	   var query = from q in _context.XMPurchaseRejecteds
                    where ids.Contains(q.Id)
                    select q;
            var xmpurchaserejecteds = query.ToList();
            foreach (var item in xmpurchaserejecteds)
            {
                if (!_context.IsAttached(item))
                    _context.XMPurchaseRejecteds.Attach(item);  
    
                _context.XMPurchaseRejecteds.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
