
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
    public partial class XMNickCustomerMappingService: IXMNickCustomerMappingService
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
    	public XMNickCustomerMappingService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IXMNickCustomerMappingService成员
        /// <summary>
        /// Insert into XMNickCustomerMapping
        /// </summary>
        /// <param name="xmnickcustomermapping">XMNickCustomerMapping</param>
    	public void InsertXMNickCustomerMapping(XMNickCustomerMapping xmnickcustomermapping)
    	{	
            if (xmnickcustomermapping == null)
                return;
    
            if (!this._context.IsAttached(xmnickcustomermapping))
    			
                this._context.XMNickCustomerMappings.AddObject(xmnickcustomermapping);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into XMNickCustomerMapping
        /// </summary>
        /// <param name="xmnickcustomermapping">XMNickCustomerMapping</param>
        public void UpdateXMNickCustomerMapping(XMNickCustomerMapping xmnickcustomermapping)
        {
            if (xmnickcustomermapping == null)
                return;
    
            if (this._context.IsAttached(xmnickcustomermapping))
                this._context.XMNickCustomerMappings.Attach(xmnickcustomermapping);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to XMNickCustomerMapping list
        /// </summary>
        public List<XMNickCustomerMapping> GetXMNickCustomerMappingList()
        {		
            var query = from p in this._context.XMNickCustomerMappings
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to XMNickCustomerMapping Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>XMNickCustomerMapping Page List</returns>
        public PagedList<XMNickCustomerMapping> SearchXMNickCustomerMapping(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.XMNickCustomerMappings
                        orderby p.NickCustomerID
                        select p;
            return new PagedList<XMNickCustomerMapping>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="nickcustomerid">XMNickCustomerMapping NickCustomerID</param>
        /// <returns>XMNickCustomerMapping</returns>   
        public XMNickCustomerMapping GetXMNickCustomerMappingByNickCustomerID(int nickcustomerid)
        {
            var query = from p in this._context.XMNickCustomerMappings
                        where p.NickCustomerID.Equals(nickcustomerid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerID">XMNickCustomerMapping NickCustomerID</param>
        public void DeleteXMNickCustomerMapping(int nickcustomerid)
        {
            var xmnickcustomermapping = this.GetXMNickCustomerMappingByNickCustomerID(nickcustomerid);
            if (xmnickcustomermapping == null)
                return;
    
            if (!this._context.IsAttached(xmnickcustomermapping))
                this._context.XMNickCustomerMappings.Attach(xmnickcustomermapping);
    
            this._context.DeleteObject(xmnickcustomermapping);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete XMNickCustomerMapping by NickCustomerID
        /// </summary>
        /// <param name="NickCustomerIDs">XMNickCustomerMapping NickCustomerID</param>
        public void BatchDeleteXMNickCustomerMapping(List<int> nickcustomerids)
        {
    	   var query = from q in _context.XMNickCustomerMappings
                    where nickcustomerids.Contains(q.NickCustomerID)
                    select q;
            var xmnickcustomermappings = query.ToList();
            foreach (var item in xmnickcustomermappings)
            {
                if (!_context.IsAttached(item))
                    _context.XMNickCustomerMappings.Attach(item);  
    
                _context.XMNickCustomerMappings.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
