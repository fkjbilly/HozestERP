
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
    public partial interface ICustomerRoleService
    {
        #region ICustomerRoleService成员
        /// <summary>
        /// Insert into CustomerRole
        /// </summary>
        /// <param name="customerrole">CustomerRole</param>
    	void InsertCustomerRole(CustomerRole customerrole);
    	
        /// <summary>
        /// Update into CustomerRole
        /// </summary>
        /// <param name="customerrole">CustomerRole</param>
        void UpdateCustomerRole(CustomerRole customerrole);	
    	
        /// <summary>
        /// get to CustomerRole list
        /// </summary>
        List<CustomerRole> GetCustomerRoleList();
    	       
    	/// <summary>
    	/// get to CustomerRole Page List
    	/// </summary>
    	/// <param name="pageIndex">当前页</param>
    	/// <param name="pageSize">返回记录数</param>
    	/// <param name="sortExpression">排序字段</param>
    	/// <param name="sortDirection">排序规则</param>
    	/// <returns>CustomerRole Page List</returns>
    	PagedList<CustomerRole> SearchCustomerRole(int pageIndex, int pageSize, string sortExpression, string sortDirection);
    
    	/// <summary>
        /// get a CustomerRole by CustomerRoleID
        /// </summary>
        /// <param name="customerroleid">CustomerRole CustomerRoleID</param>
        /// <returns>CustomerRole</returns>   
        CustomerRole GetCustomerRoleByCustomerRoleID(int customerroleid);
    
    	/// <summary>
        /// delete CustomerRole by CustomerRoleID
        /// </summary>
        /// <param name="CustomerRoleID">CustomerRole CustomerRoleID</param>
        void DeleteCustomerRole(int customerroleid);
    	
    	/// <summary>
        /// Batch delete CustomerRole by CustomerRoleID
        /// </summary>
        /// <param name="CustomerRoleIDs">CustomerRole CustomerRoleID</param>
        void BatchDeleteCustomerRole(List<int> customerroleids);

        #endregion
    }
}
