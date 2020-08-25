
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
    public partial class XMStorage : BaseEntity
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
        public int PurchaseId { get; set; }

        /// <summary>
        /// Gets or sets the WareHouseId
        /// </summary>
        public int WareHouseId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierId
        /// </summary>
        public Nullable<int> SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the BizUserId
        /// </summary>
        public Nullable<int> BizUserId { get; set; }

        /// <summary>
        /// Gets or sets the BizDt
        /// </summary>
        public Nullable<System.DateTime> BizDt { get; set; }

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
        /// Gets or sets the BillStatus
        /// </summary>
        public Nullable<int> BillStatus { get; set; }

        /// <summary>
        /// Gets or sets the ProductsMoney
        /// </summary>
        public Nullable<decimal> ProductsMoney { get; set; }

        /// <summary>
        /// Gets or sets the BillMemo
        /// </summary>
        public string BillMemo { get; set; }

        /// <summary>
        /// Gets or sets the StorageDate
        /// </summary>
        public Nullable<System.DateTime> StorageDate { get; set; }

        /// <summary>
        /// Gets or sets the PaymentType
        /// </summary>
        public Nullable<int> PaymentType { get; set; }

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
        /// 支付方式
        /// </summary>
        public string PayType
        {
            get
            {
                string payType = "";
                if (this.PaymentType != null)
                {
                    var code = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.PaymentType.Value);
                    if (code != null)
                    {
                        payType = code.CodeName;
                    }
                }
                return payType;
            }
        }



        public string WareHouseName
        {
            get
            {
                string wareHouseName = "";
                if (WareHouseId != null)
                {
                    var sup = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(WareHouseId);
                    if (sup != null)
                    {
                        wareHouseName = sup.Name;
                    }
                }
                return wareHouseName;
            }
        }
        /// <summary>
        /// 采购单号
        /// </summary>
        public string PurChaseNumber
        {
            get
            {
                string purchaseNumber = "";
                var purchaseInfo = IoC.Resolve<IXMPurchaseService>().GetXMPurchaseById(this.PurchaseId);
                if (purchaseInfo != null)
                {
                    purchaseNumber = purchaseInfo.PurchaseNumber;
                }
                return purchaseNumber;
            }
        }
        /// <summary>
        /// 发出工厂
        /// </summary>
        public string EmitFactory
        {
            get
            {
                string emitFactory = "";
                var purchaseInfo = IoC.Resolve<IXMPurchaseService>().GetXMPurchaseById(this.PurchaseId);
                if (purchaseInfo != null)
                {
                    emitFactory = purchaseInfo.EmitFactory;
                }
                return emitFactory;
            }
        }

        public int ProjectId
        {
            get
            {
                int projectId = 1;
                var sup = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(WareHouseId);
                if (sup != null)
                {
                    projectId = sup.ProjectId.Value;
                }
                return projectId;
            }
        }

        //获取供应商名称
        public string SuppliersName
        {
            get
            {
                string supplierName = "";
                if (SupplierId != null)
                {
                    var sup = IoC.Resolve<IXMSuppliersService>().GetXMSuppliersByIdDirect(SupplierId.Value);
                    if (sup != null)
                    {
                        supplierName = sup.SupplierName;
                    }
                }
                return supplierName;
            }
        }
        /// <summary>
        /// 采购单号
        /// </summary>
        public string PurchaseNumber
        {
            get
            {
                string purchaseNumber = "";
                if (PurchaseId != null)
                {
                    var pur = IoC.Resolve<IXMPurchaseService>().GetXMPurchaseById(PurchaseId);
                    if (pur != null)
                    {
                        purchaseNumber = pur.PurchaseNumber;
                    }
                }
                return purchaseNumber;
            }
        }



        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_StorageProductDetails list
        /// </summary>
        public virtual ICollection<XMStorageProductDetails> XM_StorageProductDetails { get; set; }

        #endregion
    }
}
