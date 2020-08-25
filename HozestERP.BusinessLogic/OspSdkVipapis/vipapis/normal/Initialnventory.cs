using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class Initialnventory {
		
		///<summary>
		/// 商品条码
		/// @sampleValue barcode 
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 初始库存 默认50000
		///</summary>
		
		private int? inventory_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetInventory(){
			return this.inventory_;
		}
		
		public void SetInventory(int? value){
			this.inventory_ = value;
		}
		
	}
	
}