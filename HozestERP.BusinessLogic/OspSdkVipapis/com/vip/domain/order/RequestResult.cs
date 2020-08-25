using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class RequestResult {
		
		///<summary>
		/// 状态
		///</summary>
		
		private com.vip.domain.order.ResponseCodeStatus? response_code_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		public com.vip.domain.order.ResponseCodeStatus? GetResponse_code(){
			return this.response_code_;
		}
		
		public void SetResponse_code(com.vip.domain.order.ResponseCodeStatus? value){
			this.response_code_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}