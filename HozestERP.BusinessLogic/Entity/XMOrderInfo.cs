
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
    public partial class XMOrderInfo: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderInfoCreateDate
        /// </summary>
        public Nullable<System.DateTime> OrderInfoCreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the AppointDeliveryTime
        /// </summary>
        public Nullable<System.DateTime> AppointDeliveryTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliveryTime
        /// </summary>
        public Nullable<System.DateTime> DeliveryTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the PayDate
        /// </summary>
        public Nullable<System.DateTime> PayDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderInfoModified
        /// </summary>
        public Nullable<System.DateTime> OrderInfoModified { get; set; }
    
    	/// <summary>
        /// Gets or sets the CompletionTime
        /// </summary>
        public Nullable<System.DateTime> CompletionTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderStatus
        /// </summary>
        public string OrderStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the WantID
        /// </summary>
        public string WantID { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyerName
        /// </summary>
        public string BuyerName { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyerMobile
        /// </summary>
        public string BuyerMobile { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyerPhone
        /// </summary>
        public string BuyerPhone { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyerAddress
        /// </summary>
        public string BuyerAddress { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyerE_mail
        /// </summary>
        public string BuyerE_mail { get; set; }
    
    	/// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }
    
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
        /// Gets or sets the DeliveryAddressSpare
        /// </summary>
        public string DeliveryAddressSpare { get; set; }
    
    	/// <summary>
        /// Gets or sets the Mobile
        /// </summary>
        public string Mobile { get; set; }
    
    	/// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }
    
    	/// <summary>
        /// Gets or sets the SourceType
        /// </summary>
        public string SourceType { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerServiceRemark
        /// </summary>
        public string CustomerServiceRemark { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
    
    	/// <summary>
        /// Gets or sets the BelongsServiceId
        /// </summary>
        public Nullable<int> BelongsServiceId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ForService
        /// </summary>
        public string ForService { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsInvoiced
        /// </summary>
        public Nullable<bool> IsInvoiced { get; set; }
    
    	/// <summary>
        /// Gets or sets the InvoiceNo
        /// </summary>
        public string InvoiceNo { get; set; }
    
    	/// <summary>
        /// Gets or sets the InvoiceHead
        /// </summary>
        public string InvoiceHead { get; set; }
    
    	/// <summary>
        /// Gets or sets the PayMethod
        /// </summary>
        public string PayMethod { get; set; }
    
    	/// <summary>
        /// Gets or sets the InvoicePrice
        /// </summary>
        public Nullable<decimal> InvoicePrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the DistributeMethod
        /// </summary>
        public string DistributeMethod { get; set; }
    
    	/// <summary>
        /// Gets or sets the DistributePrice
        /// </summary>
        public Nullable<decimal> DistributePrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsDistributed
        /// </summary>
        public Nullable<bool> IsDistributed { get; set; }
    
    	/// <summary>
        /// Gets or sets the SupportPrice
        /// </summary>
        public Nullable<decimal> SupportPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductWeight
        /// </summary>
        public Nullable<decimal> ProductWeight { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductPrice
        /// </summary>
        public Nullable<decimal> ProductPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the Taxes
        /// </summary>
        public Nullable<decimal> Taxes { get; set; }
    
    	/// <summary>
        /// Gets or sets the Discount
        /// </summary>
        public Nullable<decimal> Discount { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductPromotion
        /// </summary>
        public Nullable<decimal> ProductPromotion { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderPromotion
        /// </summary>
        public Nullable<decimal> OrderPromotion { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderPrice
        /// </summary>
        public Nullable<decimal> OrderPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReceivablePrice
        /// </summary>
        public Nullable<decimal> ReceivablePrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the PayPrice
        /// </summary>
        public Nullable<decimal> PayPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsScalping
        /// </summary>
        public Nullable<bool> IsScalping { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsCashBack
        /// </summary>
        public Nullable<bool> IsCashBack { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsSentGifts
        /// </summary>
        public Nullable<bool> IsSentGifts { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEvaluate
        /// </summary>
        public Nullable<bool> IsEvaluate { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyerObtainPointFee
        /// </summary>
        public Nullable<decimal> BuyerObtainPointFee { get; set; }
    
    	/// <summary>
        /// Gets or sets the TradeFrom
        /// </summary>
        public string TradeFrom { get; set; }
    
    	/// <summary>
        /// Gets or sets the RealPointFee
        /// </summary>
        public Nullable<decimal> RealPointFee { get; set; }
    
    	/// <summary>
        /// Gets or sets the CommissionFee
        /// </summary>
        public Nullable<decimal> CommissionFee { get; set; }
    
    	/// <summary>
        /// Gets or sets the TradeSource
        /// </summary>
        public string TradeSource { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreditCardFee
        /// </summary>
        public Nullable<decimal> CreditCardFee { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsAbnormal
        /// </summary>
        public Nullable<bool> IsAbnormal { get; set; }
    
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
        /// Gets or sets the FinancialAudit
        /// </summary>
        public Nullable<bool> FinancialAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsOurOrder
        /// </summary>
        public Nullable<bool> IsOurOrder { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_OrderInfoProductDetails list
        /// </summary>
        public virtual ICollection<XMOrderInfoProductDetails> XM_OrderInfoProductDetails { get; set; }

        #endregion
    }
}
