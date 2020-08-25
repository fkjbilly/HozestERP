using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class AddProductResponse {
		
		///<summary>
		/// 商品（spu）ID，新增成功时返回
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 新增成功的sku列表
		///</summary>
		
		private List<vipapis.marketplace.product.SuccessSku> success_skus_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public List<vipapis.marketplace.product.SuccessSku> GetSuccess_skus(){
			return this.success_skus_;
		}
		
		public void SetSuccess_skus(List<vipapis.marketplace.product.SuccessSku> value){
			this.success_skus_ = value;
		}
		
	}
	
}