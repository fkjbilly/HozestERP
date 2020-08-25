using System;
using System.Collections.Generic;
using System.Text;

namespace com.vipshop.cis.sdk.api.datain.si.response{
	
	
	
	
	
	public class SyncVrwIncrInvResponse {
		
		///<summary>
		/// 通用响应Header
		///</summary>
		
		private com.vipshop.cis.sdk.api.datain.si.response.ChannelResponseHeader header_;
		
		///<summary>
		/// 增量同步请求消息体
		///</summary>
		
		private com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayload payload_;
		
		public com.vipshop.cis.sdk.api.datain.si.response.ChannelResponseHeader GetHeader(){
			return this.header_;
		}
		
		public void SetHeader(com.vipshop.cis.sdk.api.datain.si.response.ChannelResponseHeader value){
			this.header_ = value;
		}
		public com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayload GetPayload(){
			return this.payload_;
		}
		
		public void SetPayload(com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayload value){
			this.payload_ = value;
		}
		
	}
	
}