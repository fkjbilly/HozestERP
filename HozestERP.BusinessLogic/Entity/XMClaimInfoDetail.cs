
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
    public partial class XMClaimInfoDetail: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ClaimInfoID
        /// </summary>
        public int ClaimInfoID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ClaimTypeID
        /// </summary>
        public int ClaimTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ClaimAcount
        /// </summary>
        public Nullable<decimal> ClaimAcount { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsConfirm
        /// </summary>
        public Nullable<bool> IsConfirm { get; set; }
    
    	/// <summary>
        /// Gets or sets the ConfirmPerson
        /// </summary>
        public Nullable<int> ConfirmPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the ConfirmDate
        /// </summary>
        public Nullable<System.DateTime> ConfirmDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the Reason
        /// </summary>
        public string Reason { get; set; }
    
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
    
    	/// <summary>
        /// Gets or sets the ResponsiblePerson
        /// </summary>
        public string ResponsiblePerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the DamagedCondition
        /// </summary>
        public string DamagedCondition { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
