
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-02-22 09:17:47
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
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class XMFinancialCapitalFlow : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Date
        /// </summary>
        public Nullable<System.DateTime> Date { get; set; }

        /// <summary>
        /// Gets or sets the Abstract
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        /// Gets or sets the AssociatedPerson
        /// </summary>
        public string AssociatedPerson { get; set; }

        /// <summary>
        /// Gets or sets the ReceivablesType
        /// </summary>
        public Nullable<int> ReceivablesType { get; set; }

        /// <summary>
        /// Gets or sets the BudgetType
        /// </summary>
        public Nullable<int> BudgetType { get; set; }

        /// <summary>
        /// Gets or sets the DepartmentID
        /// </summary>
        public Nullable<int> DepartmentID { get; set; }

        /// <summary>
        /// Gets or sets the BelongingProjectID
        /// </summary>
        public Nullable<int> BelongingProjectID { get; set; }

        /// <summary>
        /// Gets or sets the PaymentCollectionType
        /// </summary>
        public Nullable<int> PaymentCollectionType { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }

        /// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the IsIncome
        /// </summary>
        public Nullable<bool> IsIncome { get; set; }

        /// <summary>
        /// Gets or sets the Audit
        /// </summary>
        public Nullable<bool> Audit { get; set; }

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

        public string ReceivablesTypeName
        {
            get
            {
                if (this.ReceivablesType != null && this.ReceivablesType != -1)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID((int)this.ReceivablesType).CodeName;
                }
                else
                {
                    return "";
                }
            }
        }

        public string BudgetTypeName
        {
            get
            {
                if (this.BudgetType != null && this.BudgetType != -1)
                {
                    var info = IoC.Resolve<IXMFinancialFieldService>().GetBudgetSettingByID((int)this.BudgetType);
                    if (info != null)
                    {
                        return info.FieldName;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        public string PaymentCollectionTypeName
        {
            get
            {
                if (this.PaymentCollectionType != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID((int)this.PaymentCollectionType).CodeName;
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
        public string DepartmentIDName
        {
            get
            {
                //var department = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID((int)this.DepartmentID);
                //if (department != null)
                //    return department.CodeName;
                return IoC.Resolve<IXMFinancialCapitalFlowService>().getDepartmentName((int)DepartmentID);
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
                return result;
            }
        }

        public string CompanyName
        {
            get
            {
                var EnterpriseService = IoC.Resolve<IEnterpriseService>();
                var department = EnterpriseService.GetDepartmentById((int)DepartmentID);
                if(department==null)
                {
                    return "和众互联";
                }
                else
                {
                    var company = EnterpriseService.GetEnterpriseById(department.EnterpriseID);
                    if(company==null)
                    {
                        return "";
                    }
                    else
                    {
                        return company.EntName;
                    }
                }
            }
        }

        #endregion
    }
}
