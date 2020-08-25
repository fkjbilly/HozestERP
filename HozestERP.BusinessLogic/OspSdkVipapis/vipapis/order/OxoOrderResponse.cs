using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OxoOrderResponse {
		
		///<summary>
		/// 是否有下页 true:有 false:无
		///</summary>
		
		private bool? has_next_;
		
		///<summary>
		/// 商品订单列表
		///</summary>
		
		private List<vipapis.order.OxoOrder> oxo_orders_;
		
		public bool? GetHas_next(){
			return this.has_next_;
		}
		
		public void SetHas_next(bool? value){
			this.has_next_ = value;
		}
		public List<vipapis.order.OxoOrder> GetOxo_orders(){
			return this.oxo_orders_;
		}
		
		public void SetOxo_orders(List<vipapis.order.OxoOrder> value){
			this.oxo_orders_ = value;
		}
		
	}
	
}