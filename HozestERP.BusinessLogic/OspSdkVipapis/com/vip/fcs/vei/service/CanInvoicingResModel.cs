using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class CanInvoicingResModel {
		
		///<summary>
		/// true为可开具电子发票，false为不可开具电子发票
		///</summary>
		
		private bool? result_;
		
		///<summary>
		/// 结果消息
		///</summary>
		
		private com.vip.fcs.vei.service.BaseRetMsg restulMesg_;
		
		public bool? GetResult(){
			return this.result_;
		}
		
		public void SetResult(bool? value){
			this.result_ = value;
		}
		public com.vip.fcs.vei.service.BaseRetMsg GetRestulMesg(){
			return this.restulMesg_;
		}
		
		public void SetRestulMesg(com.vip.fcs.vei.service.BaseRetMsg value){
			this.restulMesg_ = value;
		}
		
	}
	
}