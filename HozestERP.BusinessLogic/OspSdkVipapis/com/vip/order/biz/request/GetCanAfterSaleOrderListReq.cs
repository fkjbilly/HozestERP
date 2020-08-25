using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetCanAfterSaleOrderListReq {
		
		///<summary>
		/// 账号ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单频道来源
		///</summary>
		
		private List<string> vipclubList_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public List<string> GetVipclubList(){
			return this.vipclubList_;
		}
		
		public void SetVipclubList(List<string> value){
			this.vipclubList_ = value;
		}
		
	}
	
}