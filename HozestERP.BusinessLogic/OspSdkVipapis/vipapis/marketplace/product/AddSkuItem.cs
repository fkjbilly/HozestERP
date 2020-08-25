using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class AddSkuItem {
		
		///<summary>
		/// 外部sku编号
		/// @sampleValue outer_sku_id barcode_sample
		///</summary>
		
		private string outer_sku_id_;
		
		///<summary>
		/// 市场价（吊牌价）
		/// @sampleValue market_price 739.00
		///</summary>
		
		private double? market_price_;
		
		///<summary>
		/// 销售价
		/// @sampleValue sell_price 259.00
		///</summary>
		
		private double? sell_price_;
		
		///<summary>
		/// 简化版销售属性
		///</summary>
		
		private List<vipapis.marketplace.product.SimpleProperty> simple_sale_props_;
		
		public string GetOuter_sku_id(){
			return this.outer_sku_id_;
		}
		
		public void SetOuter_sku_id(string value){
			this.outer_sku_id_ = value;
		}
		public double? GetMarket_price(){
			return this.market_price_;
		}
		
		public void SetMarket_price(double? value){
			this.market_price_ = value;
		}
		public double? GetSell_price(){
			return this.sell_price_;
		}
		
		public void SetSell_price(double? value){
			this.sell_price_ = value;
		}
		public List<vipapis.marketplace.product.SimpleProperty> GetSimple_sale_props(){
			return this.simple_sale_props_;
		}
		
		public void SetSimple_sale_props(List<vipapis.marketplace.product.SimpleProperty> value){
			this.simple_sale_props_ = value;
		}
		
	}
	
}