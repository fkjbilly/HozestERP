using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class ConfirmResult {
		
		///<summary>
		/// 返回结果代码，001:成功;<br>201:参数有误;<br>202:接口内部异常;<br>203:验证未通过;
		///</summary>
		
		private string code_;
		
		///<summary>
		/// 返回信息
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