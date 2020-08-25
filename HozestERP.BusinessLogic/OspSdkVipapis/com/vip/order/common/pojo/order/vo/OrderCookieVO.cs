using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderCookieVO {
		
		///<summary>
		/// 
		///</summary>
		
		private string phpsessionId_;
		
		///<summary>
		/// 
		///</summary>
		
		private string marsCid_;
		
		///<summary>
		/// cid
		///</summary>
		
		private string cid_;
		
		///<summary>
		/// mid
		///</summary>
		
		private string mid_;
		
		///<summary>
		/// did
		///</summary>
		
		private string did_;
		
		public string GetPhpsessionId(){
			return this.phpsessionId_;
		}
		
		public void SetPhpsessionId(string value){
			this.phpsessionId_ = value;
		}
		public string GetMarsCid(){
			return this.marsCid_;
		}
		
		public void SetMarsCid(string value){
			this.marsCid_ = value;
		}
		public string GetCid(){
			return this.cid_;
		}
		
		public void SetCid(string value){
			this.cid_ = value;
		}
		public string GetMid(){
			return this.mid_;
		}
		
		public void SetMid(string value){
			this.mid_ = value;
		}
		public string GetDid(){
			return this.did_;
		}
		
		public void SetDid(string value){
			this.did_ = value;
		}
		
	}
	
}