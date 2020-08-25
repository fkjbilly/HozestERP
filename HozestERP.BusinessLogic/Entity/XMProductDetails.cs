
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
    public partial class XMProductDetails: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        public Nullable<int> ProductId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductTypeId
        /// </summary>
        public Nullable<int> ProductTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformInventory
        /// </summary>
        public Nullable<int> PlatformInventory { get; set; }
    
    	/// <summary>
        /// Gets or sets the strUrl
        /// </summary>
        public string strUrl { get; set; }
    
    	/// <summary>
        /// Gets or sets the Images
        /// </summary>
        public Nullable<int> Images { get; set; }
    
    	/// <summary>
        /// Gets or sets the Costprice
        /// </summary>
        public Nullable<decimal> Costprice { get; set; }
    
    	/// <summary>
        /// Gets or sets the Saleprice
        /// </summary>
        public Nullable<decimal> Saleprice { get; set; }
    
    	/// <summary>
        /// Gets or sets the TCostprice
        /// </summary>
        public Nullable<decimal> TCostprice { get; set; }
    
    	/// <summary>
        /// Gets or sets the TDateTimeStart
        /// </summary>
        public Nullable<System.DateTime> TDateTimeStart { get; set; }
    
    	/// <summary>
        /// Gets or sets the TDateTimeEnd
        /// </summary>
        public Nullable<System.DateTime> TDateTimeEnd { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsMainPush
        /// </summary>
        public Nullable<bool> IsMainPush { get; set; }
    
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
        /// Gets or sets the Color
        /// </summary>
        public string Color { get; set; }
    
    	/// <summary>
        /// Gets or sets the TemporaryManufacturersCode
        /// </summary>
        public string TemporaryManufacturersCode { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
