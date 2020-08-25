using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class GetPriceApplicationRequest {
		
		///<summary>
		/// 价格申请单号
		///</summary>
		
		private string application_id_;
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 清单分页号, 不填默认为：1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 分页大小， 不填默认为：100
		///</summary>
		
		private int? limit_;
		
		public string GetApplication_id(){
			return this.application_id_;
		}
		
		public void SetApplication_id(string value){
			this.application_id_ = value;
		}
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
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