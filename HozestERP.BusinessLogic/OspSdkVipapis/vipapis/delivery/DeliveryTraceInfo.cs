using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DeliveryTraceInfo {
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storage_no_;
		
		///<summary>
		/// 物流单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 物流信息
		///</summary>
		
		private List<vipapis.delivery.TraceInfo> traces_;
		
		public string GetStorage_no(){
			return this.storage_no_;
		}
		
		public void SetStorage_no(string value){
			this.storage_no_ = value;
		}
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
		public List<vipapis.delivery.TraceInfo> GetTraces(){
			return this.traces_;
		}
		
		public void SetTraces(List<vipapis.delivery.TraceInfo> value){
			this.traces_ = value;
		}
		
	}
	
}