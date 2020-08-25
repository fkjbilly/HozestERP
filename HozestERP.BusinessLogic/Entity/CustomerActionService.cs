
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
    public partial class CustomerActionService: ICustomerActionService
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
    	public CustomerActionService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICustomerActionService成员
        /// <summary>
        /// Insert into CustomerAction
        /// </summary>
        /// <param name="customeraction">CustomerAction</param>
    	public void InsertCustomerAction(CustomerAction customeraction)
    	{	
            if (customeraction == null)
                return;
    
            if (!this._context.IsAttached(customeraction))
    			
                this._context.CustomerActions.AddObject(customeraction);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CustomerAction
        /// </summary>
        /// <param name="customeraction">CustomerAction</param>
        public void UpdateCustomerAction(CustomerAction customeraction)
        {
            if (customeraction == null)
                return;
    
            if (this._context.IsAttached(customeraction))
                this._context.CustomerActions.Attach(customeraction);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CustomerAction list
        /// </summary>
        public List<CustomerAction> GetCustomerActionList()
        {		
            var query = from p in this._context.CustomerActions
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to CustomerAction Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CustomerAction Page List</returns>
        public PagedList<CustomerAction> SearchCustomerAction(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CustomerActions
                        orderby p.CustomerActionID
                        select p;
            return new PagedList<CustomerAction>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CustomerAction by CustomerActionID
        /// </summary>
        /// <param name="customeractionid">CustomerAction CustomerActionID</param>
        /// <returns>CustomerAction</returns>   
        public CustomerAction GetCustomerActionByCustomerActionID(int customeractionid)
        {
            var query = from p in this._context.CustomerActions
                        where p.CustomerActionID.Equals(customeractionid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CustomerAction by CustomerActionID
        /// </summary>
        /// <param name="CustomerActionID">CustomerAction CustomerActionID</param>
        public void DeleteCustomerAction(int customeractionid)
        {
            var customeraction = this.GetCustomerActionByCustomerActionID(customeractionid);
            if (customeraction == null)
                return;
    
            if (!this._context.IsAttached(customeraction))
                this._context.CustomerActions.Attach(customeraction);
    
            this._context.DeleteObject(customeraction);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CustomerAction by CustomerActionID
        /// </summary>
        /// <param name="CustomerActionIDs">CustomerAction CustomerActionID</param>
        public void BatchDeleteCustomerAction(List<int> customeractionids)
        {
    	   var query = from q in _context.CustomerActions
                    where customeractionids.Contains(q.CustomerActionID)
                    select q;
            var customeractions = query.ToList();
            foreach (var item in customeractions)
            {
                if (!_context.IsAttached(item))
                    _context.CustomerActions.Attach(item);  
    
                _context.CustomerActions.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
