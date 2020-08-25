using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class AddOrderTransportReq {
		
		///<summary>
		/// 用户Id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 物流详情
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderTransportDetailVO orderTransportDetailVO_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderTransportDetailVO GetOrderTransportDetailVO(){
			return this.orderTransportDetailVO_;
		}
		
		public void SetOrderTransportDetailVO(com.vip.order.common.pojo.order.vo.OrderTransportDetailVO value){
			this.orderTransportDetailVO_ = value;
		}
		
	}
	
}