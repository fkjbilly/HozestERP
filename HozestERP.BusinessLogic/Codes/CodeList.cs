/******************************************************************
** Copyright (c) 2008 -2012 
** 创建人:方银朗
** 创建日期:2011-02-11
** 修改人: 方银朗
** 修改日期: 2011-02-11
** 描 述: 方银朗 2011-02-11 增加类的头部注释
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
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.Codes
{
    public partial class CodeList: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the CodeID
        /// </summary>
        public int CodeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CodeTypeID
        /// </summary>
        public int CodeTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CodeNO
        /// </summary>
        public string CodeNO { get; set; }
    
    	/// <summary>
        /// Gets or sets the CodeName
        /// </summary>
        public string CodeName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }
    
    	/// <summary>
        /// Gets or sets the DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the SCodeType
        /// </summary>
        public virtual CodeType SCodeType { get; set; }

     
        #endregion

    }
}
