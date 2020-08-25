
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
    public partial class Customer: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public int CustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }
    
    	/// <summary>
        /// Gets or sets the Username
        /// </summary>
        public string Username { get; set; }
    
    	/// <summary>
        /// Gets or sets the PasswordHash
        /// </summary>
        public string PasswordHash { get; set; }
    
    	/// <summary>
        /// Gets or sets the SaltKey
        /// </summary>
        public string SaltKey { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsAdmin
        /// </summary>
        public bool IsAdmin { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsGuest
        /// </summary>
        public bool IsGuest { get; set; }
    
    	/// <summary>
        /// Gets or sets the Signature
        /// </summary>
        public string Signature { get; set; }
    
    	/// <summary>
        /// Gets or sets the AdminComment
        /// </summary>
        public string AdminComment { get; set; }
    
    	/// <summary>
        /// Gets or sets the Active
        /// </summary>
        public bool Active { get; set; }
    
    	/// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }
    
    	/// <summary>
        /// Gets or sets the RegistrationDate
        /// </summary>
        public System.DateTime RegistrationDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the TimeZoneID
        /// </summary>
        public string TimeZoneID { get; set; }
    
    	/// <summary>
        /// Gets or sets the AvatarID
        /// </summary>
        public int AvatarID { get; set; }
    
    	/// <summary>
        /// Gets or sets the DateOfBirth
        /// </summary>
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SActivityLogs list
        /// </summary>
        public virtual ICollection<ActivityLog> SActivityLogs { get; set; }
    
    	/// <summary>
        /// Gets or sets the SCustomerAttributes list
        /// </summary>
        public virtual ICollection<CustomerAttribute> SCustomerAttributes { get; set; }
    
    	/// <summary>
        /// Gets or sets the SCustomerRoles list
        /// </summary>
        public virtual ICollection<CustomerRole> SCustomerRoles { get; set; }
    
    	/// <summary>
        /// Gets or sets the SPortalColumnNumbers list
        /// </summary>
        public virtual ICollection<PortalColumnNumber> SPortalColumnNumbers { get; set; }
    
    	/// <summary>
        /// Gets or sets the SCustomerInfo
        /// </summary>
        public virtual CustomerInfo SCustomerInfo { get; set; }
    
    	/// <summary>
        /// Gets or sets the SStaffPrivilegesCustomerRole list
        /// </summary>
        public virtual ICollection<CustomerRole> SStaffPrivilegesCustomerRole { get; set; }

        #endregion
    }
}
