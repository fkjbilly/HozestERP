
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
    public partial class XMQuestionDetail: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the QuestionID
        /// </summary>
        public int QuestionID { get; set; }
    
    	/// <summary>
        /// Gets or sets the SrvBeforeCustomerID
        /// </summary>
        public Nullable<int> SrvBeforeCustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the SrvAfterCustomerID
        /// </summary>
        public Nullable<int> SrvAfterCustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }
    
    	/// <summary>
        /// Gets or sets the ResultMsg
        /// </summary>
        public string ResultMsg { get; set; }
    
    	/// <summary>
        /// Gets or sets the QuestionTypeID
        /// </summary>
        public Nullable<int> QuestionTypeID { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrdersTime
        /// </summary>
        public Nullable<System.DateTime> OrdersTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the Status
        /// </summary>
        public Nullable<int> Status { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsReturns
        /// </summary>
        public Nullable<bool> IsReturns { get; set; }
    
    	/// <summary>
        /// Gets or sets the ResultsId
        /// </summary>
        public Nullable<int> ResultsId { get; set; }
    
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
        /// Gets or sets the XM_Question
        /// </summary>
        public virtual XMQuestion XM_Question { get; set; }

        #endregion
    }
}
