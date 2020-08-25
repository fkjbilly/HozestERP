using System;
using System.Collections.Generic;
using System.Text;

namespace com.vipshop.cis.sdk.api.datain.si.response{
	
	
	
	
	
	public class ChannelResponseHeader {
		
		///<summary>
		/// 0: 成功; 4: 警告,暂时未有警告类型; 8 错误
		///</summary>
		
		private int? response_code_;
		
		///<summary>
		/// 000：成功;非000:失败
		///</summary>
		
		private string result_code_;
		
		///<summary>
		/// 详细信息描述
		///</summary>
		
		private string message_;
		
		///<summary>
		/// 本地扩展,和request中传入的一样
		///</summary>
		
		private Dictionary<string, string> local_area_;
		
		///<summary>
		/// trace id
		///</summary>
		
		private string trace_id_;
		
		public int? GetResponse_code(){
			return this.response_code_;
		}
		
		public void SetResponse_code(int? value){
			this.response_code_ = value;
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
		public Dictionary<string, string> GetLocal_area(){
			return this.local_area_;
		}
		
		public void SetLocal_area(Dictionary<string, string> value){
			this.local_area_ = value;
		}
		public string GetTrace_id(){
			return this.trace_id_;
		}
		
		public void SetTrace_id(string value){
			this.trace_id_ = value;
		}
		
	}
	
}