using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class BatchGetOrderActiveDetailResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 查询订单优惠明细结果列表
		///</summary>
		
		private List<com.vip.order.biz.response.OrderActiveDetailResult> detailList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.OrderActiveDetailResult> GetDetailList(){
			return this.detailList_;
		}
		
		public void SetDetailList(List<com.vip.order.biz.response.OrderActiveDetailResult> value){
			this.detailList_ = value;
		}
		
	}
	
}