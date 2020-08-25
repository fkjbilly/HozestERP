
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
    public partial class XMOrderInfoProductDetails: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderInfoID
        /// </summary>
        public Nullable<int> OrderInfoID { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }
    
    	/// <summary>
        /// Gets or sets the FactoryPrice
        /// </summary>
        public Nullable<decimal> FactoryPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the TCostprice
        /// </summary>
        public Nullable<decimal> TCostprice { get; set; }
    
    	/// <summary>
        /// Gets or sets the SalesPrice
        /// </summary>
        public Nullable<decimal> SalesPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the ISArrivedLibrary
        /// </summary>
        public Nullable<bool> ISArrivedLibrary { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }
    
    	/// <summary>
        /// Gets or sets the CutoffShipDay
        /// </summary>
        public Nullable<System.DateTime> CutoffShipDay { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsExpedited
        /// </summary>
        public Nullable<bool> IsExpedited { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsSingleRow
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }
    
    	/// <summary>
        /// Gets or sets the Status
        /// </summary>
        public string Status { get; set; }
    
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
        /// Gets or sets the TManufacturersCode
        /// </summary>
        public string TManufacturersCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the SpareRemarks
        /// </summary>
        public string SpareRemarks { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_OrderInfo
        /// </summary>
        public virtual XMOrderInfo XM_OrderInfo { get; set; }

        #endregion
    }
}
