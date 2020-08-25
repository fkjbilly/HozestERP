using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetAfterSaleOpTypeReq {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户Id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 售后服务类型 canReturn:是否可普通退 canDeliveryFetchReturn:是否可上门揽退（闪电退）canExchange:是否可普通换 canDeliveryFetchExchange:是否可上门揽换（闪电换）
		///</summary>
		
		private List<string> opTypes_;
		
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
		public List<string> GetOpTypes(){
			return this.opTypes_;
		}
		
		public void SetOpTypes(List<string> value){
			this.opTypes_ = value;
		}
		
	}
	
}