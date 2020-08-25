
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
    public partial class XMOrderInfoApp: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the AppKey
        /// </summary>
        public string AppKey { get; set; }
    
    	/// <summary>
        /// Gets or sets the AppSecret
        /// </summary>
        public string AppSecret { get; set; }
    
    	/// <summary>
        /// Gets or sets the CallbackUrl
        /// </summary>
        public string CallbackUrl { get; set; }
    
    	/// <summary>
        /// Gets or sets the AccessToken
        /// </summary>
        public string AccessToken { get; set; }
    
    	/// <summary>
        /// Gets or sets the ServerUrl
        /// </summary>
        public string ServerUrl { get; set; }
    
    	/// <summary>
        /// Gets or sets the EndSynchronousDate
        /// </summary>
        public Nullable<System.DateTime> EndSynchronousDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateId
        /// </summary>
        public Nullable<int> CreateId { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the ModifyId
        /// </summary>
        public Nullable<int> ModifyId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ModifyDate
        /// </summary>
        public Nullable<System.DateTime> ModifyDate { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
