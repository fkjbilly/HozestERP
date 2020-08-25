
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2018-01-23 13:30:25
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

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMWorkerInfo: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }
    
    	/// <summary>
        /// Gets or sets the Province
        /// </summary>
        public string Province { get; set; }
    
    	/// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }
    
    	/// <summary>
        /// Gets or sets the Regin
        /// </summary>
        public string Regin { get; set; }
    
    	/// <summary>
        /// Gets or sets the LevelType
        /// </summary>
        public string LevelType { get; set; }
    
    	/// <summary>
        /// Gets or sets the PayMethod
        /// </summary>
        public string PayMethod { get; set; }

        /// <summary>
        /// Gets or sets the PayMethod
        /// </summary>
        public string InstallationType { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatePerson
        /// </summary>
        public int? CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatePerson
        /// </summary>
        public int? UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateTime { get; set; }

        #endregion

        #region Custom Properties
    		
    	
        #endregion

    }
}
