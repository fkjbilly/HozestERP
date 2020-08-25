using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderRefundWayVO {
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 支付金额
		///</summary>
		
		private string money_;
		
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		
	}
	
}