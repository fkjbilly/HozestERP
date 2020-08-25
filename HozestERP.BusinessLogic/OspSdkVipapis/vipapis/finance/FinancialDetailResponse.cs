using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class FinancialDetailResponse {
		
		///<summary>
		/// 财务明细信息列表
		///</summary>
		
		private List<vipapis.finance.FinancialDetail> details_;
		
		///<summary>
		/// 总记录数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.finance.FinancialDetail> GetDetails(){
			return this.details_;
		}
		
		public void SetDetails(List<vipapis.finance.FinancialDetail> value){
			this.details_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}