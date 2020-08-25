using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;

namespace HozestERP.BusinessLogic.ManageProject
{
    public partial class XMDeliveryNew
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 发货单类型：订单、赠品
        /// </summary>
        public Nullable<int> DeliveryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryNumber
        /// </summary>
        public string DeliveryNumber { get; set; }

        /// <summary>
        /// 挂起发货单
        /// </summary>
        public Nullable<bool> IsShelve { get; set; }

        /// <summary>
        /// Gets or sets the OrderRemarks
        /// </summary>
        public string OrderRemarks { get; set; }

        /// <summary>
        /// Gets or sets the Shipper
        /// </summary>
        public Nullable<int> Shipper { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the OrderStatus
        /// </summary>
        public string OrderStatus { get; set; }

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
        /// Gets or sets the OrderId
        /// </summary>
        public Nullable<int> OrderId { get; set; }

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }

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
        /// Gets or sets the DeliveryAddressSpare
        /// </summary>
        public string DeliveryAddressSpare { get; set; }

        /// <summary>
        /// Gets or sets the Mobile
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the Tel
        /// </summary>
        public string Tel { get; set; }

        #region  订单商品信息

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the ProductNum
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// Gets or sets the SalesPrice
        /// </summary>
        public Nullable<decimal> SalesPrice { get; set; }

        #endregion

        /// <summary>
        /// 赠品主表Id
        /// </summary>
        public Nullable<int> PremiumsId { get; set; }

        /// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }

        /// <summary>
        /// 买家ID
        /// </summary>
        public string WantID { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        public Nullable<decimal> DistributePrice { get; set; }

        /// <summary>
        /// 买家备注
        /// </summary>
        public string orderRemark { get; set; }

        /// <summary>
        /// 客服备注
        /// </summary>
        public string CustomerServiceRemark { get; set; }

        /// <summary>
        /// 拍下时间
        /// </summary>
        public Nullable<System.DateTime> OrderInfoCreateDate { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public Nullable<System.DateTime> PayDate { get; set; }

        /// <summary>
        /// 发货单是否打印
        /// </summary>
        public bool? IsPrint { get; set; }

        /// <summary>
        /// 物流信息是否延迟
        /// </summary>
        public bool? IsLogisticsInfoLate { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public int? projectId { get; set; }
        /// <summary>
        /// 发货单状态
        /// </summary>
        public string VerificationStatus { get; set; }

        #region 赠品商品信息
        ///// <summary>
        ///// Gets or sets the PlatformMerchantCode
        ///// </summary>
        //public string XMPPlatformMerchantCode { get; set; }

        ///// <summary>
        ///// Gets or sets the ProductName
        ///// </summary>
        //public string XMPProductName { get; set; }

        ///// <summary>
        ///// Gets or sets the Specifications
        ///// </summary>
        //public string XMPSpecifications { get; set; }

        ///// <summary>
        ///// Gets or sets the ProductNum
        ///// </summary>
        //public Nullable<int> XMPProductNum { get; set; }

        ///// <summary>
        ///// Gets or sets the SalesPrice
        ///// </summary>
        //public Nullable<decimal> XMPFactoryPrice { get; set; }

        #endregion

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
                    var nick = IoC.Resolve<IXMNickService>().GetXMNickByID(this.NickID.Value);
                    if (nick != null)
                    {
                        result = nick.nick;
                    }
                }
                return result;
            }

        }

        /// <summary>
        /// 发货单类型
        /// </summary>
        public string DeliveryTypeName
        {
            get
            {
                string result = "";
                if (this.DeliveryTypeId.HasValue)
                {
                    var codelist = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.DeliveryTypeId.Value);
                    if (codelist != null)
                    {
                        result = codelist.CodeName;
                    }
                }
                return result;
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

        /// <summary>
        /// 物流公司
        /// </summary>
        public string LogisticsCompany
        {
            get
            {
                string result = "";
                if (this.LogisticsId != null)
                {
                    var Logistic = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomByLogisticId(this.LogisticsId.ToString());
                    if (Logistic != null)
                    {
                        result = Logistic.LogisticsName;
                    }
                }
                return result;
            }
        }
    }
}
