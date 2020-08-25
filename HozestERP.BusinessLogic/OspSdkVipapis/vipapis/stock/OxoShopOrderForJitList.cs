using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class OxoShopOrderForJitList {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 订单明细结构体
		///</summary>
		
		private List<vipapis.stock.OxoOrderGoodsJitList> oxo_order_goods_jit_list_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public List<vipapis.stock.OxoOrderGoodsJitList> GetOxo_order_goods_jit_list(){
			return this.oxo_order_goods_jit_list_;
		}
		
		public void SetOxo_order_goods_jit_list(List<vipapis.stock.OxoOrderGoodsJitList> value){
			this.oxo_order_goods_jit_list_ = value;
		}
		
	}
	
}