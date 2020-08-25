
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
    public partial class AdvanceApplication: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }
    
    	/// <summary>
        /// Gets or sets the ScalpingId
        /// </summary>
        public Nullable<int> ScalpingId { get; set; }
    
    	/// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
    
    	/// <summary>
        /// Gets or sets the TheAdvanceType
        /// </summary>
        public Nullable<int> TheAdvanceType { get; set; }
    
    	/// <summary>
        /// Gets or sets the NickId
        /// </summary>
        public Nullable<int> NickId { get; set; }
    
    	/// <summary>
        /// Gets or sets the ApplicationDepartment
        /// </summary>
        public Nullable<int> ApplicationDepartment { get; set; }
    
    	/// <summary>
        /// Gets or sets the ApplicationPayee
        /// </summary>
        public string ApplicationPayee { get; set; }
    
    	/// <summary>
        /// Gets or sets the TheAdvanceSubject
        /// </summary>
        public string TheAdvanceSubject { get; set; }
    
    	/// <summary>
        /// Gets or sets the TheAdvanceMoney
        /// </summary>
        public Nullable<decimal> TheAdvanceMoney { get; set; }
    
    	/// <summary>
        /// Gets or sets the ForecastReturnTime
        /// </summary>
        public Nullable<System.DateTime> ForecastReturnTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the Subject
        /// </summary>
        public string Subject { get; set; }
    
    	/// <summary>
        /// Gets or sets the Applicants
        /// </summary>
        public Nullable<int> Applicants { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManagerPeople
        /// </summary>
        public Nullable<int> ManagerPeople { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManagerIsAudit
        /// </summary>
        public Nullable<bool> ManagerIsAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the ManagerTime
        /// </summary>
        public Nullable<System.DateTime> ManagerTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancePeople
        /// </summary>
        public Nullable<int> FinancePeople { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceIsAudit
        /// </summary>
        public Nullable<bool> FinanceIsAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceAuditTime
        /// </summary>
        public Nullable<System.DateTime> FinanceAuditTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the PaymentTime
        /// </summary>
        public Nullable<System.DateTime> PaymentTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the AdvanceState
        /// </summary>
        public Nullable<int> AdvanceState { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceOkPeople
        /// </summary>
        public Nullable<int> FinanceOkPeople { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceOkIsAudit
        /// </summary>
        public Nullable<bool> FinanceOkIsAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceOkTime
        /// </summary>
        public Nullable<System.DateTime> FinanceOkTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceAdvanceEndPeople
        /// </summary>
        public Nullable<int> FinanceAdvanceEndPeople { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceAdvanceEndIsAudit
        /// </summary>
        public Nullable<bool> FinanceAdvanceEndIsAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinanceAdvanceEndTime
        /// </summary>
        public Nullable<System.DateTime> FinanceAdvanceEndTime { get; set; }
    
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
        /// Gets or sets the DirectorPeople
        /// </summary>
        public Nullable<int> DirectorPeople { get; set; }
    
    	/// <summary>
        /// Gets or sets the DirectorIsAudit
        /// </summary>
        public Nullable<bool> DirectorIsAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the DirectorTime
        /// </summary>
        public Nullable<System.DateTime> DirectorTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the OperationsPeople
        /// </summary>
        public Nullable<int> OperationsPeople { get; set; }
    
    	/// <summary>
        /// Gets or sets the OperationIsAudit
        /// </summary>
        public Nullable<bool> OperationIsAudit { get; set; }
    
    	/// <summary>
        /// Gets or sets the OperationTime
        /// </summary>
        public Nullable<System.DateTime> OperationTime { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
