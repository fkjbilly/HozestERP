using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class Result {
		
		///<summary>
		/// 消息码，200为处理成功。
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 消息
		///</summary>
		
		private string message_;
		
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}