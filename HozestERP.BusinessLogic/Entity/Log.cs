
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
    public partial class Log: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the LogID
        /// </summary>
        public int LogID { get; set; }
    
    	/// <summary>
        /// Gets or sets the LogTypeID
        /// </summary>
        public int LogTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Severity
        /// </summary>
        public int Severity { get; set; }
    
    	/// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; }
    
    	/// <summary>
        /// Gets or sets the Exception
        /// </summary>
        public string Exception { get; set; }
    
    	/// <summary>
        /// Gets or sets the IPAddress
        /// </summary>
        public string IPAddress { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public int CustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the PageURL
        /// </summary>
        public string PageURL { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReferrerURL
        /// </summary>
        public string ReferrerURL { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatedOn
        /// </summary>
        public System.DateTime CreatedOn { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
