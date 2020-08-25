using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class ReturnOrderDetailsRequest {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 订单号(order_id与order_return_id两者必填一项)
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 客退申请单号()
		///</summary>
		
		private string order_return_id_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetOrder_return_id(){
			return this.order_return_id_;
		}
		
		public void SetOrder_return_id(string value){
			this.order_return_id_ = value;
		}
		
	}
	
}