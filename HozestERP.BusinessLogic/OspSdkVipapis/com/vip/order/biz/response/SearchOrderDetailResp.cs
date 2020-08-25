using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class SearchOrderDetailResp {
		
		///<summary>
		/// 
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 订单详情列表
		///</summary>
		
		private List<com.vip.order.biz.response.OrderDetailItem> orderDetailItemList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.OrderDetailItem> GetOrderDetailItemList(){
			return this.orderDetailItemList_;
		}
		
		public void SetOrderDetailItemList(List<com.vip.order.biz.response.OrderDetailItem> value){
			this.orderDetailItemList_ = value;
		}
		
	}
	
}