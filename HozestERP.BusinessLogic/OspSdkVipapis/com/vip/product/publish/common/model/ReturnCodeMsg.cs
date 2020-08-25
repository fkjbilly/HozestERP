using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.product.publish.common.model{
	
	
	
	
	
	public class ReturnCodeMsg {
		
		///<summary>
		/// 返回码
		///</summary>
		
		private int? returnCode_;
		
		///<summary>
		/// 错误信息
		///</summary>
		
		private string errorMsg_;
		
		public int? GetReturnCode(){
			return this.returnCode_;
		}
		
		public void SetReturnCode(int? value){
			this.returnCode_ = value;
		}
		public string GetErrorMsg(){
			return this.errorMsg_;
		}
		
		public void SetErrorMsg(string value){
			this.errorMsg_ = value;
		}
		
	}
	
}