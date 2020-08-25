using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class PutKeyToRollbackQueueReq {
		
		///<summary>
		/// uniqueKey列表 
		///</summary>
		
		private List<string> keySet_;
		
		public List<string> GetKeySet(){
			return this.keySet_;
		}
		
		public void SetKeySet(List<string> value){
			this.keySet_ = value;
		}
		
	}
	
}