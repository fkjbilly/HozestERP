using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderSnByExOrderSnResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 第三方订单列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderCoopResultVO> orderCoopList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderCoopResultVO> GetOrderCoopList(){
			return this.orderCoopList_;
		}
		
		public void SetOrderCoopList(List<com.vip.order.common.pojo.order.vo.OrderCoopResultVO> value){
			this.orderCoopList_ = value;
		}
		
	}
	
}