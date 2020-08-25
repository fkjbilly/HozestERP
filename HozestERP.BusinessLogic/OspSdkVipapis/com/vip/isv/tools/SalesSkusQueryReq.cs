using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class SalesSkusQueryReq {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private long? vendorId_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 专场id
		///</summary>
		
		private long? salesNo_;
		
		public long? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(long? value){
			this.vendorId_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public long? GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(long? value){
			this.salesNo_ = value;
		}
		
	}
	
}