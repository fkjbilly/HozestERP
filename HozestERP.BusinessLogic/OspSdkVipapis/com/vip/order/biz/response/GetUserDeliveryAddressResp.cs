using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetUserDeliveryAddressResp {
		
		///<summary>
		/// 
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 收货地址
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO> orderReceiveAddrList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO> GetOrderReceiveAddrList(){
			return this.orderReceiveAddrList_;
		}
		
		public void SetOrderReceiveAddrList(List<com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO> value){
			this.orderReceiveAddrList_ = value;
		}
		
	}
	
}