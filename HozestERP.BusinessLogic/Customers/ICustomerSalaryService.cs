
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-12-02 10:57:05
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
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.Customers
{
    public partial interface ICustomerSalaryService
    {
        #region ICustomerSalaryService成员
        /// <summary>
        /// Insert into CustomerSalary
        /// </summary>
        /// <param name="customersalary">CustomerSalary</param>
    	void InsertCustomerSalary(CustomerSalary customersalary);
    	
        /// <summary>
        /// Update into CustomerSalary
        /// </summary>
        /// <param name="customersalary">CustomerSalary</param>
        void UpdateCustomerSalary(CustomerSalary customersalary);	
    	
        /// <summary>
        /// get to CustomerSalary list
        /// </summary>
        List<CustomerSalary> GetCustomerSalaryList();

        List<CustomerSalaryAll> GetCustomerSalaryListByData(int DepartmentID, string FullName, int Year, int Month);
        List<CustomerSalaryAll> GetCustomerSalaryListByIDNumber(string IDNumber, int Year, int Month);
        List<Department> GetDepartmentIDByID(int DepartmentID);
        List<CustomerRole> GetCustomerRoleIDByParentsID(int CustomerRoleID);

    	/// <summary>
    	/// get to CustomerSalary Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CustomerSalary Page List</returns>
    	PagedList<CustomerSalary> SearchCustomerSalary(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CustomerSalary by ID
        /// </summary>
        /// <param name="id">CustomerSalary ID</param>
        /// <returns>CustomerSalary</returns>   
        CustomerSalary GetCustomerSalaryByID(int id);
    
    	/// <summary>
        /// delete CustomerSalary by ID
        /// </summary>
        /// <param name="ID">CustomerSalary ID</param>
        void DeleteCustomerSalary(int id);
    	
    	/// <summary>
        /// Batch delete CustomerSalary by ID
        /// </summary>
        /// <param name="IDs">CustomerSalary ID</param>
        void BatchDeleteCustomerSalary(List<int> ids);

        #endregion
    }
}
