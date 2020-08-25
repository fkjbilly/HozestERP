using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderLogsResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单日志信息列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderLogsVO> orderLogInfoList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderLogsVO> GetOrderLogInfoList(){
			return this.orderLogInfoList_;
		}
		
		public void SetOrderLogInfoList(List<com.vip.order.common.pojo.order.vo.OrderLogsVO> value){
			this.orderLogInfoList_ = value;
		}
		
	}
	
}