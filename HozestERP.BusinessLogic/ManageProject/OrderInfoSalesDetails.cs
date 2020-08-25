using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{ 

    public partial class OrderInfoSalesDetails : BaseEntity
    {
        #region Primitive Properties

        #region 订单信息

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; } 
         
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        ///项目id
        /// </summary>
        public Nullable<int> ProjectId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 厂家编码
        /// </summary>
        public string ManufacturersCode { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }
         
        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformTypeName { get; set; }

        /// <summary>
        /// Gets or sets the OrderInfoCreateDate
        /// </summary>
        public Nullable<System.DateTime> OrderInfoCreateDate { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public Nullable<System.DateTime> DeliveryTime { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public Nullable<System.DateTime> PayDate { get; set; }


        /// <summary>
        /// 订单完成时间
        /// </summary>
        public Nullable<System.DateTime> CompletionTime { get; set; }


        /// <summary>
        /// Gets or sets the OrderInfoModified
        /// </summary>
        public Nullable<System.DateTime> OrderInfoModified { get; set; }

        /// <summary>
        /// Gets or sets the OrderCode
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// Gets or sets the OrderStatus
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// Gets or sets the WantID
        /// </summary>
        public string WantID { get; set; } 

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

        /// <summary>
        /// Gets or sets the SourceType
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// Gets or sets the CustomerServiceRemark
        /// </summary>
        public string CustomerServiceRemark { get; set; }

        /// <summary>
        /// Gets or sets the Remark
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the ForService
        /// </summary>
        public string ForService { get; set; }

        /// <summary>
        /// Gets or sets the IsInvoiced
        /// </summary>
        public Nullable<bool> IsInvoiced { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceNo
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceHead
        /// </summary>
        public string InvoiceHead { get; set; }

        /// <summary>
        /// Gets or sets the PayMethod
        /// </summary>
        public string PayMethod { get; set; }

        /// <summary>
        /// Gets or sets the InvoicePrice
        /// </summary>
        public Nullable<decimal> InvoicePrice { get; set; }

        /// <summary>
        /// Gets or sets the DistributeMethod
        /// </summary>
        public string DistributeMethod { get; set; }

        /// <summary>
        /// Gets or sets the DistributePrice
        /// </summary>
        public Nullable<decimal> DistributePrice { get; set; }

        /// <summary>
        /// Gets or sets the IsDistributed
        /// </summary>
        public Nullable<bool> IsDistributed { get; set; }

        /// <summary>
        /// Gets or sets the SupportPrice
        /// </summary>
        public Nullable<decimal> SupportPrice { get; set; }

        /// <summary>
        /// Gets or sets the ProductWeight
        /// </summary>
        public Nullable<decimal> ProductWeight { get; set; }

        /// <summary>
        /// Gets or sets the ProductPrice
        /// </summary>
        public Nullable<decimal> ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the Taxes
        /// </summary>
        public Nullable<decimal> Taxes { get; set; }

        /// <summary>
        /// Gets or sets the Discount
        /// </summary>
        public Nullable<decimal> Discount { get; set; }

        /// <summary>
        /// Gets or sets the ProductPromotion
        /// </summary>
        public Nullable<decimal> ProductPromotion { get; set; }

        /// <summary>
        /// Gets or sets the OrderPromotion
        /// </summary>
        public Nullable<decimal> OrderPromotion { get; set; }

        /// <summary>
        /// Gets or sets the OrderPrice
        /// </summary>
        public Nullable<decimal> OrderPrice { get; set; }

        /// <summary>
        /// Gets or sets the ReceivablePrice
        /// </summary>
        public Nullable<decimal> ReceivablePrice { get; set; }

        /// <summary>
        /// 已支付金额
        /// </summary>
        public Nullable<decimal> PayPrice { get; set; }

        /// <summary>
        /// 是否刷单
        /// </summary>
        public Nullable<bool> IsScalping { get; set; }

        /// <summary>
        /// 是否返现
        /// </summary>
        public Nullable<bool> IsCashBack { get; set; }

        /// <summary>
        /// 是否已发赠品
        /// </summary>
        public Nullable<bool> IsSentGifts { get; set; }

        /// <summary>
        /// 是否赔付	
        /// </summary>
        public Nullable<bool> IsEvaluate { get; set; }
         
         

        public Nullable<DateTime> AppointDeliveryTime { get; set; }

        public Nullable<Decimal> BuyerObtainPointFee { get; set; }

        public string TradeFrom { get; set; }

        public Nullable<Decimal> RealPointFee { get; set; }

        public Nullable<Decimal> CommissionFee { get; set; }

        public string TradeSource { get; set; }

        public Nullable<Decimal> CreditCardFee { get; set; }

        /// <summary>
        /// Gets or sets the IsEvaluate
        /// </summary>
        public Nullable<bool> IsAbnormal { get; set; }

        #endregion

        #region 订单明细

        /// <summary>
        /// 明细Id
        /// </summary>
        public int DetailsID { get; set; }

        /// <summary>
        ///主表Id
        /// </summary>
        public int OrderInfoID { get; set; }
        
        /// <summary>
        /// 产品编码
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// 产品主表Id
        /// </summary>
        public Nullable<int> ProductId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// 出厂价
        /// </summary>
        public Nullable<decimal> FactoryPrice { get; set; }
         
        /// <summary>
        /// 平均出厂价
        /// </summary>
        public Nullable<decimal> AvgFactoryPrice { get; set; }

        /// <summary>
        /// Gets or sets the TCostprice
        /// </summary>
        public Nullable<decimal> TCostprice { get; set; }

        /// <summary>
        /// Gets or sets the SalesPrice
        /// </summary>
        public Nullable<decimal> SalesPrice { get; set; }

        /// <summary>
        /// Gets or sets the ISArrivedLibrary
        /// </summary>
        public Nullable<bool> ISArrivedLibrary { get; set; }

        /// <summary>
        /// Gets or sets the Remarks
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the CutoffShipDay
        /// </summary>
        public Nullable<System.DateTime> CutoffShipDay { get; set; }

        /// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }

        public Nullable<bool> IsExpedited { get; set; }

        public string Status { get; set; }

        public Nullable<bool> IsSingleRow { get; set; }

        #endregion
         

        /// <summary>
        /// 返现旺旺号
        /// </summary>
        public string XMCashBackApplicationWantNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string BuyerName { get; set; }

        /// <summary>
        /// 返现金额
        /// </summary>
        public Nullable<decimal> CashBackMoney { get; set; }

        /// <summary>
        /// 收款账号
        /// </summary>
        public string BuyerAlipayNo { get; set; }


        /// <summary>
        /// 刷单 旺旺号
        /// </summary>
        public string XMScalpingWantID { get; set; } 

        /// <summary>
        /// 佣金
        /// </summary>
        public Nullable<decimal> Fee { get; set; }

        /// <summary>
        ///扣点
        /// </summary>
        public Nullable<decimal> Deduction { get; set; }

        /// <summary>
        /// 图标统计用的标志时间
        /// </summary>
        public Nullable<DateTime> MarkDate { get; set; }

        #endregion
        #region Custom Properties


        #endregion
        #region Navigation Properties

        /// <summary>
        /// Gets or sets the XM_OrderInfo
        /// </summary>
        public virtual XMOrderInfo XM_OrderInfo { get; set; }

        #endregion
    }
}
