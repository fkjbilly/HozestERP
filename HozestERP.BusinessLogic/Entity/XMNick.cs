
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
    public partial class XMNick: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the nick_id
        /// </summary>
        public int nick_id { get; set; }
    
    	/// <summary>
        /// Gets or sets the nick
        /// </summary>
        public string nick { get; set; }
    
    	/// <summary>
        /// Gets or sets the shopManager
        /// </summary>
        public string shopManager { get; set; }
    
    	/// <summary>
        /// Gets or sets the customerRoleID
        /// </summary>
        public Nullable<int> customerRoleID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }
    
    	/// <summary>
        /// Gets or sets the isEnable
        /// </summary>
        public bool isEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the createPerson
        /// </summary>
        public string createPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the updatePerson
        /// </summary>
        public string updatePerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the createTime
        /// </summary>
        public System.DateTime createTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the updateTime
        /// </summary>
        public Nullable<System.DateTime> updateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public int PlatformTypeId { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
