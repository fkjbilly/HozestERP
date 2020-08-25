using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class GetOrderFinancialDataResponse {
		
		///<summary>
		/// 销售订单详情列表
		///</summary>
		
		private List<vipapis.finance.OrderDetail> orders_;
		
		public List<vipapis.finance.OrderDetail> GetOrders(){
			return this.orders_;
		}
		
		public void SetOrders(List<vipapis.finance.OrderDetail> value){
			this.orders_ = value;
		}
		
	}
	
}