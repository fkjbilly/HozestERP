using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CreateOrderElectronicInvoiceReq {
		
		///<summary>
		/// 电子发票信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO orderElectronicInvoiceVO_;
		
		public com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO GetOrderElectronicInvoiceVO(){
			return this.orderElectronicInvoiceVO_;
		}
		
		public void SetOrderElectronicInvoiceVO(com.vip.order.common.pojo.order.vo.OrderElectronicInvoiceVO value){
			this.orderElectronicInvoiceVO_ = value;
		}
		
	}
	
}