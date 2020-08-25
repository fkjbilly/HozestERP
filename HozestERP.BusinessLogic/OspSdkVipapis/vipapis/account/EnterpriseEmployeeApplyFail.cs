using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseEmployeeApplyFail {
		
		///<summary>
		/// 账号升级申请信息
		///</summary>
		
		private vipapis.account.EnterpriseEmployeeApplyInfo apply_info_;
		
		///<summary>
		/// 申请返回结果的错误信息
		///</summary>
		
		private string error_msg_;
		
		public vipapis.account.EnterpriseEmployeeApplyInfo GetApply_info(){
			return this.apply_info_;
		}
		
		public void SetApply_info(vipapis.account.EnterpriseEmployeeApplyInfo value){
			this.apply_info_ = value;
		}
		public string GetError_msg(){
			return this.error_msg_;
		}
		
		public void SetError_msg(string value){
			this.error_msg_ = value;
		}
		
	}
	
}