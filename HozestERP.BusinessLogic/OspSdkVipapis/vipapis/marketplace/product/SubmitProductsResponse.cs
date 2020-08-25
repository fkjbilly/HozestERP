using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class SubmitProductsResponse {
		
		///<summary>
		/// 商品提交审核结果列表
		///</summary>
		
		private List<vipapis.marketplace.product.SubmitProductsResult> results_;
		
		public List<vipapis.marketplace.product.SubmitProductsResult> GetResults(){
			return this.results_;
		}
		
		public void SetResults(List<vipapis.marketplace.product.SubmitProductsResult> value){
			this.results_ = value;
		}
		
	}
	
}