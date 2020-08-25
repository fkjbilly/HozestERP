
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-04-26 15:27:24
** 修改人:
** 修改日期:
** 描 述: 
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace HozestERP.BusinessLogic.Entity
{
    public partial class CustomerRole: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the CustomerRoleID
        /// </summary>
        public int CustomerRoleID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Code
        /// </summary>
        public string Code { get; set; }
    
    	/// <summary>
        /// Gets or sets the ParentCustomerRoleID
        /// </summary>
        public int ParentCustomerRoleID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }
    
    	/// <summary>
        /// Gets or sets the Active
        /// </summary>
        public bool Active { get; set; }
    
    	/// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }
    
    	/// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateStaff
        /// </summary>
        public int CreateStaff { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public System.DateTime CreateDate { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SACLs list
        /// </summary>
        public virtual ICollection<ACL> SACLs { get; set; }
    
    	/// <summary>
        /// Gets or sets the SACLModules list
        /// </summary>
        public virtual ICollection<ACLModule> SACLModules { get; set; }
    
    	/// <summary>
        /// Gets or sets the SCustomers list
        /// </summary>
        public virtual ICollection<Customer> SCustomers { get; set; }
    
    	/// <summary>
        /// Gets or sets the SCustomerRoleStaffPrivileges list
        /// </summary>
        public virtual ICollection<Customer> SCustomerRoleStaffPrivileges { get; set; }
    
    	/// <summary>
        /// Gets or sets the SDepartments list
        /// </summary>
        public virtual ICollection<Department> SDepartments { get; set; }

        #endregion
    }
}
