using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class OrderListCountResp {
		
		///<summary>
		/// 
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? orderCount_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public int? GetOrderCount(){
			return this.orderCount_;
		}
		
		public void SetOrderCount(int? value){
			this.orderCount_ = value;
		}
		
	}
	
}