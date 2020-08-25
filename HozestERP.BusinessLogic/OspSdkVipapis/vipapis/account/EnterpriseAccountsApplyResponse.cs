using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseAccountsApplyResponse {
		
		///<summary>
		/// 账号批量申请结果，返回申请失败的员工账号列表
		///</summary>
		
		private List<vipapis.account.EnterpriseEmployeeApplyFail> apply_fail_;
		
		public List<vipapis.account.EnterpriseEmployeeApplyFail> GetApply_fail(){
			return this.apply_fail_;
		}
		
		public void SetApply_fail(List<vipapis.account.EnterpriseEmployeeApplyFail> value){
			this.apply_fail_ = value;
		}
		
	}
	
}