using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.pg{
	
	
	
	
	
	public class Product {
		
		///<summary>
		/// 产品名称
		///</summary>
		
		private string goods_name_;
		
		///<summary>
		/// 产品条码
		///</summary>
		
		private string goods_barcode_;
		
		///<summary>
		/// 下挂产品条码
		///</summary>
		
		private string under_goods_barcode_;
		
		///<summary>
		/// 下挂产品名称
		///</summary>
		
		private string under_goods_name_;
		
		///<summary>
		/// 下挂产品数量
		///</summary>
		
		private int? under_goods_quantity_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string goods_no_;
		
		///<summary>
		/// 一级品类名称
		///</summary>
		
		private string cat1_name_;
		
		///<summary>
		/// 采购状态
		///</summary>
		
		private string purchase_status_;
		
		///<summary>
		/// 页面价格
		///</summary>
		
		private double? page_sale_price_;
		
		///<summary>
		/// 页面URL
		///</summary>
		
		private string page_url_;
		
		///<summary>
		/// 商品图片1
		///</summary>
		
		private string goods_image_1_;
		
		///<summary>
		/// 商品图片2
		///</summary>
		
		private string goods_image_2_;
		
		///<summary>
		/// 商品图片3
		///</summary>
		
		private string goods_image_3_;
		
		///<summary>
		/// 商品图片4
		///</summary>
		
		private string goods_image_4_;
		
		///<summary>
		/// 商品图片5
		///</summary>
		
		private string goods_image_5_;
		
		///<summary>
		/// 商品图片6
		///</summary>
		
		private string goods_image_6_;
		
		///<summary>
		/// 品牌
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 上架时间
		///</summary>
		
		private string put_shelves_time_;
		
		public string GetGoods_name(){
			return this.goods_name_;
		}
		
		public void SetGoods_name(string value){
			this.goods_name_ = value;
		}
		public string GetGoods_barcode(){
			return this.goods_barcode_;
		}
		
		public void SetGoods_barcode(string value){
			this.goods_barcode_ = value;
		}
		public string GetUnder_goods_barcode(){
			return this.under_goods_barcode_;
		}
		
		public void SetUnder_goods_barcode(string value){
			this.under_goods_barcode_ = value;
		}
		public string GetUnder_goods_name(){
			return this.under_goods_name_;
		}
		
		public void SetUnder_goods_name(string value){
			this.under_goods_name_ = value;
		}
		public int? GetUnder_goods_quantity(){
			return this.under_goods_quantity_;
		}
		
		public void SetUnder_goods_quantity(int? value){
			this.under_goods_quantity_ = value;
		}
		public string GetGoods_no(){
			return this.goods_no_;
		}
		
		public void SetGoods_no(string value){
			this.goods_no_ = value;
		}
		public string GetCat1_name(){
			return this.cat1_name_;
		}
		
		public void SetCat1_name(string value){
			this.cat1_name_ = value;
		}
		public string GetPurchase_status(){
			return this.purchase_status_;
		}
		
		public void SetPurchase_status(string value){
			this.purchase_status_ = value;
		}
		public double? GetPage_sale_price(){
			return this.page_sale_price_;
		}
		
		public void SetPage_sale_price(double? value){
			this.page_sale_price_ = value;
		}
		public string GetPage_url(){
			return this.page_url_;
		}
		
		public void SetPage_url(string value){
			this.page_url_ = value;
		}
		public string GetGoods_image_1(){
			return this.goods_image_1_;
		}
		
		public void SetGoods_image_1(string value){
			this.goods_image_1_ = value;
		}
		public string GetGoods_image_2(){
			return this.goods_image_2_;
		}
		
		public void SetGoods_image_2(string value){
			this.goods_image_2_ = value;
		}
		public string GetGoods_image_3(){
			return this.goods_image_3_;
		}
		
		public void SetGoods_image_3(string value){
			this.goods_image_3_ = value;
		}
		public string GetGoods_image_4(){
			return this.goods_image_4_;
		}
		
		public void SetGoods_image_4(string value){
			this.goods_image_4_ = value;
		}
		public string GetGoods_image_5(){
			return this.goods_image_5_;
		}
		
		public void SetGoods_image_5(string value){
			this.goods_image_5_ = value;
		}
		public string GetGoods_image_6(){
			return this.goods_image_6_;
		}
		
		public void SetGoods_image_6(string value){
			this.goods_image_6_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetPut_shelves_time(){
			return this.put_shelves_time_;
		}
		
		public void SetPut_shelves_time(string value){
			this.put_shelves_time_ = value;
		}
		
	}
	
}