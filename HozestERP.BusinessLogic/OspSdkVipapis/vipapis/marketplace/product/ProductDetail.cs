using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class ProductDetail {
		
		///<summary>
		/// 商品spu编码
		/// @sampleValue spu_id 525
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 款号(商家在唯品会新增商品时自己录入的spu标识编码)(不可重复)
		/// @sampleValue outer_spu_id 12322111
		///</summary>
		
		private string outer_spu_id_;
		
		///<summary>
		/// sku列表
		///</summary>
		
		private List<vipapis.marketplace.product.SkuDetail> skus_;
		
		///<summary>
		/// 商品名称
		/// @sampleValue title 优雅浅口鞋
		///</summary>
		
		private string title_;
		
		///<summary>
		/// 子商品名
		/// @sampleValue sub_title 头层牛漆皮圆头甜美优雅
		///</summary>
		
		private string sub_title_;
		
		///<summary>
		/// 商品属性
		///</summary>
		
		private Dictionary<string, string> prod_props_;
		
		///<summary>
		/// 自定义商品属性
		///</summary>
		
		private Dictionary<string, string> custom_prod_props_;
		
		///<summary>
		/// 图片列表
		///</summary>
		
		private List<vipapis.marketplace.product.Image> images_;
		
		///<summary>
		/// 产地
		/// @sampleValue area_output 广州
		///</summary>
		
		private string area_output_;
		
		///<summary>
		/// 品牌ID
		/// @sampleValue brand_id 112
		///</summary>
		
		private int? brand_id_;
		
		///<summary>
		/// 品牌名称
		/// @sampleValue brand_name 周大福CHOW TAI FOOK
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 三级分类
		/// @sampleValue third_category_id 112
		///</summary>
		
		private int? third_category_id_;
		
		///<summary>
		/// 售后说明
		/// @sampleValue sale_service 凭保修证1年保修
		///</summary>
		
		private string sale_service_;
		
		///<summary>
		/// 配件
		/// @sampleValue accessories 配件
		///</summary>
		
		private string accessories_;
		
		///<summary>
		/// 长（cm）
		/// @sampleValue length 10
		///</summary>
		
		private double? length_;
		
		///<summary>
		/// 宽（cm）
		/// @sampleValue width 10
		///</summary>
		
		private double? width_;
		
		///<summary>
		/// 高（cm）
		/// @sampleValue high 10
		///</summary>
		
		private double? high_;
		
		///<summary>
		/// 重量（g）
		/// @sampleValue weight 1
		///</summary>
		
		private double? weight_;
		
		///<summary>
		/// 商品状态
		/// @sampleValue audit_status 11待提交，12待审核，13审核通过，14审核不通过
		///</summary>
		
		private string audit_status_;
		
		///<summary>
		/// 尺码表id
		/// @sampleValue size_table_id 尺码表id
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 毛重（g）
		/// @sampleValue gross_weight 1
		///</summary>
		
		private int? gross_weight_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public string GetOuter_spu_id(){
			return this.outer_spu_id_;
		}
		
		public void SetOuter_spu_id(string value){
			this.outer_spu_id_ = value;
		}
		public List<vipapis.marketplace.product.SkuDetail> GetSkus(){
			return this.skus_;
		}
		
		public void SetSkus(List<vipapis.marketplace.product.SkuDetail> value){
			this.skus_ = value;
		}
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public string GetSub_title(){
			return this.sub_title_;
		}
		
		public void SetSub_title(string value){
			this.sub_title_ = value;
		}
		public Dictionary<string, string> GetProd_props(){
			return this.prod_props_;
		}
		
		public void SetProd_props(Dictionary<string, string> value){
			this.prod_props_ = value;
		}
		public Dictionary<string, string> GetCustom_prod_props(){
			return this.custom_prod_props_;
		}
		
		public void SetCustom_prod_props(Dictionary<string, string> value){
			this.custom_prod_props_ = value;
		}
		public List<vipapis.marketplace.product.Image> GetImages(){
			return this.images_;
		}
		
		public void SetImages(List<vipapis.marketplace.product.Image> value){
			this.images_ = value;
		}
		public string GetArea_output(){
			return this.area_output_;
		}
		
		public void SetArea_output(string value){
			this.area_output_ = value;
		}
		public int? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(int? value){
			this.brand_id_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public int? GetThird_category_id(){
			return this.third_category_id_;
		}
		
		public void SetThird_category_id(int? value){
			this.third_category_id_ = value;
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
		public double? GetLength(){
			return this.length_;
		}
		
		public void SetLength(double? value){
			this.length_ = value;
		}
		public double? GetWidth(){
			return this.width_;
		}
		
		public void SetWidth(double? value){
			this.width_ = value;
		}
		public double? GetHigh(){
			return this.high_;
		}
		
		public void SetHigh(double? value){
			this.high_ = value;
		}
		public double? GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(double? value){
			this.weight_ = value;
		}
		public string GetAudit_status(){
			return this.audit_status_;
		}
		
		public void SetAudit_status(string value){
			this.audit_status_ = value;
		}
		public long? GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(long? value){
			this.size_table_id_ = value;
		}
		public int? GetGross_weight(){
			return this.gross_weight_;
		}
		
		public void SetGross_weight(int? value){
			this.gross_weight_ = value;
		}
		
	}
	
}