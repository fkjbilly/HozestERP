using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class OrderDetailItem {
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO order_;
		
		///<summary>
		/// 订单第三方标识
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderCoopVO exOrderSn_;
		
		///<summary>
		/// 订单发票
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderInvoiceVO orderInvoice_;
		
		///<summary>
		/// 订单电子发票
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO orderElectronicInvoice_;
		
		///<summary>
		/// 订单收货地址信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO orderReceiveAddr_;
		
		///<summary>
		/// 订单支付及优惠信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO orderPayAndDiscount_;
		
		///<summary>
		/// 订单支付明细
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> orderPayDetailList_;
		
		///<summary>
		/// 订单分期付款
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO> orderPayInstalmentList_;
		
		///<summary>
		/// 订单商品
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO> orderGoodsAndDescribeList_;
		
		///<summary>
		/// 订单活动
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderActiveVO> orderActiveList_;
		
		///<summary>
		/// 订单logs
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderLogsVO> orderLogsList_;
		
		///<summary>
		/// 订单变更历史
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderStatusHistoryVO> orderStatusHistoryList_;
		
		///<summary>
		/// 物流信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVO> orderTransportDetailsAndPackageList_;
		
		///<summary>
		/// 预付订单额外信息-弃用，改用prepayOrderExtendList
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO prepayOrderExtend_;
		
		///<summary>
		/// 订单售后申请
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderReturnApplyListVO> orderReturnApplyList_;
		
		///<summary>
		/// 订单换货申请
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVO> orderExchangeApplyList_;
		
		///<summary>
		/// 订单详情补充信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO orderDetailsSuppInfo_;
		
		///<summary>
		/// 订单回退地址信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.ReturnAddressVO returnAddress_;
		
		///<summary>
		/// 订单唯品卡信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderCardVO> orderCardList_;
		
		///<summary>
		/// 订单取消退款信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderCancelDataVO orderCancelData_;
		
		///<summary>
		/// 订单退货商品信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsBackVO> orderGoodsBackList_;
		
		///<summary>
		/// 退款银行信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderBackBankVO> orderBackBankList_;
		
		///<summary>
		/// 订单支付pay_id信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrdersPayTypeVO ordersPayType_;
		
		///<summary>
		/// 订单pos机支付信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPosVO orderPos_;
		
		///<summary>
		/// 订单品牌券信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderCouponVO> couponList_;
		
		///<summary>
		/// 订单可操作状态列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OpStatusVO> opStatusList_;
		
		///<summary>
		/// 预付子单信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> prepayOrderExtendList_;
		
		///<summary>
		/// 退款信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO> orderRefundDetailsList_;
		
		///<summary>
		/// 订单成单支付信息列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderPaySnVO> orderPaySnList_;
		
		///<summary>
		/// 赔付记录
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderCompensateVO orderCompensate_;
		
		///<summary>
		/// 寻仓记录
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> orderWarehouseList_;
		
		///<summary>
		/// 订单业务属性纵表
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO orderBizExtAttr_;
		
		public com.vip.order.common.pojo.order.vo.OrderVO GetOrder(){
			return this.order_;
		}
		
		public void SetOrder(com.vip.order.common.pojo.order.vo.OrderVO value){
			this.order_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderCoopVO GetExOrderSn(){
			return this.exOrderSn_;
		}
		
		public void SetExOrderSn(com.vip.order.common.pojo.order.vo.OrderCoopVO value){
			this.exOrderSn_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderInvoiceVO GetOrderInvoice(){
			return this.orderInvoice_;
		}
		
		public void SetOrderInvoice(com.vip.order.common.pojo.order.vo.OrderInvoiceVO value){
			this.orderInvoice_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO GetOrderElectronicInvoice(){
			return this.orderElectronicInvoice_;
		}
		
		public void SetOrderElectronicInvoice(com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO value){
			this.orderElectronicInvoice_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO GetOrderReceiveAddr(){
			return this.orderReceiveAddr_;
		}
		
		public void SetOrderReceiveAddr(com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value){
			this.orderReceiveAddr_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO GetOrderPayAndDiscount(){
			return this.orderPayAndDiscount_;
		}
		
		public void SetOrderPayAndDiscount(com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value){
			this.orderPayAndDiscount_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> GetOrderPayDetailList(){
			return this.orderPayDetailList_;
		}
		
		public void SetOrderPayDetailList(List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> value){
			this.orderPayDetailList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO> GetOrderPayInstalmentList(){
			return this.orderPayInstalmentList_;
		}
		
		public void SetOrderPayInstalmentList(List<com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO> value){
			this.orderPayInstalmentList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO> GetOrderGoodsAndDescribeList(){
			return this.orderGoodsAndDescribeList_;
		}
		
		public void SetOrderGoodsAndDescribeList(List<com.vip.order.common.pojo.order.vo.OrderGoodsAndDescribeVO> value){
			this.orderGoodsAndDescribeList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderActiveVO> GetOrderActiveList(){
			return this.orderActiveList_;
		}
		
		public void SetOrderActiveList(List<com.vip.order.common.pojo.order.vo.OrderActiveVO> value){
			this.orderActiveList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderLogsVO> GetOrderLogsList(){
			return this.orderLogsList_;
		}
		
		public void SetOrderLogsList(List<com.vip.order.common.pojo.order.vo.OrderLogsVO> value){
			this.orderLogsList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderStatusHistoryVO> GetOrderStatusHistoryList(){
			return this.orderStatusHistoryList_;
		}
		
		public void SetOrderStatusHistoryList(List<com.vip.order.common.pojo.order.vo.OrderStatusHistoryVO> value){
			this.orderStatusHistoryList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVO> GetOrderTransportDetailsAndPackageList(){
			return this.orderTransportDetailsAndPackageList_;
		}
		
		public void SetOrderTransportDetailsAndPackageList(List<com.vip.order.common.pojo.order.vo.OrderTransportDetailsAndPackageVO> value){
			this.orderTransportDetailsAndPackageList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO GetPrepayOrderExtend(){
			return this.prepayOrderExtend_;
		}
		
		public void SetPrepayOrderExtend(com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value){
			this.prepayOrderExtend_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderReturnApplyListVO> GetOrderReturnApplyList(){
			return this.orderReturnApplyList_;
		}
		
		public void SetOrderReturnApplyList(List<com.vip.order.common.pojo.order.vo.OrderReturnApplyListVO> value){
			this.orderReturnApplyList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVO> GetOrderExchangeApplyList(){
			return this.orderExchangeApplyList_;
		}
		
		public void SetOrderExchangeApplyList(List<com.vip.order.common.pojo.order.vo.OrderExchangeApplyListVO> value){
			this.orderExchangeApplyList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO GetOrderDetailsSuppInfo(){
			return this.orderDetailsSuppInfo_;
		}
		
		public void SetOrderDetailsSuppInfo(com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO value){
			this.orderDetailsSuppInfo_ = value;
		}
		public com.vip.order.common.pojo.order.vo.ReturnAddressVO GetReturnAddress(){
			return this.returnAddress_;
		}
		
		public void SetReturnAddress(com.vip.order.common.pojo.order.vo.ReturnAddressVO value){
			this.returnAddress_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderCardVO> GetOrderCardList(){
			return this.orderCardList_;
		}
		
		public void SetOrderCardList(List<com.vip.order.common.pojo.order.vo.OrderCardVO> value){
			this.orderCardList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderCancelDataVO GetOrderCancelData(){
			return this.orderCancelData_;
		}
		
		public void SetOrderCancelData(com.vip.order.common.pojo.order.vo.OrderCancelDataVO value){
			this.orderCancelData_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderGoodsBackVO> GetOrderGoodsBackList(){
			return this.orderGoodsBackList_;
		}
		
		public void SetOrderGoodsBackList(List<com.vip.order.common.pojo.order.vo.OrderGoodsBackVO> value){
			this.orderGoodsBackList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderBackBankVO> GetOrderBackBankList(){
			return this.orderBackBankList_;
		}
		
		public void SetOrderBackBankList(List<com.vip.order.common.pojo.order.vo.OrderBackBankVO> value){
			this.orderBackBankList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrdersPayTypeVO GetOrdersPayType(){
			return this.ordersPayType_;
		}
		
		public void SetOrdersPayType(com.vip.order.common.pojo.order.vo.OrdersPayTypeVO value){
			this.ordersPayType_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderPosVO GetOrderPos(){
			return this.orderPos_;
		}
		
		public void SetOrderPos(com.vip.order.common.pojo.order.vo.OrderPosVO value){
			this.orderPos_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderCouponVO> GetCouponList(){
			return this.couponList_;
		}
		
		public void SetCouponList(List<com.vip.order.common.pojo.order.vo.OrderCouponVO> value){
			this.couponList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OpStatusVO> GetOpStatusList(){
			return this.opStatusList_;
		}
		
		public void SetOpStatusList(List<com.vip.order.common.pojo.order.vo.OpStatusVO> value){
			this.opStatusList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> GetPrepayOrderExtendList(){
			return this.prepayOrderExtendList_;
		}
		
		public void SetPrepayOrderExtendList(List<com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO> value){
			this.prepayOrderExtendList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO> GetOrderRefundDetailsList(){
			return this.orderRefundDetailsList_;
		}
		
		public void SetOrderRefundDetailsList(List<com.vip.order.common.pojo.order.vo.OrderRefundDetailsVO> value){
			this.orderRefundDetailsList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderPaySnVO> GetOrderPaySnList(){
			return this.orderPaySnList_;
		}
		
		public void SetOrderPaySnList(List<com.vip.order.common.pojo.order.vo.OrderPaySnVO> value){
			this.orderPaySnList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderCompensateVO GetOrderCompensate(){
			return this.orderCompensate_;
		}
		
		public void SetOrderCompensate(com.vip.order.common.pojo.order.vo.OrderCompensateVO value){
			this.orderCompensate_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> GetOrderWarehouseList(){
			return this.orderWarehouseList_;
		}
		
		public void SetOrderWarehouseList(List<com.vip.order.common.pojo.order.vo.OrderWarehouseVO> value){
			this.orderWarehouseList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO GetOrderBizExtAttr(){
			return this.orderBizExtAttr_;
		}
		
		public void SetOrderBizExtAttr(com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO value){
			this.orderBizExtAttr_ = value;
		}
		
	}
	
}