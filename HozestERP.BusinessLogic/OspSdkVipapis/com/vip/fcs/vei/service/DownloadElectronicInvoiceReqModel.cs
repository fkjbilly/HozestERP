using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class DownloadElectronicInvoiceReqModel {
		
		///<summary>
		/// 发票赋码
		///</summary>
		
		private string fpCode_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private string orderId_;
		
		///<summary>
		/// 会员ID
		///</summary>
		
		private string userId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		public string GetFpCode(){
			return this.fpCode_;
		}
		
		public void SetFpCode(string value){
			this.fpCode_ = value;
		}
		public string GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(string value){
			this.orderId_ = value;
		}
		public string GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(string value){
			this.userId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		
	}
	
}