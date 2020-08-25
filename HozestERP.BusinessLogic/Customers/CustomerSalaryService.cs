
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人: 樊开健
** 创建日期:2015-12-02 10:57:07
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
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.Customers
{
    public partial class CustomerSalaryService: ICustomerSalaryService
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
    	public CustomerSalaryService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region ICustomerSalaryService成员
        /// <summary>
        /// Insert into CustomerSalary
        /// </summary>
        /// <param name="customersalary">CustomerSalary</param>
    	public void InsertCustomerSalary(CustomerSalary customersalary)
    	{	
            if (customersalary == null)
                return;
    
            if (!this._context.IsAttached(customersalary))
    			
                this._context.CustomerSalaries.AddObject(customersalary);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into CustomerSalary
        /// </summary>
        /// <param name="customersalary">CustomerSalary</param>
        public void UpdateCustomerSalary(CustomerSalary customersalary)
        {
            if (customersalary == null)
                return;
    
            if (this._context.IsAttached(customersalary))
                this._context.CustomerSalaries.Attach(customersalary);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to CustomerSalary list
        /// </summary>
        public List<CustomerSalary> GetCustomerSalaryList()
        {		
            var query = from p in this._context.CustomerSalaries
                        select p;
            return query.ToList();
        }

        public List<CustomerSalaryAll> GetCustomerSalaryListByData(int DepartmentID, string FullName, int Year, int Month)
        {
            var query = from p in this._context.CustomerSalaries
                        join info in this._context.CustomerInfoes
                        on p.CustomerInfoID equals info.CustomerID
                        where p.Year == Year
                        && p.Month == Month
                        && info.FullName.Contains(FullName)
                        //&& info.Deleted == false
                        && (DepartmentID == -1 || info.DepartmentID == DepartmentID)
                        select new CustomerSalaryAll
                        {
                            ID = p.ID,
                            FullName = info.FullName,
                            DepartmentID = info.DepartmentID,
                            IDNumber = info.IDNumber,
                            GenderID = info.GenderID,
                            BasePay = p.BasePay,
                            MeritPay = p.MeritPay,
                            RealSalary = p.RealSalary,
                            CustomerInfoID = info.CustomerID,
                            ShouldSalary = p.ShouldSalary
                        };
            return query.ToList();
        }

        public List<CustomerSalaryAll> GetCustomerSalaryListByIDNumber(string IDNumber, int Year, int Month)
        {
            var query = from p in this._context.CustomerSalaries
                        join info in this._context.CustomerInfoes
                        on p.CustomerInfoID equals info.CustomerID
                        where p.Year == Year
                        && p.Month == Month
                        && info.IDNumber == IDNumber
                        select new CustomerSalaryAll
                        {
                            ID = p.ID,
                            CustomerInfoID = info.CustomerID,
                            FullName = info.FullName,
                            DepartmentID = info.DepartmentID,
                            IDNumber = info.IDNumber,
                            GenderID = info.GenderID,
                            BasePay = p.BasePay,
                            MeritPay = p.MeritPay,
                            RealSalary = p.RealSalary
                        };
            return query.ToList();
        }

        public List<Department> GetDepartmentIDByID(int DepartmentID)
        {
            var query = from p in this._context.Departments
                        where p.ParentID == DepartmentID
                        && !p.Deleted
                        select p;
            return query.ToList();
        }

        public List<CustomerRole> GetCustomerRoleIDByParentsID(int CustomerRoleID)
        {
            var query = from p in this._context.CustomerRoles
                        where p.ParentCustomerRoleID == CustomerRoleID
                        && !p.Deleted
                        select p;
            return query.ToList();
        }

        /// <summary>
        /// get to CustomerSalary Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>CustomerSalary Page List</returns>
        public PagedList<CustomerSalary> SearchCustomerSalary(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.CustomerSalaries
                        orderby p.ID
                        select p;
            return new PagedList<CustomerSalary>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a CustomerSalary by ID
        /// </summary>
        /// <param name="id">CustomerSalary ID</param>
        /// <returns>CustomerSalary</returns>   
        public CustomerSalary GetCustomerSalaryByID(int id)
        {
            var query = from p in this._context.CustomerSalaries
                        where p.ID.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete CustomerSalary by ID
        /// </summary>
        /// <param name="ID">CustomerSalary ID</param>
        public void DeleteCustomerSalary(int id)
        {
            var customersalary = this.GetCustomerSalaryByID(id);
            if (customersalary == null)
                return;
    
            if (!this._context.IsAttached(customersalary))
                this._context.CustomerSalaries.Attach(customersalary);
    
            this._context.DeleteObject(customersalary);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete CustomerSalary by ID
        /// </summary>
        /// <param name="IDs">CustomerSalary ID</param>
        public void BatchDeleteCustomerSalary(List<int> ids)
        {
    	   var query = from q in _context.CustomerSalaries
                    where ids.Contains(q.ID)
                    select q;
            var customersalarys = query.ToList();
            foreach (var item in customersalarys)
            {
                if (!_context.IsAttached(item))
                    _context.CustomerSalaries.Attach(item);  
    
                _context.CustomerSalaries.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
