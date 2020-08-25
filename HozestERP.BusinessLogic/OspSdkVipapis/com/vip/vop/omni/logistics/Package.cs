using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.logistics{
	
	
	
	
	
	public class Package {
		
		///<summary>
		/// 物流状态码
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 物流承运商
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 物流状态列表
		///</summary>
		
		private List<com.vip.vop.omni.logistics.TraceInfo> traceInfos_;
		
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		public List<com.vip.vop.omni.logistics.TraceInfo> GetTraceInfos(){
			return this.traceInfos_;
		}
		
		public void SetTraceInfos(List<com.vip.vop.omni.logistics.TraceInfo> value){
			this.traceInfos_ = value;
		}
		
	}
	
}