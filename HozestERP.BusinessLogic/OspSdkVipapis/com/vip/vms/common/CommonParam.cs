using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vms.common{
	
	
	
	
	
	public class CommonParam {
		
		///<summary>
		/// 调用方应用名称
		///</summary>
		
		private string appName_;
		
		public string GetAppName(){
			return this.appName_;
		}
		
		public void SetAppName(string value){
			this.appName_ = value;
		}
		
	}
	
}