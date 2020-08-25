
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
    public partial class XMConsultation: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public string CustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ReceptionDate
        /// </summary>
        public Nullable<System.DateTime> ReceptionDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the NoTurnoverType
        /// </summary>
        public string NoTurnoverType { get; set; }
    
    	/// <summary>
        /// Gets or sets the DateReason
        /// </summary>
        public string DateReason { get; set; }
    
    	/// <summary>
        /// Gets or sets the NoCause
        /// </summary>
        public Nullable<int> NoCause { get; set; }
    
    	/// <summary>
        /// Gets or sets the FollowGrade
        /// </summary>
        public string FollowGrade { get; set; }
    
    	/// <summary>
        /// Gets or sets the LeaderComments
        /// </summary>
        public string LeaderComments { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsOrder
        /// </summary>
        public Nullable<bool> IsOrder { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Created
        /// </summary>
        public Nullable<System.DateTime> Created { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Updated
        /// </summary>
        public Nullable<System.DateTime> Updated { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string ManufacturersCode { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
