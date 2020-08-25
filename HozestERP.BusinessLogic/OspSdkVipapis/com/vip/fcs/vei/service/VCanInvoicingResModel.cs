using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class VCanInvoicingResModel {
		
		///<summary>
		/// 是否可开具电子发票, true为可开具, false为不可开具
		///</summary>
		
		private bool? canEinvoice_;
		
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
		public com.vip.fcs.vei.service.BaseRetMsg GetRestulMesg(){
			return this.restulMesg_;
		}
		
		public void SetRestulMesg(com.vip.fcs.vei.service.BaseRetMsg value){
			this.restulMesg_ = value;
		}
		
	}
	
}