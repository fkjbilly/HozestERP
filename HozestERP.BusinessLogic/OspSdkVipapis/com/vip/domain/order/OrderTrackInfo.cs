using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class OrderTrackInfo {
		
		///<summary>
		/// ERP订单号
		///</summary>
		
		private string erp_order_sn_;
		
		///<summary>
		/// 物流状态编码
		///</summary>
		
		private string transport_code_;
		
		///<summary>
		/// 物流状态信息
		///</summary>
		
		private string transport_detail_;
		
		///<summary>
		/// 状态发生时间
		///</summary>
		
		private string action_time_;
		
		public string GetErp_order_sn(){
			return this.erp_order_sn_;
		}
		
		public void SetErp_order_sn(string value){
			this.erp_order_sn_ = value;
		}
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
		public string GetAction_time(){
			return this.action_time_;
		}
		
		public void SetAction_time(string value){
			this.action_time_ = value;
		}
		
	}
	
}