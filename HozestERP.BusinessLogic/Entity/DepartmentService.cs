
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
    public partial class DepartmentService: IDepartmentService
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
    	public DepartmentService(HozestERPObjectContext context)
        {
            this._context = context;
            this._cacheManager = new HozestERPRequestCache();
        }
    	
        #endregion
    	
        #region IDepartmentService成员
        /// <summary>
        /// Insert into Department
        /// </summary>
        /// <param name="department">Department</param>
    	public void InsertDepartment(Department department)
    	{	
            if (department == null)
                return;
    
            if (!this._context.IsAttached(department))
    			
                this._context.Departments.AddObject(department);
    
            this._context.SaveChanges();
    	}
    		
        /// <summary>
        /// Update into Department
        /// </summary>
        /// <param name="department">Department</param>
        public void UpdateDepartment(Department department)
        {
            if (department == null)
                return;
    
            if (this._context.IsAttached(department))
                this._context.Departments.Attach(department);
    
            this._context.SaveChanges();
        }
    	
        /// <summary>
        /// get to Department list
        /// </summary>
        public List<Department> GetDepartmentList()
        {		
            var query = from p in this._context.Departments
                        select p;
            return query.ToList();
        }
    
    	
        /// <summary>
        /// get to Department Page List
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">返回记录数</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序规则</param>
        /// <returns>Department Page List</returns>
        public PagedList<Department> SearchDepartment(int pageIndex, int pageSize, string sortExpression, string sortDirection)
        {
            var query = from p in this._context.Departments
                        orderby p.DepartmentID
                        select p;
            return new PagedList<Department>(query, pageIndex, pageSize, sortExpression, sortDirection);
        }
    
    	/// <summary>
        /// get a Department by DepartmentID
        /// </summary>
        /// <param name="departmentid">Department DepartmentID</param>
        /// <returns>Department</returns>   
        public Department GetDepartmentByDepartmentID(int departmentid)
        {
            var query = from p in this._context.Departments
                        where p.DepartmentID.Equals(departmentid)
                        select p;
            return query.SingleOrDefault();
        }
    
    	/// <summary>
        /// delete Department by DepartmentID
        /// </summary>
        /// <param name="DepartmentID">Department DepartmentID</param>
        public void DeleteDepartment(int departmentid)
        {
            var department = this.GetDepartmentByDepartmentID(departmentid);
            if (department == null)
                return;
    
            if (!this._context.IsAttached(department))
                this._context.Departments.Attach(department);
    
            this._context.DeleteObject(department);
            this._context.SaveChanges();
        }
    	
    	/// <summary>
        /// Batch delete Department by DepartmentID
        /// </summary>
        /// <param name="DepartmentIDs">Department DepartmentID</param>
        public void BatchDeleteDepartment(List<int> departmentids)
        {
    	   var query = from q in _context.Departments
                    where departmentids.Contains(q.DepartmentID)
                    select q;
            var departments = query.ToList();
            foreach (var item in departments)
            {
                if (!_context.IsAttached(item))
                    _context.Departments.Attach(item);  
    
                _context.Departments.DeleteObject(item);    
            }
            _context.SaveChanges();
        }

        #endregion
    }
}
