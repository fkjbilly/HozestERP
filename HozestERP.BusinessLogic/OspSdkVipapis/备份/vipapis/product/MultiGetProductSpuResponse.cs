using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class MultiGetProductSpuResponse {
		
		///<summary>
		/// 商品列表信息
		///</summary>
		
		private List<vipapis.product.ProductSpuInfo> products_;
		
		///<summary>
		/// 当前页返回总记录数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.product.ProductSpuInfo> GetProducts(){
			return this.products_;
		}
		
		public void SetProducts(List<vipapis.product.ProductSpuInfo> value){
			this.products_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}