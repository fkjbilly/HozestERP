
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
    public partial class XMFinancialField: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ParentID
        /// </summary>
        public Nullable<int> ParentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the FieldCode
        /// </summary>
        public string FieldCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the FieldName
        /// </summary>
        public string FieldName { get; set; }
    
    	/// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
    
    	/// <summary>
        /// Gets or sets the AddUserId
        /// </summary>
        public Nullable<int> AddUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the AddTime
        /// </summary>
        public Nullable<System.DateTime> AddTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the EditUserId
        /// </summary>
        public Nullable<int> EditUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the EditTime
        /// </summary>
        public Nullable<System.DateTime> EditTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public Nullable<bool> Deleted { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsManagementField
        /// </summary>
        public Nullable<bool> IsManagementField { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
