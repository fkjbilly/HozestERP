using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class PaymentReceivedReq {
		
		///<summary>
		/// userId
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单Id
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 是否支付成功
		///</summary>
		
		private bool? isPaySuccess_;
		
		///<summary>
		/// 是否有权限
		///</summary>
		
		private bool? hasPriv_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public bool? GetIsPaySuccess(){
			return this.isPaySuccess_;
		}
		
		public void SetIsPaySuccess(bool? value){
			this.isPaySuccess_ = value;
		}
		public bool? GetHasPriv(){
			return this.hasPriv_;
		}
		
		public void SetHasPriv(bool? value){
			this.hasPriv_ = value;
		}
		
	}
	
}