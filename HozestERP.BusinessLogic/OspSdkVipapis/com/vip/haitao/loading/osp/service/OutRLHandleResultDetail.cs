using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class OutRLHandleResultDetail {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单处理结果编码
		///</summary>
		
		private string handleResultCode_;
		
		///<summary>
		/// 订单处理结果详情
		///</summary>
		
		private string handleResultMsg_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetHandleResultCode(){
			return this.handleResultCode_;
		}
		
		public void SetHandleResultCode(string value){
			this.handleResultCode_ = value;
		}
		public string GetHandleResultMsg(){
			return this.handleResultMsg_;
		}
		
		public void SetHandleResultMsg(string value){
			this.handleResultMsg_ = value;
		}
		
	}
	
}