using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class TraceDetail {
		
		///<summary>
		/// 物流状态编码
		///</summary>
		
		private string transportCode_;
		
		///<summary>
		/// 物流状态信息
		///</summary>
		
		private string transportDetail_;
		
		///<summary>
		/// 物流状态时间
		///</summary>
		
		private string transportTime_;
		
		public string GetTransportCode(){
			return this.transportCode_;
		}
		
		public void SetTransportCode(string value){
			this.transportCode_ = value;
		}
		public string GetTransportDetail(){
			return this.transportDetail_;
		}
		
		public void SetTransportDetail(string value){
			this.transportDetail_ = value;
		}
		public string GetTransportTime(){
			return this.transportTime_;
		}
		
		public void SetTransportTime(string value){
			this.transportTime_ = value;
		}
		
	}
	
}