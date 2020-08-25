using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class Einvoice {
		
		///<summary>
		/// 电子发票链接
		///</summary>
		
		private string e_invoice_url_;
		
		///<summary>
		/// 电子发票-发票代码
		///</summary>
		
		private string e_invoice_code_;
		
		///<summary>
		/// 电子发票-发票号码
		///</summary>
		
		private string e_invoice_serial_no_;
		
		///<summary>
		/// 开票人/公司纳税人识别号/统一社会信用代码
		///</summary>
		
		private string vendor_tax_pay_no_;
		
		///<summary>
		/// 是否取消订单冲红(0-否,1-是)订单开票后，后续客户取消/拒收/客退等导致订单的取消，已开发票需要冲红，此字段回传为1，正常订单开票回传0
		///</summary>
		
		private string is_writeback_;
		
		public string GetE_invoice_url(){
			return this.e_invoice_url_;
		}
		
		public void SetE_invoice_url(string value){
			this.e_invoice_url_ = value;
		}
		public string GetE_invoice_code(){
			return this.e_invoice_code_;
		}
		
		public void SetE_invoice_code(string value){
			this.e_invoice_code_ = value;
		}
		public string GetE_invoice_serial_no(){
			return this.e_invoice_serial_no_;
		}
		
		public void SetE_invoice_serial_no(string value){
			this.e_invoice_serial_no_ = value;
		}
		public string GetVendor_tax_pay_no(){
			return this.vendor_tax_pay_no_;
		}
		
		public void SetVendor_tax_pay_no(string value){
			this.vendor_tax_pay_no_ = value;
		}
		public string GetIs_writeback(){
			return this.is_writeback_;
		}
		
		public void SetIs_writeback(string value){
			this.is_writeback_ = value;
		}
		
	}
	
}