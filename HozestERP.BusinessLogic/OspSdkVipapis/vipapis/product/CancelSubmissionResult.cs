using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class CancelSubmissionResult {
		
		///<summary>
		/// 商品spu信息
		///</summary>
		
		private vipapis.product.VendorProductSN vendorProductSN_;
		
		///<summary>
		/// 是否成功
		///</summary>
		
		private bool? is_success_;
		
		public vipapis.product.VendorProductSN GetVendorProductSN(){
			return this.vendorProductSN_;
		}
		
		public void SetVendorProductSN(vipapis.product.VendorProductSN value){
			this.vendorProductSN_ = value;
		}
		public bool? GetIs_success(){
			return this.is_success_;
		}
		
		public void SetIs_success(bool? value){
			this.is_success_ = value;
		}
		
	}
	
}