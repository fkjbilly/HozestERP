using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class SearchOrderLogsReq {
		
		///<summary>
		/// 订单列表。OrderVO只需要使用userId/orderSn/orderId三个属性作为入参
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderVO> orderList_;
		
		///<summary>
		/// 日志操作用户名
		///</summary>
		
		private List<string> userNameList_;
		
		///<summary>
		/// 操作类型id列表
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam operateTypeRange_;
		
		///<summary>
		/// 查找时间
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam dateRange_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderVO> GetOrderList(){
			return this.orderList_;
		}
		
		public void SetOrderList(List<com.vip.order.common.pojo.order.vo.OrderVO> value){
			this.orderList_ = value;
		}
		public List<string> GetUserNameList(){
			return this.userNameList_;
		}
		
		public void SetUserNameList(List<string> value){
			this.userNameList_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOperateTypeRange(){
			return this.operateTypeRange_;
		}
		
		public void SetOperateTypeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.operateTypeRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetDateRange(){
			return this.dateRange_;
		}
		
		public void SetDateRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.dateRange_ = value;
		}
		
	}
	
}