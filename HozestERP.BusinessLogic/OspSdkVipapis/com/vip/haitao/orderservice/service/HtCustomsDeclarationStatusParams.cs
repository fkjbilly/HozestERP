using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtCustomsDeclarationStatusParams {
		
		///<summary>
		///</summary>
		
		private string customsCode_;
		
		///<summary>
		/// 调用方代码
		///</summary>
		
		private string userId_;
		
		///<summary>
		///</summary>
		
		private List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> body_;
		
		public string GetCustomsCode(){
			return this.customsCode_;
		}
		
		public void SetCustomsCode(string value){
			this.customsCode_ = value;
		}
		public string GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(string value){
			this.userId_ = value;
		}
		public List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> GetBody(){
			return this.body_;
		}
		
		public void SetBody(List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> value){
			this.body_ = value;
		}
		
	}
	
}