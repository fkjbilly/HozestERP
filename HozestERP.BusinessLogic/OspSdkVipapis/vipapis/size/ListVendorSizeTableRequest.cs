using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.size{
	
	
	
	
	
	public class ListVendorSizeTableRequest {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 333
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 唯品会三级类目ID
		/// @sampleValue category_id 304
		///</summary>
		
		private int? category_id_;
		
		///<summary>
		/// 当前页
		/// @sampleValue page 1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 每页记录数
		/// @sampleValue limit 10
		///</summary>
		
		private int? limit_;
		
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
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		
	}
	
}