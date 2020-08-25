using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.product.publish.service{
	
	
	
	
	
	public class ShoeReportReturn {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 返回信息
		///</summary>
		
		private com.vip.product.publish.common.model.ReturnCodeMsg returnCodeMsg_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public com.vip.product.publish.common.model.ReturnCodeMsg GetReturnCodeMsg(){
			return this.returnCodeMsg_;
		}
		
		public void SetReturnCodeMsg(com.vip.product.publish.common.model.ReturnCodeMsg value){
			this.returnCodeMsg_ = value;
		}
		
	}
	
}