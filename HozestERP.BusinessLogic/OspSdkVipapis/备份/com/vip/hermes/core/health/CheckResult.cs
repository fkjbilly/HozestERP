using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.hermes.core.health{
	
	
	
	
	
	public class CheckResult {
		
		///<summary>
		/// 服务状态
		///</summary>
		
		private com.vip.hermes.core.health.Status status_;
		
		///<summary>
		/// 详细信息
		///</summary>
		
		private Dictionary<string, string> details_;
		
		public com.vip.hermes.core.health.Status GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(com.vip.hermes.core.health.Status value){
			this.status_ = value;
		}
		public Dictionary<string, string> GetDetails(){
			return this.details_;
		}
		
		public void SetDetails(Dictionary<string, string> value){
			this.details_ = value;
		}
		
	}
	
}