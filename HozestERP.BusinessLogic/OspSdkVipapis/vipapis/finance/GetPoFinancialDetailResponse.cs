using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class GetPoFinancialDetailResponse {
		
		///<summary>
		/// 记录总数
		///</summary>
		
		private long? total_;
		
		///<summary>
		/// 是否有下一页
		///</summary>
		
		private bool? has_next_;
		
		///<summary>
		/// 经销业务财务对账数据
		///</summary>
		
		private List<vipapis.finance.PoFinancialDetail> po_financial_details_;
		
		public long? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(long? value){
			this.total_ = value;
		}
		public bool? GetHas_next(){
			return this.has_next_;
		}
		
		public void SetHas_next(bool? value){
			this.has_next_ = value;
		}
		public List<vipapis.finance.PoFinancialDetail> GetPo_financial_details(){
			return this.po_financial_details_;
		}
		
		public void SetPo_financial_details(List<vipapis.finance.PoFinancialDetail> value){
			this.po_financial_details_ = value;
		}
		
	}
	
}