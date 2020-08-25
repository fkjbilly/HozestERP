using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class EditProductResponse {
		
		///<summary>
		/// 修改商品（spu）的结果
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