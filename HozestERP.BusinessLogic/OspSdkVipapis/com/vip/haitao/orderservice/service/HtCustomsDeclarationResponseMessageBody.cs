using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtCustomsDeclarationResponseMessageBody {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 请求状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 业务状态码
		///</summary>
		
		private string bizResponseCode_;
		
		///<summary>
		/// 业务描述
		///</summary>
		
		private string bizResponseMsg_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetBizResponseCode(){
			return this.bizResponseCode_;
		}
		
		public void SetBizResponseCode(string value){
			this.bizResponseCode_ = value;
		}
		public string GetBizResponseMsg(){
			return this.bizResponseMsg_;
		}
		
		public void SetBizResponseMsg(string value){
			this.bizResponseMsg_ = value;
		}
		
	}
	
}