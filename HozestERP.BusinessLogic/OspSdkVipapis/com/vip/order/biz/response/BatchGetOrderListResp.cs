using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class BatchGetOrderListResp {
		
		///<summary>
		/// 
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderInfoVO> orderInfoList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderInfoVO> GetOrderInfoList(){
			return this.orderInfoList_;
		}
		
		public void SetOrderInfoList(List<com.vip.order.common.pojo.order.vo.OrderInfoVO> value){
			this.orderInfoList_ = value;
		}
		
	}
	
}