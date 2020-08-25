using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CSCCancelBackReq {
		
		///<summary>
		/// 订单id
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