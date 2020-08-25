
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
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.Codes;

namespace HozestERP.BusinessLogic.ManageInventory
{
    public partial class XMSaleDelivery : BaseEntity
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
        /// Gets or sets the OrderInfoID
        /// </summary>
        public int OrderInfoID { get; set; }
        /// <summary>
        /// Gets or sets the SaleInfoId
        /// </summary>
        public int SaleInfoId { get; set; }

        /// <summary>
        /// Gets or sets the WareHouseId
        /// </summary>
        public int WareHouseId { get; set; }

        /// <summary>
        /// Gets or sets the BillStatus
        /// </summary>
        public int BillStatus { get; set; }

        /// <summary>
        /// Gets or sets the SaleMoney
        /// </summary>
        public Nullable<decimal> SaleMoney { get; set; }

        /// <summary>
        /// Gets or sets the ReceivingType
        /// </summary>
        public Nullable<int> ReceivingType { get; set; }

        /// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }

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
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateID
        /// </summary>
        public Nullable<int> UpdateID { get; set; }
        /// <summary>
        /// Gets or sets the PremiumsID
        /// </summary>
        public Nullable<int> PremiumsID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> DeliveryID { get; set; }

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
        /// 支付方式
        /// </summary>
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


        /// <summary>
        /// 销售单号
        /// </summary>
        public string SaleRef
        {
            get
            {
                string saleRef = "";
                var saleInfo = IoC.Resolve<IXMSaleInfoService>().GetXMSaleInfoById(this.SaleInfoId);
                if (saleInfo != null)
                {
                    saleRef = saleInfo.Ref;
                }
                if (saleRef == "")
                {
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByID(this.OrderInfoID);
                    if (OrderInfo != null)
                    {
                        saleRef = OrderInfo.OrderCode;
                    }
                }
                return saleRef;
            }
        }

        public int ProjectId
        {
            get
            {
                int projectId = 1;
                if (WareHouseId != null)
                {
                    var sup = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(WareHouseId);
                    if (sup != null)
                    {
                        projectId = sup.ProjectId.Value;
                    }
                }
                return projectId;
            }
        }

        public string NickName
        {
            get
            {
                string nickName = "";
                var wareHouses = IoC.Resolve<IXMWareHousesService>().GetXMWareHousesById(this.WareHouseId);
                if (wareHouses != null && wareHouses.NickId != null)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(wareHouses.NickId.Value);
                    if (nick != null)
                    {
                        nickName = nick.nick;
                    }
                }
                if (nickName == "")
                {
                    var OrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByID(this.OrderInfoID);
                    if (OrderInfo != null)
                    {
                        nickName = OrderInfo.NickName;
                    }
                }
                return nickName;
            }
        }

        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_SaleDeliveryProductDetails list
        /// </summary>
        public virtual ICollection<XMSaleDeliveryProductDetails> XM_SaleDeliveryProductDetails { get; set; }

        #endregion
    }
}
