
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
    public partial class XMBusinessData: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContractNumber
        /// </summary>
        public string ContractNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContractAmount
        /// </summary>
        public Nullable<decimal> ContractAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the ClientCompany
        /// </summary>
        public string ClientCompany { get; set; }
    
    	/// <summary>
        /// Gets or sets the SubmitLimit
        /// </summary>
        public string SubmitLimit { get; set; }
    
    	/// <summary>
        /// Gets or sets the SubmitDate
        /// </summary>
        public Nullable<System.DateTime> SubmitDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the ActualAmount
        /// </summary>
        public Nullable<decimal> ActualAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the BelongingDepID
        /// </summary>
        public Nullable<int> BelongingDepID { get; set; }
    
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
        /// Gets or sets the PayPerson
        /// </summary>
        public string PayPerson { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_BusinessDataDetail list
        /// </summary>
        public virtual ICollection<XMBusinessDataDetail> XM_BusinessDataDetail { get; set; }

        #endregion
    }
}
