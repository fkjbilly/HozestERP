using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class GetOxoShopOrderForPopResponse {
		
		///<summary>
		/// 直发门店订单信息列表
		///</summary>
		
		private List<vipapis.stock.OxoShopOrderForPopList> oxo_shop_order_for_pop_list_;
		
		public List<vipapis.stock.OxoShopOrderForPopList> GetOxo_shop_order_for_pop_list(){
			return this.oxo_shop_order_for_pop_list_;
		}
		
		public void SetOxo_shop_order_for_pop_list(List<vipapis.stock.OxoShopOrderForPopList> value){
			this.oxo_shop_order_for_pop_list_ = value;
		}
		
	}
	
}