using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ConfirmDeliveredReq {
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		
	}
	
}