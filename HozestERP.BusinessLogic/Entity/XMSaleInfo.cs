
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
    public partial class XMSaleInfo: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the Ref
        /// </summary>
        public string Ref { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderInfoID
        /// </summary>
        public int OrderInfoID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerName
        /// </summary>
        public string CustomerName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }
    
    	/// <summary>
        /// Gets or sets the SaleAddress
        /// </summary>
        public string SaleAddress { get; set; }
    
    	/// <summary>
        /// Gets or sets the SaleMoney
        /// </summary>
        public Nullable<decimal> SaleMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReceivingType
        /// </summary>
        public Nullable<int> ReceivingType { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the BillStatus
        /// </summary>
        public Nullable<int> BillStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }
    
    	/// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }
    
    	/// <summary>
        /// Gets or sets the BizDt
        /// </summary>
        public Nullable<System.DateTime> BizDt { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
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
        /// Gets or sets the ProjectId
        /// </summary>
        public Nullable<int> ProjectId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ExpressFee
        /// </summary>
        public Nullable<decimal> ExpressFee { get; set; }
    
    	/// <summary>
        /// Gets or sets the PartsFee
        /// </summary>
        public Nullable<decimal> PartsFee { get; set; }
    
    	/// <summary>
        /// Gets or sets the InstallFee
        /// </summary>
        public Nullable<decimal> InstallFee { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_SaleInfoProductDetails list
        /// </summary>
        public virtual ICollection<XMSaleInfoProductDetails> XM_SaleInfoProductDetails { get; set; }

        #endregion
    }
}
