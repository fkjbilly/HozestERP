using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetPrepayOrderUnpayMsgResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 尾单支付提醒消息
		///</summary>
		
		private List<com.vip.order.biz.response.PrepayOrderUnpayMsg> msgList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.PrepayOrderUnpayMsg> GetMsgList(){
			return this.msgList_;
		}
		
		public void SetMsgList(List<com.vip.order.biz.response.PrepayOrderUnpayMsg> value){
			this.msgList_ = value;
		}
		
	}
	
}