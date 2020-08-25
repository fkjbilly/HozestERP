using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.eip.osp.vendor{
	
	
	
	
	
	public class VendorSysResponse {
		
		///<summary>
		/// 响应信息
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