using System;
using System.Collections.Generic;
using System.Text;

namespace com.vipshop.cis.sdk.api.datain.si.response{
	
	
	
	
	
	public class SyncVrwIncrInvResponsePayloadItem {
		
		///<summary>
		/// 流水ID,全局唯一,和请求传入的值相同
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 000：成功;非000:失败
		///</summary>
		
		private string result_code_;
		
		///<summary>
		/// result_code时非000时失败的详细信息
		///</summary>
		
		private string message_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetResult_code(){
			return this.result_code_;
		}
		
		public void SetResult_code(string value){
			this.result_code_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}