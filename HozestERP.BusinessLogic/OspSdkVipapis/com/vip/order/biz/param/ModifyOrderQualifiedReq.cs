using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.param{
	
	
	
	
	
	public class ModifyOrderQualifiedReq {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 账号id
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