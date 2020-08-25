using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetCanAfterSaleOrderListResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单数据
		///</summary>
		
		private List<com.vip.order.biz.response.CanAfterSaleOrderInfo> canAfterSaleOrderInfoList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.CanAfterSaleOrderInfo> GetCanAfterSaleOrderInfoList(){
			return this.canAfterSaleOrderInfoList_;
		}
		
		public void SetCanAfterSaleOrderInfoList(List<com.vip.order.biz.response.CanAfterSaleOrderInfo> value){
			this.canAfterSaleOrderInfoList_ = value;
		}
		
	}
	
}