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

namespace HozestERP.BusinessLogic.Codes
{
    public partial class CodeType : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the CodeTypeID
        /// </summary>
        public int CodeTypeID { get; set; }

        /// <summary>
        /// Gets or sets the CodeTypeCode
        /// </summary>
        public string CodeTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the Module ID
        /// </summary>
        public int ModuleID { get; set; }

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

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the SCodeList list
        /// </summary>
        public virtual ICollection<CodeList> SCodeLists { get; set; }

        #endregion
    }
}
