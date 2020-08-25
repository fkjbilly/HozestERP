using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class SubmitDeliveryResponse {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 送货单号
		///</summary>
		
		private string storageNo_;
		
		///<summary>
		/// 总箱数
		///</summary>
		
		private int? totalBox_;
		
		///<summary>
		/// 总商品数
		///</summary>
		
		private int? amount_;
		
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
		public int? GetTotalBox(){
			return this.totalBox_;
		}
		
		public void SetTotalBox(int? value){
			this.totalBox_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		
	}
	
}