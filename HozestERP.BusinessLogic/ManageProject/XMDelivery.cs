
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-01-30 09:44:22
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
using HozestERP.BusinessLogic.ManageFinance;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMDelivery : BaseEntity
    {
        #region Primitive Properties

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 发货单类型：480 正式产品  481 赠送产品 708 换货产品 722 发票
        /// </summary>
        public Nullable<int> DeliveryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Shipper
        /// </summary>
        public Nullable<int> Shipper { get; set; }

        /// <summary>
        /// 挂起发货单
        /// </summary>
        public Nullable<bool> IsShelve { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryNumber
        /// </summary>
        public string DeliveryNumber { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the OrderRemarks
        /// </summary>
        public string OrderRemarks { get; set; }

        /// <summary>
        /// Gets or sets the ShelveRemarks
        /// </summary>
        public string ShelveRemarks { get; set; }

        /// <summary>
        /// Gets or sets the ProductNo
        /// </summary>
        public string ProductNo { get; set; }

        /// <summary>
        /// Gets or sets the LogisticsNumber
        /// </summary>
        public string LogisticsNumber { get; set; }

        /// <summary>
        /// Gets or sets the LogisticsId
        /// </summary>
        public Nullable<int> LogisticsId { get; set; }

        /// <summary>
        /// Gets or sets the LogisticsCode
        /// </summary>
        public string LogisticsCode { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public Nullable<decimal> Price { get; set; }

        /// <summary>
        /// Gets or sets the IsDelivery
        /// </summary>
        public Nullable<bool> IsDelivery { get; set; }

        /// <summary>
        /// Gets or sets the CreateId
        /// </summary>
        public Nullable<int> CreateId { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the UpdateId
        /// </summary>
        public Nullable<int> UpdateId { get; set; }

        /// <summary>
        /// Gets or sets the UpdateDate
        /// </summary>
        public Nullable<System.DateTime> UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the IsEnabled
        /// </summary>
        public Nullable<bool> IsEnabled { get; set; }

        /// <summary>
        /// 打印次数
        /// </summary>
        public Nullable<int> PrintQuantity { get; set; }
        /// <summary>
        /// 打印批次
        /// </summary>
        public Nullable<int> PrintBatch { get; set; }
        /// <summary>
        /// 打印时间
        /// </summary>
        public Nullable<System.DateTime> PrintDateTime { get; set; }

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the Mobile
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Gets or sets the Province
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the County
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryAddress
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// 是否已打印发货单
        /// </summary>
        public bool? IsPrint { get; set; }

        /// <summary>
        /// 物流信息是否延迟
        /// </summary>
        public bool? IsLogisticsInfoLate { get; set; }

        /// <summary>
        /// 是否平台发货
        /// </summary>
        public bool? IsPlatformDeliver { get; set; }

        /// <summary>
        /// Gets or sets the VerificationStatus
        /// </summary>
        public string VerificationStatus { get; set; }

        #endregion
        #region Custom Properties

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int NickID
        {
            get
            {
                int result = -1;
                if (this.OrderCode != null && this.OrderCode.Length > 0)
                {
                    var orderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(this.OrderCode);
                    if (orderinfo != null)
                    {
                        result = int.Parse(orderinfo.NickID.ToString());
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// WantID
        /// </summary>
        public string WantID
        {
            get
            {
                string result = "";
                if (this.OrderCode != null && this.OrderCode.Length > 0)
                {
                    var orderinfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(this.OrderCode);
                    if (orderinfo != null)
                    {
                        result = orderinfo.WantID;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string NickName
        {
            get
            {
                string result = "";
                if (this.NickID != null && this.NickID > 0)
                {
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickID);
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }
        }

        //快递公司
        public string ExpressName
        {
            get
            {
                string value = "";
                if (this.LogisticsId != null)
                {
                    var Info = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticId(this.LogisticsId.ToString());//快递公司
                    if (Info != null)
                    {
                        value = Info.LogisticsName;
                    }
                }
                return value;
            }
        }

        /// <summary>
        /// 发货方
        /// </summary>
        public string ShipperName
        {
            get
            {
                string result = "";
                if (this.Shipper != null)
                {
                    var list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.Shipper.Value);
                    if (list != null)
                    {
                        result = list.CodeName;
                    }
                }
                return result;
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_Delivery_Details list
        /// </summary>
        public virtual ICollection<XMDeliveryDetails> XM_Delivery_Details { get; set; }

        /// <summary>
        /// Gets or sets the XM_Bills list
        /// </summary>
        public virtual ICollection<XMBills> XM_Bills { get; set; }

        #endregion
    }
}
