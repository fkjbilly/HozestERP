using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderGoodsItem {
		
		///<summary>
		/// 订单基本信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO order_;
		
		///<summary>
		/// 订单收货地址信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO orderReceiveAddr_;
		
		///<summary>
		/// 订单支付及优惠信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO orderPayAndDiscount_;
		
		///<summary>
		/// 订单商品信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderGoodsVO orderGoods_;
		
		///<summary>
		/// 订单商品补充信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO orderDetailsSuppInfo_;
		
		public com.vip.order.common.pojo.order.vo.OrderVO GetOrder(){
			return this.order_;
		}
		
		public void SetOrder(com.vip.order.common.pojo.order.vo.OrderVO value){
			this.order_ = value;
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
		public com.vip.order.common.pojo.order.vo.OrderGoodsVO GetOrderGoods(){
			return this.orderGoods_;
		}
		
		public void SetOrderGoods(com.vip.order.common.pojo.order.vo.OrderGoodsVO value){
			this.orderGoods_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO GetOrderDetailsSuppInfo(){
			return this.orderDetailsSuppInfo_;
		}
		
		public void SetOrderDetailsSuppInfo(com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO value){
			this.orderDetailsSuppInfo_ = value;
		}
		
	}
	
}