using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class InvoiceOrderDataResModel {
		
		///<summary>
		/// true为提交成功，false为提交失败
		///</summary>
		
		private bool? result_;
		
		///<summary>
		/// 结果消息
		///</summary>
		
		private com.vip.fcs.vei.service.BaseRetMsg resultMesg_;
		
		public bool? GetResult(){
			return this.result_;
		}
		
		public void SetResult(bool? value){
			this.result_ = value;
		}
		public com.vip.fcs.vei.service.BaseRetMsg GetResultMesg(){
			return this.resultMesg_;
		}
		
		public void SetResultMesg(com.vip.fcs.vei.service.BaseRetMsg value){
			this.resultMesg_ = value;
		}
		
	}
	
}