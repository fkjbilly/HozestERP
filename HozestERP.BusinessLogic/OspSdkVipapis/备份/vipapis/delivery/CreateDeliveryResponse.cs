using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class CreateDeliveryResponse {
		
		///<summary>
		/// 出库单Id
		///</summary>
		
		private string delivery_id_;
		
		///<summary>
		/// 入库编号
		///</summary>
		
		private string storage_no_;
		
		public string GetDelivery_id(){
			return this.delivery_id_;
		}
		
		public void SetDelivery_id(string value){
			this.delivery_id_ = value;
		}
		public string GetStorage_no(){
			return this.storage_no_;
		}
		
		public void SetStorage_no(string value){
			this.storage_no_ = value;
		}
		
	}
	
}