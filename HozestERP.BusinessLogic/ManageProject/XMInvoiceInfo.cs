
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-08-24 09:15:40
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
using HozestERP.BusinessLogic.CustomerManagement;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMInvoiceInfo : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the RelationID
        /// </summary>
        public string RelationID { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceNo
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceType
        /// </summary>
        public Nullable<int> InvoiceType { get; set; }

        /// <summary>
        /// Gets or sets the DutyParagraph
        /// </summary>
        public string DutyParagraph { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Gets or sets the BankAccount
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the AccountNumber
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceHeader
        /// </summary>
        public string InvoiceHeader { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceStatus
        /// </summary>
        public Nullable<int> InvoiceStatus { get; set; }

        /// <summary>
        /// Gets or sets the IsSingleRow
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }

        /// <summary>
        /// Gets or sets the IsBilling
        /// </summary>
        public Nullable<bool> IsBilling { get; set; }

        /// <summary>
        /// 发票已开
        /// </summary>
        public Nullable<bool> IsInvoiceOpen { get; set; }

        /// <summary>
        /// Gets or sets the IsScrap
        /// </summary>
        public Nullable<bool> IsScrap { get; set; }

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// Gets or sets the CreateID
        /// </summary>
        public Nullable<int> CreateID { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        #endregion
        #region Custom Properties

        public string UpdateName
        {
            get
            {
                string updateName = "";
                if (this.UpdateID != null)
                {
                    var customer = IoC.Resolve<ICustomerInfoService>().GetCustomerInfoByID(this.UpdateID.Value);
                    if (customer != null)
                    {
                        updateName = customer.FullName;
                    }
                }
                return updateName;
            }
        }

        public string InvoiceTypeName
        {
            get
            {
                string str = "";
                if (this.InvoiceType != null)
                {
                    var list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(235);
                    foreach (var a in list)
                    {
                        if (a.CodeID == this.InvoiceType)
                        {
                            str = a.CodeName;
                            break;
                        }
                    }
                }
                return str;
            }
        }

        public string InvoiceStatusName
        {
            get
            {
                string str = "";
                if (this.InvoiceStatus != null)
                {
                    var list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeTypeID(233);
                    foreach (var a in list)
                    {
                        if (a.CodeID == this.InvoiceStatus)
                        {
                            str = a.CodeName;
                            break;
                        }
                    }
                }
                return str;
            }
        }

        public bool IsDelivery
        {
            get
            {
                bool delivery = false;
                if (this.ID != null)
                {
                    var DeliveryInfo = IoC.Resolve<IXMDeliveryService>().GetXMDeliveryByInvoiceInfo(this.ID);
                    if (DeliveryInfo != null)
                    {
                        return (bool)DeliveryInfo.IsDelivery == null ? false : (bool)DeliveryInfo.IsDelivery;
                    }
                }
                return delivery;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_InvoiceInfoDetail list
        /// </summary>
        public virtual ICollection<XMInvoiceInfoDetail> XM_InvoiceInfoDetail { get; set; }

        #endregion
    }
}
