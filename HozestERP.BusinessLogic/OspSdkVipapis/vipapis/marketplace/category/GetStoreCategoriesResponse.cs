using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.category{
	
	
	
	
	
	public class GetStoreCategoriesResponse {
		
		///<summary>
		/// 店铺类目列表
		///</summary>
		
		private List<vipapis.marketplace.category.StoreCategory> categories_;
		
		public List<vipapis.marketplace.category.StoreCategory> GetCategories(){
			return this.categories_;
		}
		
		public void SetCategories(List<vipapis.marketplace.category.StoreCategory> value){
			this.categories_ = value;
		}
		
	}
	
}