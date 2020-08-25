using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetActualStorageInfoRequest {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storage_no_;
		
		///<summary>
		/// 页码，默认为：1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 单页记录数,最大记录数为：200，默认为：200
		///</summary>
		
		private int? limit_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetStorage_no(){
			return this.storage_no_;
		}
		
		public void SetStorage_no(string value){
			this.storage_no_ = value;
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