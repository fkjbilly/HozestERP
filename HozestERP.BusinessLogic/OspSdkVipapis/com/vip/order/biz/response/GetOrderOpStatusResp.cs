using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderOpStatusResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 可操作状态列表
		///</summary>
		
		private List<com.vip.order.biz.response.OrderOpStatus> orderOpList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.OrderOpStatus> GetOrderOpList(){
			return this.orderOpList_;
		}
		
		public void SetOrderOpList(List<com.vip.order.biz.response.OrderOpStatus> value){
			this.orderOpList_ = value;
		}
		
	}
	
}