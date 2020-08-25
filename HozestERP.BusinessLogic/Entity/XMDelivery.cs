
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
    public partial class XMDelivery: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliveryTypeId
        /// </summary>
        public Nullable<int> DeliveryTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliveryNumber
        /// </summary>
        public string DeliveryNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductNo
        /// </summary>
        public string ProductNo { get; set; }
    
    	/// <summary>
        /// Gets or sets the LogisticsNumber
        /// </summary>
        public string LogisticsNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the LogisticsId
        /// </summary>
        public Nullable<int> LogisticsId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Price
        /// </summary>
        public Nullable<decimal> Price { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsDelivery
        /// </summary>
        public Nullable<bool> IsDelivery { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateId
        /// </summary>
        public Nullable<int> CreateId { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateId
        /// </summary>
        public Nullable<int> UpdateId { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }
    
    	/// <summary>
        /// Gets or sets the PrintQuantity
        /// </summary>
        public Nullable<int> PrintQuantity { get; set; }
    
    	/// <summary>
        /// Gets or sets the PrintBatch
        /// </summary>
        public Nullable<int> PrintBatch { get; set; }
    
    	/// <summary>
        /// Gets or sets the PrintDateTime
        /// </summary>
        public Nullable<System.DateTime> PrintDateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the LogisticsCode
        /// </summary>
        public string LogisticsCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the Shipper
        /// </summary>
        public Nullable<int> Shipper { get; set; }
    
    	/// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Mobile
        /// </summary>
        public string Mobile { get; set; }
    
    	/// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }
    
    	/// <summary>
        /// Gets or sets the Province
        /// </summary>
        public string Province { get; set; }
    
    	/// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }
    
    	/// <summary>
        /// Gets or sets the County
        /// </summary>
        public string County { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliveryAddress
        /// </summary>
        public string DeliveryAddress { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsShelve
        /// </summary>
        public Nullable<bool> IsShelve { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderRemarks
        /// </summary>
        public string OrderRemarks { get; set; }
    
    	/// <summary>
        /// Gets or sets the ShelveRemarks
        /// </summary>
        public string ShelveRemarks { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_Delivery_Details list
        /// </summary>
        public virtual ICollection<XMDeliveryDetails> XM_Delivery_Details { get; set; }

        #endregion
    }
}
