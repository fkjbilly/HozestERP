using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class GetProductsResponse {
		
		///<summary>
		/// 商品信息
		///</summary>
		
		private List<vipapis.marketplace.product.Product> products_;
		
		///<summary>
		/// 是否有下一页
		/// @sampleValue has_next true
		///</summary>
		
		private bool? has_next_;
		
		public List<vipapis.marketplace.product.Product> GetProducts(){
			return this.products_;
		}
		
		public void SetProducts(List<vipapis.marketplace.product.Product> value){
			this.products_ = value;
		}
		public bool? GetHas_next(){
			return this.has_next_;
		}
		
		public void SetHas_next(bool? value){
			this.has_next_ = value;
		}
		
	}
	
}