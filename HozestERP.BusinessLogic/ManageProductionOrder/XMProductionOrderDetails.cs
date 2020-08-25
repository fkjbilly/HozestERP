
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2017-04-14 10:05:06
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

namespace HozestERP.BusinessLogic.ManageProductionOrder
{
    public partial class XMProductionOrderDetails: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductionOrderID
        /// </summary>
        public Nullable<int> ProductionOrderID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string ManufacturersCode { get; set; }
    
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
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the Status
        /// </summary>
        public Nullable<bool> Status { get; set; }
    
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
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductWeight
        /// </summary>
        public string ProductWeight { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductVolume
        /// </summary>
        public string ProductVolume { get; set; }
    
    	/// <summary>
        /// Gets or sets the ProductionNumber
        /// </summary>
        public string ProductionNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the EstimateStorageDate
        /// </summary>
        public Nullable<System.DateTime> EstimateStorageDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsSingleRow
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_ProductionOrder
        /// </summary>
        public virtual XMProductionOrder XM_ProductionOrder { get; set; }

        #endregion
    }
}
