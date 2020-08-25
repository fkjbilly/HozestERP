
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
    public partial class XMPremiums: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }
    
    	/// <summary>
        /// Gets or sets the WantId
        /// </summary>
        public string WantId { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEvaluation
        /// </summary>
        public Nullable<bool> IsEvaluation { get; set; }
    
    	/// <summary>
        /// Gets or sets the EvaluationDate
        /// </summary>
        public Nullable<System.DateTime> EvaluationDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the PremiumsStatus
        /// </summary>
        public Nullable<int> PremiumsStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the ActivityExplanation
        /// </summary>
        public string ActivityExplanation { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancePeople
        /// </summary>
        public Nullable<int> FinancePeople { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceIsAudit
        /// </summary>
        public Nullable<bool> FinanceIsAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceTime
        /// </summary>
        public Nullable<System.DateTime> FinanceTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManagerPeople
        /// </summary>
        public Nullable<int> ManagerPeople { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManagerStatus
        /// </summary>
        public Nullable<int> ManagerStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the PremiumsTypeId
        /// </summary>
        public Nullable<int> PremiumsTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManagerTime
        /// </summary>
        public Nullable<System.DateTime> ManagerTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManagerExplanation
        /// </summary>
        public string ManagerExplanation { get; set; }
    
    	/// <summary>
        /// Gets or sets the DirectorPeople
        /// </summary>
        public Nullable<int> DirectorPeople { get; set; }
    
    	/// <summary>
        /// Gets or sets the DirectorStatus
        /// </summary>
        public Nullable<int> DirectorStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the DirectorTime
        /// </summary>
        public Nullable<System.DateTime> DirectorTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the DirectorExplanation
        /// </summary>
        public string DirectorExplanation { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsSingleRow
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreatorID
        /// </summary>
        public Nullable<int> CreatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdatorID
        /// </summary>
        public Nullable<int> UpdatorID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the PaymentPerson
        /// </summary>
        public Nullable<int> PaymentPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the QuestionDetailID
        /// </summary>
        public string QuestionDetailID { get; set; }
    
    	/// <summary>
        /// Gets or sets the EvaluationID
        /// </summary>
        public Nullable<int> EvaluationID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Note
        /// </summary>
        public string Note { get; set; }
    
    	/// <summary>
        /// Gets or sets the NoOrderNickId
        /// </summary>
        public Nullable<int> NoOrderNickId { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
