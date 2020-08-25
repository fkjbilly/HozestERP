using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtSaleOrderCancellationResult {
		
		///<summary>
		/// 请求头
		///</summary>
		
		private com.vip.haitao.orderservice.service.Head head_;
		
		///<summary>
		/// 取消单列表
		///</summary>
		
		private List<com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModel> cancelledSaleOrderList_;
		
		public com.vip.haitao.orderservice.service.Head GetHead(){
			return this.head_;
		}
		
		public void SetHead(com.vip.haitao.orderservice.service.Head value){
			this.head_ = value;
		}
		public List<com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModel> GetCancelledSaleOrderList(){
			return this.cancelledSaleOrderList_;
		}
		
		public void SetCancelledSaleOrderList(List<com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModel> value){
			this.cancelledSaleOrderList_ = value;
		}
		
	}
	
}