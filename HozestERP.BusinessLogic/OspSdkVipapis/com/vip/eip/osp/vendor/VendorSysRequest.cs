using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.eip.osp.vendor{
	
	
	
	
	
	public class VendorSysRequest {
		
		///<summary>
		/// 请求消息
		///</summary>
		
		private string msg_;
		
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		
	}
	
}