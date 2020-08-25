using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GroupByOrderAuditResult {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 操作状态
		///</summary>
		
		private bool? status_;
		
		///<summary>
		/// 说明
		///</summary>
		
		private string message_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public bool? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(bool? value){
			this.status_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}