using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class PriceApplicationStatus {
		
		///<summary>
		/// 价格申请单id
		///</summary>
		
		private string application_id_;
		
		///<summary>
		/// 清单状态, 未确认：0，待确认：1 ，已确认：6，检查异常：9<br>已取消：10，待供应商处理：11，待供应商提交：12<br>待商助审核：13， 已下架 ：14
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 异常状态, 0：未检查、1：检查中、2：无异常、3：有异常
		///</summary>
		
		private string exception_status_;
		
		public string GetApplication_id(){
			return this.application_id_;
		}
		
		public void SetApplication_id(string value){
			this.application_id_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetException_status(){
			return this.exception_status_;
		}
		
		public void SetException_status(string value){
			this.exception_status_ = value;
		}
		
	}
	
}