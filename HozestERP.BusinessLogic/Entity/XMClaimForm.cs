
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
    public partial class XMClaimForm: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ClaimNumber
        /// </summary>
        public string ClaimNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the ApplicationNo
        /// </summary>
        public string ApplicationNo { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsReturn
        /// </summary>
        public Nullable<bool> IsReturn { get; set; }
    
    	/// <summary>
        /// Gets or sets the ClaimDate
        /// </summary>
        public Nullable<System.DateTime> ClaimDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ClaimType
        /// </summary>
        public Nullable<int> ClaimType { get; set; }
    
    	/// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReturnTime
        /// </summary>
        public Nullable<System.DateTime> ReturnTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinishTime
        /// </summary>
        public Nullable<System.DateTime> FinishTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the ConsignorName
        /// </summary>
        public string ConsignorName { get; set; }
    
    	/// <summary>
        /// Gets or sets the CompanyName
        /// </summary>
        public string CompanyName { get; set; }
    
    	/// <summary>
        /// Gets or sets the BeginDate
        /// </summary>
        public Nullable<System.DateTime> BeginDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the EndDate
        /// </summary>
        public Nullable<System.DateTime> EndDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the LogisticsNumber
        /// </summary>
        public string LogisticsNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the GoodsName
        /// </summary>
        public string GoodsName { get; set; }
    
    	/// <summary>
        /// Gets or sets the Count
        /// </summary>
        public Nullable<int> Count { get; set; }
    
    	/// <summary>
        /// Gets or sets the InsuredAmount
        /// </summary>
        public Nullable<decimal> InsuredAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the BeginPlace
        /// </summary>
        public string BeginPlace { get; set; }
    
    	/// <summary>
        /// Gets or sets the EndPlace
        /// </summary>
        public string EndPlace { get; set; }
    
    	/// <summary>
        /// Gets or sets the BrokenPieces
        /// </summary>
        public Nullable<int> BrokenPieces { get; set; }
    
    	/// <summary>
        /// Gets or sets the BrokenStatus
        /// </summary>
        public string BrokenStatus { get; set; }
    
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

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_ClaimForm1
        /// </summary>
        public virtual XMClaimForm XM_ClaimForm1 { get; set; }
    
    	/// <summary>
        /// Gets or sets the XM_ClaimForm2
        /// </summary>
        public virtual XMClaimForm XM_ClaimForm2 { get; set; }
    
    	/// <summary>
        /// Gets or sets the XM_ClaimFormDetail list
        /// </summary>
        public virtual ICollection<XMClaimFormDetail> XM_ClaimFormDetail { get; set; }

        #endregion
    }
}
