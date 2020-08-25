
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
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.BusinessLogic.ManageBusiness
{
    public partial class XMBusinessDataAll: BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the SubmitDate
        /// </summary>
        public Nullable<System.DateTime> SubmitDate { get; set; }

        /// <summary>
        /// Gets or sets the BusinessDataID
        /// </summary>
        public Nullable<int> BusinessDataID { get; set; }

        /// <summary>
        /// Gets or sets the AmountType
        /// </summary>
        public Nullable<int> AmountType { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public Nullable<decimal> Amount { get; set; }

        /// <summary>
        /// Gets or sets the DomainName
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets or sets the BusinessType
        /// </summary>
        public Nullable<int> BusinessType { get; set; }

        /// <summary>
        /// Gets or sets the Remark1
        /// </summary>
        public string Remark1 { get; set; }

        /// <summary>
        /// Gets or sets the Remark2
        /// </summary>
        public string Remark2 { get; set; }

        /// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }

        /// <summary>
        /// Gets or sets the ServiceBeginDate
        /// </summary>
        public Nullable<System.DateTime> ServiceBeginDate { get; set; }

        /// <summary>
        /// Gets or sets the ServiceEndDate
        /// </summary>
        public Nullable<System.DateTime> ServiceEndDate { get; set; }

        /// <summary>
        /// Gets or sets the AuditPerson
        /// </summary>
        public Nullable<int> AuditPerson { get; set; }

        /// <summary>
        /// Gets or sets the AuditDate
        /// </summary>
        public Nullable<System.DateTime> AuditDate { get; set; }

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

        /// <summary>
        /// Gets or sets the BelongingCusID
        /// </summary>
        public string BelongingName { get; set; }

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

        public string AuditPersonName
        {
            get
            {
                if (this.AuditPerson != null)
                {
                    return IoC.Resolve<IXMBusinessDataService>().GetCustomerName(this.AuditPerson.Value.ToString());
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

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_BusinessData
        /// </summary>
        public virtual XMBusinessData XM_BusinessData { get; set; }

        #endregion
    }
}
