using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GroupByOrderAuditParam {
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		
	}
	
}