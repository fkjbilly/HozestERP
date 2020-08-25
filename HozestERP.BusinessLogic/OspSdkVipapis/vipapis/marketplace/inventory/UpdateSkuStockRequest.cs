using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.inventory{
	
	
	
	
	
	public class UpdateSkuStockRequest {
		
		///<summary>
		/// 商品skuID，对应prodSkuId
		///</summary>
		
		private string sku_id_;
		
		///<summary>
		/// 商品库存数量
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		public string GetSku_id(){
			return this.sku_id_;
		}
		
		public void SetSku_id(string value){
			this.sku_id_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		
	}
	
}