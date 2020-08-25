using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.oauth{
	
	
	
	
	
	public class RefreshTokenRequest {
		
		///<summary>
		/// 刷新令牌值
		///</summary>
		
		private string refresh_token_;
		
		///<summary>
		/// 申请应用时分配的appKey
		///</summary>
		
		private string client_id_;
		
		///<summary>
		/// 申请应用时分配的appSecret
		///</summary>
		
		private string client_secret_;
		
		///<summary>
		/// 应用IP地址
		///</summary>
		
		private string request_client_ip_;
		
		public string GetRefresh_token(){
			return this.refresh_token_;
		}
		
		public void SetRefresh_token(string value){
			this.refresh_token_ = value;
		}
		public string GetClient_id(){
			return this.client_id_;
		}
		
		public void SetClient_id(string value){
			this.client_id_ = value;
		}
		public string GetClient_secret(){
			return this.client_secret_;
		}
		
		public void SetClient_secret(string value){
			this.client_secret_ = value;
		}
		public string GetRequest_client_ip(){
			return this.request_client_ip_;
		}
		
		public void SetRequest_client_ip(string value){
			this.request_client_ip_ = value;
		}
		
	}
	
}