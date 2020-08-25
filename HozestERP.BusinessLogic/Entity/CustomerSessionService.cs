
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
    public partial class CustomerSessionService: ICustomerSessionService
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
    	public CustomerSessionService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICustomerSessionService成员
        /// <summary>
        /// Insert into CustomerSession
        /// </summary>
        /// <param name="customersession">CustomerSession</param>
    	public void InsertCustomerSession(CustomerSession customersession)
    	{	
            if (customersession == null)
                return;
    
            if (!this._context.IsAttached(customersession))
    			
                this._context.CustomerSessions.AddObject(customersession);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CustomerSession
        /// </summary>
        /// <param name="customersession">CustomerSession</param>
        public void UpdateCustomerSession(CustomerSession customersession)
        {
            if (customersession == null)
                return;
    
            if (this._context.IsAttached(customersession))
                this._context.CustomerSessions.Attach(customersession);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CustomerSession list
        /// </summary>
        public List<CustomerSession> GetCustomerSessionList()
        {		
            var query = from p in this._context.CustomerSessions
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CustomerSession Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CustomerSession Page List</returns>
        public PagedList<CustomerSession> SearchCustomerSession(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CustomerSessions
                        orderby p.CustomerSessionGUID
                        select p;
            return new PagedList<CustomerSession>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CustomerSession by CustomerSessionGUID
        /// </summary>
        /// <param name="customersessionguid">CustomerSession CustomerSessionGUID</param>
        /// <returns>CustomerSession</returns>   
        public CustomerSession GetCustomerSessionByCustomerSessionGUID(System.Guid customersessionguid)
        {
            var query = from p in this._context.CustomerSessions
                        where p.CustomerSessionGUID.Equals(customersessionguid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CustomerSession by CustomerSessionGUID
        /// </summary>
        /// <param name="CustomerSessionGUID">CustomerSession CustomerSessionGUID</param>
        public void DeleteCustomerSession(System.Guid customersessionguid)
        {
            var customersession = this.GetCustomerSessionByCustomerSessionGUID(customersessionguid);
            if (customersession == null)
                return;
    
            if (!this._context.IsAttached(customersession))
                this._context.CustomerSessions.Attach(customersession);
    
            this._context.DeleteObject(customersession);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CustomerSession by CustomerSessionGUID
        /// </summary>
        /// <param name="CustomerSessionGUIDs">CustomerSession CustomerSessionGUID</param>
        public void BatchDeleteCustomerSession(List<System.Guid> customersessionguids)
        {
    	   var query = from q in _context.CustomerSessions
                    where customersessionguids.Contains(q.CustomerSessionGUID)
                    select q;
            var customersessions = query.ToList();
            foreach (var item in customersessions)
            {
                if (!_context.IsAttached(item))
                    _context.CustomerSessions.Attach(item);  
    
                _context.CustomerSessions.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
