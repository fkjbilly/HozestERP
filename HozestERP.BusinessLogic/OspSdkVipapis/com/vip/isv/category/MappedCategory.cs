using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.category{
	
	
	
	
	
	public class MappedCategory {
		
		///<summary>
		/// 类目属性匹配关系
		///</summary>
		
		private List<com.vip.isv.category.MappedCategoryProperty> properties_;
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 类目匹配树id
		///</summary>
		
		private int? vendor_category_tree_id_;
		
		///<summary>
		/// 类目匹配树名称
		/// @sampleValue vendor_category_tree_name 类目
		///</summary>
		
		private string vendor_category_tree_name_;
		
		///<summary>
		/// 供应商类目树(完整树路径)
		/// @sampleValue vendor_category_path 女装>裙装>连衣裙
		///</summary>
		
		private string vendor_category_path_;
		
		///<summary>
		/// 供应商叶子类目名称
		///</summary>
		
		private string vendor_category_name_;
		
		///<summary>
		/// 供应商叶子类目id
		///</summary>
		
		private string vendor_category_id_;
		
		///<summary>
		/// 唯品会类目树名称(完整树路径)
		/// @sampleValue vip_category_path 女装>裙装>连衣裙
		///</summary>
		
		private string vip_category_path_;
		
		///<summary>
		/// 唯品会类目树id(完整树id)
		/// @sampleValue vip_category_path_id 311>1095>334
		///</summary>
		
		private string vip_category_path_id_;
		
		///<summary>
		/// 唯品会叶子类目名称
		/// @sampleValue vip_category_name 连衣裙
		///</summary>
		
		private string vip_category_name_;
		
		///<summary>
		/// 唯品会叶子类目id
		///</summary>
		
		private int? vip_category_id_;
		
		public List<com.vip.isv.category.MappedCategoryProperty> GetProperties(){
			return this.properties_;
		}
		
		public void SetProperties(List<com.vip.isv.category.MappedCategoryProperty> value){
			this.properties_ = value;
		}
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetVendor_category_tree_id(){
			return this.vendor_category_tree_id_;
		}
		
		public void SetVendor_category_tree_id(int? value){
			this.vendor_category_tree_id_ = value;
		}
		public string GetVendor_category_tree_name(){
			return this.vendor_category_tree_name_;
		}
		
		public void SetVendor_category_tree_name(string value){
			this.vendor_category_tree_name_ = value;
		}
		public string GetVendor_category_path(){
			return this.vendor_category_path_;
		}
		
		public void SetVendor_category_path(string value){
			this.vendor_category_path_ = value;
		}
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
		public string GetVip_category_path(){
			return this.vip_category_path_;
		}
		
		public void SetVip_category_path(string value){
			this.vip_category_path_ = value;
		}
		public string GetVip_category_path_id(){
			return this.vip_category_path_id_;
		}
		
		public void SetVip_category_path_id(string value){
			this.vip_category_path_id_ = value;
		}
		public string GetVip_category_name(){
			return this.vip_category_name_;
		}
		
		public void SetVip_category_name(string value){
			this.vip_category_name_ = value;
		}
		public int? GetVip_category_id(){
			return this.vip_category_id_;
		}
		
		public void SetVip_category_id(int? value){
			this.vip_category_id_ = value;
		}
		
	}
	
}