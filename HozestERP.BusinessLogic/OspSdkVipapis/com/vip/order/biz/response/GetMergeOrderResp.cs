using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetMergeOrderResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 主单
		///</summary>
		
		private com.vip.order.biz.response.MergeOrderItem mainOrder_;
		
		///<summary>
		/// 可合并的订单列表
		///</summary>
		
		private List<com.vip.order.biz.response.MergeOrderItem> canMergeOrders_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public com.vip.order.biz.response.MergeOrderItem GetMainOrder(){
			return this.mainOrder_;
		}
		
		public void SetMainOrder(com.vip.order.biz.response.MergeOrderItem value){
			this.mainOrder_ = value;
		}
		public List<com.vip.order.biz.response.MergeOrderItem> GetCanMergeOrders(){
			return this.canMergeOrders_;
		}
		
		public void SetCanMergeOrders(List<com.vip.order.biz.response.MergeOrderItem> value){
			this.canMergeOrders_ = value;
		}
		
	}
	
}