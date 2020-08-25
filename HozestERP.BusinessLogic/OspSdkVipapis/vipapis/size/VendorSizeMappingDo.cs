using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class VendorSizeMappingDo {
		
		///<summary>
		/// 主键id
		/// @sampleValue id 
		///</summary>
		
		private int? id_;
		
		///<summary>
		/// 供应商id
		/// @sampleValue vendor_id 
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 唯品会类目路径名称
		/// @sampleValue vip_category_path 
		///</summary>
		
		private string vip_category_path_;
		
		///<summary>
		/// 唯品会类目路径id
		/// @sampleValue vip_category_path_id 
		///</summary>
		
		private string vip_category_path_id_;
		
		///<summary>
		/// 唯品会叶子类目名称
		/// @sampleValue vip_category_name 
		///</summary>
		
		private string vip_category_name_;
		
		///<summary>
		/// 唯品会叶子类目id
		/// @sampleValue vip_category_id 
		///</summary>
		
		private int? vip_category_id_;
		
		///<summary>
		/// 尺码表id
		/// @sampleValue size_table_id 
		///</summary>
		
		private string size_table_id_;
		
		///<summary>
		/// 创建时间
		/// @sampleValue create_time 
		///</summary>
		
		private System.DateTime? create_time_;
		
		///<summary>
		/// 更新时间
		/// @sampleValue update_time 
		///</summary>
		
		private System.DateTime? update_time_;
		
		public int? GetId(){
			return this.id_;
		}
		
		public void SetId(int? value){
			this.id_ = value;
		}
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
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
		public string GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(string value){
			this.size_table_id_ = value;
		}
		public System.DateTime? GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(System.DateTime? value){
			this.create_time_ = value;
		}
		public System.DateTime? GetUpdate_time(){
			return this.update_time_;
		}
		
		public void SetUpdate_time(System.DateTime? value){
			this.update_time_ = value;
		}
		
	}
	
}