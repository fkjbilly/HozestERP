
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
    public partial class CodeType: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the CodeTypeID
        /// </summary>
        public int CodeTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ModuleID
        /// </summary>
        public int ModuleID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CodeTypeCode
        /// </summary>
        public string CodeTypeCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the CodeTypeName
        /// </summary>
        public string CodeTypeName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }
    
    	/// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SCodeLists list
        /// </summary>
        public virtual ICollection<CodeList> SCodeLists { get; set; }

        #endregion
    }
}
