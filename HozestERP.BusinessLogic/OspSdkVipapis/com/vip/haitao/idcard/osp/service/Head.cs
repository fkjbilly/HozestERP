using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.idcard.osp.service{
	
	
	
	
	
	public class Head {
		
		///<summary>
		/// 系统响应时间.符合格式:yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string responseTime_;
		
		///<summary>
		/// 系统响应编码
		///</summary>
		
		private string sysResponseCode_;
		
		///<summary>
		/// 系统响应说明
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