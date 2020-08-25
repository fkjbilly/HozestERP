using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class DownloadElectronicInvoiceReqModel2 {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		
	}
	
}