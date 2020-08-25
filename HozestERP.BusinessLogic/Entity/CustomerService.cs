
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
    public partial class CustomerService: ICustomerService
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
    	public CustomerService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICustomerService成员
        /// <summary>
        /// Insert into Customer
        /// </summary>
        /// <param name="customer">Customer</param>
    	public void InsertCustomer(Customer customer)
    	{	
            if (customer == null)
                return;
    
            if (!this._context.IsAttached(customer))
    			
                this._context.Customers.AddObject(customer);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                return;
    
            if (this._context.IsAttached(customer))
                this._context.Customers.Attach(customer);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Customer list
        /// </summary>
        public List<Customer> GetCustomerList()
        {		
            var query = from p in this._context.Customers
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Customer Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Customer Page List</returns>
        public PagedList<Customer> SearchCustomer(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Customers
                        orderby p.CustomerID
                        select p;
            return new PagedList<Customer>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Customer by CustomerID
        /// </summary>
        /// <param name="customerid">Customer CustomerID</param>
        /// <returns>Customer</returns>   
        public Customer GetCustomerByCustomerID(int customerid)
        {
            var query = from p in this._context.Customers
                        where p.CustomerID.Equals(customerid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Customer by CustomerID
        /// </summary>
        /// <param name="CustomerID">Customer CustomerID</param>
        public void DeleteCustomer(int customerid)
        {
            var customer = this.GetCustomerByCustomerID(customerid);
            if (customer == null)
                return;
    
            if (!this._context.IsAttached(customer))
                this._context.Customers.Attach(customer);
    
            this._context.DeleteObject(customer);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Customer by CustomerID
        /// </summary>
        /// <param name="CustomerIDs">Customer CustomerID</param>
        public void BatchDeleteCustomer(List<int> customerids)
        {
    	   var query = from q in _context.Customers
                    where customerids.Contains(q.CustomerID)
                    select q;
            var customers = query.ToList();
            foreach (var item in customers)
            {
                if (!_context.IsAttached(item))
                    _context.Customers.Attach(item);  
    
                _context.Customers.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
