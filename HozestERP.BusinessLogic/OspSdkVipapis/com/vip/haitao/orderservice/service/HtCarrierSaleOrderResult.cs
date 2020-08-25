using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtCarrierSaleOrderResult {
		
		///<summary>
		/// 请求头
		///</summary>
		
		private com.vip.haitao.orderservice.service.Head head_;
		
		///<summary>
		/// 销售订单列表
		///</summary>
		
		private List<com.vip.haitao.orderservice.service.HtSaleOrderChbResult> saleOrderList_;
		
		public com.vip.haitao.orderservice.service.Head GetHead(){
			return this.head_;
		}
		
		public void SetHead(com.vip.haitao.orderservice.service.Head value){
			this.head_ = value;
		}
		public List<com.vip.haitao.orderservice.service.HtSaleOrderChbResult> GetSaleOrderList(){
			return this.saleOrderList_;
		}
		
		public void SetSaleOrderList(List<com.vip.haitao.orderservice.service.HtSaleOrderChbResult> value){
			this.saleOrderList_ = value;
		}
		
	}
	
}