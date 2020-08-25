using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class DoubleSvipToken {
		
		///<summary>
		///</summary>
		
		private string accessToken_;
		
		///<summary>
		///</summary>
		
		private string svipToken_;
		
		///<summary>
		/// token过期时间 yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string expireTime_;
		
		public string GetAccessToken(){
			return this.accessToken_;
		}
		
		public void SetAccessToken(string value){
			this.accessToken_ = value;
		}
		public string GetSvipToken(){
			return this.svipToken_;
		}
		
		public void SetSvipToken(string value){
			this.svipToken_ = value;
		}
		public string GetExpireTime(){
			return this.expireTime_;
		}
		
		public void SetExpireTime(string value){
			this.expireTime_ = value;
		}
		
	}
	
}