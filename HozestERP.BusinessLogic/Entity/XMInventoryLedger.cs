
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
    public partial class XMInventoryLedger: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the WarehouseId
        /// </summary>
        public int WarehouseId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the InCount
        /// </summary>
        public Nullable<int> InCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the InMoney
        /// </summary>
        public Nullable<decimal> InMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the InPrice
        /// </summary>
        public Nullable<decimal> InPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the OutCount
        /// </summary>
        public Nullable<decimal> OutCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the OutMoney
        /// </summary>
        public Nullable<decimal> OutMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the OutPrice
        /// </summary>
        public Nullable<decimal> OutPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the BalanceCount
        /// </summary>
        public Nullable<int> BalanceCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the BalanceMoney
        /// </summary>
        public Nullable<decimal> BalanceMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the BalnacePrice
        /// </summary>
        public Nullable<decimal> BalnacePrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the AfloatCount
        /// </summary>
        public Nullable<int> AfloatCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the AfloatMoney
        /// </summary>
        public Nullable<decimal> AfloatMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the AfloatPrice
        /// </summary>
        public Nullable<decimal> AfloatPrice { get; set; }
    
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

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
