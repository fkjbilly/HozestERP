using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class InventoryDeductOrdersResponse {
		
		///<summary>
		/// 拣货单
		///</summary>
		
		private string pick_no_;
		
		///<summary>
		/// 是否有下页 true:有 false:无
		///</summary>
		
		private bool? has_next_;
		
		///<summary>
		/// 订单列表
		///</summary>
		
		private List<vipapis.order.DeductOrder> deductOrders_;
		
		public string GetPick_no(){
			return this.pick_no_;
		}
		
		public void SetPick_no(string value){
			this.pick_no_ = value;
		}
		public bool? GetHas_next(){
			return this.has_next_;
		}
		
		public void SetHas_next(bool? value){
			this.has_next_ = value;
		}
		public List<vipapis.order.DeductOrder> GetDeductOrders(){
			return this.deductOrders_;
		}
		
		public void SetDeductOrders(List<vipapis.order.DeductOrder> value){
			this.deductOrders_ = value;
		}
		
	}
	
}