using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderInstalmentsListResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单分期付款列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderInstalmentVO> orderInstalmentList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderInstalmentVO> GetOrderInstalmentList(){
			return this.orderInstalmentList_;
		}
		
		public void SetOrderInstalmentList(List<com.vip.order.common.pojo.order.vo.OrderInstalmentVO> value){
			this.orderInstalmentList_ = value;
		}
		
	}
	
}