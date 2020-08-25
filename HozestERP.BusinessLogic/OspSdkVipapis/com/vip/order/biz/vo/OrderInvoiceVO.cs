using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class OrderInvoiceVO {
		
		///<summary>
		/// 发票类型
		///</summary>
		
		private int? invoiceType_;
		
		///<summary>
		/// 发票抬头
		///</summary>
		
		private string invoice_;
		
		///<summary>
		/// 在线支付总金额
		///</summary>
		
		private string payMoney_;
		
		///<summary>
		/// 在线支付不可开发票的金额
		///</summary>
		
		private string invoiceDeductMoney_;
		
		///<summary>
		/// 支付时间
		///</summary>
		
		private long? payTime_;
		
		///<summary>
		/// 不可开发票明细
		///</summary>
		
		private string detail_;
		
		public int? GetInvoiceType(){
			return this.invoiceType_;
		}
		
		public void SetInvoiceType(int? value){
			this.invoiceType_ = value;
		}
		public string GetInvoice(){
			return this.invoice_;
		}
		
		public void SetInvoice(string value){
			this.invoice_ = value;
		}
		public string GetPayMoney(){
			return this.payMoney_;
		}
		
		public void SetPayMoney(string value){
			this.payMoney_ = value;
		}
		public string GetInvoiceDeductMoney(){
			return this.invoiceDeductMoney_;
		}
		
		public void SetInvoiceDeductMoney(string value){
			this.invoiceDeductMoney_ = value;
		}
		public long? GetPayTime(){
			return this.payTime_;
		}
		
		public void SetPayTime(long? value){
			this.payTime_ = value;
		}
		public string GetDetail(){
			return this.detail_;
		}
		
		public void SetDetail(string value){
			this.detail_ = value;
		}
		
	}
	
}