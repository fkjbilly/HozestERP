using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class OrderDetail {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 订单商品明细
		///</summary>
		
		private List<vipapis.marketplace.delivery.OrderProduct> order_products_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public List<vipapis.marketplace.delivery.OrderProduct> GetOrder_products(){
			return this.order_products_;
		}
		
		public void SetOrder_products(List<vipapis.marketplace.delivery.OrderProduct> value){
			this.order_products_ = value;
		}
		
	}
	
}