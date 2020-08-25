using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class AddSizeTableRequest {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 尺码表名称
		///</summary>
		
		private string size_table_name_;
		
		///<summary>
		/// 尺码表类型
		/// @sampleValue size_table_type 1：标准尺码表 2：自定义(暂只支持标准尺码表)
		///</summary>
		
		private short? size_table_type_;
		
		///<summary>
		/// html内容
		///</summary>
		
		private string size_table_html_;
		
		///<summary>
		/// 温馨提示
		///</summary>
		
		private string size_table_tips_;
		
		///<summary>
		/// 三级类目id
		///</summary>
		
		private int? category_id_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetSize_table_name(){
			return this.size_table_name_;
		}
		
		public void SetSize_table_name(string value){
			this.size_table_name_ = value;
		}
		public short? GetSize_table_type(){
			return this.size_table_type_;
		}
		
		public void SetSize_table_type(short? value){
			this.size_table_type_ = value;
		}
		public string GetSize_table_html(){
			return this.size_table_html_;
		}
		
		public void SetSize_table_html(string value){
			this.size_table_html_ = value;
		}
		public string GetSize_table_tips(){
			return this.size_table_tips_;
		}
		
		public void SetSize_table_tips(string value){
			this.size_table_tips_ = value;
		}
		public int? GetCategory_id(){
			return this.category_id_;
		}
		
		public void SetCategory_id(int? value){
			this.category_id_ = value;
		}
		
	}
	
}