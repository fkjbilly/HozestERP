using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ReleaseStockReq {
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 操作人
		///</summary>
		
		private string adminUser_;
		
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetAdminUser(){
			return this.adminUser_;
		}
		
		public void SetAdminUser(string value){
			this.adminUser_ = value;
		}
		
	}
	
}