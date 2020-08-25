using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class CustomerBackOrderTrackInfo {
		
		///<summary>
		/// ERP客退单号
		///</summary>
		
		private string erp_back_sn_;
		
		///<summary>
		/// 物流状态编码号
		///</summary>
		
		private string transport_code_;
		
		///<summary>
		/// 物流状态信息
		///</summary>
		
		private string transport_detail_;
		
		///<summary>
		/// 异常类型
		///</summary>
		
		private string ab_reason_;
		
		///<summary>
		/// 异常备注
		///</summary>
		
		private string ab_remark_;
		
		///<summary>
		/// 状态发生时间(例:2014-07-14 17:18:37)
		///</summary>
		
		private string action_time_;
		
		public string GetErp_back_sn(){
			return this.erp_back_sn_;
		}
		
		public void SetErp_back_sn(string value){
			this.erp_back_sn_ = value;
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
		public string GetAb_reason(){
			return this.ab_reason_;
		}
		
		public void SetAb_reason(string value){
			this.ab_reason_ = value;
		}
		public string GetAb_remark(){
			return this.ab_remark_;
		}
		
		public void SetAb_remark(string value){
			this.ab_remark_ = value;
		}
		public string GetAction_time(){
			return this.action_time_;
		}
		
		public void SetAction_time(string value){
			this.action_time_ = value;
		}
		
	}
	
}