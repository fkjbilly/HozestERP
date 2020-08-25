using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetCanRefundOrderListReq {
		
		///<summary>
		/// 订单SN列表
		///</summary>
		
		private List<string> orderSnSet_;
		
		///<summary>
		/// 用户ID列表
		///</summary>
		
		private List<long?> userIdSet_;
		
		///<summary>
		/// 用户ID列表
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderTimeRange_;
		
		///<summary>
		/// 查询结果要求
		///</summary>
		
		private com.vip.order.biz.request.ResultRequirementMap requirement_;
		
		public List<string> GetOrderSnSet(){
			return this.orderSnSet_;
		}
		
		public void SetOrderSnSet(List<string> value){
			this.orderSnSet_ = value;
		}
		public List<long?> GetUserIdSet(){
			return this.userIdSet_;
		}
		
		public void SetUserIdSet(List<long?> value){
			this.userIdSet_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderTimeRange(){
			return this.orderTimeRange_;
		}
		
		public void SetOrderTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderTimeRange_ = value;
		}
		public com.vip.order.biz.request.ResultRequirementMap GetRequirement(){
			return this.requirement_;
		}
		
		public void SetRequirement(com.vip.order.biz.request.ResultRequirementMap value){
			this.requirement_ = value;
		}
		
	}
	
}