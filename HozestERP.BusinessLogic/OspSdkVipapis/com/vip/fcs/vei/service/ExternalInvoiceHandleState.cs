using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class ExternalInvoiceHandleState {
		
		///<summary>
		/// 0为未处理，1为已处理
		///</summary>
		
		private string state_;
		
		///<summary>
		/// 发票代码
		///</summary>
		
		private string fpdm_;
		
		///<summary>
		/// 发票号码
		///</summary>
		
		private string fphm_;
		
		///<summary>
		/// 订单号码
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 响应状态
		///</summary>
		
		private com.vip.fcs.vei.service.BaseRetMsg retMsg_;
		
		public string GetState(){
			return this.state_;
		}
		
		public void SetState(string value){
			this.state_ = value;
		}
		public string GetFpdm(){
			return this.fpdm_;
		}
		
		public void SetFpdm(string value){
			this.fpdm_ = value;
		}
		public string GetFphm(){
			return this.fphm_;
		}
		
		public void SetFphm(string value){
			this.fphm_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public com.vip.fcs.vei.service.BaseRetMsg GetRetMsg(){
			return this.retMsg_;
		}
		
		public void SetRetMsg(com.vip.fcs.vei.service.BaseRetMsg value){
			this.retMsg_ = value;
		}
		
	}
	
}