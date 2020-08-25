using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class BatchModifyOrderInvoiceReq {
		
		///<summary>
		/// 订单发票更新信息列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderInvoiceVO> orderInvoiceList_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderInvoiceVO> GetOrderInvoiceList(){
			return this.orderInvoiceList_;
		}
		
		public void SetOrderInvoiceList(List<com.vip.order.common.pojo.order.vo.OrderInvoiceVO> value){
			this.orderInvoiceList_ = value;
		}
		
	}
	
}