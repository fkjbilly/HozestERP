using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class PostOrderVMSMessageReq {
		
		///<summary>
		/// 消息场景
		///</summary>
		
		private string msgScenario_;
		
		///<summary>
		/// 消息类型
		///</summary>
		
		private int? msgType_;
		
		///<summary>
		/// 数据，注意，这个字符串参数的utf-8编码的字节不能超过100KB
		///</summary>
		
		private string msgContent_;
		
		public string GetMsgScenario(){
			return this.msgScenario_;
		}
		
		public void SetMsgScenario(string value){
			this.msgScenario_ = value;
		}
		public int? GetMsgType(){
			return this.msgType_;
		}
		
		public void SetMsgType(int? value){
			this.msgType_ = value;
		}
		public string GetMsgContent(){
			return this.msgContent_;
		}
		
		public void SetMsgContent(string value){
			this.msgContent_ = value;
		}
		
	}
	
}