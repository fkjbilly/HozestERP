using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderListByUserIdResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单信息列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderInfoVO> orderList_;
		
		///<summary>
		/// 父单信息列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.ParentOrderInfoVO> parentOrderList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderInfoVO> GetOrderList(){
			return this.orderList_;
		}
		
		public void SetOrderList(List<com.vip.order.common.pojo.order.vo.OrderInfoVO> value){
			this.orderList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.ParentOrderInfoVO> GetParentOrderList(){
			return this.parentOrderList_;
		}
		
		public void SetParentOrderList(List<com.vip.order.common.pojo.order.vo.ParentOrderInfoVO> value){
			this.parentOrderList_ = value;
		}
		
	}
	
}