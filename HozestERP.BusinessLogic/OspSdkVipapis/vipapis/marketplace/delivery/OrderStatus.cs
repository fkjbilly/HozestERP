using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class OrderStatus {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 返回的状态码： 10:订单已审核, 22:订单已发货, 25:已签收, , 70:已拒收, 97:订单已取消
		///</summary>
		
		private string order_status_;
		
		///<summary>
		/// 是否已导出,1：已经导出；0：未导出
		///</summary>
		
		private string is_export_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(string value){
			this.order_status_ = value;
		}
		public string GetIs_export(){
			return this.is_export_;
		}
		
		public void SetIs_export(string value){
			this.is_export_ = value;
		}
		
	}
	
}