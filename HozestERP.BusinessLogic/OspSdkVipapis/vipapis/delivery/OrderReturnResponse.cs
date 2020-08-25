using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class OrderReturnResponse {
		
		///<summary>
		/// 客退申请单列表
		///</summary>
		
		private List<vipapis.delivery.OrderReturn> order_return_list_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.OrderReturn> GetOrder_return_list(){
			return this.order_return_list_;
		}
		
		public void SetOrder_return_list(List<vipapis.delivery.OrderReturn> value){
			this.order_return_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}