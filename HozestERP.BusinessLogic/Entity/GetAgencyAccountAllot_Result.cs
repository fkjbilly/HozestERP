
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
    public partial class GetAgencyAccountAllot_Result: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
    	public int ID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the AgentAccountID
        /// </summary>
    	public Nullable<int> AgentAccountID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the ClientID
        /// </summary>
    	public Nullable<int> ClientID{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the AgentAccountName
        /// </summary>
    	public string AgentAccountName{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the MasterWangNo
        /// </summary>
    	public string MasterWangNo{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the Enabled
        /// </summary>
    	public Nullable<int> Enabled{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CreateStaff
        /// </summary>
    	public Nullable<int> CreateStaff{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
    	public Nullable<System.DateTime> CreateDate{ get; set; } 
    	
    	/// <summary>
        /// Gets or sets the AEManager
        /// </summary>
    	public string AEManager{ get; set; } 
    	
        #endregion
    }
}
