
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2017-04-26 15:27:57
** 修改人:
** 修改日期:
** 描 述: 接口类
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
    public partial interface ICustomerService
    {
        #region ICustomerService成员
        /// <summary>
        /// Insert into Customer
        /// </summary>
        /// <param name="customer">Customer</param>
    	void InsertCustomer(Customer customer);
    	
        /// <summary>
        /// Update into Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        void UpdateCustomer(Customer customer);	
    	
        /// <summary>
        /// get to Customer list
        /// </summary>
        List<Customer> GetCustomerList();
    	       
    	/// <summary>
    	/// get to Customer Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Customer Page List</returns>
    	PagedList<Customer> SearchCustomer(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Customer by CustomerID
        /// </summary>
        /// <param name="customerid">Customer CustomerID</param>
        /// <returns>Customer</returns>   
        Customer GetCustomerByCustomerID(int customerid);
    
    	/// <summary>
        /// delete Customer by CustomerID
        /// </summary>
        /// <param name="CustomerID">Customer CustomerID</param>
        void DeleteCustomer(int customerid);
    	
    	/// <summary>
        /// Batch delete Customer by CustomerID
        /// </summary>
        /// <param name="CustomerIDs">Customer CustomerID</param>
        void BatchDeleteCustomer(List<int> customerids);

        #endregion
    }
}
