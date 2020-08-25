using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetDeliveryListResponse {
		
		///<summary>
		/// 送货单列表
		///</summary>
		
		private List<vipapis.delivery.DeliveryList> delivery_list_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.DeliveryList> GetDelivery_list(){
			return this.delivery_list_;
		}
		
		public void SetDelivery_list(List<vipapis.delivery.DeliveryList> value){
			this.delivery_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}