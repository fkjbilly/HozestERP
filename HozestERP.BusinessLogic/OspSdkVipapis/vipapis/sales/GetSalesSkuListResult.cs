using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.sales{
	
	
	
	
	
	public class GetSalesSkuListResult {
		
		///<summary>
		/// 总数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 专场sku列表
		///</summary>
		
		private List<vipapis.sales.SalesSku> skuList_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.sales.SalesSku> GetSkuList(){
			return this.skuList_;
		}
		
		public void SetSkuList(List<vipapis.sales.SalesSku> value){
			this.skuList_ = value;
		}
		
	}
	
}