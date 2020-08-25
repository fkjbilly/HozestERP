using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class AppendSkusResponse {
		
		///<summary>
		/// 增加sku的结果
		///</summary>
		
		private bool? success_;
		
		///<summary>
		/// 增加sku失败信息
		///</summary>
		
		private string error_msg_;
		
		///<summary>
		/// 商品（spu）ID，
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 新增成功的sku列表
		///</summary>
		
		private List<vipapis.marketplace.product.SuccessSku> success_skus_;
		
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