
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2018-04-02 15:26:12
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMLogisticsCost: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        public string LogisticsNumber { get; set; }

        /// <summary>
        /// Gets or sets the ModuleName
        /// </summary>
        public string ModuleName { get; set; }
    
    	/// <summary>
        /// Gets or sets the ModuleID
        /// </summary>
        public Nullable<int> ModuleID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Fee
        /// </summary>
        public Nullable<decimal> Fee { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReconciliationTime
        /// </summary>
        public Nullable<System.DateTime> ReconciliationTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        #endregion

        #region Custom Properties
    		
    	
        #endregion

    }
}
