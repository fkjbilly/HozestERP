
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
    public partial class Sys_AlertTimeSet: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public Nullable<int> CustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the AlertID
        /// </summary>
        public Nullable<int> AlertID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Cycletime
        /// </summary>
        public Nullable<int> Cycletime { get; set; }
    
    	/// <summary>
        /// Gets or sets the Spare1
        /// </summary>
        public string Spare1 { get; set; }
    
    	/// <summary>
        /// Gets or sets the Spare2
        /// </summary>
        public string Spare2 { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
