
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-12-08 13:14:09
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
    public partial class XMBusinessData: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContractNumber
        /// </summary>
        public string ContractNumber { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContractAmount
        /// </summary>
        public Nullable<decimal> ContractAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the ClientCompany
        /// </summary>
        public string ClientCompany { get; set; }
    
    	/// <summary>
        /// Gets or sets the SubmitLimit
        /// </summary>
        public string SubmitLimit { get; set; }

        /// <summary>
        /// Gets or sets the PayPerson
        /// </summary>
        public string PayPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the SubmitDate
        /// </summary>
        public Nullable<System.DateTime> SubmitDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the ActualAmount
        /// </summary>
        public Nullable<decimal> ActualAmount { get; set; }
    
    	/// <summary>
        /// Gets or sets the BelongingDepID
        /// </summary>
        public Nullable<int> BelongingDepID { get; set; }
    
    	/// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }
    
    	/// <summary>
        /// Gets or sets the Creator
        /// </summary>
        public Nullable<int> Creator { get; set; }
    
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

        #endregion
        #region Custom Properties

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

        public string BelongingName
        {
            get
            {
                if (this.ID != null)
                {
                    return IoC.Resolve<IXMBusinessDataService>().GetCustomerNameByBusinessDateID(this.ID);
                }
                else
                {
                    return "";
                }
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

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName
        {
            get
            {
                var department = IoC.Resolve<IEnterpriseService>().GetDepartmentById((int)this.BelongingDepID);
                if (department != null)
                    return department.DepName;
                return string.Empty;
            }
        }

        public string StrSubmitDate
        {
            get
            {
                return ((DateTime)this.SubmitDate).ToString("yyyy/MM/dd");
            }
        }

        #endregion
        #region Navigation Properties
    
    	/// <summary>
        /// Gets or sets the XM_BusinessDataDetail list
        /// </summary>
        public virtual ICollection<XMBusinessDataDetail> XM_BusinessDataDetail { get; set; }

        #endregion
    }
}
