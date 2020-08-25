using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class VendorProduct {
		
		///<summary>
		/// 商品标题
		///</summary>
		
		private string title_;
		
		///<summary>
		/// 商品图片地址
		///</summary>
		
		private string image_url_;
		
		///<summary>
		/// 商品类型0: 普通商品,1:赠品,2:自由赠,3:换购商品,4:捆绑销售商品,5:礼品）
		///</summary>
		
		private int? product_type_;
		
		///<summary>
		/// 品牌id
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 品牌名,有中文用中文，否则用英文
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 品牌中文名
		///</summary>
		
		private string brand_cn_name_;
		
		///<summary>
		/// 品牌英文名
		///</summary>
		
		private string brand_en_name_;
		
		///<summary>
		/// 三级类目ID
		///</summary>
		
		private int? third_level_category_id_;
		
		///<summary>
		/// 三级类目的名称
		///</summary>
		
		private string third_level_category_name_;
		
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public string GetImage_url(){
			return this.image_url_;
		}
		
		public void SetImage_url(string value){
			this.image_url_ = value;
		}
		public int? GetProduct_type(){
			return this.product_type_;
		}
		
		public void SetProduct_type(int? value){
			this.product_type_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetBrand_cn_name(){
			return this.brand_cn_name_;
		}
		
		public void SetBrand_cn_name(string value){
			this.brand_cn_name_ = value;
		}
		public string GetBrand_en_name(){
			return this.brand_en_name_;
		}
		
		public void SetBrand_en_name(string value){
			this.brand_en_name_ = value;
		}
		public int? GetThird_level_category_id(){
			return this.third_level_category_id_;
		}
		
		public void SetThird_level_category_id(int? value){
			this.third_level_category_id_ = value;
		}
		public string GetThird_level_category_name(){
			return this.third_level_category_name_;
		}
		
		public void SetThird_level_category_name(string value){
			this.third_level_category_name_ = value;
		}
		
	}
	
}