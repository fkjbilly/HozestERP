using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.hermes.core.health{
	
	
	
	
	
	public class Status {
		
		///<summary>
		/// 状态码
		///</summary>
		
		private string code_;
		
		///<summary>
		/// 描述
		///</summary>
		
		private string description_;
		
		public string GetCode(){
			return this.code_;
		}
		
		public void SetCode(string value){
			this.code_ = value;
		}
		public string GetDescription(){
			return this.description_;
		}
		
		public void SetDescription(string value){
			this.description_ = value;
		}
		
	}
	
}