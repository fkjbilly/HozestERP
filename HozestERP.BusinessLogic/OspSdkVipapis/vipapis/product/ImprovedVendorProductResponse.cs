using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ImprovedVendorProductResponse {
		
		///<summary>
		/// 成功数据列表
		///</summary>
		
		private List<vipapis.product.ImprovedVendorProductSuccessItem> success_items_;
		
		///<summary>
		/// 操作失败的数据列表
		///</summary>
		
		private List<vipapis.product.ImprovedVendorProductFailItem> fail_items_;
		
		public List<vipapis.product.ImprovedVendorProductSuccessItem> GetSuccess_items(){
			return this.success_items_;
		}
		
		public void SetSuccess_items(List<vipapis.product.ImprovedVendorProductSuccessItem> value){
			this.success_items_ = value;
		}
		public List<vipapis.product.ImprovedVendorProductFailItem> GetFail_items(){
			return this.fail_items_;
		}
		
		public void SetFail_items(List<vipapis.product.ImprovedVendorProductFailItem> value){
			this.fail_items_ = value;
		}
		
	}
	
}