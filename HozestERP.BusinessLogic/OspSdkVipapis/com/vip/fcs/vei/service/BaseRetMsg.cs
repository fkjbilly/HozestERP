using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class BaseRetMsg {
		
		///<summary>
		/// 状态码
		///</summary>
		
		private string code_;
		
		///<summary>
		/// 具体消息
		///</summary>
		
		private string mesg_;
		
		public string GetCode(){
			return this.code_;
		}
		
		public void SetCode(string value){
			this.code_ = value;
		}
		public string GetMesg(){
			return this.mesg_;
		}
		
		public void SetMesg(string value){
			this.mesg_ = value;
		}
		
	}
	
}