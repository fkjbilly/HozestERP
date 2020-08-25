using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ProductStock {
		
		///<summary>
		/// 商品ID
		///</summary>
		
		private int? product_id_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 商品销售价格
		///</summary>
		
		private double? sell_price_;
		
		///<summary>
		/// 库存状况，true:有库存；false:没有库存
		///</summary>
		
		private bool? hasStock_;
		
		public int? GetProduct_id(){
			return this.product_id_;
		}
		
		public void SetProduct_id(int? value){
			this.product_id_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public double? GetSell_price(){
			return this.sell_price_;
		}
		
		public void SetSell_price(double? value){
			this.sell_price_ = value;
		}
		public bool? GetHasStock(){
			return this.hasStock_;
		}
		
		public void SetHasStock(bool? value){
			this.hasStock_ = value;
		}
		
	}
	
}