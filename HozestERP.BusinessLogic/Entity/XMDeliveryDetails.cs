
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
    public partial class XMDeliveryDetails: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliveryId
        /// </summary>
        public Nullable<int> DeliveryId { get; set; }
    
    	/// <summary>
        /// Gets or sets the DetailsTypeId
        /// </summary>
        public Nullable<int> DetailsTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderNo
        /// </summary>
        public string OrderNo { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductlId
        /// </summary>
        public Nullable<int> ProductlId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the PrdouctName
        /// </summary>
        public string PrdouctName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }
    
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
        /// Gets or sets the WarehouseID
        /// </summary>
        public Nullable<int> WarehouseID { get; set; }
    
    	/// <summary>
        /// Gets or sets the InvoiceInfoID
        /// </summary>
        public Nullable<int> InvoiceInfoID { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_Delivery
        /// </summary>
        public virtual XMDelivery XM_Delivery { get; set; }

        #endregion
    }
}
