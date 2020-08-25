using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CheckDeliveryFetchExchangeReq {
		
		///<summary>
		/// 订单号 
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户ID 
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 地址ID 
		///</summary>
		
		private long? areaId_;
		
		///<summary>
		/// 地址层级 默认为4 
		///</summary>
		
		private int? addressLevel_;
		
		///<summary>
		/// 档期、专场的skuId列表
		///</summary>
		
		private List<long?> merItemNoSet_;
		
		///<summary>
		/// 地址ID2 
		///</summary>
		
		private string areaIdStr_;
		
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
		public long? GetAreaId(){
			return this.areaId_;
		}
		
		public void SetAreaId(long? value){
			this.areaId_ = value;
		}
		public int? GetAddressLevel(){
			return this.addressLevel_;
		}
		
		public void SetAddressLevel(int? value){
			this.addressLevel_ = value;
		}
		public List<long?> GetMerItemNoSet(){
			return this.merItemNoSet_;
		}
		
		public void SetMerItemNoSet(List<long?> value){
			this.merItemNoSet_ = value;
		}
		public string GetAreaIdStr(){
			return this.areaIdStr_;
		}
		
		public void SetAreaIdStr(string value){
			this.areaIdStr_ = value;
		}
		
	}
	
}