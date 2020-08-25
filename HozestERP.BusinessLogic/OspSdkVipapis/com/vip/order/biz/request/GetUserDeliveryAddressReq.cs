using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetUserDeliveryAddressReq {
		
		///<summary>
		/// 用户id列
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单状态order_status
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam statusRange_;
		
		///<summary>
		/// 下单日期(order_date)
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderDateRange_;
		
		///<summary>
		/// 下单时间段(add_time)
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderTimeRange_;
		
		///<summary>
		/// 订单记录数
		///</summary>
		
		private int? orderLimit_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetStatusRange(){
			return this.statusRange_;
		}
		
		public void SetStatusRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.statusRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderDateRange(){
			return this.orderDateRange_;
		}
		
		public void SetOrderDateRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderDateRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderTimeRange(){
			return this.orderTimeRange_;
		}
		
		public void SetOrderTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderTimeRange_ = value;
		}
		public int? GetOrderLimit(){
			return this.orderLimit_;
		}
		
		public void SetOrderLimit(int? value){
			this.orderLimit_ = value;
		}
		
	}
	
}