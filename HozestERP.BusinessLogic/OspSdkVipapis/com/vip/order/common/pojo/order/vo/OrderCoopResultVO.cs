using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderCoopResultVO {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 第三方订单号
		///</summary>
		
		private string exOrderSn_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetExOrderSn(){
			return this.exOrderSn_;
		}
		
		public void SetExOrderSn(string value){
			this.exOrderSn_ = value;
		}
		
	}
	
}