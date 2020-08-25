using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderDeliveryInfo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 运单列表
		///</summary>
		
		private List<vipapis.order.DeliveryInfo> delivery_list_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public List<vipapis.order.DeliveryInfo> GetDelivery_list(){
			return this.delivery_list_;
		}
		
		public void SetDelivery_list(List<vipapis.order.DeliveryInfo> value){
			this.delivery_list_ = value;
		}
		
	}
	
}