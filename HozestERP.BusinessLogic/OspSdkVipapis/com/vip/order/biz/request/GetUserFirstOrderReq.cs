using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetUserFirstOrderReq {
		
		///<summary>
		/// 会员ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 0-只查普通订单，1-只查预付订单。取值为空时，分别查询普通订单及预付订单。
		///</summary>
		
		private int? orderCategory_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		
	}
	
}