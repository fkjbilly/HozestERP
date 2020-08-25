using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.idcard.osp.service{
	
	
	
	
	
	public class HtIdCardInfoRequest {
		
		///<summary>
		/// 请求系统标识
		///</summary>
		
		private string userId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		public string GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(string value){
			this.userId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		
	}
	
}