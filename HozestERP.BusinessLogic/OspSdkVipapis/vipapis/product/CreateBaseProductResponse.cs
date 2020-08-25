using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class CreateBaseProductResponse {
		
		///<summary>
		/// 创建非标准商品成功列表
		///</summary>
		
		private List<vipapis.product.CreateBaseProductResult> success_list_;
		
		///<summary>
		/// 创建非标准商品失败列表
		///</summary>
		
		private List<vipapis.product.CreateBaseProductResult> failed_list_;
		
		public List<vipapis.product.CreateBaseProductResult> GetSuccess_list(){
			return this.success_list_;
		}
		
		public void SetSuccess_list(List<vipapis.product.CreateBaseProductResult> value){
			this.success_list_ = value;
		}
		public List<vipapis.product.CreateBaseProductResult> GetFailed_list(){
			return this.failed_list_;
		}
		
		public void SetFailed_list(List<vipapis.product.CreateBaseProductResult> value){
			this.failed_list_ = value;
		}
		
	}
	
}