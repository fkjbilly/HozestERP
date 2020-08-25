using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class OrderRefundReq {
		
		///<summary>
		/// 退款金额
		///</summary>
		
		private com.vip.order.biz.request.RefundMoneyUnit refundMoney_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单类别： 0-普通订单，1-预付订单
		///</summary>
		
		private int? orderCategory_;
		
		///<summary>
		/// 退款场景：1-退货退款,2-修改订单,3-合并订单,4-取消订单,5-投递失败退款,6-特殊退款,7-取消预付首单
		///</summary>
		
		private int? sceneType_;
		
		///<summary>
		/// 退款类型： 1-退款，2-收款
		///</summary>
		
		private int? billType_;
		
		///<summary>
		/// 退款原因
		///</summary>
		
		private string refundReason_;
		
		public com.vip.order.biz.request.RefundMoneyUnit GetRefundMoney(){
			return this.refundMoney_;
		}
		
		public void SetRefundMoney(com.vip.order.biz.request.RefundMoneyUnit value){
			this.refundMoney_ = value;
		}
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
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		public int? GetSceneType(){
			return this.sceneType_;
		}
		
		public void SetSceneType(int? value){
			this.sceneType_ = value;
		}
		public int? GetBillType(){
			return this.billType_;
		}
		
		public void SetBillType(int? value){
			this.billType_ = value;
		}
		public string GetRefundReason(){
			return this.refundReason_;
		}
		
		public void SetRefundReason(string value){
			this.refundReason_ = value;
		}
		
	}
	
}