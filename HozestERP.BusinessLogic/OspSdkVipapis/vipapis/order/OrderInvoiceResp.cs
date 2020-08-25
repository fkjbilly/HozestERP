using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderInvoiceResp {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 发票寄送包裹号
		///</summary>
		
		private string package_no_;
		
		///<summary>
		/// 发票抬头
		///</summary>
		
		private string invoice_title_;
		
		///<summary>
		/// 给客户开票金额
		///</summary>
		
		private double? invoice_amount_;
		
		///<summary>
		/// 发票类型:0-不需要开发票;1-纸质个人发票;2-纸质公司发票;3-电子发票;4-电子发票纸质版
		///</summary>
		
		private int? invoice_type_;
		
		///<summary>
		/// 纳税人识别号/统一社会信用代码
		///</summary>
		
		private string tax_pay_no_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetPackage_no(){
			return this.package_no_;
		}
		
		public void SetPackage_no(string value){
			this.package_no_ = value;
		}
		public string GetInvoice_title(){
			return this.invoice_title_;
		}
		
		public void SetInvoice_title(string value){
			this.invoice_title_ = value;
		}
		public double? GetInvoice_amount(){
			return this.invoice_amount_;
		}
		
		public void SetInvoice_amount(double? value){
			this.invoice_amount_ = value;
		}
		public int? GetInvoice_type(){
			return this.invoice_type_;
		}
		
		public void SetInvoice_type(int? value){
			this.invoice_type_ = value;
		}
		public string GetTax_pay_no(){
			return this.tax_pay_no_;
		}
		
		public void SetTax_pay_no(string value){
			this.tax_pay_no_ = value;
		}
		
	}
	
}