using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class TxGetTokenRequest {
		
		///<summary>
		/// openId
		///</summary>
		
		private string openId_;
		
		///<summary>
		/// 用户ip
		///</summary>
		
		private string userIp_;
		
		public string GetOpenId(){
			return this.openId_;
		}
		
		public void SetOpenId(string value){
			this.openId_ = value;
		}
		public string GetUserIp(){
			return this.userIp_;
		}
		
		public void SetUserIp(string value){
			this.userIp_ = value;
		}
		
	}
	
}