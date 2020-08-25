
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
    public partial class CRMBUTarget1_Result: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
    	public int ID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the Date
        /// </summary>
    	public string Date{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the EYear
        /// </summary>
    	public Nullable<int> EYear{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the Emonth
        /// </summary>
    	public Nullable<int> Emonth{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the HaveAmount
        /// </summary>
    	public decimal HaveAmount{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CompletionRate
        /// </summary>
    	public string CompletionRate{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ConNUm
        /// </summary>
    	public int ConNUm{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CusCompletionRate
        /// </summary>
    	public string CusCompletionRate{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the AVCuPrice
        /// </summary>
    	public Nullable<decimal> AVCuPrice{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the LinkCusNum
        /// </summary>
    	public Nullable<int> LinkCusNum{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the IntentionCusNum
        /// </summary>
    	public Nullable<int> IntentionCusNum{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the NewCusNum
        /// </summary>
    	public Nullable<int> NewCusNum{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the TargetSales
        /// </summary>
    	public Nullable<decimal> TargetSales{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ROWNUM
        /// </summary>
    	public Nullable<long> ROWNUM{ get; set; } 
    	
        #endregion
    }
}
