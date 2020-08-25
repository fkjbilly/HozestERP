
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
    public partial class XMBusinessDataOther: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Object
        /// </summary>
        public string Object { get; set; }
    
    	/// <summary>
        /// Gets or sets the SubmitDate
        /// </summary>
        public Nullable<System.DateTime> SubmitDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the BelongingDepID
        /// </summary>
        public Nullable<int> BelongingDepID { get; set; }
    
    	/// <summary>
        /// Gets or sets the BelongingName
        /// </summary>
        public string BelongingName { get; set; }
    
    	/// <summary>
        /// Gets or sets the AmountType
        /// </summary>
        public Nullable<int> AmountType { get; set; }
    
    	/// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }
    
    	/// <summary>
        /// Gets or sets the BusinessType
        /// </summary>
        public Nullable<int> BusinessType { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContractlStatus
        /// </summary>
        public Nullable<bool> ContractlStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the FAuditPerson
        /// </summary>
        public Nullable<int> FAuditPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the CAuditPerson
        /// </summary>
        public Nullable<int> CAuditPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }
    
    	/// <summary>
        /// Gets or sets the Creator
        /// </summary>
        public Nullable<int> Creator { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the Updater
        /// </summary>
        public Nullable<int> Updater { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the BelongingProjectID
        /// </summary>
        public Nullable<int> BelongingProjectID { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
