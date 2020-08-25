using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class PickProduct {
		
		///<summary>
		/// 商品拣货数量
		///</summary>
		
		private int? stock_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string art_no_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 尺码
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 供货价（不含税）
		///</summary>
		
		private string actual_unit_price_;
		
		///<summary>
		/// 供货价（含税）
		///</summary>
		
		private string actual_market_price_;
		
		public int? GetStock(){
			return this.stock_;
		}
		
		public void SetStock(int? value){
			this.stock_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetArt_no(){
			return this.art_no_;
		}
		
		public void SetArt_no(string value){
			this.art_no_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public string GetActual_unit_price(){
			return this.actual_unit_price_;
		}
		
		public void SetActual_unit_price(string value){
			this.actual_unit_price_ = value;
		}
		public string GetActual_market_price(){
			return this.actual_market_price_;
		}
		
		public void SetActual_market_price(string value){
			this.actual_market_price_ = value;
		}
		
	}
	
}