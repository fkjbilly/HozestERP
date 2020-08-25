
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-03-01 09:19:33
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
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.Customers
{
    public partial class SocialSecurityFund : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the CustomerInfoID
        /// </summary>
        public Nullable<int> CustomerInfoID { get; set; }

        /// <summary>
        /// Gets or sets the Year
        /// </summary>
        public Nullable<int> Year { get; set; }

        /// <summary>
        /// Gets or sets the Month
        /// </summary>
        public Nullable<int> Month { get; set; }

        /// <summary>
        /// Gets or sets the RankManagement
        /// </summary>
        public string RankManagement { get; set; }

        /// <summary>
        /// Gets or sets the Post
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// Gets or sets the HouseholdRegister
        /// </summary>
        public string HouseholdRegister { get; set; }

        /// <summary>
        /// Gets or sets the InsuranceType
        /// </summary>
        public string InsuranceType { get; set; }

        /// <summary>
        /// Gets or sets the PensionBase
        /// </summary>
        public Nullable<decimal> PensionBase { get; set; }

        /// <summary>
        /// Gets or sets the PensionCompany
        /// </summary>
        public Nullable<decimal> PensionCompany { get; set; }

        /// <summary>
        /// Gets or sets the PensionPerson
        /// </summary>
        public Nullable<decimal> PensionPerson { get; set; }

        /// <summary>
        /// Gets or sets the MedicalCareBase
        /// </summary>
        public Nullable<decimal> MedicalCareBase { get; set; }

        /// <summary>
        /// Gets or sets the MedicalCareCompany
        /// </summary>
        public Nullable<decimal> MedicalCareCompany { get; set; }

        /// <summary>
        /// Gets or sets the MedicalCarePerson
        /// </summary>
        public Nullable<decimal> MedicalCarePerson { get; set; }

        /// <summary>
        /// Gets or sets the UnemploymentBase
        /// </summary>
        public Nullable<decimal> UnemploymentBase { get; set; }

        /// <summary>
        /// Gets or sets the UnemploymentCompany
        /// </summary>
        public Nullable<decimal> UnemploymentCompany { get; set; }

        /// <summary>
        /// Gets or sets the UnemploymentPerson
        /// </summary>
        public Nullable<decimal> UnemploymentPerson { get; set; }

        /// <summary>
        /// Gets or sets the InjuryJobBase
        /// </summary>
        public Nullable<decimal> InjuryJobBase { get; set; }

        /// <summary>
        /// Gets or sets the InjuryJobCompany
        /// </summary>
        public Nullable<decimal> InjuryJobCompany { get; set; }

        /// <summary>
        /// Gets or sets the BirthBase
        /// </summary>
        public Nullable<decimal> BirthBase { get; set; }

        /// <summary>
        /// Gets or sets the BirthCompany
        /// </summary>
        public Nullable<decimal> BirthCompany { get; set; }

        /// <summary>
        /// Gets or sets the AccumulationFundBase
        /// </summary>
        public Nullable<decimal> AccumulationFundBase { get; set; }

        /// <summary>
        /// Gets or sets the AccumulationCompany
        /// </summary>
        public Nullable<decimal> AccumulationCompany { get; set; }

        /// <summary>
        /// Gets or sets the AccumulationFundPerson
        /// </summary>
        public Nullable<decimal> AccumulationFundPerson { get; set; }

        /// <summary>
        /// Gets or sets the CompanyTotal
        /// </summary>
        public Nullable<decimal> CompanyTotal { get; set; }

        /// <summary>
        /// Gets or sets the PersonTotal
        /// </summary>
        public Nullable<decimal> PersonTotal { get; set; }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        public Nullable<decimal> Total { get; set; }

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

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName
        {
            get
            {
                var department = IoC.Resolve<ISocialSecurityFundService>().GetDepartmentName((int)this.CustomerInfoID);
                if (department != null)
                {
                    return department.DepName;
                }
                return "";
            }
        }

        /// <summary>
        /// 部门性质名称
        /// </summary>
        public string ParentDepName
        {
            get
            {
                var department = IoC.Resolve<ISocialSecurityFundService>().GetDepartmentName((int)this.CustomerInfoID);
                if (department != null && department.ParentDepartment != null)
                {
                    return department.ParentDepartment.DepName;
                }
                else
                {
                    return this.DepartmentName;
                }
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName
        {
            get
            {
                var customer = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID((int)this.CustomerInfoID);
                if (customer != null)
                    return customer.FullName;
                return string.Empty;
            }
        }

        /// <summary>
        /// 年月
        /// </summary>
        public string YearMonth
        {
            get
            {
                return this.Year + "-" + this.Month.ToString().PadLeft(2, '0');
            }
        }

        #endregion
    }
}
