using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class ExternalInvoiceHandleStateResModel {
		
		///<summary>
		/// 发票状态
		///</summary>
		
		private List<com.vip.fcs.vei.service.ExternalInvoiceHandleState> externalInvoiceHandleStateList_;
		
		///<summary>
		/// 响应状态
		///</summary>
		
		private com.vip.fcs.vei.service.BaseRetMsg retMsg_;
		
		public List<com.vip.fcs.vei.service.ExternalInvoiceHandleState> GetExternalInvoiceHandleStateList(){
			return this.externalInvoiceHandleStateList_;
		}
		
		public void SetExternalInvoiceHandleStateList(List<com.vip.fcs.vei.service.ExternalInvoiceHandleState> value){
			this.externalInvoiceHandleStateList_ = value;
		}
		public com.vip.fcs.vei.service.BaseRetMsg GetRetMsg(){
			return this.retMsg_;
		}
		
		public void SetRetMsg(com.vip.fcs.vei.service.BaseRetMsg value){
			this.retMsg_ = value;
		}
		
	}
	
}