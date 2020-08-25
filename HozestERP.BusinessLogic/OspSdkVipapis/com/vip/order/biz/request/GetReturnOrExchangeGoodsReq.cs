using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetReturnOrExchangeGoodsReq {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户Id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 售后服务类型 return:普通退 deliveryFetchReturn:上门揽退 exchange:普通换 deliveryFetchExchange:上门揽换
		///</summary>
		
		private string opType_;
		
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
		public string GetOpType(){
			return this.opType_;
		}
		
		public void SetOpType(string value){
			this.opType_ = value;
		}
		
	}
	
}