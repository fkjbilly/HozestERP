using System;
using System.Collections.Generic;
using System.Text;

namespace com.vipshop.cis.sdk.api.datain.si.request{
	
	
	
	
	
	public class SyncVrwIncrInvRequestPayload {
		
		///<summary>
		/// 增量同步请求消息体数据列表
		///</summary>
		
		private List<com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItem> data_list_;
		
		public List<com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItem> GetData_list(){
			return this.data_list_;
		}
		
		public void SetData_list(List<com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItem> value){
			this.data_list_ = value;
		}
		
	}
	
}