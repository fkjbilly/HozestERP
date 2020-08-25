using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class UpdateOrderToReturnVerifiedReq {
		
		///<summary>
		/// orderSn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户Id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private int? orderStatus_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public int? GetOrderStatus(){
			return this.orderStatus_;
		}
		
		public void SetOrderStatus(int? value){
			this.orderStatus_ = value;
		}
		
	}
	
}