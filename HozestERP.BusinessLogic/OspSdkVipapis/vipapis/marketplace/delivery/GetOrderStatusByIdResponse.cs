using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class GetOrderStatusByIdResponse {
		
		///<summary>
		/// 订单状态返回body
		///</summary>
		
		private List<vipapis.marketplace.delivery.OrderStatus> order_status_list_;
		
		public List<vipapis.marketplace.delivery.OrderStatus> GetOrder_status_list(){
			return this.order_status_list_;
		}
		
		public void SetOrder_status_list(List<vipapis.marketplace.delivery.OrderStatus> value){
			this.order_status_list_ = value;
		}
		
	}
	
}