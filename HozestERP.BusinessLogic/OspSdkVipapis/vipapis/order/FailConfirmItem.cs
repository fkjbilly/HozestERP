using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class FailConfirmItem {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 失败原因
		///</summary>
		
		private string failure_msg_;
		
		///<summary>
		/// 失败编码
		///</summary>
		
		private string failure_code_;
		
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
		public string GetFailure_code(){
			return this.failure_code_;
		}
		
		public void SetFailure_code(string value){
			this.failure_code_ = value;
		}
		
	}
	
}