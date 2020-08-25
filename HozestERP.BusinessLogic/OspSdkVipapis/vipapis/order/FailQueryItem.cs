using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class FailQueryItem {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 发票类型:0-不需要开发票;1-纸质个人发票;2-纸质公司发票;3-电子发票;4-电子发票纸质版
		///</summary>
		
		private int? invoice_type_;
		
		///<summary>
		/// 错误信息
		///</summary>
		
		private string failure_msg_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public int? GetInvoice_type(){
			return this.invoice_type_;
		}
		
		public void SetInvoice_type(int? value){
			this.invoice_type_ = value;
		}
		public string GetFailure_msg(){
			return this.failure_msg_;
		}
		
		public void SetFailure_msg(string value){
			this.failure_msg_ = value;
		}
		
	}
	
}