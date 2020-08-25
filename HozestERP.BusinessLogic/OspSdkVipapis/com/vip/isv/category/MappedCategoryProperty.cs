using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.category{
	
	
	
	
	
	public class MappedCategoryProperty {
		
		///<summary>
		/// 供应商类目属性名称
		/// @sampleValue vendor_prop_Name 色彩
		///</summary>
		
		private string vendor_prop_Name_;
		
		///<summary>
		/// 唯品会类目属性名称
		/// @sampleValue vip_prop_name 颜色
		///</summary>
		
		private string vip_prop_name_;
		
		///<summary>
		/// 唯品会类目属性id
		///</summary>
		
		private int? vip_prop_id_;
		
		public string GetVendor_prop_Name(){
			return this.vendor_prop_Name_;
		}
		
		public void SetVendor_prop_Name(string value){
			this.vendor_prop_Name_ = value;
		}
		public string GetVip_prop_name(){
			return this.vip_prop_name_;
		}
		
		public void SetVip_prop_name(string value){
			this.vip_prop_name_ = value;
		}
		public int? GetVip_prop_id(){
			return this.vip_prop_id_;
		}
		
		public void SetVip_prop_id(int? value){
			this.vip_prop_id_ = value;
		}
		
	}
	
}