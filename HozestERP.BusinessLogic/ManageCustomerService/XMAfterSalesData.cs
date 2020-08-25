
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-07-01 15:43:24
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

namespace HozestERP.BusinessLogic.ManageCustomerService
{
    public partial class XMAfterSalesData: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public Nullable<int> CustomerID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Month
        /// </summary>
        public string Month { get; set; }
    
    	/// <summary>
        /// Gets or sets the Type
        /// </summary>
        public Nullable<bool> Type { get; set; }
    
    	/// <summary>
        /// Gets or sets the ErrorCount
        /// </summary>
        public Nullable<int> ErrorCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the TMIndex
        /// </summary>
        public Nullable<decimal> TMIndex { get; set; }
    
    	/// <summary>
        /// Gets or sets the DSRScore
        /// </summary>
        public Nullable<decimal> DSRScore { get; set; }
    
    	/// <summary>
        /// Gets or sets the ResponseTime
        /// </summary>
        public Nullable<decimal> ResponseTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the JDResponseTime
        /// </summary>
        public Nullable<decimal> JDResponseTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the JDCustomerService
        /// </summary>
        public Nullable<decimal> JDCustomerService { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerComplaints
        /// </summary>
        public Nullable<int> CustomerComplaints { get; set; }
    
    	/// <summary>
        /// Gets or sets the EvaluationPoints
        /// </summary>
        public Nullable<int> EvaluationPoints { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateTime
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateTime
        /// </summary>
        public Nullable<System.DateTime> UpdateTime { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
