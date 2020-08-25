using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class SignOrderReq {
		
		///<summary>
		/// 订单号及用户ID
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderSnAndIdVO orderSnAndUserId_;
		
		public com.vip.order.common.pojo.order.vo.OrderSnAndIdVO GetOrderSnAndUserId(){
			return this.orderSnAndUserId_;
		}
		
		public void SetOrderSnAndUserId(com.vip.order.common.pojo.order.vo.OrderSnAndIdVO value){
			this.orderSnAndUserId_ = value;
		}
		
	}
	
}