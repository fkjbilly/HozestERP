using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class B2CSupportSendSmsReq {
		
		///<summary>
		/// 手机号码列表
		///</summary>
		
		private List<string> mobiles_;
		
		///<summary>
		/// 短信内容
		///</summary>
		
		private string content_;
		
		public List<string> GetMobiles(){
			return this.mobiles_;
		}
		
		public void SetMobiles(List<string> value){
			this.mobiles_ = value;
		}
		public string GetContent(){
			return this.content_;
		}
		
		public void SetContent(string value){
			this.content_ = value;
		}
		
	}
	
}