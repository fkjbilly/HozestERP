
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
    public partial class XMOtherCostDetail: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the Year
        /// </summary>
        public int Year { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepartmentID
        /// </summary>
        public int DepartmentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancialFieldID
        /// </summary>
        public int FinancialFieldID { get; set; }
    
    	/// <summary>
        /// Gets or sets the OneMonthCost
        /// </summary>
        public Nullable<decimal> OneMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the TwoMonthCost
        /// </summary>
        public Nullable<decimal> TwoMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the ThreeMonthCost
        /// </summary>
        public Nullable<decimal> ThreeMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the FourMonthCost
        /// </summary>
        public Nullable<decimal> FourMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the FiveMonthCost
        /// </summary>
        public Nullable<decimal> FiveMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the SixMonthCost
        /// </summary>
        public Nullable<decimal> SixMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the SevenMonthCost
        /// </summary>
        public Nullable<decimal> SevenMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the EightMonthCost
        /// </summary>
        public Nullable<decimal> EightMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the NineMonthCost
        /// </summary>
        public Nullable<decimal> NineMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the TenMonthCost
        /// </summary>
        public Nullable<decimal> TenMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the ElevenMonthCost
        /// </summary>
        public Nullable<decimal> ElevenMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the TwelMonthCost
        /// </summary>
        public Nullable<decimal> TwelMonthCost { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
