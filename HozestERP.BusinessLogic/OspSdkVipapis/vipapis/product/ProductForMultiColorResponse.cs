using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ProductForMultiColorResponse {
		
		///<summary>
		/// 款号，同一款号商品不区分颜色、尺码
		/// @sampleValue sn 113113302011
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 品牌ID
		/// @sampleValue brand_id 123
		///</summary>
		
		private int? brand_id_;
		
		///<summary>
		/// 失败信息
		/// @sampleValue error_msg 通过品牌id获取不到品牌
		///</summary>
		
		private string error_msg_;
		
		///<summary>
		/// 成功sku列表
		///</summary>
		
		private List<vipapis.product.SuccessSkuItem> success_sku_list_;
		
		///<summary>
		/// 失败sku列表
		///</summary>
		
		private List<vipapis.product.VendorProductFailItem> fail_sku_list_;
		
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		public int? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(int? value){
			this.brand_id_ = value;
		}
		public string GetError_msg(){
			return this.error_msg_;
		}
		
		public void SetError_msg(string value){
			this.error_msg_ = value;
		}
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