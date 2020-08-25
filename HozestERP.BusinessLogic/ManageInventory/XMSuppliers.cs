
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-04-25 17:06:07
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
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMSuppliers: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the SupplierCode
        /// </summary>
        public string SupplierCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the SupplierName
        /// </summary>
        public string SupplierName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Contacter
        /// </summary>
        public string Contacter { get; set; }
    
    	/// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }
    
    	/// <summary>
        /// Gets or sets the QQ
        /// </summary>
        public string QQ { get; set; }
    
    	/// <summary>
        /// Gets or sets the Mobile
        /// </summary>
        public string Mobile { get; set; }
    
    	/// <summary>
        /// Gets or sets the Address
        /// </summary>
        public string Address { get; set; }
    
    	/// <summary>
        /// Gets or sets the BankName
        /// </summary>
        public string BankName { get; set; }
    
    	/// <summary>
        /// Gets or sets the BankAccount
        /// </summary>
        public string BankAccount { get; set; }
    
    	/// <summary>
        /// Gets or sets the TaxNumber
        /// </summary>
        public string TaxNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the Fax
        /// </summary>
        public string Fax { get; set; }
    
    	/// <summary>
        /// Gets or sets the Note
        /// </summary>
        public string Note { get; set; }
    
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
        /// Gets or sets the IsDeleted
        /// </summary>
        public Nullable<bool> IsDeleted { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_Bills list
        /// </summary>
        public virtual ICollection<XMBills> XM_Bills { get; set; }

        /// <summary>
        /// Gets or sets the XM_Bills list
        /// </summary>
        public virtual ICollection<XMProduct> XM_Product { get; set; }

        #endregion
    }
}
