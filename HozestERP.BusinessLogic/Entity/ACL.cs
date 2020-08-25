
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
    public partial class ACL: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ACLID
        /// </summary>
        public int ACLID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerActionID
        /// </summary>
        public int CustomerActionID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerRoleID
        /// </summary>
        public int CustomerRoleID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Allow
        /// </summary>
        public bool Allow { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SCustomerAction
        /// </summary>
        public virtual CustomerAction SCustomerAction { get; set; }
    
    	/// <summary>
        /// Gets or sets the SCustomerRole
        /// </summary>
        public virtual CustomerRole SCustomerRole { get; set; }

        #endregion
    }
}
