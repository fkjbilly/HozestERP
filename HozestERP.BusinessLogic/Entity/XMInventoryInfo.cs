
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
    public partial class XMInventoryInfo: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the PrductId
        /// </summary>
        public int PrductId { get; set; }
    
    	/// <summary>
        /// Gets or sets the WfId
        /// </summary>
        public int WfId { get; set; }
    
    	/// <summary>
        /// Gets or sets the StockNumber
        /// </summary>
        public Nullable<int> StockNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the WarningValue
        /// </summary>
        public Nullable<int> WarningValue { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
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
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the CanOrderCount
        /// </summary>
        public Nullable<int> CanOrderCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the SaleStatus
        /// </summary>
        public Nullable<int> SaleStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the CanStorageCount
        /// </summary>
        public Nullable<int> CanStorageCount { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_InventoryBarcodeDetail list
        /// </summary>
        public virtual ICollection<XMInventoryBarcodeDetail> XM_InventoryBarcodeDetail { get; set; }

        #endregion
    }
}
