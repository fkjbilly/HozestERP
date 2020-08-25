using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderListByPosNoResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 根据posNo查询订单列表
		///</summary>
		
		private Dictionary<string, List<com.vip.order.common.pojo.order.vo.OrderByPosVO>> orderPosMap_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public Dictionary<string, List<com.vip.order.common.pojo.order.vo.OrderByPosVO>> GetOrderPosMap(){
			return this.orderPosMap_;
		}
		
		public void SetOrderPosMap(Dictionary<string, List<com.vip.order.common.pojo.order.vo.OrderByPosVO>> value){
			this.orderPosMap_ = value;
		}
		
	}
	
}