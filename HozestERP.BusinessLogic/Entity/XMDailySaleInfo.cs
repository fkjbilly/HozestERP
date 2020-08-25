
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
    public partial class XMDailySaleInfo: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public int ProductId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderQuantity
        /// </summary>
        public Nullable<int> OrderQuantity { get; set; }
    
    	/// <summary>
        /// Gets or sets the MerchandiseViewCount
        /// </summary>
        public Nullable<int> MerchandiseViewCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the VisitorNumber
        /// </summary>
        public Nullable<int> VisitorNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the ConversionRate
        /// </summary>
        public Nullable<decimal> ConversionRate { get; set; }
    
    	/// <summary>
        /// Gets or sets the CumulativeAttention
        /// </summary>
        public Nullable<int> CumulativeAttention { get; set; }
    
    	/// <summary>
        /// Gets or sets the AddCartCount
        /// </summary>
        public Nullable<int> AddCartCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the CartConversionRate
        /// </summary>
        public Nullable<decimal> CartConversionRate { get; set; }
    
    	/// <summary>
        /// Gets or sets the EvaluationQuantity
        /// </summary>
        public Nullable<int> EvaluationQuantity { get; set; }
    
    	/// <summary>
        /// Gets or sets the PraiseQuantity
        /// </summary>
        public Nullable<int> PraiseQuantity { get; set; }
    
    	/// <summary>
        /// Gets or sets the PraiseRate
        /// </summary>
        public Nullable<decimal> PraiseRate { get; set; }
    
    	/// <summary>
        /// Gets or sets the FlowRate
        /// </summary>
        public Nullable<decimal> FlowRate { get; set; }
    
    	/// <summary>
        /// Gets or sets the ExterFlowRate
        /// </summary>
        public Nullable<decimal> ExterFlowRate { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
