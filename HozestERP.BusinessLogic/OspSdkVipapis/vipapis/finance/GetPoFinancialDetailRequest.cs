using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class GetPoFinancialDetailRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// po号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 查询时间段的开始时间
		///</summary>
		
		private System.DateTime? st_query_time_;
		
		///<summary>
		/// 查询时间段的结束时间
		///</summary>
		
		private System.DateTime? et_query_time_;
		
		///<summary>
		/// 页码，不填默认为：1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 每页大小，不填默认为：50，最大：100，超过一百，会按照最大值：100查询
		///</summary>
		
		private int? limit_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public System.DateTime? GetSt_query_time(){
			return this.st_query_time_;
		}
		
		public void SetSt_query_time(System.DateTime? value){
			this.st_query_time_ = value;
		}
		public System.DateTime? GetEt_query_time(){
			return this.et_query_time_;
		}
		
		public void SetEt_query_time(System.DateTime? value){
			this.et_query_time_ = value;
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