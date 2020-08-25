using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class ProductQueryResponse {
		
		///<summary>
		/// 分页结构体
		///</summary>
		
		private vipapis.puma.Pagination pagination_;
		
		///<summary>
		/// 商品信息列表
		///</summary>
		
		private List<vipapis.puma.Product> marketing_products_;
		
		public vipapis.puma.Pagination GetPagination(){
			return this.pagination_;
		}
		
		public void SetPagination(vipapis.puma.Pagination value){
			this.pagination_ = value;
		}
		public List<vipapis.puma.Product> GetMarketing_products(){
			return this.marketing_products_;
		}
		
		public void SetMarketing_products(List<vipapis.puma.Product> value){
			this.marketing_products_ = value;
		}
		
	}
	
}