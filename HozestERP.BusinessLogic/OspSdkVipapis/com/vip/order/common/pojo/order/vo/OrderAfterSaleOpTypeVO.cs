using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderAfterSaleOpTypeVO {
		
		///<summary>
		/// 是否可操作 0:不可以 1:可以
		///</summary>
		
		private int? opFlag_;
		
		///<summary>
		/// 不可操作原因状态码
		///</summary>
		
		private string reasonCode_;
		
		///<summary>
		/// 不可操作原因
		///</summary>
		
		private string reason_;
		
		public int? GetOpFlag(){
			return this.opFlag_;
		}
		
		public void SetOpFlag(int? value){
			this.opFlag_ = value;
		}
		public string GetReasonCode(){
			return this.reasonCode_;
		}
		
		public void SetReasonCode(string value){
			this.reasonCode_ = value;
		}
		public string GetReason(){
			return this.reason_;
		}
		
		public void SetReason(string value){
			this.reason_ = value;
		}
		
	}
	
}