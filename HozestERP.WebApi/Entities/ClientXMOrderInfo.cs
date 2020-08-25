using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.WebApi.Entities
{
    public class OrderInfoListClient
    {
        public List<XMOrderInfoClient> xmOrderInfoClientList { get; set; }
    }
    
    public class XMOrderInfoClient
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 订单标志位 0，没导入过 1，已导入 2，需覆盖
        /// </summary>
        public int into_erp_type { get; set; }
        /// <summary>
        /// Gets or sets the NickID
        /// </summary>
        public Nullable<int> NickID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformTypeId
        /// </summary>
        public Nullable<int> PlatformTypeId { get; set; }

        /// <summary>
        /// Gets or sets the OrderInfoCreateDate
        /// </summary>
        public Nullable<System.DateTime> OrderInfoCreateDate { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryTime
        /// </summary>
        public Nullable<System.DateTime> DeliveryTime { get; set; }

        /// <summary>
        /// Gets or sets the PayDate
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
        /// Gets or sets the BuyerName
        /// </summary>
        public string BuyerName { get; set; }

        /// <summary>
        /// Gets or sets the BuyerMobile
        /// </summary>
        public string BuyerMobile { get; set; }

        /// <summary>
        /// Gets or sets the BuyerPhone
        /// </summary>
        public string BuyerPhone { get; set; }

        /// <summary>
        /// Gets or sets the BuyerAddress
        /// </summary>
        public string BuyerAddress { get; set; }
        /// <summary>
        /// 买家邮箱
        /// </summary>
        public string BuyerE_mail { get; set; }
        ///// <summary>
        ///// 身份证号
        ///// </summary>
        //public string IdentityCard { get; set; }
        ///// <summary>
        ///// 支付单号
        ///// </summary>
        //public string PaymentNo { get; set; }
        ///// <summary>
        ///// 商家订单交易号
        ///// </summary>
        //public string OrderSeqNo { get; set; }
        ///// <summary>
        ///// 支付类型编号
        ///// </summary>
        //public string Source { get; set; }
        ///// <summary>
        ///// 买家姓名
        ///// </summary>
        //public string RealName { get; set; }
        /// <summary>
        /// 收货人姓名
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
        /// 所属旺旺号Id
        /// </summary>
        public Nullable<int> BelongsServiceId { get; set; }

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
        /// 运费
        /// </summary>
        public Nullable<decimal> DistributePrice { get; set; }

        /// <summary>
        /// Gets or sets the IsDistributed
        /// </summary>
        public Nullable<bool> IsDistributed { get; set; }

        /// <summary>
        /// 是否通过财务审计(百度的，有待考证) true 是；false 否
        /// </summary>
        public Nullable<bool> FinancialAudit { get; set; }

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
        ///税
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
        /// 订单优惠
        /// </summary>
        public Nullable<decimal> OrderPromotion { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public Nullable<decimal> OrderPrice { get; set; }

        /// <summary>
        /// Gets or sets the ReceivablePrice
        /// </summary>
        public Nullable<decimal> ReceivablePrice { get; set; }

        /// <summary>
        /// 支付金额
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

        /// <summary>
        /// Gets or sets the IsAudit
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }

        /// <summary>
        /// Gets or sets the IsOurOrder
        /// </summary>
        public bool IsOurOrder { get; set; }

        /// <summary>
        /// 是否删除 true删除；false不删除
        /// </summary>
        public bool IsEnable { get; set; }

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


        /// <summary>
        /// Gets or sets the XM_OrderInfoProductDetails list
        /// </summary>
        public List<XMOrderInfoProductDetailsClient> XM_OrderInfoProductDetails { get; set; }
    }

    public class XMOrderInfoProductDetailsClient
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the OrderInfoID
        /// </summary>
        public Nullable<int> OrderInfoID { get; set; }

        /// <summary>
        /// Gets or sets the PlatformMerchantCode
        /// </summary>
        public string PlatformMerchantCode { get; set; }

        /// <summary>
        /// Gets or sets the ManufacturersCode
        /// </summary>
        public string TManufacturersCode { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Specifications
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the SpareRemarks
        /// </summary>
        public string SpareRemarks { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public Nullable<int> ProductNum { get; set; }

        /// <summary>
        /// 出厂价
        /// </summary>
        public Nullable<decimal> FactoryPrice { get; set; }

        /// <summary>
        /// 特供价
        /// </summary>
        public Nullable<decimal> TCostprice { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        public Nullable<decimal> SalesPrice { get; set; }

        /// <summary>
        /// 是否抵库
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
        /// 是否审核
        /// </summary>
        public Nullable<bool> IsAudit { get; set; }

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

        /// <summary>
        /// 是否加急
        /// </summary>
        public Nullable<bool> IsExpedited { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// 否已排过单
        /// </summary>
        public Nullable<bool> IsSingleRow { get; set; }
    }
}
