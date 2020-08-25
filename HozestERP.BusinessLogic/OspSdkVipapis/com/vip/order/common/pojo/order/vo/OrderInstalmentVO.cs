using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderInstalmentVO {
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO order_;
		
		///<summary>
		/// 订单分期付款信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO orderPayInstalment_;
		
		public com.vip.order.common.pojo.order.vo.OrderVO GetOrder(){
			return this.order_;
		}
		
		public void SetOrder(com.vip.order.common.pojo.order.vo.OrderVO value){
			this.order_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO GetOrderPayInstalment(){
			return this.orderPayInstalment_;
		}
		
		public void SetOrderPayInstalment(com.vip.order.common.pojo.order.vo.OrderPayInstalmentVO value){
			this.orderPayInstalment_ = value;
		}
		
	}
	
}