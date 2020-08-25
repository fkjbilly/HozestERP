using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrderPayTypeResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单支付类型信息列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrdersPayTypeVO> ordersPayTypeList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrdersPayTypeVO> GetOrdersPayTypeList(){
			return this.ordersPayTypeList_;
		}
		
		public void SetOrdersPayTypeList(List<com.vip.order.common.pojo.order.vo.OrdersPayTypeVO> value){
			this.ordersPayTypeList_ = value;
		}
		
	}
	
}