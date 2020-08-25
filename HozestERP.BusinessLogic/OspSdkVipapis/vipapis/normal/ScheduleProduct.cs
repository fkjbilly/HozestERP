using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class ScheduleProduct {
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		
	}
	
}