using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class OrderInvoicesV2Resp {
		
		///<summary>
		/// 
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 发票列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderInvoiceVO> orderInvoiceList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderInvoiceVO> GetOrderInvoiceList(){
			return this.orderInvoiceList_;
		}
		
		public void SetOrderInvoiceList(List<com.vip.order.common.pojo.order.vo.OrderInvoiceVO> value){
			this.orderInvoiceList_ = value;
		}
		
	}
	
}