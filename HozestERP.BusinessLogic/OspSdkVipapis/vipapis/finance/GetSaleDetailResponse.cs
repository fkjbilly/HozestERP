using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class GetSaleDetailResponse {
		
		///<summary>
		/// 订单编号列表
		///</summary>
		
		private List<vipapis.finance.OrderItem> order_item_list_;
		
		public List<vipapis.finance.OrderItem> GetOrder_item_list(){
			return this.order_item_list_;
		}
		
		public void SetOrder_item_list(List<vipapis.finance.OrderItem> value){
			this.order_item_list_ = value;
		}
		
	}
	
}