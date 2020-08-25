using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class SpuWithSkusBaseInfo {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 525
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 品牌ID
		/// @sampleValue brand_id 123
		///</summary>
		
		private int? brand_id_;
		
		///<summary>
		/// 款号
		/// @sampleValue sn 113113302011
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 商品名称
		/// @sampleValue product_name 头层牛漆皮圆头甜美优雅浅口鞋
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 商品状态
		/// @sampleValue status DRAFT
		///</summary>
		
		private vipapis.product.ProductStatus? status_;
		
		///<summary>
		/// sku列表
		///</summary>
		
		private List<vipapis.product.SkuBaseInfo> sku_base_info_list_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(int? value){
			this.brand_id_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public vipapis.product.ProductStatus? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(vipapis.product.ProductStatus? value){
			this.status_ = value;
		}
		public List<vipapis.product.SkuBaseInfo> GetSku_base_info_list(){
			return this.sku_base_info_list_;
		}
		
		public void SetSku_base_info_list(List<vipapis.product.SkuBaseInfo> value){
			this.sku_base_info_list_ = value;
		}
		
	}
	
}