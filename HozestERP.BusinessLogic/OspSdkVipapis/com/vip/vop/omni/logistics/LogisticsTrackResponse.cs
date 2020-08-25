using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.logistics{
	
	
	
	
	
	public class LogisticsTrackResponse {
		
		///<summary>
		/// 订单列表
		///</summary>
		
		private List<com.vip.vop.omni.logistics.Order> orders_;
		
		public List<com.vip.vop.omni.logistics.Order> GetOrders(){
			return this.orders_;
		}
		
		public void SetOrders(List<com.vip.vop.omni.logistics.Order> value){
			this.orders_ = value;
		}
		
	}
	
}