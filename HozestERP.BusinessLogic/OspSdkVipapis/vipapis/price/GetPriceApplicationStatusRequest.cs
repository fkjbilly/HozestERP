using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class GetPriceApplicationStatusRequest {
		
		///<summary>
		/// 供应商Id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 价格申请单id列表,最大不超过100个申请单id
		///</summary>
		
		private List<string> application_id_list_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public List<string> GetApplication_id_list(){
			return this.application_id_list_;
		}
		
		public void SetApplication_id_list(List<string> value){
			this.application_id_list_ = value;
		}
		
	}
	
}