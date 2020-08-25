using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.sales{
	
	
	
	
	
	public class BarcodeMessage {
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 信息
		///</summary>
		
		private string message_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}