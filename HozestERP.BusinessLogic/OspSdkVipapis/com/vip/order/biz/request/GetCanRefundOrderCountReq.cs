using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetCanRefundOrderCountReq {
		
		///<summary>
		/// 订单SN列表
		///</summary>
		
		private List<string> orderSnSet_;
		
		///<summary>
		/// 用户ID列表
		///</summary>
		
		private List<long?> userIdSet_;
		
		///<summary>
		/// 下单时间段
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderTimeRange_;
		
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
		
	}
	
}