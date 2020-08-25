using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.sales{
	
	
	
	
	
	public class GetUpcomingSalesSkusResult {
		
		///<summary>
		/// 总记录数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 待售专场SKU列表
		///</summary>
		
		private List<vipapis.sales.UpcomingSalesSku> upcomingSalesSkus_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.sales.UpcomingSalesSku> GetUpcomingSalesSkus(){
			return this.upcomingSalesSkus_;
		}
		
		public void SetUpcomingSalesSkus(List<vipapis.sales.UpcomingSalesSku> value){
			this.upcomingSalesSkus_ = value;
		}
		
	}
	
}