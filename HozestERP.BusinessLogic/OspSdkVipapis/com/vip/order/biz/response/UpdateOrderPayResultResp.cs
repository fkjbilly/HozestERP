using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class UpdateOrderPayResultResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单支付结果通知处理结果列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.NotifyResponseOrderVO> orderList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.NotifyResponseOrderVO> GetOrderList(){
			return this.orderList_;
		}
		
		public void SetOrderList(List<com.vip.order.common.pojo.order.vo.NotifyResponseOrderVO> value){
			this.orderList_ = value;
		}
		
	}
	
}