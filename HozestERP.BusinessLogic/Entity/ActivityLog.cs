
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
    public partial class ActivityLog: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ActivityLogID
        /// </summary>
        public int ActivityLogID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ActivityLogTypeID
        /// </summary>
        public int ActivityLogTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public int CustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Comment
        /// </summary>
        public string Comment { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatedOn
        /// </summary>
        public System.DateTime CreatedOn { get; set; }
    
    	/// <summary>
        /// Gets or sets the MerchantID
        /// </summary>
        public Nullable<int> MerchantID { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SActivityLogType
        /// </summary>
        public virtual ActivityLogType SActivityLogType { get; set; }
    
    	/// <summary>
        /// Gets or sets the SCustomer
        /// </summary>
        public virtual Customer SCustomer { get; set; }

        #endregion
    }
}
