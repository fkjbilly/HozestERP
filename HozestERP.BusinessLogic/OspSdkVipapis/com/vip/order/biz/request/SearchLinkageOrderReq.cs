using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class SearchLinkageOrderReq {
		
		///<summary>
		/// 订单号（拆单后的子单）
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 会员ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 权限(针对客服,用户不填)
		///</summary>
		
		private com.vip.order.biz.request.CancelOrderPrivilegeReq cancelOrderPrivilegeReq_;
		
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
		public com.vip.order.biz.request.CancelOrderPrivilegeReq GetCancelOrderPrivilegeReq(){
			return this.cancelOrderPrivilegeReq_;
		}
		
		public void SetCancelOrderPrivilegeReq(com.vip.order.biz.request.CancelOrderPrivilegeReq value){
			this.cancelOrderPrivilegeReq_ = value;
		}
		
	}
	
}