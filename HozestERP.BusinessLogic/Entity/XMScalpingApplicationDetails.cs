
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
    public partial class XMScalpingApplicationDetails: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ScalpingDetailsId
        /// </summary>
        public int ScalpingDetailsId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ScalpingId
        /// </summary>
        public Nullable<int> ScalpingId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ScalpingTime
        /// </summary>
        public Nullable<System.DateTime> ScalpingTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the RequiredFlow
        /// </summary>
        public string RequiredFlow { get; set; }
    
    	/// <summary>
        /// Gets or sets the NaturalFlow
        /// </summary>
        public string NaturalFlow { get; set; }
    
    	/// <summary>
        /// Gets or sets the ForecastDeal
        /// </summary>
        public Nullable<int> ForecastDeal { get; set; }
    
    	/// <summary>
        /// Gets or sets the ForecastScalpingQuantity
        /// </summary>
        public Nullable<int> ForecastScalpingQuantity { get; set; }
    
    	/// <summary>
        /// Gets or sets the ConversionRate
        /// </summary>
        public decimal ConversionRate { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerPrice
        /// </summary>
        public Nullable<decimal> CustomerPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateTime { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
