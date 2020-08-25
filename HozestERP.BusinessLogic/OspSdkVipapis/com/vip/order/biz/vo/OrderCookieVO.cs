using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class OrderCookieVO {
		
		///<summary>
		/// 
		///</summary>
		
		private string phpsessionId_;
		
		///<summary>
		/// 
		///</summary>
		
		private string marsCid_;
		
		public string GetPhpsessionId(){
			return this.phpsessionId_;
		}
		
		public void SetPhpsessionId(string value){
			this.phpsessionId_ = value;
		}
		public string GetMarsCid(){
			return this.marsCid_;
		}
		
		public void SetMarsCid(string value){
			this.marsCid_ = value;
		}
		
	}
	
}