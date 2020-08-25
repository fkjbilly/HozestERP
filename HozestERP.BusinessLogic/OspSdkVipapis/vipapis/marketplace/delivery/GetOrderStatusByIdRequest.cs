using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class GetOrderStatusByIdRequest {
		
		///<summary>
		/// 订单号列表
		///</summary>
		
		private List<string> order_ids_;
		
		public List<string> GetOrder_ids(){
			return this.order_ids_;
		}
		
		public void SetOrder_ids(List<string> value){
			this.order_ids_ = value;
		}
		
	}
	
}