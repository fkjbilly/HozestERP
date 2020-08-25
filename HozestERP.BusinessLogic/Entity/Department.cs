
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
    public partial class Department: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the DepartmentID
        /// </summary>
        public int DepartmentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ParentID
        /// </summary>
        public Nullable<int> ParentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the EnterpriseID
        /// </summary>
        public int EnterpriseID { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepCode
        /// </summary>
        public string DepCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepName
        /// </summary>
        public string DepName { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepType
        /// </summary>
        public Nullable<int> DepType { get; set; }
    
    	/// <summary>
        /// Gets or sets the Label
        /// </summary>
        public string Label { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepManagerID
        /// </summary>
        public int DepManagerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Address
        /// </summary>
        public string Address { get; set; }
    
    	/// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }
    
    	/// <summary>
        /// Gets or sets the Published
        /// </summary>
        public bool Published { get; set; }
    
    	/// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }
    
    	/// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
    
    	/// <summary>
        /// Gets or sets the AddUserId
        /// </summary>
        public Nullable<int> AddUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the AddTime
        /// </summary>
        public string AddTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the EditUserId
        /// </summary>
        public Nullable<int> EditUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the EditTime
        /// </summary>
        public string EditTime { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SEnterprise
        /// </summary>
        public virtual Enterprise SEnterprise { get; set; }
    
    	/// <summary>
        /// Gets or sets the SCustomerInfos list
        /// </summary>
        public virtual ICollection<CustomerInfo> SCustomerInfos { get; set; }
    
    	/// <summary>
        /// Gets or sets the SCustomerRoles list
        /// </summary>
        public virtual ICollection<CustomerRole> SCustomerRoles { get; set; }

        #endregion
    }
}
