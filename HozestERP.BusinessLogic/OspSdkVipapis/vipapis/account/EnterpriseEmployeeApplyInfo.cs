using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseEmployeeApplyInfo {
		
		///<summary>
		/// 企业员工的编号
		/// @sampleValue enterprise_employee_no 78949922
		///</summary>
		
		private string enterprise_employee_no_;
		
		///<summary>
		/// 员工的手机号
		/// @sampleValue phone_no 13810281234
		///</summary>
		
		private string phone_no_;
		
		///<summary>
		/// 企业员工账号的状态:0在职,1离职
		/// @sampleValue account_type 0
		///</summary>
		
		private int? account_type_;
		
		public string GetEnterprise_employee_no(){
			return this.enterprise_employee_no_;
		}
		
		public void SetEnterprise_employee_no(string value){
			this.enterprise_employee_no_ = value;
		}
		public string GetPhone_no(){
			return this.phone_no_;
		}
		
		public void SetPhone_no(string value){
			this.phone_no_ = value;
		}
		public int? GetAccount_type(){
			return this.account_type_;
		}
		
		public void SetAccount_type(int? value){
			this.account_type_ = value;
		}
		
	}
	
}