using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class ConfirmPriceApplicationRequest {
		
		///<summary>
		/// 供应商Id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 价格申请单id
		///</summary>
		
		private string application_id_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetApplication_id(){
			return this.application_id_;
		}
		
		public void SetApplication_id(string value){
			this.application_id_ = value;
		}
		
	}
	
}