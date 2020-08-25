using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class SaleOrders {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 订单出库时间
		///</summary>
		
		private string out_time_;
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private List<vipapis.overseas.SaleOrderInfo> order_list_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetOut_time(){
			return this.out_time_;
		}
		
		public void SetOut_time(string value){
			this.out_time_ = value;
		}
		public List<vipapis.overseas.SaleOrderInfo> GetOrder_list(){
			return this.order_list_;
		}
		
		public void SetOrder_list(List<vipapis.overseas.SaleOrderInfo> value){
			this.order_list_ = value;
		}
		
	}
	
}