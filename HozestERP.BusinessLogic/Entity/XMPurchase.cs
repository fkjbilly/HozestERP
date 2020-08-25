
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
    public partial class XMPurchase: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the PurchaseNumber
        /// </summary>
        public string PurchaseNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the SupplierId
        /// </summary>
        public Nullable<int> SupplierId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Contact
        /// </summary>
        public string Contact { get; set; }
    
    	/// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }
    
    	/// <summary>
        /// Gets or sets the Fax
        /// </summary>
        public string Fax { get; set; }
    
    	/// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PurchaseDate
        /// </summary>
        public Nullable<System.DateTime> PurchaseDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the InputUserId
        /// </summary>
        public Nullable<int> InputUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the Date_Created
        /// </summary>
        public Nullable<System.DateTime> Date_Created { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the BillStatus
        /// </summary>
        public int BillStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the Tax
        /// </summary>
        public Nullable<decimal> Tax { get; set; }
    
    	/// <summary>
        /// Gets or sets the MoneywithTax
        /// </summary>
        public Nullable<decimal> MoneywithTax { get; set; }
    
    	/// <summary>
        /// Gets or sets the PaymentType
        /// </summary>
        public Nullable<int> PaymentType { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductsMoney
        /// </summary>
        public Nullable<decimal> ProductsMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the DealDate
        /// </summary>
        public Nullable<System.DateTime> DealDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the DealAddress
        /// </summary>
        public string DealAddress { get; set; }
    
    	/// <summary>
        /// Gets or sets the ConfirmUserId
        /// </summary>
        public Nullable<int> ConfirmUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ConfirmDate
        /// </summary>
        public Nullable<System.DateTime> ConfirmDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the BillMemo
        /// </summary>
        public string BillMemo { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the EmitFactory
        /// </summary>
        public string EmitFactory { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyMember
        /// </summary>
        public string BuyMember { get; set; }
    
    	/// <summary>
        /// Gets or sets the Receiver
        /// </summary>
        public string Receiver { get; set; }
    
    	/// <summary>
        /// Gets or sets the PayDate
        /// </summary>
        public Nullable<System.DateTime> PayDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the SellerRemarks
        /// </summary>
        public string SellerRemarks { get; set; }
    
    	/// <summary>
        /// Gets or sets the BuyerRemarks
        /// </summary>
        public string BuyerRemarks { get; set; }
    
    	/// <summary>
        /// Gets or sets the Freight
        /// </summary>
        public Nullable<decimal> Freight { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReceiverMobile
        /// </summary>
        public string ReceiverMobile { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsBuildOrder
        /// </summary>
        public Nullable<bool> IsBuildOrder { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_PurchaseProductDetails list
        /// </summary>
        public virtual ICollection<XMPurchaseProductDetails> XM_PurchaseProductDetails { get; set; }

        #endregion
    }
}
