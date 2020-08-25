using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class EInvoiceInfo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderId_;
		
		///<summary>
		/// 电子发票开票状态(0-未处理,1-正常,2-失败)
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 电子发票-发票代码
		///</summary>
		
		private string eInvoiceCode_;
		
		///<summary>
		/// 电子发票-发票号码
		///</summary>
		
		private string eInvoiceSerialNo_;
		
		///<summary>
		/// 状态描述
		///</summary>
		
		private string msg_;
		
		public string GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(string value){
			this.orderId_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public string GetEInvoiceCode(){
			return this.eInvoiceCode_;
		}
		
		public void SetEInvoiceCode(string value){
			this.eInvoiceCode_ = value;
		}
		public string GetEInvoiceSerialNo(){
			return this.eInvoiceSerialNo_;
		}
		
		public void SetEInvoiceSerialNo(string value){
			this.eInvoiceSerialNo_ = value;
		}
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		
	}
	
}