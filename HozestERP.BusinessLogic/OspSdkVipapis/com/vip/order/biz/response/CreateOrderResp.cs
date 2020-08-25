using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class CreateOrderResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.biz.response.Result result_;
		
		///<summary>
		/// 订单号列表
		///</summary>
		
		private List<com.vip.order.biz.vo.CreateOrdersItemVO> orderIdSnList_;
		
		public com.vip.order.biz.response.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.biz.response.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.vo.CreateOrdersItemVO> GetOrderIdSnList(){
			return this.orderIdSnList_;
		}
		
		public void SetOrderIdSnList(List<com.vip.order.biz.vo.CreateOrdersItemVO> value){
			this.orderIdSnList_ = value;
		}
		
	}
	
}