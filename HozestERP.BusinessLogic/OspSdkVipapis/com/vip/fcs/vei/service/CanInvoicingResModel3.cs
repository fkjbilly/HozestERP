using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class CanInvoicingResModel3 {
		
		///<summary>
		/// true为可开具电子发票，false为不可开具电子发票
		///</summary>
		
		private bool? canEinvoice_;
		
		///<summary>
		/// true为可开具电子发票打印版，false为不可开具电子发票打印版
		///</summary>
		
		private bool? canEinvoicePrint_;
		
		///<summary>
		/// true为可开具纸质发票，false为不可开具纸质发票
		///</summary>
		
		private bool? canPaperInvoice_;
		
		///<summary>
		/// 默认显示的发票选项
		///</summary>
		
		private int? defaultInvoiceType_;
		
		///<summary>
		/// 结果消息
		///</summary>
		
		private com.vip.fcs.vei.service.BaseRetMsg restulMesg_;
		
		public bool? GetCanEinvoice(){
			return this.canEinvoice_;
		}
		
		public void SetCanEinvoice(bool? value){
			this.canEinvoice_ = value;
		}
		public bool? GetCanEinvoicePrint(){
			return this.canEinvoicePrint_;
		}
		
		public void SetCanEinvoicePrint(bool? value){
			this.canEinvoicePrint_ = value;
		}
		public bool? GetCanPaperInvoice(){
			return this.canPaperInvoice_;
		}
		
		public void SetCanPaperInvoice(bool? value){
			this.canPaperInvoice_ = value;
		}
		public int? GetDefaultInvoiceType(){
			return this.defaultInvoiceType_;
		}
		
		public void SetDefaultInvoiceType(int? value){
			this.defaultInvoiceType_ = value;
		}
		public com.vip.fcs.vei.service.BaseRetMsg GetRestulMesg(){
			return this.restulMesg_;
		}
		
		public void SetRestulMesg(com.vip.fcs.vei.service.BaseRetMsg value){
			this.restulMesg_ = value;
		}
		
	}
	
}