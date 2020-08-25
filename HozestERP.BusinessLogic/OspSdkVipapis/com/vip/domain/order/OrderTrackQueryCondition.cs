using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class OrderTrackQueryCondition {
		
		///<summary>
		/// ERP订单号
		///</summary>
		
		private string erp_order_sn_;
		
		public string GetErp_order_sn(){
			return this.erp_order_sn_;
		}
		
		public void SetErp_order_sn(string value){
			this.erp_order_sn_ = value;
		}
		
	}
	
}