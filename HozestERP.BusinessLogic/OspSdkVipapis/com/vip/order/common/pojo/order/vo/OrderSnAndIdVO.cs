using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderSnAndIdVO {
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		
	}
	
}