using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class FailItem {
		
		///<summary>
		/// 失败的订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 失败原因
		///</summary>
		
		private string failure_msg_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetFailure_msg(){
			return this.failure_msg_;
		}
		
		public void SetFailure_msg(string value){
			this.failure_msg_ = value;
		}
		
	}
	
}