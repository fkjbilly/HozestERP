using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.brand{
	
	
	
	
	
	public class VendorBrandRelationShip {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 550
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 供应商名称
		/// @sampleValue vendor_name 唯品会
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// 品牌ID
		/// @sampleValue brand_id 4356
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 品牌中文名
		/// @sampleValue brand_name 耐克
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 品牌英文名
		/// @sampleValue brand_name_eng nike
		///</summary>
		
		private string brand_name_eng_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetVendor_name(){
			return this.vendor_name_;
		}
		
		public void SetVendor_name(string value){
			this.vendor_name_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetBrand_name_eng(){
			return this.brand_name_eng_;
		}
		
		public void SetBrand_name_eng(string value){
			this.brand_name_eng_ = value;
		}
		
	}
	
}