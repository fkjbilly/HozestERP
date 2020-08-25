using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class ExportOrderByIdResponse {
		
		///<summary>
		/// 订单导出信息
		///</summary>
		
		private List<vipapis.marketplace.delivery.ExportOrderInfo> orders_;
		
		public List<vipapis.marketplace.delivery.ExportOrderInfo> GetOrders(){
			return this.orders_;
		}
		
		public void SetOrders(List<vipapis.marketplace.delivery.ExportOrderInfo> value){
			this.orders_ = value;
		}
		
	}
	
}