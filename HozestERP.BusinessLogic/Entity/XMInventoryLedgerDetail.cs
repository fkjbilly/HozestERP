
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
    public partial class XMInventoryLedgerDetail: BaseEntity
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
        public Nullable<int> OutCount { get; set; }
    
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
        /// Gets or sets the BalancePrice
        /// </summary>
        public Nullable<decimal> BalancePrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the RefNumber
        /// </summary>
        public string RefNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the BizDate
        /// </summary>
        public Nullable<System.DateTime> BizDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the RefType
        /// </summary>
        public Nullable<int> RefType { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
