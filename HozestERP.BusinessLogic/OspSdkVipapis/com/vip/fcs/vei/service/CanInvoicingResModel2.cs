using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class CanInvoicingResModel2 {
		
		///<summary>
		/// true为可开具电子发票，false为不可开具电子发票
		///</summary>
		
		private bool? canEinvoice_;
		
		///<summary>
		/// true为可开具电子发票打印版，false为不可开具电子发票打印版
		///</summary>
		
		private bool? canEinvoicePrint_;
		
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
		public com.vip.fcs.vei.service.BaseRetMsg GetRestulMesg(){
			return this.restulMesg_;
		}
		
		public void SetRestulMesg(com.vip.fcs.vei.service.BaseRetMsg value){
			this.restulMesg_ = value;
		}
		
	}
	
}