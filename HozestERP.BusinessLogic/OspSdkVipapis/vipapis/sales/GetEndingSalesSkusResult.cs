using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.sales{
	
	
	
	
	
	public class GetEndingSalesSkusResult {
		
		///<summary>
		/// 总记录数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 下线专场SKU列表
		///</summary>
		
		private List<vipapis.sales.EndingSalesSku> endingSalesSkus_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.sales.EndingSalesSku> GetEndingSalesSkus(){
			return this.endingSalesSkus_;
		}
		
		public void SetEndingSalesSkus(List<vipapis.sales.EndingSalesSku> value){
			this.endingSalesSkus_ = value;
		}
		
	}
	
}