using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.logistics{
	
	
	
	
	
	public class LogisticsTrackRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 订单号，支持批量，<= 50
		///</summary>
		
		private List<string> order_id_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public List<string> GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(List<string> value){
			this.order_id_ = value;
		}
		
	}
	
}