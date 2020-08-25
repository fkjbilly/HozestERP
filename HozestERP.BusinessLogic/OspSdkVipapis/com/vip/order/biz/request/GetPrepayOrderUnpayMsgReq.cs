using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetPrepayOrderUnpayMsgReq {
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		
	}
	
}