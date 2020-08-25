
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
    public partial class XMQuestion: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderNO
        /// </summary>
        public string OrderNO { get; set; }
    
    	/// <summary>
        /// Gets or sets the LogisticsNo
        /// </summary>
        public string LogisticsNo { get; set; }
    
    	/// <summary>
        /// Gets or sets the EmergencyDegree
        /// </summary>
        public Nullable<int> EmergencyDegree { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformID
        /// </summary>
        public Nullable<int> PlatformID { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Status
        /// </summary>
        public Nullable<int> Status { get; set; }
    
    	/// <summary>
        /// Gets or sets the Buyer
        /// </summary>
        public string Buyer { get; set; }
    
    	/// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }
    
    	/// <summary>
        /// Gets or sets the RefundLogisticsNo
        /// </summary>
        public string RefundLogisticsNo { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsSolve
        /// </summary>
        public Nullable<bool> IsSolve { get; set; }
    
    	/// <summary>
        /// Gets or sets the QuestionLevel
        /// </summary>
        public Nullable<int> QuestionLevel { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateByID
        /// </summary>
        public Nullable<int> CreateByID { get; set; }
    
    	/// <summary>
        /// Gets or sets the LastModifyTime
        /// </summary>
        public Nullable<System.DateTime> LastModifyTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the LastModifyByID
        /// </summary>
        public Nullable<int> LastModifyByID { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_QuestionDetail list
        /// </summary>
        public virtual ICollection<XMQuestionDetail> XM_QuestionDetail { get; set; }

        #endregion
    }
}
