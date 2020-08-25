using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtCustomsDeclarationResponseMessage {
		
		///<summary>
		/// 请求头
		///</summary>
		
		private com.vip.haitao.orderservice.service.Head head_;
		
		///<summary>
		/// 返回报文体
		///</summary>
		
		private List<com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBody> body_;
		
		public com.vip.haitao.orderservice.service.Head GetHead(){
			return this.head_;
		}
		
		public void SetHead(com.vip.haitao.orderservice.service.Head value){
			this.head_ = value;
		}
		public List<com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBody> GetBody(){
			return this.body_;
		}
		
		public void SetBody(List<com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBody> value){
			this.body_ = value;
		}
		
	}
	
}