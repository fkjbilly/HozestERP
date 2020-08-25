using System;
using System.Collections.Generic;
using System.Text;

namespace com.vipshop.cis.sdk.api.datain.si.response{
	
	
	
	
	
	public class SyncVrwIncrInvResponsePayload {
		
		///<summary>
		/// 增量同步响应消息体数据列表
		///</summary>
		
		private List<com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItem> data_list_;
		
		public List<com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItem> GetData_list(){
			return this.data_list_;
		}
		
		public void SetData_list(List<com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItem> value){
			this.data_list_ = value;
		}
		
	}
	
}