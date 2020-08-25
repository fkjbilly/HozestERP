using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.inventory{
	
	
	
	
	
	public class GetSkuStockRequest {
		
		///<summary>
		/// 商品skuID，对应prodSkuId
		///</summary>
		
		private string sku_id_;
		
		public string GetSku_id(){
			return this.sku_id_;
		}
		
		public void SetSku_id(string value){
			this.sku_id_ = value;
		}
		
	}
	
}