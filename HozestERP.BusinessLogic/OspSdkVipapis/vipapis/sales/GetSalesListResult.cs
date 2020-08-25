using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.sales{
	
	
	
	
	
	public class GetSalesListResult {
		
		///<summary>
		/// 总数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 专场列表
		///</summary>
		
		private List<vipapis.sales.Sales> salesList_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.sales.Sales> GetSalesList(){
			return this.salesList_;
		}
		
		public void SetSalesList(List<vipapis.sales.Sales> value){
			this.salesList_ = value;
		}
		
	}
	
}