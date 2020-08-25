using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderDeviceInfoVO {
		
		///<summary>
		/// pc id
		///</summary>
		
		private string cid_;
		
		///<summary>
		/// app id
		///</summary>
		
		private string mid_;
		
		///<summary>
		/// did
		///</summary>
		
		private string did_;
		
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