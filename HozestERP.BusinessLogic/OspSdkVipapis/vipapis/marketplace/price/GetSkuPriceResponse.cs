using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.price{
	
	
	
	
	
	public class GetSkuPriceResponse {
		
		///<summary>
		/// 商品sku id
		///</summary>
		
		private string sku_id_;
		
		///<summary>
		/// 市场价
		///</summary>
		
		private double? market_price_;
		
		///<summary>
		/// 销售价
		///</summary>
		
		private double? sale_price_;
		
		public string GetSku_id(){
			return this.sku_id_;
		}
		
		public void SetSku_id(string value){
			this.sku_id_ = value;
		}
		public double? GetMarket_price(){
			return this.market_price_;
		}
		
		public void SetMarket_price(double? value){
			this.market_price_ = value;
		}
		public double? GetSale_price(){
			return this.sale_price_;
		}
		
		public void SetSale_price(double? value){
			this.sale_price_ = value;
		}
		
	}
	
}