using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderTrack {
		
		///<summary>
		/// 物流信息
		///</summary>
		
		private List<vipapis.order.TransportInfo> timeline_;
		
		///<summary>
		/// 是否货到付款   0否 1是
		///</summary>
		
		private byte? is_cod_;
		
		///<summary>
		/// 承运商
		///</summary>
		
		private string transport_;
		
		public List<vipapis.order.TransportInfo> GetTimeline(){
			return this.timeline_;
		}
		
		public void SetTimeline(List<vipapis.order.TransportInfo> value){
			this.timeline_ = value;
		}
		public byte? GetIs_cod(){
			return this.is_cod_;
		}
		
		public void SetIs_cod(byte? value){
			this.is_cod_ = value;
		}
		public string GetTransport(){
			return this.transport_;
		}
		
		public void SetTransport(string value){
			this.transport_ = value;
		}
		
	}
	
}