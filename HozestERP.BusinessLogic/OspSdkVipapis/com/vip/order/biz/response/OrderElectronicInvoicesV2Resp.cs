using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class OrderElectronicInvoicesV2Resp {
		
		///<summary>
		/// 
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 发票列表
		///</summary>
		
		private List<com.vip.order.biz.response.OrderElectronicInvoiceDetailV2Resp> orderElectronicInvoiceList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.OrderElectronicInvoiceDetailV2Resp> GetOrderElectronicInvoiceList(){
			return this.orderElectronicInvoiceList_;
		}
		
		public void SetOrderElectronicInvoiceList(List<com.vip.order.biz.response.OrderElectronicInvoiceDetailV2Resp> value){
			this.orderElectronicInvoiceList_ = value;
		}
		
	}
	
}