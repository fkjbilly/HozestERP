using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class UpdateWarehouseInventoryResult {
		
		///<summary>
		/// 流水号
		/// @sampleValue transaction_id 
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 处理消息
		/// @sampleValue message 
		///</summary>
		
		private string message_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}