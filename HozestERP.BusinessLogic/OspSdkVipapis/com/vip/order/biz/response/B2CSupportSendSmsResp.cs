using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class B2CSupportSendSmsResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 发送成功的号码列表，仅代表调用mmp成功
		///</summary>
		
		private List<string> successMobiles_;
		
		///<summary>
		/// 发送失败的号码列表，仅代表调用mmp得不到正确的响应
		///</summary>
		
		private List<string> failMobiles_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<string> GetSuccessMobiles(){
			return this.successMobiles_;
		}
		
		public void SetSuccessMobiles(List<string> value){
			this.successMobiles_ = value;
		}
		public List<string> GetFailMobiles(){
			return this.failMobiles_;
		}
		
		public void SetFailMobiles(List<string> value){
			this.failMobiles_ = value;
		}
		
	}
	
}