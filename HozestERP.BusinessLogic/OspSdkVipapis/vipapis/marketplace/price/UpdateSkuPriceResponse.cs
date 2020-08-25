using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.price{
	
	
	
	
	
	public class UpdateSkuPriceResponse {
		
		///<summary>
		/// 是否成功:true/false
		/// @sampleValue success true
		///</summary>
		
		private bool? success_;
		
		public bool? GetSuccess(){
			return this.success_;
		}
		
		public void SetSuccess(bool? value){
			this.success_ = value;
		}
		
	}
	
}