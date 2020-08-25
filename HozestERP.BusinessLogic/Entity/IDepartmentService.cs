
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
    public partial interface IDepartmentService
    {
        #region IDepartmentService成员
        /// <summary>
        /// Insert into Department
        /// </summary>
        /// <param name="department">Department</param>
    	void InsertDepartment(Department department);
    	
        /// <summary>
        /// Update into Department
        /// </summary>
        /// <param name="department">Department</param>
        void UpdateDepartment(Department department);	
    	
        /// <summary>
        /// get to Department list
        /// </summary>
        List<Department> GetDepartmentList();
    	       
    	/// <summary>
    	/// get to Department Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>Department Page List</returns>
    	PagedList<Department> SearchDepartment(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a Department by DepartmentID
        /// </summary>
        /// <param name="departmentid">Department DepartmentID</param>
        /// <returns>Department</returns>   
        Department GetDepartmentByDepartmentID(int departmentid);
    
    	/// <summary>
        /// delete Department by DepartmentID
        /// </summary>
        /// <param name="DepartmentID">Department DepartmentID</param>
        void DeleteDepartment(int departmentid);
    	
    	/// <summary>
        /// Batch delete Department by DepartmentID
        /// </summary>
        /// <param name="DepartmentIDs">Department DepartmentID</param>
        void BatchDeleteDepartment(List<int> departmentids);

        #endregion
    }
}
