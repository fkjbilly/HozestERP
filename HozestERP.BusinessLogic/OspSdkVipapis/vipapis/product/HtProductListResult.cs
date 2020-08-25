using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class HtProductListResult {
		
		///<summary>
		/// 当前页码
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 总页数
		///</summary>
		
		private int? total_page_;
		
		///<summary>
		/// 商品列表
		///</summary>
		
		private List<vipapis.product.HtProduct> product_list_;
		
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetTotal_page(){
			return this.total_page_;
		}
		
		public void SetTotal_page(int? value){
			this.total_page_ = value;
		}
		public List<vipapis.product.HtProduct> GetProduct_list(){
			return this.product_list_;
		}
		
		public void SetProduct_list(List<vipapis.product.HtProduct> value){
			this.product_list_ = value;
		}
		
	}
	
}