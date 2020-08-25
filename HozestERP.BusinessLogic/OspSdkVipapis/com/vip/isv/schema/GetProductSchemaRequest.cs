using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.schema{
	
	
	
	
	
	public class GetProductSchemaRequest {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 525
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 分类ID(只可录入三级分类ID)
		/// @sampleValue category_id 111
		///</summary>
		
		private int? category_id_;
		
		///<summary>
		/// 模板类型:create/edit
		///</summary>
		
		private string schema_type_;
		
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
		public string GetSchema_type(){
			return this.schema_type_;
		}
		
		public void SetSchema_type(string value){
			this.schema_type_ = value;
		}
		
	}
	
}