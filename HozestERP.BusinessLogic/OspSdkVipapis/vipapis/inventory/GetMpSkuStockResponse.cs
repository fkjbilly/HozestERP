using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory{
	
	
	
	
	
	public class GetMpSkuStockResponse {
		
		///<summary>
		/// 查询店铺sku库存
		///</summary>
		
		private List<vipapis.inventory.MpSkuStock> sku_stock_result_;
		
		public List<vipapis.inventory.MpSkuStock> GetSku_stock_result(){
			return this.sku_stock_result_;
		}
		
		public void SetSku_stock_result(List<vipapis.inventory.MpSkuStock> value){
			this.sku_stock_result_ = value;
		}
		
	}
	
}