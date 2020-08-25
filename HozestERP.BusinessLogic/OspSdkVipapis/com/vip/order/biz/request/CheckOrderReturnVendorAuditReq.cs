using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CheckOrderReturnVendorAuditReq {
		
		///<summary>
		/// 订单号，必传字段
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单的用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 需要退货的商品的merItemNo（对应size_id）
		///</summary>
		
		private List<long?> returnMerItemNoSet_;
		
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
		public List<long?> GetReturnMerItemNoSet(){
			return this.returnMerItemNoSet_;
		}
		
		public void SetReturnMerItemNoSet(List<long?> value){
			this.returnMerItemNoSet_ = value;
		}
		
	}
	
}