
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
    public partial class SearchTargetDetails_Result: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
    	public int ID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the SalesmanName
        /// </summary>
    	public string SalesmanName{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the Amount
        /// </summary>
    	public decimal Amount{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the SalesmanId
        /// </summary>
    	public int SalesmanId{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the HaveAmount
        /// </summary>
    	public decimal HaveAmount{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ContractNum
        /// </summary>
    	public int ContractNum{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ContractAmount
        /// </summary>
    	public decimal ContractAmount{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ClientUnit
        /// </summary>
    	public Nullable<decimal> ClientUnit{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CompletionRate
        /// </summary>
    	public string CompletionRate{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ROWNUM
        /// </summary>
    	public Nullable<long> ROWNUM{ get; set; } 
    	
        #endregion
    }
}
