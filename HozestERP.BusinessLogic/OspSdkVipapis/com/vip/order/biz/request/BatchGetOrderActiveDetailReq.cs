using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class BatchGetOrderActiveDetailReq {
		
		///<summary>
		/// 订单状态范围
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> orderSnAndUserIdList_;
		
		///<summary>
		/// 优惠活动类型查询范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam activeTypeRange_;
		
		///<summary>
		/// 优惠活动维度查询范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam activeFieldRange_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> GetOrderSnAndUserIdList(){
			return this.orderSnAndUserIdList_;
		}
		
		public void SetOrderSnAndUserIdList(List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value){
			this.orderSnAndUserIdList_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetActiveTypeRange(){
			return this.activeTypeRange_;
		}
		
		public void SetActiveTypeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.activeTypeRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetActiveFieldRange(){
			return this.activeFieldRange_;
		}
		
		public void SetActiveFieldRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.activeFieldRange_ = value;
		}
		
	}
	
}