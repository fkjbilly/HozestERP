using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class AppendSkuResponse {
		
		///<summary>
		/// 成功sku列表
		///</summary>
		
		private List<vipapis.product.SuccessSkuItem> success_sku_list_;
		
		///<summary>
		/// 失败sku列表
		///</summary>
		
		private List<vipapis.product.VendorProductFailItem> fail_sku_list_;
		
		public List<vipapis.product.SuccessSkuItem> GetSuccess_sku_list(){
			return this.success_sku_list_;
		}
		
		public void SetSuccess_sku_list(List<vipapis.product.SuccessSkuItem> value){
			this.success_sku_list_ = value;
		}
		public List<vipapis.product.VendorProductFailItem> GetFail_sku_list(){
			return this.fail_sku_list_;
		}
		
		public void SetFail_sku_list(List<vipapis.product.VendorProductFailItem> value){
			this.fail_sku_list_ = value;
		}
		
	}
	
}