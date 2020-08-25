using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class SearchOrderInvoicesReq {
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单ID列表
		///</summary>
		
		private List<long?> orderIdList_;
		
		///<summary>
		/// 订单序列号列表
		///</summary>
		
		private List<string> orderSnList_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public List<long?> GetOrderIdList(){
			return this.orderIdList_;
		}
		
		public void SetOrderIdList(List<long?> value){
			this.orderIdList_ = value;
		}
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		
	}
	
}