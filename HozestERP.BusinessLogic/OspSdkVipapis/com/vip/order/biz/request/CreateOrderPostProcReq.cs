using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CreateOrderPostProcReq {
		
		///<summary>
		/// 订单号列表 
		///</summary>
		
		private List<string> orderSn_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		public List<string> GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(List<string> value){
			this.orderSn_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		
	}
	
}