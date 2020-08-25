using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class UserDeleteOrderReq {
		
		///<summary>
		/// 订单id
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		
	}
	
}