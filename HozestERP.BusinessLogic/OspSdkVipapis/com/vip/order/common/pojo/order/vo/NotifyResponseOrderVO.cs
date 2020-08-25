using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class NotifyResponseOrderVO {
		
		///<summary>
		/// 订单SN
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单ID,普通订单通过order_id传入支付成功时回传
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 预付订单流水号
		///</summary>
		
		private string orderCode_;
		
		///<summary>
		/// 支付号
		///</summary>
		
		private string paySn_;
		
		///<summary>
		/// 返回码
		///</summary>
		
		private string retCode_;
		
		///<summary>
		/// 返回消息
		///</summary>
		
		private string retMessage_;
		
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
		public string GetOrderCode(){
			return this.orderCode_;
		}
		
		public void SetOrderCode(string value){
			this.orderCode_ = value;
		}
		public string GetPaySn(){
			return this.paySn_;
		}
		
		public void SetPaySn(string value){
			this.paySn_ = value;
		}
		public string GetRetCode(){
			return this.retCode_;
		}
		
		public void SetRetCode(string value){
			this.retCode_ = value;
		}
		public string GetRetMessage(){
			return this.retMessage_;
		}
		
		public void SetRetMessage(string value){
			this.retMessage_ = value;
		}
		
	}
	
}