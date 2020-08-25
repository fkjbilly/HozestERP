
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-12-16 08:53:12
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMBusinessDataOther: BaseEntity
    {
        #region Primitive Properties
    
    	/// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
    
    	/// <summary>
        /// Gets or sets the Object
        /// </summary>
        public string Object { get; set; }
    
    	/// <summary>
        /// Gets or sets the SubmitDate
        /// </summary>
        public Nullable<System.DateTime> SubmitDate { get; set; }
    
    	/// <summary>
        /// Gets or sets the BelongingDepID
        /// </summary>
        public Nullable<int> BelongingDepID { get; set; }

        /// <summary>
        /// Gets or sets the BelongingProjectID
        /// </summary>
        public Nullable<int> BelongingProjectID { get; set; }

    	/// <summary>
        /// Gets or sets the BelongingName
        /// </summary>
        public string BelongingName { get; set; }
    
    	/// <summary>
        /// Gets or sets the AmountType
        /// </summary>
        public Nullable<int> AmountType { get; set; }
    
    	/// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }
    
    	/// <summary>
        /// Gets or sets the BusinessType
        /// </summary>
        public Nullable<int> BusinessType { get; set; }
    
    	/// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }
    
    	/// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the ContractlStatus
        /// </summary>
        public Nullable<bool> ContractlStatus { get; set; }
    
    	/// <summary>
        /// Gets or sets the FAuditPerson
        /// </summary>
        public Nullable<int> FAuditPerson { get; set; }
    
    	/// <summary>
        /// Gets or sets the CAuditPerson
        /// </summary>
        public Nullable<int> CAuditPerson { get; set; }
    
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

        public string AmountTypeName
        {
            get
            {
                if (this.AmountType != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID((int)this.AmountType).CodeName;
                }
                else
                {
                    return "";
                }
            }
        }

        public string BusinessTypeName
        {
            get
            {
                if (this.BusinessType != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID((int)this.BusinessType).CodeName;
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

        public string FAuditPersonName
        {
            get
            {
                if (this.FAuditPerson != null)
                {
                    return IoC.Resolve<IXMBusinessDataService>().GetCustomerName(this.FAuditPerson.Value.ToString());
                }
                else
                {
                    return "";
                }
            }
        }

        public string CAuditPersonName
        {
            get
            {
                if (this.CAuditPerson != null)
                {
                    return IoC.Resolve<IXMBusinessDataService>().GetCustomerName(this.CAuditPerson.Value.ToString());
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                string result = "";
                if (this.BelongingProjectID != null && this.BelongingProjectID != -1)
                {
                    var nick = IoC.Resolve<IXMProjectService>().GetXMProjectById(this.BelongingProjectID.Value);
                    if (nick != null)
                    {
                        result = nick.ProjectName;
                    }
                }
                else if (this.BelongingProjectID == -1)
                {
                    if (this.BelongingDepID == 63)
                    {
                        result = "B2C";
                    }
                    else if (this.BelongingDepID == 297)
                    {
                        result = "B2B";
                    }
                }
                return result;
            }
        }

        #endregion
    }
}
