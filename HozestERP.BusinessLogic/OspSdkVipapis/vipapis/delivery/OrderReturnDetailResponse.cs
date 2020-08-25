using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class OrderReturnDetailResponse {
		
		///<summary>
		/// 客退订单详情
		///</summary>
		
		private List<vipapis.delivery.Return> order_return_detail_list_;
		
		///<summary>
		/// 总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.Return> GetOrder_return_detail_list(){
			return this.order_return_detail_list_;
		}
		
		public void SetOrder_return_detail_list(List<vipapis.delivery.Return> value){
			this.order_return_detail_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}