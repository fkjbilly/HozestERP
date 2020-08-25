
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-07-05 16:39:08
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
using HozestERP.BusinessLogic.ManageInventory;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public partial class XMPaymentApply : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PurchaseID
        /// </summary>
        public int PurchaseID { get; set; }

        /// <summary>
        /// Gets or sets the ContractNumber
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// Gets or sets the RequestFundsReason
        /// </summary>
        public string RequestFundsReason { get; set; }

        /// <summary>
        /// Gets or sets the PayAmounts
        /// </summary>
        public decimal PayAmounts { get; set; }

        /// <summary>
        /// Gets or sets the PayMode
        /// </summary>
        public int PayMode { get; set; }

        /// <summary>
        /// Gets or sets the BankAcount
        /// </summary>
        public string BankAcount { get; set; }

        /// <summary>
        /// Gets or sets the SupplierID
        /// </summary>
        public Nullable<int> SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the RequstDate
        /// </summary>
        public Nullable<System.DateTime> RequstDate { get; set; }

        /// <summary>
        /// Gets or sets the UserDate
        /// </summary>
        public Nullable<System.DateTime> UserDate { get; set; }

        /// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }

        /// <summary>
        /// Gets or sets the FinancialStatus
        /// </summary>
        public Nullable<bool> FinancialStatus { get; set; }

        /// <summary>
        /// Gets or sets the ApplicantID
        /// </summary>
        public Nullable<int> ApplicantID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// Gets or sets the IsAuditPerson
        /// </summary>
        public Nullable<int> IsAuditPerson { get; set; }

        /// <summary>
        /// Gets or sets the FinancialStatusPerson
        /// </summary>
        public Nullable<int> FinancialStatusPerson { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> IsAuditDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> FinancialStatusDate { get; set; }

        /// <summary>
        /// Gets or sets the FinancialConfirm
        /// </summary>
        public Nullable<bool> FinancialConfirm { get; set; }

        /// <summary>
        /// Gets or sets the ConfirmDate
        /// </summary>
        public Nullable<System.DateTime> ConfirmDate { get; set; }


        /// <summary>
        /// Gets or sets the ConfirmPerson
        /// </summary>
        public Nullable<int> ConfirmPerson { get; set; }


        #endregion
        #region Custom Properties

        /// <summary>
        /// 采购单号
        /// </summary>
        public string PurchaseRef
        {
            get
            {
                string purchaseRef = "";
                if (this.PurchaseID != null)
                {
                    var purchases = IoC.Resolve<IXMPurchaseService>().GetXMPurchaseById(this.PurchaseID);
                    if (purchases != null)
                    {
                        purchaseRef = purchases.PurchaseNumber;
                    }
                }
                return purchaseRef;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayMentName
        {
            get
            {
                string payMentName = "";
                var code = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PayMode);
                if (code != null)
                {
                    payMentName = code.CodeName;
                }
                return payMentName;
            }
        }
        /// <summary>
        /// 神请人
        /// </summary>
        public string Requester
        {
            get
            {
                string requester = "";
                if (this.ApplicantID != null)
                {
                    var customerInfo = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.ApplicantID.Value);
                    if (customerInfo != null)
                    {
                        requester = customerInfo.FullName;
                    }
                }
                return requester;
            }
        }

        #endregion
    }
}
