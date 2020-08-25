using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.oauth{
	
	
	
	
	
	public class RefreshTokenResponse {
		
		///<summary>
		/// 访问令牌
		///</summary>
		
		private string access_token_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? create_at_;
		
		///<summary>
		/// 有效时长(秒)
		///</summary>
		
		private long? expires_in_;
		
		///<summary>
		/// 过期时间
		///</summary>
		
		private System.DateTime? expires_time_;
		
		///<summary>
		/// 是否过期
		///</summary>
		
		private bool? is_expired_;
		
		///<summary>
		/// 刷新令牌值
		///</summary>
		
		private string refresh_token_;
		
		///<summary>
		/// 刷新令牌过期时间
		///</summary>
		
		private System.DateTime? refresh_expires_time_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private string status_;
		
		public string GetAccess_token(){
			return this.access_token_;
		}
		
		public void SetAccess_token(string value){
			this.access_token_ = value;
		}
		public System.DateTime? GetCreate_at(){
			return this.create_at_;
		}
		
		public void SetCreate_at(System.DateTime? value){
			this.create_at_ = value;
		}
		public long? GetExpires_in(){
			return this.expires_in_;
		}
		
		public void SetExpires_in(long? value){
			this.expires_in_ = value;
		}
		public System.DateTime? GetExpires_time(){
			return this.expires_time_;
		}
		
		public void SetExpires_time(System.DateTime? value){
			this.expires_time_ = value;
		}
		public bool? GetIs_expired(){
			return this.is_expired_;
		}
		
		public void SetIs_expired(bool? value){
			this.is_expired_ = value;
		}
		public string GetRefresh_token(){
			return this.refresh_token_;
		}
		
		public void SetRefresh_token(string value){
			this.refresh_token_ = value;
		}
		public System.DateTime? GetRefresh_expires_time(){
			return this.refresh_expires_time_;
		}
		
		public void SetRefresh_expires_time(System.DateTime? value){
			this.refresh_expires_time_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		
	}
	
}