
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2014-12-19 16:58:48
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
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Enterprises;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageFinance
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
        /// Gets or sets the DirectorPeople
        /// </summary>
        public Nullable<int> OperationsPeople { get; set; }

        /// <summary>
        /// Gets or sets the DirectorIsAudit
        /// </summary>
        public Nullable<bool> OperationIsAudit { get; set; }

        /// <summary>
        /// Gets or sets the DirectorTime
        /// </summary>
        public Nullable<System.DateTime> OperationTime { get; set; }
         
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

        #endregion
        #region Custom Properties

         //<summary>
         //刷单编号
         //</summary>
        public XMScalpingApplication ScalpingNo
        {
            get
            {
                if (this.PlatformTypeId != null)
                {
                    return IoC.Resolve<IXMScalpingApplicationService>().GetXMScalpingApplicationByScalpingId(this.ScalpingId.Value);
                }
                else
                {

                    return null;
                }
            }
        } 

        /// <summary>
        /// 平台类型
        /// </summary>
        public CodeList PlatformTypeName
        {
            get
            {
                if (this.PlatformTypeId != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PlatformTypeId.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 暂支类型
        /// </summary>
        public CodeList TheAdvanceTypeName
        {
            get
            {
                if (this.TheAdvanceType != null)
                {
                    return IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.TheAdvanceType.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public XMNick NickName
        {
            get
            {
                if (this.NickId != null)
                {
                    return IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickId.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        
        /// <summary>
        /// 申请部门
        /// </summary>
        public Department DepartmentName
        {
            get
            {
                if (this.ApplicationDepartment != null)
                {
                    return IoC.Resolve<IEnterpriseService>().GetDepartmentById(this.ApplicationDepartment.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// 申请人
        /// </summary>
        public CustomerInfo ApplicantsName
        {
            get
            {
                if (this.Applicants != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.Applicants.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        
        /// <summary>
        /// 店长
        /// </summary>
        public CustomerInfo ManagerPeopleName
        {
            get
            {
                if (this.ManagerPeople != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.ManagerPeople.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        /// <summary>
        /// 财务审核人
        /// </summary>
        public CustomerInfo FinancePeopleName
        {
            get
            {
                if (this.FinancePeople != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.FinancePeople.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        
         /// <summary>
        /// 财务确认人
        /// </summary>
        public CustomerInfo FinanceOkPeopleName
        {
            get
            {
                if (this.FinanceOkPeople != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.FinanceOkPeople.Value);
                }
                else
                {

                    return null;
                }
            }
        }


        /// <summary>
        /// 经理
        /// </summary>
        public CustomerInfo DirectorPeopleName
        {
            get
            {
                if (this.DirectorPeople != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.DirectorPeople.Value);
                }
                else
                {

                    return null;
                }
            }
        }

        /// <summary>
        /// 暂支结束确认人
        /// </summary>
        public CustomerInfo FinanceAdvanceEndPeopleName
        {
            get
            {
                if (this.FinanceAdvanceEndPeople != null)
                {
                    return IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.FinanceAdvanceEndPeople.Value);
                }
                else
                {

                    return null;
                }
            }
        }
        
        //AdvanceState
        #endregion
    }
}
