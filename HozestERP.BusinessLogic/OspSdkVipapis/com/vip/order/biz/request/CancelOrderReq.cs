using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CancelOrderReq {
		
		///<summary>
		/// 会员id 
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单类别 
		///</summary>
		
		private byte? orderCategory_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单号 
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户选择的取消原因ID 
		///</summary>
		
		private int? reasonChoice_;
		
		///<summary>
		/// 用户输入的取消原因 
		///</summary>
		
		private string reasonRemark_;
		
		///<summary>
		/// 是否预览 
		///</summary>
		
		private bool? isPreview_;
		
		///<summary>
		/// appVersion 
		///</summary>
		
		private string appVersion_;
		
		///<summary>
		/// 取消操作类型(0: 取消单个 1: 强制联动取消) 默认0 
		///</summary>
		
		private int? opType_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public byte? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(byte? value){
			this.orderCategory_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetReasonChoice(){
			return this.reasonChoice_;
		}
		
		public void SetReasonChoice(int? value){
			this.reasonChoice_ = value;
		}
		public string GetReasonRemark(){
			return this.reasonRemark_;
		}
		
		public void SetReasonRemark(string value){
			this.reasonRemark_ = value;
		}
		public bool? GetIsPreview(){
			return this.isPreview_;
		}
		
		public void SetIsPreview(bool? value){
			this.isPreview_ = value;
		}
		public string GetAppVersion(){
			return this.appVersion_;
		}
		
		public void SetAppVersion(string value){
			this.appVersion_ = value;
		}
		public int? GetOpType(){
			return this.opType_;
		}
		
		public void SetOpType(int? value){
			this.opType_ = value;
		}
		
	}
	
}