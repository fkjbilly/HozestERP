using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetSkuPriceResponse {
		
		///<summary>
		/// 供货价列表
		///</summary>
		
		private List<vipapis.delivery.PriceInfo> price_list_;
		
		public List<vipapis.delivery.PriceInfo> GetPrice_list(){
			return this.price_list_;
		}
		
		public void SetPrice_list(List<vipapis.delivery.PriceInfo> value){
			this.price_list_ = value;
		}
		
	}
	
}