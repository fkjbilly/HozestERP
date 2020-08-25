using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CancelOrderFixDataReq {
		
		///<summary>
		/// operation 
		///</summary>
		
		private string operation_;
		
		///<summary>
		/// 订单号 
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户选择的取消原因ID 
		///</summary>
		
		private bool? goodsStatus_;
		
		///<summary>
		/// 退款类型 
		///</summary>
		
		private int? refundType_;
		
		public string GetOperation(){
			return this.operation_;
		}
		
		public void SetOperation(string value){
			this.operation_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public bool? GetGoodsStatus(){
			return this.goodsStatus_;
		}
		
		public void SetGoodsStatus(bool? value){
			this.goodsStatus_ = value;
		}
		public int? GetRefundType(){
			return this.refundType_;
		}
		
		public void SetRefundType(int? value){
			this.refundType_ = value;
		}
		
	}
	
}