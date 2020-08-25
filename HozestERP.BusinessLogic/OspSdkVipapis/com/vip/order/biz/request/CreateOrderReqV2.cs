using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CreateOrderReqV2 {
		
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
		/// 订单cookie
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderCookieVO orderCookie_;
		
		///<summary>
		/// 预付订单额外信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO prepayOrderExtend_;
		
		///<summary>
		/// 订单分期信息
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVO> orderPeriodsInfoList_;
		
		///<summary>
		/// unique_key
		///</summary>
		
		private string uniqueKey_;
		
		///<summary>
		/// 订单参数索引
		///</summary>
		
		private string indexKey_;
		
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
		public com.vip.order.common.pojo.order.vo.OrderCookieVO GetOrderCookie(){
			return this.orderCookie_;
		}
		
		public void SetOrderCookie(com.vip.order.common.pojo.order.vo.OrderCookieVO value){
			this.orderCookie_ = value;
		}
		public com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO GetPrepayOrderExtend(){
			return this.prepayOrderExtend_;
		}
		
		public void SetPrepayOrderExtend(com.vip.order.common.pojo.order.vo.PrepayOrderExtendVO value){
			this.prepayOrderExtend_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVO> GetOrderPeriodsInfoList(){
			return this.orderPeriodsInfoList_;
		}
		
		public void SetOrderPeriodsInfoList(List<com.vip.order.common.pojo.order.vo.PrepayOrderPeriodsInfoVO> value){
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
		public com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO GetOrderBizExtAttr(){
			return this.orderBizExtAttr_;
		}
		
		public void SetOrderBizExtAttr(com.vip.order.common.pojo.order.vo.OrderBizExtAttrVO value){
			this.orderBizExtAttr_ = value;
		}
		
	}
	
}