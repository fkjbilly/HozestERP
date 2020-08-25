
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
    public partial class XMFinancialCapitalFlow: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Date
        /// </summary>
        public Nullable<System.DateTime> Date { get; set; }
    
    	/// <summary>
        /// Gets or sets the Abstract
        /// </summary>
        public string Abstract { get; set; }
    
    	/// <summary>
        /// Gets or sets the AssociatedPerson
        /// </summary>
        public string AssociatedPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReceivablesType
        /// </summary>
        public Nullable<int> ReceivablesType { get; set; }
    
    	/// <summary>
        /// Gets or sets the BudgetType
        /// </summary>
        public Nullable<int> BudgetType { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepartmentID
        /// </summary>
        public Nullable<int> DepartmentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the BelongingProjectID
        /// </summary>
        public Nullable<int> BelongingProjectID { get; set; }
    
    	/// <summary>
        /// Gets or sets the PaymentCollectionType
        /// </summary>
        public Nullable<int> PaymentCollectionType { get; set; }
    
    	/// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsIncome
        /// </summary>
        public Nullable<bool> IsIncome { get; set; }
    
    	/// <summary>
        /// Gets or sets the Audit
        /// </summary>
        public Nullable<bool> Audit { get; set; }
    
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

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
