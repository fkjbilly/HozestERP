using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ModifyOrderInvoiceRespVO {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 消息码，200为成功
		///</summary>
		
		private string retCode_;
		
		///<summary>
		/// 消息描述
		///</summary>
		
		private string retMessage_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetRetCode(){
			return this.retCode_;
		}
		
		public void SetRetCode(string value){
			this.retCode_ = value;
		}
		public string GetRetMessage(){
			return this.retMessage_;
		}
		
		public void SetRetMessage(string value){
			this.retMessage_ = value;
		}
		
	}
	
}