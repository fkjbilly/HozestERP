using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class InvoiceConfirmResp {
		
		///<summary>
		/// 状态码（0成功，其它：失败）
		///</summary>
		
		private string code_;
		
		///<summary>
		/// 错误信息
		///</summary>
		
		private string msg_;
		
		public string GetCode(){
			return this.code_;
		}
		
		public void SetCode(string value){
			this.code_ = value;
		}
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		
	}
	
}