using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetRestockStorageInfoRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 补货单号
		///</summary>
		
		private string bh_pick_no_;
		
		///<summary>
		/// 当前页码,不填默认为：1
		///</summary>
		
		private int? page_;
		
		///<summary>
		///  每页记录总数，不填默认为：20;最大限制为：20
		///</summary>
		
		private int? limit_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetBh_pick_no(){
			return this.bh_pick_no_;
		}
		
		public void SetBh_pick_no(string value){
			this.bh_pick_no_ = value;
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