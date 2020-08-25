using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetOrderListResponse {
		
		///<summary>
		/// 订单信息列表
		///</summary>
		
		private List<vipapis.delivery.DvdOrder> dvd_order_list_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.DvdOrder> GetDvd_order_list(){
			return this.dvd_order_list_;
		}
		
		public void SetDvd_order_list(List<vipapis.delivery.DvdOrder> value){
			this.dvd_order_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}