using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class AvailableInventory {
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 供应商可售库存（<font color='red'>不能为负数</font>）
		///</summary>
		
		private int? quantity_;
		
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
		
	}
	
}