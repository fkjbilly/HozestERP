using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class GetPrintDeliveryRequest {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storageNo_;
		
		///<summary>
		/// po单号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 供应商箱号
		///</summary>
		
		private string boxNo_;
		
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
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public string GetBoxNo(){
			return this.boxNo_;
		}
		
		public void SetBoxNo(string value){
			this.boxNo_ = value;
		}
		
	}
	
}