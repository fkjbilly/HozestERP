
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
    public partial class GetBUMyContract_Result: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Url
        /// </summary>
    	public string Url{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ClientID
        /// </summary>
    	public int ClientID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ContractID
        /// </summary>
    	public int ContractID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the MasterWangNo
        /// </summary>
    	public string MasterWangNo{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the StoreName
        /// </summary>
    	public string StoreName{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the SectorID
        /// </summary>
    	public int SectorID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CreditRatingID
        /// </summary>
    	public int CreditRatingID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CusSourceID
        /// </summary>
    	public int CusSourceID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ContractCode
        /// </summary>
    	public string ContractCode{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the Amount
        /// </summary>
    	public decimal Amount{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the HavePayAmount
        /// </summary>
    	public decimal HavePayAmount{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ContractStatusID
        /// </summary>
    	public int ContractStatusID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the Published
        /// </summary>
    	public Nullable<bool> Published{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ContractDate
        /// </summary>
    	public System.DateTime ContractDate{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ServiceStartTime
        /// </summary>
    	public System.DateTime ServiceStartTime{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ServiceEndTime
        /// </summary>
    	public System.DateTime ServiceEndTime{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
    	public int CustomerID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the AMCustomerID
        /// </summary>
    	public Nullable<int> AMCustomerID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the AECustomerID
        /// </summary>
    	public Nullable<int> AECustomerID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the AMCustomerName
        /// </summary>
    	public string AMCustomerName{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the AECustomerName
        /// </summary>
    	public string AECustomerName{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the SectorName
        /// </summary>
    	public string SectorName{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CreditRatingName
        /// </summary>
    	public string CreditRatingName{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CusSourceName
        /// </summary>
    	public string CusSourceName{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CustomerName
        /// </summary>
    	public string CustomerName{ get; set; } 
    	
        #endregion
    }
}
