using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ReturnAddressVO {
		
		///<summary>
		/// 退货地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 供应商退货地址
		///</summary>
		
		private string vendorAddress_;
		
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetVendorAddress(){
			return this.vendorAddress_;
		}
		
		public void SetVendorAddress(string value){
			this.vendorAddress_ = value;
		}
		
	}
	
}