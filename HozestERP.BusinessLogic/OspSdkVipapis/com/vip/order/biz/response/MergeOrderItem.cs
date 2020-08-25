using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class MergeOrderItem {
		
		///<summary>
		/// 订单主信息
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
		/// 销售区域中文描述
		///</summary>
		
		private string areaFlagName_;
		
		///<summary>
		/// 区域标识
		///</summary>
		
		private int? areaFlag_;
		
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
		public string GetAreaFlagName(){
			return this.areaFlagName_;
		}
		
		public void SetAreaFlagName(string value){
			this.areaFlagName_ = value;
		}
		public int? GetAreaFlag(){
			return this.areaFlag_;
		}
		
		public void SetAreaFlag(int? value){
			this.areaFlag_ = value;
		}
		
	}
	
}