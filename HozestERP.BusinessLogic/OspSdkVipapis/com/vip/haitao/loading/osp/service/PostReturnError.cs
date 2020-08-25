using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class PostReturnError {
		
		///<summary>
		/// ID或业务主键
		///</summary>
		
		private string returnErrorId_;
		
		///<summary>
		/// 返回响应错误编码
		///</summary>
		
		private string returnErrorCode_;
		
		///<summary>
		/// 返回响应错误消息
		///</summary>
		
		private string retrunErrorMessage_;
		
		public string GetReturnErrorId(){
			return this.returnErrorId_;
		}
		
		public void SetReturnErrorId(string value){
			this.returnErrorId_ = value;
		}
		public string GetReturnErrorCode(){
			return this.returnErrorCode_;
		}
		
		public void SetReturnErrorCode(string value){
			this.returnErrorCode_ = value;
		}
		public string GetRetrunErrorMessage(){
			return this.retrunErrorMessage_;
		}
		
		public void SetRetrunErrorMessage(string value){
			this.retrunErrorMessage_ = value;
		}
		
	}
	
}