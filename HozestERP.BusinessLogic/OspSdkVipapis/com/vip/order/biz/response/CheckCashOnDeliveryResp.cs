using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class CheckCashOnDeliveryResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 结果: 0:不支持货到付款,1:支持货到付款
		///</summary>
		
		private int? isCod_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public int? GetIsCod(){
			return this.isCod_;
		}
		
		public void SetIsCod(int? value){
			this.isCod_ = value;
		}
		
	}
	
}