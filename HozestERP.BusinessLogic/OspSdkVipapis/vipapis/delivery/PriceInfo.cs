using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class PriceInfo {
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 1、actual_market_price为结算价（含税）=结算价（不含税）乘以(1+税率)
		///</summary>
		
		private string actual_market_price_;
		
		///<summary>
		/// 2、actual_unit_price为结算（不含税）
		///</summary>
		
		private string actual_unit_price_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetActual_market_price(){
			return this.actual_market_price_;
		}
		
		public void SetActual_market_price(string value){
			this.actual_market_price_ = value;
		}
		public string GetActual_unit_price(){
			return this.actual_unit_price_;
		}
		
		public void SetActual_unit_price(string value){
			this.actual_unit_price_ = value;
		}
		
	}
	
}