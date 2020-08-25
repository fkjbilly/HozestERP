
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
    public partial class Module: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ModuleID
        /// </summary>
        public int ModuleID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ParentID
        /// </summary>
        public Nullable<int> ParentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ModuleName
        /// </summary>
        public string ModuleName { get; set; }
    
    	/// <summary>
        /// Gets or sets the ModuleCode
        /// </summary>
        public string ModuleCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the isTarget
        /// </summary>
        public bool isTarget { get; set; }
    
    	/// <summary>
        /// Gets or sets the href
        /// </summary>
        public string href { get; set; }
    
    	/// <summary>
        /// Gets or sets the Expand
        /// </summary>
        public bool Expand { get; set; }
    
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
        /// Gets or sets the iconCls
        /// </summary>
        public string iconCls { get; set; }
    
    	/// <summary>
        /// Gets or sets the AppIconCls
        /// </summary>
        public string AppIconCls { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SCustomerActions list
        /// </summary>
        public virtual ICollection<CustomerAction> SCustomerActions { get; set; }

        #endregion
    }
}
