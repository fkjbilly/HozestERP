
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
    public partial class ActivityLogType: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ActivityLogTypeID
        /// </summary>
        public int ActivityLogTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the SystemKeyword
        /// </summary>
        public string SystemKeyword { get; set; }
    
    	/// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }
    
    	/// <summary>
        /// Gets or sets the Enabled
        /// </summary>
        public bool Enabled { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SActivityLogs list
        /// </summary>
        public virtual ICollection<ActivityLog> SActivityLogs { get; set; }

        #endregion
    }
}
