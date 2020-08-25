using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetTransportListByCodesReq {
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 物流Code列表
		///</summary>
		
		private List<string> transportCodes_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public List<string> GetTransportCodes(){
			return this.transportCodes_;
		}
		
		public void SetTransportCodes(List<string> value){
			this.transportCodes_ = value;
		}
		
	}
	
}