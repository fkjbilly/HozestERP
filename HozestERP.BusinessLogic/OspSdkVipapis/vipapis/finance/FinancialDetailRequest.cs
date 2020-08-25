using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class FinancialDetailRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 订单号，支持批量 <= 200
		///</summary>
		
		private List<string> order_id_;
		
		///<summary>
		/// 开始查询时间
		///</summary>
		
		private string st_query_time_;
		
		///<summary>
		/// 结束查询时间
		///</summary>
		
		private string et_query_time_;
		
		///<summary>
		/// 页码，默认1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 每页查询数，默认100，最大1000
		///</summary>
		
		private int? limit_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public List<string> GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(List<string> value){
			this.order_id_ = value;
		}
		public string GetSt_query_time(){
			return this.st_query_time_;
		}
		
		public void SetSt_query_time(string value){
			this.st_query_time_ = value;
		}
		public string GetEt_query_time(){
			return this.et_query_time_;
		}
		
		public void SetEt_query_time(string value){
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