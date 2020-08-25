using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtLadingBillNumberInfoResult {
		
		///<summary>
		/// 响应头
		///</summary>
		
		private com.vip.haitao.orderservice.service.Head head_;
		
		///<summary>
		/// 提单详情
		///</summary>
		
		private com.vip.haitao.orderservice.service.HtLadingBillNumberManagmentModel ladingBill_;
		
		public com.vip.haitao.orderservice.service.Head GetHead(){
			return this.head_;
		}
		
		public void SetHead(com.vip.haitao.orderservice.service.Head value){
			this.head_ = value;
		}
		public com.vip.haitao.orderservice.service.HtLadingBillNumberManagmentModel GetLadingBill(){
			return this.ladingBill_;
		}
		
		public void SetLadingBill(com.vip.haitao.orderservice.service.HtLadingBillNumberManagmentModel value){
			this.ladingBill_ = value;
		}
		
	}
	
}