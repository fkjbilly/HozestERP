using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.inventory{
	
	
	
	
	
	public class GetSkuStockResponse {
		
		///<summary>
		/// 查询店铺sku库存
		///</summary>
		
		private List<vipapis.marketplace.inventory.SkuStock> sku_stocks_;
		
		public List<vipapis.marketplace.inventory.SkuStock> GetSku_stocks(){
			return this.sku_stocks_;
		}
		
		public void SetSku_stocks(List<vipapis.marketplace.inventory.SkuStock> value){
			this.sku_stocks_ = value;
		}
		
	}
	
}