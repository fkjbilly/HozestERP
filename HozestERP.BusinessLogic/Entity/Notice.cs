
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
    public partial class Notice: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public System.Guid ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string Title { get; set; }
    
    	/// <summary>
        /// Gets or sets the DateTime
        /// </summary>
        public System.DateTime DateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the Promulgator
        /// </summary>
        public string Promulgator { get; set; }
    
    	/// <summary>
        /// Gets or sets the StartTime
        /// </summary>
        public System.DateTime StartTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the Published
        /// </summary>
        public bool Published { get; set; }
    
    	/// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsDelete
        /// </summary>
        public Nullable<bool> IsDelete { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateTime { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
