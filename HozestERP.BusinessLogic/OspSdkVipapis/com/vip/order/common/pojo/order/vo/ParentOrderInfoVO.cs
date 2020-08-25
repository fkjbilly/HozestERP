using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ParentOrderInfoVO {
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO parentOrder_;
		
		///<summary>
		/// 订单收货地址信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO parentOrderReceiveAddr_;
		
		///<summary>
		/// 订单支付及优惠信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO parentOrderPayAndDiscount_;
		
		///<summary>
		/// 订单补充信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO parentOrderDetailsSuppInfo_;
		
		public com.vip.order.common.pojo.order.vo.OrderVO GetParentOrder(){
			return this.parentOrder_;
		}
		
		public void SetParentOrder(com.vip.order.common.pojo.order.vo.OrderVO value){
			this.parentOrder_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO GetParentOrderReceiveAddr(){
			return this.parentOrderReceiveAddr_;
		}
		
		public void SetParentOrderReceiveAddr(com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value){
			this.parentOrderReceiveAddr_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO GetParentOrderPayAndDiscount(){
			return this.parentOrderPayAndDiscount_;
		}
		
		public void SetParentOrderPayAndDiscount(com.vip.order.common.pojo.order.vo.OrderPayAndDiscountVO value){
			this.parentOrderPayAndDiscount_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO GetParentOrderDetailsSuppInfo(){
			return this.parentOrderDetailsSuppInfo_;
		}
		
		public void SetParentOrderDetailsSuppInfo(com.vip.order.common.pojo.order.vo.OrderDetailsSuppInfoVO value){
			this.parentOrderDetailsSuppInfo_ = value;
		}
		
	}
	
}