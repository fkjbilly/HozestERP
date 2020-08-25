using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class CheckOrderReturnVendorAuditResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 供应商审核标记，0是不允许，1是允许
		///</summary>
		
		private int? vendorAuditFlag_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public int? GetVendorAuditFlag(){
			return this.vendorAuditFlag_;
		}
		
		public void SetVendorAuditFlag(int? value){
			this.vendorAuditFlag_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}