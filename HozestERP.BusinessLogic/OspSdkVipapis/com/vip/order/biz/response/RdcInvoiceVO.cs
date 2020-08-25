using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class RdcInvoiceVO {
		
		///<summary>
		/// orderSn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 发票jsonStrign
		///</summary>
		
		private string invoiceInfo_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetInvoiceInfo(){
			return this.invoiceInfo_;
		}
		
		public void SetInvoiceInfo(string value){
			this.invoiceInfo_ = value;
		}
		
	}
	
}