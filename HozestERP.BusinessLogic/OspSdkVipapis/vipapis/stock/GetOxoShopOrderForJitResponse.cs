using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class GetOxoShopOrderForJitResponse {
		
		///<summary>
		/// JIT门店订单信息列表
		///</summary>
		
		private List<vipapis.stock.OxoShopOrderForJitList> oxo_shop_order_for_jit_list_;
		
		public List<vipapis.stock.OxoShopOrderForJitList> GetOxo_shop_order_for_jit_list(){
			return this.oxo_shop_order_for_jit_list_;
		}
		
		public void SetOxo_shop_order_for_jit_list(List<vipapis.stock.OxoShopOrderForJitList> value){
			this.oxo_shop_order_for_jit_list_ = value;
		}
		
	}
	
}