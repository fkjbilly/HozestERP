
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
    public partial class Enterprise: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the EntId
        /// </summary>
        public int EntId { get; set; }
    
    	/// <summary>
        /// Gets or sets the EntName
        /// </summary>
        public string EntName { get; set; }
    
    	/// <summary>
        /// Gets or sets the EntTel
        /// </summary>
        public string EntTel { get; set; }
    
    	/// <summary>
        /// Gets or sets the EntFax
        /// </summary>
        public string EntFax { get; set; }
    
    	/// <summary>
        /// Gets or sets the EntAddress
        /// </summary>
        public string EntAddress { get; set; }
    
    	/// <summary>
        /// Gets or sets the EntZip
        /// </summary>
        public string EntZip { get; set; }
    
    	/// <summary>
        /// Gets or sets the EntWebSite
        /// </summary>
        public string EntWebSite { get; set; }
    
    	/// <summary>
        /// Gets or sets the EntEmail
        /// </summary>
        public string EntEmail { get; set; }
    
    	/// <summary>
        /// Gets or sets the EntBank
        /// </summary>
        public string EntBank { get; set; }
    
    	/// <summary>
        /// Gets or sets the EntBankAccount
        /// </summary>
        public string EntBankAccount { get; set; }
    
    	/// <summary>
        /// Gets or sets the AddUserId
        /// </summary>
        public int AddUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the AddTime
        /// </summary>
        public string AddTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the Published
        /// </summary>
        public bool Published { get; set; }
    
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
        /// Gets or sets the SDepartments list
        /// </summary>
        public virtual ICollection<Department> SDepartments { get; set; }

        #endregion
    }
}
