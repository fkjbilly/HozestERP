using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.product{
	
	
	
	
	
	public class EmailConfig {
		
		///<summary>
		/// 合作伙伴ID
		///</summary>
		
		private long? partnerId_;
		
		///<summary>
		/// 收件人名称
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 收件人地址
		///</summary>
		
		private string email_;
		
		///<summary>
		/// 收件人电话号码
		///</summary>
		
		private string tel_;
		
		public long? GetPartnerId(){
			return this.partnerId_;
		}
		
		public void SetPartnerId(long? value){
			this.partnerId_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public string GetEmail(){
			return this.email_;
		}
		
		public void SetEmail(string value){
			this.email_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		
	}
	
}