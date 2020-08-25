using System;
using System.Collections.Generic;
using System.Text;

namespace com.vipshop.cis.sdk.api.datain.si.request{
	
	
	
	
	
	public class SyncVrwIncrInvRequest {
		
		///<summary>
		/// 通用请求Header
		///</summary>
		
		private com.vipshop.cis.sdk.api.datain.si.request.ChannelRequestHeader header_;
		
		///<summary>
		/// 增量同步请求消息体
		///</summary>
		
		private com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayload payload_;
		
		public com.vipshop.cis.sdk.api.datain.si.request.ChannelRequestHeader GetHeader(){
			return this.header_;
		}
		
		public void SetHeader(com.vipshop.cis.sdk.api.datain.si.request.ChannelRequestHeader value){
			this.header_ = value;
		}
		public com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayload GetPayload(){
			return this.payload_;
		}
		
		public void SetPayload(com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayload value){
			this.payload_ = value;
		}
		
	}
	
}