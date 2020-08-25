
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-12-22 09:49:03
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Enterprises;

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMOtherMonthlyTarget: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the DateTime
        /// </summary>
        public System.DateTime DateTime { get; set; }
    
    	/// <summary>
        /// Gets or sets the Income
        /// </summary>
        public decimal Income { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }
    
    	/// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the Updater
        /// </summary>
        public Nullable<int> Updater { get; set; }
    
    	/// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the DepartmentID
        /// </summary>
        public int DepartmentID { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName
        {
            get
            {
                var department = IoC.Resolve<IEnterpriseService>().GetDepartmentById((int)this.DepartmentID);
                if (department != null)
                    return department.DepName;
                return string.Empty;
            }
        }
        public string AuthorName
        {
            get
            {
                if (this.Updater != null)
                {
                    return IoC.Resolve<IXMBusinessDataService>().GetCustomerName(this.Updater.Value.ToString());
                }
                else
                {
                    return "";
                }
            }
        }

        public bool FinancialStatus
        {
            get
            {
                if (this.ID != null)
                {
                    return IoC.Resolve<IXMBusinessDataService>().GetFinancialStatusByBusinessDateID(this.ID);
                }
                else
                {
                    return false;
                }
            }
        }
    	
        #endregion
    }
}
