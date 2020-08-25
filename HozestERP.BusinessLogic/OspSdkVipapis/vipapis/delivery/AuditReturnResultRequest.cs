using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class AuditReturnResultRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private long? vendor_id_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 客退申请单号
		///</summary>
		
		private string order_return_id_;
		
		///<summary>
		/// 审核结果：0：不通过；1：通过
		///</summary>
		
		private int? vendor_audit_stat_;
		
		///<summary>
		/// 审核意见描述（当审核接口为“不通过”时，此字段必填）
		///</summary>
		
		private string vendor_audit_opinion_;
		
		public long? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(long? value){
			this.vendor_id_ = value;
		}
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetOrder_return_id(){
			return this.order_return_id_;
		}
		
		public void SetOrder_return_id(string value){
			this.order_return_id_ = value;
		}
		public int? GetVendor_audit_stat(){
			return this.vendor_audit_stat_;
		}
		
		public void SetVendor_audit_stat(int? value){
			this.vendor_audit_stat_ = value;
		}
		public string GetVendor_audit_opinion(){
			return this.vendor_audit_opinion_;
		}
		
		public void SetVendor_audit_opinion(string value){
			this.vendor_audit_opinion_ = value;
		}
		
	}
	
}