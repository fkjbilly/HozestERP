/******************************************************************
** Copyright (c) 2008 -2012 和众互联
** 创建人:方银朗
** 创建日期:2012-03-21
** 修改人: 方银朗
** 修改日期: 2012-03-21
** 描 述: 方银朗 2012-03-21 创建 附件表
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

namespace HozestERP.BusinessLogic.ManageFile
{
    public partial class UploadFile: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the UploadFileID
        /// </summary>
        public int UploadFileID { get; set; }
    
    	/// <summary>
        /// Gets or sets the TaggantID
        /// </summary>
        public System.Guid TaggantID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ObjectID
        /// </summary>
        public int ObjectID { get; set; }

        /// <summary>
        /// Gets or sets the TableName
        /// </summary>
        public string TableName { get; set; }
    
    	/// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Url
        /// </summary>
        public string Url { get; set; }
    
    	/// <summary>
        /// Gets or sets the Created
        /// </summary>
        public System.DateTime Created { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public int CreatorID { get; set; }

        #endregion
    }
}
