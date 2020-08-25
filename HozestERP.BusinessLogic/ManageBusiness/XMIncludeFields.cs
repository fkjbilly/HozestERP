
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-02-29 09:08:30
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

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMIncludeFields: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepartmentId
        /// </summary>
        public Nullable<int> DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> NickId { get; set; }

        /// <summary>
        /// Gets or sets the Fields
        /// </summary>
        public string Fields { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateId
        /// </summary>
        public Nullable<int> CreateId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Createdate
        /// </summary>
        public Nullable<System.DateTime> Createdate { get; set; }
    
    	/// <summary>
        /// Gets or sets the Updatetime
        /// </summary>
        public Nullable<System.DateTime> Updatetime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateId
        /// </summary>
        public Nullable<int> UpdateId { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
