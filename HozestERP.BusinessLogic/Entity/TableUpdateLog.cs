
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
    public partial class TableUpdateLog: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the LogID
        /// </summary>
        public int LogID { get; set; }
    
    	/// <summary>
        /// Gets or sets the RequestID
        /// </summary>
        public int RequestID { get; set; }
    
    	/// <summary>
        /// Gets or sets the FieldName
        /// </summary>
        public string FieldName { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrginValue
        /// </summary>
        public string OrginValue { get; set; }
    
    	/// <summary>
        /// Gets or sets the NewValue
        /// </summary>
        public string NewValue { get; set; }
    
    	/// <summary>
        /// Gets or sets the OperatorID
        /// </summary>
        public int OperatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public System.DateTime UpdateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the TableName
        /// </summary>
        public string TableName { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
