using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class VendorProductResponse {
		
		///<summary>
		/// 成功数据列表
		///</summary>
		
		private List<string> success_barcode_list_;
		
		///<summary>
		/// 操作失败的数据列表
		///</summary>
		
		private List<vipapis.product.VendorProductFailItem> fail_item_list_;
		
		public List<string> GetSuccess_barcode_list(){
			return this.success_barcode_list_;
		}
		
		public void SetSuccess_barcode_list(List<string> value){
			this.success_barcode_list_ = value;
		}
		public List<vipapis.product.VendorProductFailItem> GetFail_item_list(){
			return this.fail_item_list_;
		}
		
		public void SetFail_item_list(List<vipapis.product.VendorProductFailItem> value){
			this.fail_item_list_ = value;
		}
		
	}
	
}