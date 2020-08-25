
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2016-05-09 16:59:04
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

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMPurchaseRejected : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Ref
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the PurchaseId
        /// </summary>
        public int MId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierId
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }

        /// <summary>
        /// Gets or sets the BizDt
        /// </summary>
        public Nullable<System.DateTime> BizDt { get; set; }

        /// <summary>
        /// Gets or sets the BillStatus
        /// </summary>
        public Nullable<int> BillStatus { get; set; }

        /// <summary>
        /// Gets or sets the RejectionMoney
        /// </summary>
        public Nullable<decimal> RejectionMoney { get; set; }

        /// <summary>
        /// Gets or sets the ReceivingType
        /// </summary>
        public Nullable<int> ReceivingType { get; set; }

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

        /// <summary>
        /// Gets or sets the IsEnable
        /// </summary>
        public Nullable<bool> IsEnable { get; set; }

        /// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }
        /// <summary>
        /// 是否入库
        /// </summary>
        public Nullable<bool> IsStoraged { get; set; }

        /// <summary>
        /// Gets or sets the BillMemo
        /// </summary>
        public string BillMemo { get; set; }
        /// <summary>
        /// 发出工厂
        /// </summary>
        public string EmitFactory { get; set; }

        #endregion
        #region Custom Properties

        public string SupplierName
        {
            get
            {
                string supplierName = "";
                if (SupplierId != null)
                {
                    var sup = IoC.Resolve<IXMSuppliersService>().GetXMSuppliersById(SupplierId);
                    if (sup != null)
                    {
                        supplierName = sup.SupplierName;
                    }
                }
                return supplierName;
            }
        }

        public string PayType
        {
            get
            {
                string payType = "";
                if (this.ReceivingType != null)
                {
                    var code = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.ReceivingType.Value);
                    if (code != null)
                    {
                        payType = code.CodeName;
                    }
                }
                return payType;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_PurchaseRejectedProductDetails list
        /// </summary>
        public virtual ICollection<XMPurchaseRejectedProductDetails> XM_PurchaseRejectedProductDetails { get; set; }

        #endregion
    }
}
