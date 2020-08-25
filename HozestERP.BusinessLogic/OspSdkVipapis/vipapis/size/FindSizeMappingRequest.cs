using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class FindSizeMappingRequest {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 唯品会类目id
		///</summary>
		
		private int? category_id_;
		
		///<summary>
		/// 供应商类目id
		///</summary>
		
		private string vendor_category_id_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetCategory_id(){
			return this.category_id_;
		}
		
		public void SetCategory_id(int? value){
			this.category_id_ = value;
		}
		public string GetVendor_category_id(){
			return this.vendor_category_id_;
		}
		
		public void SetVendor_category_id(string value){
			this.vendor_category_id_ = value;
		}
		
	}
	
}