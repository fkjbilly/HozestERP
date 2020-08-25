using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class UpdateAutoPayAuthReq {
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 支付方式ID
		///</summary>
		
		private int? payId_;
		
		///<summary>
		/// 支付类型
		///</summary>
		
		private int? payType_;
		
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
		public int? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(int? value){
			this.payId_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		
	}
	
}