using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.logistics{
	
	
	
	
	
	public class TraceInfo {
		
		///<summary>
		/// 物流状态码
		///</summary>
		
		private string transport_code_;
		
		///<summary>
		/// 物流状态信息
		///</summary>
		
		private string transport_detail_;
		
		///<summary>
		/// 物流状态时间
		///</summary>
		
		private string transport_time_;
		
		public string GetTransport_code(){
			return this.transport_code_;
		}
		
		public void SetTransport_code(string value){
			this.transport_code_ = value;
		}
		public string GetTransport_detail(){
			return this.transport_detail_;
		}
		
		public void SetTransport_detail(string value){
			this.transport_detail_ = value;
		}
		public string GetTransport_time(){
			return this.transport_time_;
		}
		
		public void SetTransport_time(string value){
			this.transport_time_ = value;
		}
		
	}
	
}