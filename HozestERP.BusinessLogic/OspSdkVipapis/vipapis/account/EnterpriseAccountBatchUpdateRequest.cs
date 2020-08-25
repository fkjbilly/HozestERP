using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseAccountBatchUpdateRequest {
		
		///<summary>
		/// 企业标识，请严格传入指定的企业标识码
		/// @sampleValue enterprise_code 16
		///</summary>
		
		private string enterprise_code_;
		
		///<summary>
		/// 批量企业员工账号申请列表，最大限制1000条
		///</summary>
		
		private List<vipapis.account.EnterpriseEmployeeApplyInfo> apply_employees_;
		
		public string GetEnterprise_code(){
			return this.enterprise_code_;
		}
		
		public void SetEnterprise_code(string value){
			this.enterprise_code_ = value;
		}
		public List<vipapis.account.EnterpriseEmployeeApplyInfo> GetApply_employees(){
			return this.apply_employees_;
		}
		
		public void SetApply_employees(List<vipapis.account.EnterpriseEmployeeApplyInfo> value){
			this.apply_employees_ = value;
		}
		
	}
	
}