
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
    public partial class XMBusinessDataDetail: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the BusinessDataID
        /// </summary>
        public Nullable<int> BusinessDataID { get; set; }
    
    	/// <summary>
        /// Gets or sets the AmountType
        /// </summary>
        public Nullable<int> AmountType { get; set; }
    
    	/// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }
    
    	/// <summary>
        /// Gets or sets the DomainName
        /// </summary>
        public string DomainName { get; set; }
    
    	/// <summary>
        /// Gets or sets the BusinessType
        /// </summary>
        public Nullable<int> BusinessType { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark1
        /// </summary>
        public string Remark1 { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark2
        /// </summary>
        public string Remark2 { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the ServiceBeginDate
        /// </summary>
        public Nullable<System.DateTime> ServiceBeginDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the ServiceEndDate
        /// </summary>
        public Nullable<System.DateTime> ServiceEndDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the AuditPerson
        /// </summary>
        public Nullable<int> AuditPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the AuditDate
        /// </summary>
        public Nullable<System.DateTime> AuditDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the BelongingName
        /// </summary>
        public string BelongingName { get; set; }
    
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
        /// Gets or sets the B2CBusinessType
        /// </summary>
        public Nullable<int> B2CBusinessType { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_BusinessData
        /// </summary>
        public virtual XMBusinessData XM_BusinessData { get; set; }

        #endregion
    }
}
