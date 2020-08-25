using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class Head {
		
		///<summary>
		/// 返回时间
		///</summary>
		
		private string responseTime_;
		
		///<summary>
		/// 返回状态码
		///</summary>
		
		private string sysResponseCode_;
		
		///<summary>
		/// 返回信息
		///</summary>
		
		private string sysResponseMsg_;
		
		public string GetResponseTime(){
			return this.responseTime_;
		}
		
		public void SetResponseTime(string value){
			this.responseTime_ = value;
		}
		public string GetSysResponseCode(){
			return this.sysResponseCode_;
		}
		
		public void SetSysResponseCode(string value){
			this.sysResponseCode_ = value;
		}
		public string GetSysResponseMsg(){
			return this.sysResponseMsg_;
		}
		
		public void SetSysResponseMsg(string value){
			this.sysResponseMsg_ = value;
		}
		
	}
	
}