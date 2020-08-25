using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class ExternalInvoiceHandleStateReqModel {
		
		///<summary>
		/// 要查询的订单号集合
		///</summary>
		
		private List<string> orderSnList_;
		
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		
	}
	
}