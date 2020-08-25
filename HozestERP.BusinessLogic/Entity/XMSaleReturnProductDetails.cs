
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
    public partial class XMSaleReturnProductDetails: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the SaleReturnId
        /// </summary>
        public int SaleReturnId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public int ProductId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductCount
        /// </summary>
        public Nullable<int> ProductCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductMoney
        /// </summary>
        public Nullable<decimal> ProductMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductPrice
        /// </summary>
        public Nullable<decimal> ProductPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the DeliveryProductsDetailID
        /// </summary>
        public Nullable<int> DeliveryProductsDetailID { get; set; }
    
    	/// <summary>
        /// Gets or sets the RejectionProductsPrice
        /// </summary>
        public Nullable<decimal> RejectionProductsPrice { get; set; }
    
    	/// <summary>
        /// Gets or sets the RejectionsaleMoney
        /// </summary>
        public Nullable<decimal> RejectionsaleMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the RejectionProdcutsCount
        /// </summary>
        public Nullable<int> RejectionProdcutsCount { get; set; }
    
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
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_SaleReturn
        /// </summary>
        public virtual XMSaleReturn XM_SaleReturn { get; set; }
    
    	/// <summary>
        /// Gets or sets the XM_SaleReturnBarCodeDetail list
        /// </summary>
        public virtual ICollection<XMSaleReturnBarCodeDetail> XM_SaleReturnBarCodeDetail { get; set; }

        #endregion
    }
}
