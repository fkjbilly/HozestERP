using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class OccupiedOrderResponse {
		
		///<summary>
		/// 商品订单列表
		///</summary>
		
		private List<vipapis.normal.OccupiedOrder> occupied_orders_;
		
		///<summary>
		/// 是否有下页 true:有 false:无
		///</summary>
		
		private bool? has_next_;
		
		public List<vipapis.normal.OccupiedOrder> GetOccupied_orders(){
			return this.occupied_orders_;
		}
		
		public void SetOccupied_orders(List<vipapis.normal.OccupiedOrder> value){
			this.occupied_orders_ = value;
		}
		public bool? GetHas_next(){
			return this.has_next_;
		}
		
		public void SetHas_next(bool? value){
			this.has_next_ = value;
		}
		
	}
	
}