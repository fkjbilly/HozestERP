using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class AddProductRequest {
		
		///<summary>
		/// 外部商品（SPU）编号
		/// @sampleValue outer_spu_id 112
		///</summary>
		
		private string outer_spu_id_;
		
		///<summary>
		/// 商品名称
		/// @sampleValue title 优雅浅口鞋
		///</summary>
		
		private string title_;
		
		///<summary>
		/// 三级分类
		/// @sampleValue third_category_id 112
		///</summary>
		
		private int? third_category_id_;
		
		///<summary>
		/// 品牌ID
		/// @sampleValue brand_id 112
		///</summary>
		
		private int? brand_id_;
		
		///<summary>
		/// 款图列表，新增商品（SPU）时，index=1的图片必传
		///</summary>
		
		private List<vipapis.marketplace.product.Image> images_;
		
		///<summary>
		/// 子商品名
		/// @sampleValue sub_title 头层牛漆皮圆头甜美优雅
		///</summary>
		
		private string sub_title_;
		
		///<summary>
		/// 商品属性
		///</summary>
		
		private List<vipapis.marketplace.product.SimpleProperty> prod_props_;
		
		///<summary>
		/// 自定义商品属性
		///</summary>
		
		private Dictionary<string, string> custom_prod_props_;
		
		///<summary>
		/// 产地
		/// @sampleValue area_output 广州
		///</summary>
		
		private string area_output_;
		
		///<summary>
		/// 售后说明
		/// @sampleValue sale_service 凭保修证1年保修
		///</summary>
		
		private string sale_service_;
		
		///<summary>
		/// 配件
		/// @sampleValue accessories 无配件
		///</summary>
		
		private string accessories_;
		
		///<summary>
		/// 长（cm）
		/// @sampleValue length 10
		///</summary>
		
		private int? length_;
		
		///<summary>
		/// 宽（cm）
		/// @sampleValue width 10
		///</summary>
		
		private int? width_;
		
		///<summary>
		/// 高（cm）
		/// @sampleValue height 10
		///</summary>
		
		private int? height_;
		
		///<summary>
		/// 重量（g）
		/// @sampleValue weight 1
		///</summary>
		
		private int? weight_;
		
		///<summary>
		/// 毛重（g）
		/// @sampleValue gross_weight 1
		///</summary>
		
		private int? gross_weight_;
		
		///<summary>
		/// sku列表
		///</summary>
		
		private List<vipapis.marketplace.product.AddSkuItem> skus_;
		
		///<summary>
		/// 色图列表，当sku的销售属性存在颜色（pid=134）是，色图必传，且必须覆盖所有颜色
		///</summary>
		
		private List<vipapis.marketplace.product.ColorImage> color_images_;
		
		public string GetOuter_spu_id(){
			return this.outer_spu_id_;
		}
		
		public void SetOuter_spu_id(string value){
			this.outer_spu_id_ = value;
		}
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public int? GetThird_category_id(){
			return this.third_category_id_;
		}
		
		public void SetThird_category_id(int? value){
			this.third_category_id_ = value;
		}
		public int? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(int? value){
			this.brand_id_ = value;
		}
		public List<vipapis.marketplace.product.Image> GetImages(){
			return this.images_;
		}
		
		public void SetImages(List<vipapis.marketplace.product.Image> value){
			this.images_ = value;
		}
		public string GetSub_title(){
			return this.sub_title_;
		}
		
		public void SetSub_title(string value){
			this.sub_title_ = value;
		}
		public List<vipapis.marketplace.product.SimpleProperty> GetProd_props(){
			return this.prod_props_;
		}
		
		public void SetProd_props(List<vipapis.marketplace.product.SimpleProperty> value){
			this.prod_props_ = value;
		}
		public Dictionary<string, string> GetCustom_prod_props(){
			return this.custom_prod_props_;
		}
		
		public void SetCustom_prod_props(Dictionary<string, string> value){
			this.custom_prod_props_ = value;
		}
		public string GetArea_output(){
			return this.area_output_;
		}
		
		public void SetArea_output(string value){
			this.area_output_ = value;
		}
		public string GetSale_service(){
			return this.sale_service_;
		}
		
		public void SetSale_service(string value){
			this.sale_service_ = value;
		}
		public string GetAccessories(){
			return this.accessories_;
		}
		
		public void SetAccessories(string value){
			this.accessories_ = value;
		}
		public int? GetLength(){
			return this.length_;
		}
		
		public void SetLength(int? value){
			this.length_ = value;
		}
		public int? GetWidth(){
			return this.width_;
		}
		
		public void SetWidth(int? value){
			this.width_ = value;
		}
		public int? GetHeight(){
			return this.height_;
		}
		
		public void SetHeight(int? value){
			this.height_ = value;
		}
		public int? GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(int? value){
			this.weight_ = value;
		}
		public int? GetGross_weight(){
			return this.gross_weight_;
		}
		
		public void SetGross_weight(int? value){
			this.gross_weight_ = value;
		}
		public List<vipapis.marketplace.product.AddSkuItem> GetSkus(){
			return this.skus_;
		}
		
		public void SetSkus(List<vipapis.marketplace.product.AddSkuItem> value){
			this.skus_ = value;
		}
		public List<vipapis.marketplace.product.ColorImage> GetColor_images(){
			return this.color_images_;
		}
		
		public void SetColor_images(List<vipapis.marketplace.product.ColorImage> value){
			this.color_images_ = value;
		}
		
	}
	
}