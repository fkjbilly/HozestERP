using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.pg{
	
	
	
	
	
	public class GetOrderListResponse {
		
		///<summary>
		/// orders
		///</summary>
		
		private List<vipapis.pg.Order> orders_;
		
		///<summary>
		/// total
		///</summary>
		
		private int? total_;
		
		public List<vipapis.pg.Order> GetOrders(){
			return this.orders_;
		}
		
		public void SetOrders(List<vipapis.pg.Order> value){
			this.orders_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}