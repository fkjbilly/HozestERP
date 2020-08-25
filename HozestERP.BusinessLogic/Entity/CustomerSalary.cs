
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
    public partial class CustomerSalary: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerInfoID
        /// </summary>
        public Nullable<int> CustomerInfoID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Year
        /// </summary>
        public Nullable<int> Year { get; set; }
    
    	/// <summary>
        /// Gets or sets the Month
        /// </summary>
        public Nullable<int> Month { get; set; }
    
    	/// <summary>
        /// Gets or sets the BasePay
        /// </summary>
        public Nullable<decimal> BasePay { get; set; }
    
    	/// <summary>
        /// Gets or sets the MeritPay
        /// </summary>
        public Nullable<decimal> MeritPay { get; set; }
    
    	/// <summary>
        /// Gets or sets the PerformanceRoyalty
        /// </summary>
        public Nullable<decimal> PerformanceRoyalty { get; set; }
    
    	/// <summary>
        /// Gets or sets the Reward
        /// </summary>
        public Nullable<decimal> Reward { get; set; }
    
    	/// <summary>
        /// Gets or sets the Subsidies
        /// </summary>
        public Nullable<decimal> Subsidies { get; set; }
    
    	/// <summary>
        /// Gets or sets the BasePayDebit
        /// </summary>
        public Nullable<decimal> BasePayDebit { get; set; }
    
    	/// <summary>
        /// Gets or sets the AbsenceDutyDebit
        /// </summary>
        public Nullable<decimal> AbsenceDutyDebit { get; set; }
    
    	/// <summary>
        /// Gets or sets the PerformanceCoefficient
        /// </summary>
        public Nullable<decimal> PerformanceCoefficient { get; set; }
    
    	/// <summary>
        /// Gets or sets the RealPerformance
        /// </summary>
        public Nullable<decimal> RealPerformance { get; set; }
    
    	/// <summary>
        /// Gets or sets the Replenishment
        /// </summary>
        public Nullable<decimal> Replenishment { get; set; }
    
    	/// <summary>
        /// Gets or sets the Debit
        /// </summary>
        public Nullable<decimal> Debit { get; set; }
    
    	/// <summary>
        /// Gets or sets the ShouldSalary
        /// </summary>
        public Nullable<decimal> ShouldSalary { get; set; }
    
    	/// <summary>
        /// Gets or sets the Pension
        /// </summary>
        public Nullable<decimal> Pension { get; set; }
    
    	/// <summary>
        /// Gets or sets the MedicalCare
        /// </summary>
        public Nullable<decimal> MedicalCare { get; set; }
    
    	/// <summary>
        /// Gets or sets the Unemployment
        /// </summary>
        public Nullable<decimal> Unemployment { get; set; }
    
    	/// <summary>
        /// Gets or sets the AccumulationFund
        /// </summary>
        public Nullable<decimal> AccumulationFund { get; set; }
    
    	/// <summary>
        /// Gets or sets the SocialSecurityTotal
        /// </summary>
        public Nullable<decimal> SocialSecurityTotal { get; set; }
    
    	/// <summary>
        /// Gets or sets the CommunicationFee
        /// </summary>
        public Nullable<decimal> CommunicationFee { get; set; }
    
    	/// <summary>
        /// Gets or sets the IndividualIncomeTax
        /// </summary>
        public Nullable<decimal> IndividualIncomeTax { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceCharge
        /// </summary>
        public Nullable<decimal> FinanceCharge { get; set; }
    
    	/// <summary>
        /// Gets or sets the RealSalary
        /// </summary>
        public Nullable<decimal> RealSalary { get; set; }
    
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
