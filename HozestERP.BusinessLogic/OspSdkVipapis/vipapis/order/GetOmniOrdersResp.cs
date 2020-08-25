using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class GetOmniOrdersResp {
		
		///<summary>
		/// 是否有下一页
		///</summary>
		
		private bool? has_next_;
		
		///<summary>
		/// 订单列表
		///</summary>
		
		private List<vipapis.order.OmniOrder> oxo_orders_;
		
		public bool? GetHas_next(){
			return this.has_next_;
		}
		
		public void SetHas_next(bool? value){
			this.has_next_ = value;
		}
		public List<vipapis.order.OmniOrder> GetOxo_orders(){
			return this.oxo_orders_;
		}
		
		public void SetOxo_orders(List<vipapis.order.OmniOrder> value){
			this.oxo_orders_ = value;
		}
		
	}
	
}