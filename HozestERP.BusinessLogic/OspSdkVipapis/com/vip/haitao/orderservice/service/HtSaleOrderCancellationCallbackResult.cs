using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtSaleOrderCancellationCallbackResult {
		
		///<summary>
		/// 请求头
		///</summary>
		
		private com.vip.haitao.orderservice.service.Head head_;
		
		///<summary>
		/// 成功释放库存订单状态列表
		///</summary>
		
		private List<com.vip.haitao.orderservice.service.CancelledOrder> orders_;
		
		public com.vip.haitao.orderservice.service.Head GetHead(){
			return this.head_;
		}
		
		public void SetHead(com.vip.haitao.orderservice.service.Head value){
			this.head_ = value;
		}
		public List<com.vip.haitao.orderservice.service.CancelledOrder> GetOrders(){
			return this.orders_;
		}
		
		public void SetOrders(List<com.vip.haitao.orderservice.service.CancelledOrder> value){
			this.orders_ = value;
		}
		
	}
	
}