using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.inventory{
	
	
	
	
	
	public class SkuStock {
		
		///<summary>
		/// 商品sku
		///</summary>
		
		private string sku_id_;
		
		///<summary>
		/// 剩余库存
		///</summary>
		
		private int? leaving_stock_;
		
		///<summary>
		/// 购物车占用
		///</summary>
		
		private int? cart_hold_;
		
		///<summary>
		/// 订单占用
		///</summary>
		
		private int? order_hold_;
		
		///<summary>
		/// 仓库编号
		///</summary>
		
		private string warehouse_;
		
		public string GetSku_id(){
			return this.sku_id_;
		}
		
		public void SetSku_id(string value){
			this.sku_id_ = value;
		}
		public int? GetLeaving_stock(){
			return this.leaving_stock_;
		}
		
		public void SetLeaving_stock(int? value){
			this.leaving_stock_ = value;
		}
		public int? GetCart_hold(){
			return this.cart_hold_;
		}
		
		public void SetCart_hold(int? value){
			this.cart_hold_ = value;
		}
		public int? GetOrder_hold(){
			return this.order_hold_;
		}
		
		public void SetOrder_hold(int? value){
			this.order_hold_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		
	}
	
}