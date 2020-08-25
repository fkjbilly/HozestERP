using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class InvoiceInfo {
		
		///<summary>
		/// 发票信息, 0:不变，1:不要发票，2:更新发票头
		///</summary>
		
		private int? invoiceFlag_;
		
		///<summary>
		/// 发票头信息
		///</summary>
		
		private string invoiceHeader_;
		
		///<summary>
		/// 发票类型
		///</summary>
		
		private int? invoiceType_;
		
		///<summary>
		/// 纳税人识别号
		///</summary>
		
		private string taxPayerNo_;
		
		public int? GetInvoiceFlag(){
			return this.invoiceFlag_;
		}
		
		public void SetInvoiceFlag(int? value){
			this.invoiceFlag_ = value;
		}
		public string GetInvoiceHeader(){
			return this.invoiceHeader_;
		}
		
		public void SetInvoiceHeader(string value){
			this.invoiceHeader_ = value;
		}
		public int? GetInvoiceType(){
			return this.invoiceType_;
		}
		
		public void SetInvoiceType(int? value){
			this.invoiceType_ = value;
		}
		public string GetTaxPayerNo(){
			return this.taxPayerNo_;
		}
		
		public void SetTaxPayerNo(string value){
			this.taxPayerNo_ = value;
		}
		
	}
	
}