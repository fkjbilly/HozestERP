using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class DeliveryTrace {
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storageNo_;
		
		///<summary>
		/// 物流单号
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carrierName_;
		
		///<summary>
		/// 物流信息
		///</summary>
		
		private List<com.vip.vop.vcloud.jit.TraceDetail> traces_;
		
		public string GetStorageNo(){
			return this.storageNo_;
		}
		
		public void SetStorageNo(string value){
			this.storageNo_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public string GetCarrierName(){
			return this.carrierName_;
		}
		
		public void SetCarrierName(string value){
			this.carrierName_ = value;
		}
		public List<com.vip.vop.vcloud.jit.TraceDetail> GetTraces(){
			return this.traces_;
		}
		
		public void SetTraces(List<com.vip.vop.vcloud.jit.TraceDetail> value){
			this.traces_ = value;
		}
		
	}
	
}