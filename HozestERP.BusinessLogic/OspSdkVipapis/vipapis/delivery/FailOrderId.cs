using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class FailOrderId {
		
		///<summary>
		/// 订单号码
		/// @sampleValue order_id 
		///</summary>
		
		private string order_id_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		
	}
	
}