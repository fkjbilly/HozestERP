using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class Product {
		
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
		/// 商品标题
		/// @sampleValue title 头层牛漆皮圆头甜美优雅浅口鞋
		///</summary>
		
		private string title_;
		
		///<summary>
		/// 品牌ID
		/// @sampleValue brand_id 1221
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 商品状态
		/// @sampleValue shelf_status 1.上架 0,下架
		///</summary>
		
		private string shelf_status_;
		
		///<summary>
		/// 商品审核状态（11待提交，12待审核，13审核通过，14审核不通过）
		/// @sampleValue audit_status 11
		///</summary>
		
		private string audit_status_;
		
		///<summary>
		/// 类目1级名称
		/// @sampleValue first_category_name 女装
		///</summary>
		
		private string first_category_name_;
		
		///<summary>
		/// 类目2级名称
		/// @sampleValue second_category_name 上装
		///</summary>
		
		private string second_category_name_;
		
		///<summary>
		/// 类目3级名称
		/// @sampleValue third_category_name 外套
		///</summary>
		
		private string third_category_name_;
		
		///<summary>
		/// 商品列表图
		///</summary>
		
		private string image_url_;
		
		///<summary>
		/// sku列表
		///</summary>
		
		private List<string> sku_ids_;
		
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
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetShelf_status(){
			return this.shelf_status_;
		}
		
		public void SetShelf_status(string value){
			this.shelf_status_ = value;
		}
		public string GetAudit_status(){
			return this.audit_status_;
		}
		
		public void SetAudit_status(string value){
			this.audit_status_ = value;
		}
		public string GetFirst_category_name(){
			return this.first_category_name_;
		}
		
		public void SetFirst_category_name(string value){
			this.first_category_name_ = value;
		}
		public string GetSecond_category_name(){
			return this.second_category_name_;
		}
		
		public void SetSecond_category_name(string value){
			this.second_category_name_ = value;
		}
		public string GetThird_category_name(){
			return this.third_category_name_;
		}
		
		public void SetThird_category_name(string value){
			this.third_category_name_ = value;
		}
		public string GetImage_url(){
			return this.image_url_;
		}
		
		public void SetImage_url(string value){
			this.image_url_ = value;
		}
		public List<string> GetSku_ids(){
			return this.sku_ids_;
		}
		
		public void SetSku_ids(List<string> value){
			this.sku_ids_ = value;
		}
		
	}
	
}