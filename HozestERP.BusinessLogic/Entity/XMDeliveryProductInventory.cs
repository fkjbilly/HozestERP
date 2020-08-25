
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
    public partial class XMDeliveryProductInventory: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Year
        /// </summary>
        public Nullable<int> Year { get; set; }
    
    	/// <summary>
        /// Gets or sets the Month
        /// </summary>
        public Nullable<int> Month { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string ManufacturersCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the SurplusInventory
        /// </summary>
        public Nullable<int> SurplusInventory { get; set; }
    
    	/// <summary>
        /// Gets or sets the StorageCount
        /// </summary>
        public Nullable<int> StorageCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the StorageAmount
        /// </summary>
        public Nullable<decimal> StorageAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliveryCount
        /// </summary>
        public Nullable<int> DeliveryCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliveryAmount
        /// </summary>
        public Nullable<decimal> DeliveryAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the InventoryCount
        /// </summary>
        public Nullable<int> InventoryCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the InventoryAmount
        /// </summary>
        public Nullable<decimal> InventoryAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
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
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
