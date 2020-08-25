using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class GetOrdersResponse {
		
		///<summary>
		/// 符合查询条件的总记录数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 订单信息列表
		///</summary>
		
		private List<vipapis.marketplace.delivery.SovOrder> orders_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.marketplace.delivery.SovOrder> GetOrders(){
			return this.orders_;
		}
		
		public void SetOrders(List<vipapis.marketplace.delivery.SovOrder> value){
			this.orders_ = value;
		}
		
	}
	
}