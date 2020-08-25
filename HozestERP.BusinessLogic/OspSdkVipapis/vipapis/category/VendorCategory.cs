using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.category{
	
	
	
	
	
	public class VendorCategory {
		
		///<summary>
		/// 最后一级类目的类目名称
		/// @sampleValue vendor_category_name 女士衬衫
		///</summary>
		
		private string vendor_category_name_;
		
		///<summary>
		/// 最后一级类目的类目ID
		///</summary>
		
		private string vendor_category_id_;
		
		///<summary>
		/// 非叶子结点的类目名称路径，请以半角“>”号隔开。
		/// @sampleValue vendor_category_path 衣服>女士上衣
		///</summary>
		
		private string vendor_category_path_;
		
		///<summary>
		/// 属性的结构
		/// @sampleValue vendor_properties_map {"颜色":["红色","蓝色"],"尺寸":["M","L","XL"]}
		///</summary>
		
		private Dictionary<string, List<string>> vendor_properties_map_;
		
		public string GetVendor_category_name(){
			return this.vendor_category_name_;
		}
		
		public void SetVendor_category_name(string value){
			this.vendor_category_name_ = value;
		}
		public string GetVendor_category_id(){
			return this.vendor_category_id_;
		}
		
		public void SetVendor_category_id(string value){
			this.vendor_category_id_ = value;
		}
		public string GetVendor_category_path(){
			return this.vendor_category_path_;
		}
		
		public void SetVendor_category_path(string value){
			this.vendor_category_path_ = value;
		}
		public Dictionary<string, List<string>> GetVendor_properties_map(){
			return this.vendor_properties_map_;
		}
		
		public void SetVendor_properties_map(Dictionary<string, List<string>> value){
			this.vendor_properties_map_ = value;
		}
		
	}
	
}