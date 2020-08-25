using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class PutIntoSplitQueueResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 交易流水号操作结果日志
		///</summary>
		
		private List<com.vip.order.biz.response.OrderResult> orderResultList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.OrderResult> GetOrderResultList(){
			return this.orderResultList_;
		}
		
		public void SetOrderResultList(List<com.vip.order.biz.response.OrderResult> value){
			this.orderResultList_ = value;
		}
		
	}
	
}