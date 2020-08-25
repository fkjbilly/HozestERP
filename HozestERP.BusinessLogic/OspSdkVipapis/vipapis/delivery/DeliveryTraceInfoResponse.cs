using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DeliveryTraceInfoResponse {
		
		///<summary>
		/// 物流详情信息
		///</summary>
		
		private List<vipapis.delivery.DeliveryTraceInfo> delivery_trace_infoes_;
		
		public List<vipapis.delivery.DeliveryTraceInfo> GetDelivery_trace_infoes(){
			return this.delivery_trace_infoes_;
		}
		
		public void SetDelivery_trace_infoes(List<vipapis.delivery.DeliveryTraceInfo> value){
			this.delivery_trace_infoes_ = value;
		}
		
	}
	
}