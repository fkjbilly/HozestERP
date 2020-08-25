using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseAccountResponse {
		
		///<summary>
		/// 总记录数量
		/// @sampleValue total_count 20
		///</summary>
		
		private int? total_count_;
		
		///<summary>
		/// 总记页数
		/// @sampleValue total_page 1
		///</summary>
		
		private int? total_page_;
		
		///<summary>
		/// 查询到的账号升级结果列表
		///</summary>
		
		private List<vipapis.account.EnterpriseAccountResult> enterpriseAccounts_;
		
		public int? GetTotal_count(){
			return this.total_count_;
		}
		
		public void SetTotal_count(int? value){
			this.total_count_ = value;
		}
		public int? GetTotal_page(){
			return this.total_page_;
		}
		
		public void SetTotal_page(int? value){
			this.total_page_ = value;
		}
		public List<vipapis.account.EnterpriseAccountResult> GetEnterpriseAccounts(){
			return this.enterpriseAccounts_;
		}
		
		public void SetEnterpriseAccounts(List<vipapis.account.EnterpriseAccountResult> value){
			this.enterpriseAccounts_ = value;
		}
		
	}
	
}