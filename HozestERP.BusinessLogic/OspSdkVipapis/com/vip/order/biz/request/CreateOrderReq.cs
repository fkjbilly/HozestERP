using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CreateOrderReq {
		
		///<summary>
		/// 订单信息 
		///</summary>
		
		private com.vip.order.biz.vo.OrderVO order_;
		
		///<summary>
		/// 订单第三方标识
		///</summary>
		
		private com.vip.order.biz.vo.OrderCoopVO exOrderSn_;
		
		///<summary>
		/// 订单发票
		///</summary>
		
		private com.vip.order.biz.vo.OrderInvoiceVO orderInvoice_;
		
		///<summary>
		/// 订单电子发票
		///</summary>
		
		private com.vip.order.biz.vo.OrderElectronicInvoiceVO orderElectronicInvoice_;
		
		///<summary>
		/// 订单收货地址信息
		///</summary>
		
		private com.vip.order.biz.vo.OrderReceiveAddrVO orderReceiveAddr_;
		
		///<summary>
		/// 订单支付及优惠信息
		///</summary>
		
		private com.vip.order.biz.vo.OrderPayAndDiscountVO orderPayAndDiscount_;
		
		///<summary>
		/// 订单支付明细
		///</summary>
		
		private List<com.vip.order.biz.vo.OrderPayDetailVO> orderPayDetailList_;
		
		///<summary>
		/// 订单分期付款
		///</summary>
		
		private List<com.vip.order.biz.vo.OrderPayInstalmentVO> orderPayInstalmentList_;
		
		///<summary>
		/// 订单商品
		///</summary>
		
		private List<com.vip.order.biz.vo.OrderGoodsAndDescribeVO> orderGoodsAndDescribeList_;
		
		///<summary>
		/// 订单活动
		///</summary>
		
		private List<com.vip.order.biz.vo.OrderActiveVO> orderActiveList_;
		
		///<summary>
		/// 订单cookie
		///</summary>
		
		private com.vip.order.biz.vo.OrderCookieVO orderCookie_;
		
		///<summary>
		/// 预付订单额外信息
		///</summary>
		
		private com.vip.order.biz.vo.PrepayOrderExtendVO prepayOrderExtend_;
		
		///<summary>
		/// 订单分期信息
		///</summary>
		
		private List<com.vip.order.biz.vo.PrepayOrderPeriodsInfoVO> orderPeriodsInfoList_;
		
		///<summary>
		/// unique_key
		///</summary>
		
		private string uniqueKey_;
		
		///<summary>
		/// 订单参数索引
		///</summary>
		
		private string indexKey_;
		
		public com.vip.order.biz.vo.OrderVO GetOrder(){
			return this.order_;
		}
		
		public void SetOrder(com.vip.order.biz.vo.OrderVO value){
			this.order_ = value;
		}
		public com.vip.order.biz.vo.OrderCoopVO GetExOrderSn(){
			return this.exOrderSn_;
		}
		
		public void SetExOrderSn(com.vip.order.biz.vo.OrderCoopVO value){
			this.exOrderSn_ = value;
		}
		public com.vip.order.biz.vo.OrderInvoiceVO GetOrderInvoice(){
			return this.orderInvoice_;
		}
		
		public void SetOrderInvoice(com.vip.order.biz.vo.OrderInvoiceVO value){
			this.orderInvoice_ = value;
		}
		public com.vip.order.biz.vo.OrderElectronicInvoiceVO GetOrderElectronicInvoice(){
			return this.orderElectronicInvoice_;
		}
		
		public void SetOrderElectronicInvoice(com.vip.order.biz.vo.OrderElectronicInvoiceVO value){
			this.orderElectronicInvoice_ = value;
		}
		public com.vip.order.biz.vo.OrderReceiveAddrVO GetOrderReceiveAddr(){
			return this.orderReceiveAddr_;
		}
		
		public void SetOrderReceiveAddr(com.vip.order.biz.vo.OrderReceiveAddrVO value){
			this.orderReceiveAddr_ = value;
		}
		public com.vip.order.biz.vo.OrderPayAndDiscountVO GetOrderPayAndDiscount(){
			return this.orderPayAndDiscount_;
		}
		
		public void SetOrderPayAndDiscount(com.vip.order.biz.vo.OrderPayAndDiscountVO value){
			this.orderPayAndDiscount_ = value;
		}
		public List<com.vip.order.biz.vo.OrderPayDetailVO> GetOrderPayDetailList(){
			return this.orderPayDetailList_;
		}
		
		public void SetOrderPayDetailList(List<com.vip.order.biz.vo.OrderPayDetailVO> value){
			this.orderPayDetailList_ = value;
		}
		public List<com.vip.order.biz.vo.OrderPayInstalmentVO> GetOrderPayInstalmentList(){
			return this.orderPayInstalmentList_;
		}
		
		public void SetOrderPayInstalmentList(List<com.vip.order.biz.vo.OrderPayInstalmentVO> value){
			this.orderPayInstalmentList_ = value;
		}
		public List<com.vip.order.biz.vo.OrderGoodsAndDescribeVO> GetOrderGoodsAndDescribeList(){
			return this.orderGoodsAndDescribeList_;
		}
		
		public void SetOrderGoodsAndDescribeList(List<com.vip.order.biz.vo.OrderGoodsAndDescribeVO> value){
			this.orderGoodsAndDescribeList_ = value;
		}
		public List<com.vip.order.biz.vo.OrderActiveVO> GetOrderActiveList(){
			return this.orderActiveList_;
		}
		
		public void SetOrderActiveList(List<com.vip.order.biz.vo.OrderActiveVO> value){
			this.orderActiveList_ = value;
		}
		public com.vip.order.biz.vo.OrderCookieVO GetOrderCookie(){
			return this.orderCookie_;
		}
		
		public void SetOrderCookie(com.vip.order.biz.vo.OrderCookieVO value){
			this.orderCookie_ = value;
		}
		public com.vip.order.biz.vo.PrepayOrderExtendVO GetPrepayOrderExtend(){
			return this.prepayOrderExtend_;
		}
		
		public void SetPrepayOrderExtend(com.vip.order.biz.vo.PrepayOrderExtendVO value){
			this.prepayOrderExtend_ = value;
		}
		public List<com.vip.order.biz.vo.PrepayOrderPeriodsInfoVO> GetOrderPeriodsInfoList(){
			return this.orderPeriodsInfoList_;
		}
		
		public void SetOrderPeriodsInfoList(List<com.vip.order.biz.vo.PrepayOrderPeriodsInfoVO> value){
			this.orderPeriodsInfoList_ = value;
		}
		public string GetUniqueKey(){
			return this.uniqueKey_;
		}
		
		public void SetUniqueKey(string value){
			this.uniqueKey_ = value;
		}
		public string GetIndexKey(){
			return this.indexKey_;
		}
		
		public void SetIndexKey(string value){
			this.indexKey_ = value;
		}
		
	}
	
}