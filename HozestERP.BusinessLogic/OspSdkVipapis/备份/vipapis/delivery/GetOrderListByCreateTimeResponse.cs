using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetOrderListByCreateTimeResponse {
		
		///<summary>
		/// 订单列表
		///</summary>
		
		private List<vipapis.delivery.OrderListByCreateTime> order_list_by_create_time_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.OrderListByCreateTime> GetOrder_list_by_create_time(){
			return this.order_list_by_create_time_;
		}
		
		public void SetOrder_list_by_create_time(List<vipapis.delivery.OrderListByCreateTime> value){
			this.order_list_by_create_time_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}