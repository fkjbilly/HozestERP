using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetOrderDetailResponse {
		
		///<summary>
		/// 订单明细信息列表
		///</summary>
		
		private List<vipapis.delivery.DvdOrderDetail> orderDetails_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.DvdOrderDetail> GetOrderDetails(){
			return this.orderDetails_;
		}
		
		public void SetOrderDetails(List<vipapis.delivery.DvdOrderDetail> value){
			this.orderDetails_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}