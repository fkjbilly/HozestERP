
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
    public partial class XMJDSaleRejectedService: IXMJDSaleRejectedService
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
    	public XMJDSaleRejectedService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMJDSaleRejectedService成员
        /// <summary>
        /// Insert into XMJDSaleRejected
        /// </summary>
        /// <param name="xmjdsalerejected">XMJDSaleRejected</param>
    	public void InsertXMJDSaleRejected(XMJDSaleRejected xmjdsalerejected)
    	{	
            if (xmjdsalerejected == null)
                return;
    
            if (!this._context.IsAttached(xmjdsalerejected))
    			
                this._context.XMJDSaleRejecteds.AddObject(xmjdsalerejected);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMJDSaleRejected
        /// </summary>
        /// <param name="xmjdsalerejected">XMJDSaleRejected</param>
        public void UpdateXMJDSaleRejected(XMJDSaleRejected xmjdsalerejected)
        {
            if (xmjdsalerejected == null)
                return;
    
            if (this._context.IsAttached(xmjdsalerejected))
                this._context.XMJDSaleRejecteds.Attach(xmjdsalerejected);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMJDSaleRejected list
        /// </summary>
        public List<XMJDSaleRejected> GetXMJDSaleRejectedList()
        {		
            var query = from p in this._context.XMJDSaleRejecteds
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMJDSaleRejected Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMJDSaleRejected Page List</returns>
        public PagedList<XMJDSaleRejected> SearchXMJDSaleRejected(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        orderby p.Id
                        select p;
            return new PagedList<XMJDSaleRejected>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMJDSaleRejected by Id
        /// </summary>
        /// <param name="id">XMJDSaleRejected Id</param>
        /// <returns>XMJDSaleRejected</returns>   
        public XMJDSaleRejected GetXMJDSaleRejectedById(int id)
        {
            var query = from p in this._context.XMJDSaleRejecteds
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMJDSaleRejected by Id
        /// </summary>
        /// <param name="Id">XMJDSaleRejected Id</param>
        public void DeleteXMJDSaleRejected(int id)
        {
            var xmjdsalerejected = this.GetXMJDSaleRejectedById(id);
            if (xmjdsalerejected == null)
                return;
    
            if (!this._context.IsAttached(xmjdsalerejected))
                this._context.XMJDSaleRejecteds.Attach(xmjdsalerejected);
    
            this._context.DeleteObject(xmjdsalerejected);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMJDSaleRejected by Id
        /// </summary>
        /// <param name="Ids">XMJDSaleRejected Id</param>
        public void BatchDeleteXMJDSaleRejected(List<int> ids)
        {
    	   var query = from q in _context.XMJDSaleRejecteds
                    where ids.Contains(q.Id)
                    select q;
            var xmjdsalerejecteds = query.ToList();
            foreach (var item in xmjdsalerejecteds)
            {
                if (!_context.IsAttached(item))
                    _context.XMJDSaleRejecteds.Attach(item);  
    
                _context.XMJDSaleRejecteds.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
