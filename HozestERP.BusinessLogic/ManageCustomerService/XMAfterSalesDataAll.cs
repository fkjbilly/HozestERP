
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
    public partial class XMAfterSalesDataAll: BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

    	/// <summary>
        /// Gets or sets the CustomerID
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the GroupID
        /// </summary>
        public int GroupID { get; set; }

        /// <summary>
        /// Gets or sets the GroupName
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the DemandReturn
        /// </summary>
        public int DemandReturn { get; set; }

        /// <summary>
        /// Gets or sets the ActualReturn
        /// </summary>
        public int ActualReturn { get; set; }

        /// <summary>
        /// Gets or sets the ReturnRate
        /// </summary>
        public string ReturnRate { get; set; }

        /// <summary>
        /// Gets or sets the PersonalWorkload
        /// </summary>
        public int PersonalWorkload { get; set; }

        /// <summary>
        /// Gets or sets the AverageWorkload
        /// </summary>
        public double AverageWorkload { get; set; }

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
        public string ErrorCount { get; set; }
    
    	/// <summary>
        /// Gets or sets the TMIndex
        /// </summary>
        public string TMIndex { get; set; }
    
    	/// <summary>
        /// Gets or sets the DSRScore
        /// </summary>
        public string DSRScore { get; set; }
    
    	/// <summary>
        /// Gets or sets the ResponseTime
        /// </summary>
        public string ResponseTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the JDResponseTime
        /// </summary>
        public string JDResponseTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the JDCustomerService
        /// </summary>
        public string JDCustomerService { get; set; }
    
    	/// <summary>
        /// Gets or sets the CustomerComplaints
        /// </summary>
        public string CustomerComplaints { get; set; }
    
    	/// <summary>
        /// Gets or sets the EvaluationPoints
        /// </summary>
        public string EvaluationPoints { get; set; }

        /// <summary>
        /// Gets or sets the ExistXMAfterSalesData
        /// </summary>
        public bool ExistXMAfterSalesData { get; set; }

        /// <summary>
        /// Gets or sets the IsFile
        /// </summary>
        public bool IsFile { get; set; }

        #endregion
        #region Custom Properties
    		
    	
        #endregion
    }
}
