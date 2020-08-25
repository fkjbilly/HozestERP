using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class ConfirmDeliveryRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storageNo_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetStorageNo(){
			return this.storageNo_;
		}
		
		public void SetStorageNo(string value){
			this.storageNo_ = value;
		}
		
	}
	
}