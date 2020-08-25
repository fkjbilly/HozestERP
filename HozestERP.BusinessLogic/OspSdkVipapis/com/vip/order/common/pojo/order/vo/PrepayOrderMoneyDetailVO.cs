using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class PrepayOrderMoneyDetailVO {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 预付订单流水号
		///</summary>
		
		private string orderCode_;
		
		///<summary>
		/// 第几分期
		///</summary>
		
		private int? period_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单支付金额
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetOrderCode(){
			return this.orderCode_;
		}
		
		public void SetOrderCode(string value){
			this.orderCode_ = value;
		}
		public int? GetPeriod(){
			return this.period_;
		}
		
		public void SetPeriod(int? value){
			this.period_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		
	}
	
}