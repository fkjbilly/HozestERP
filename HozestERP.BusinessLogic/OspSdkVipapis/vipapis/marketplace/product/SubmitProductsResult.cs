using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class SubmitProductsResult {
		
		///<summary>
		/// 商品spuId
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// true:成功 false:失败
		///</summary>
		
		private bool? success_;
		
		///<summary>
		/// 错误信息
		///</summary>
		
		private string error_msg_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public bool? GetSuccess(){
			return this.success_;
		}
		
		public void SetSuccess(bool? value){
			this.success_ = value;
		}
		public string GetError_msg(){
			return this.error_msg_;
		}
		
		public void SetError_msg(string value){
			this.error_msg_ = value;
		}
		
	}
	
}