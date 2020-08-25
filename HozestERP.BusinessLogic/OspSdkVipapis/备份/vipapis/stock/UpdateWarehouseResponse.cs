using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class UpdateWarehouseResponse {
		
		///<summary>
		/// transaction_id
		/// @sampleValue transaction_id 
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 处理结果
		/// @sampleValue result_code 
		///</summary>
		
		private string result_code_;
		
		///<summary>
		/// 消息
		/// @sampleValue message 
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