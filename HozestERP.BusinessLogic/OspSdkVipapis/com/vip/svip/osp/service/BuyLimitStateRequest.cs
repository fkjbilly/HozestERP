using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BuyLimitStateRequest {
		
		///<summary>
		/// userId
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 用户ip
		///</summary>
		
		private string userIp_;
		
		///<summary>
		/// mid
		///</summary>
		
		private string mid_;
		
		///<summary>
		/// 调用方
		///</summary>
		
		private string operator_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetUserIp(){
			return this.userIp_;
		}
		
		public void SetUserIp(string value){
			this.userIp_ = value;
		}
		public string GetMid(){
			return this.mid_;
		}
		
		public void SetMid(string value){
			this.mid_ = value;
		}
		public string GetOperator(){
			return this.operator_;
		}
		
		public void SetOperator(string value){
			this.operator_ = value;
		}
		
	}
	
}