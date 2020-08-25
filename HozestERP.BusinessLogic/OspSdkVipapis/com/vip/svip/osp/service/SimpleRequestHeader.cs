using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class SimpleRequestHeader {
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 用户ip
		///</summary>
		
		private string ip_;
		
		///<summary>
		/// 用户marsCid
		///</summary>
		
		private string marsCid_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetIp(){
			return this.ip_;
		}
		
		public void SetIp(string value){
			this.ip_ = value;
		}
		public string GetMarsCid(){
			return this.marsCid_;
		}
		
		public void SetMarsCid(string value){
			this.marsCid_ = value;
		}
		
	}
	
}