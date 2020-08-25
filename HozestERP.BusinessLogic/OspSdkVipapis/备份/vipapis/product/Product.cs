using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class Product {
		
		///<summary>
		/// 档期ID
		/// @sampleValue schedule_id 13092
		///</summary>
		
		private int? schedule_id_;
		
		///<summary>
		/// 商品ID
		/// @sampleValue product_id 29698121
		///</summary>
		
		private int? product_id_;
		
		///<summary>
		/// 商品名称
		/// @sampleValue product_name 荔枝纹帅气桔黄色帆船鞋
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 品牌编号
		/// @sampleValue brand_store_sn 10010363
		///</summary>
		
		private string brand_store_sn_;
		
		///<summary>
		/// 品牌中文名称
		/// @sampleValue brand_name 木林森
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 品牌英文名称
		/// @sampleValue brand_name_eng MULINSEN
		///</summary>
		
		private string brand_name_eng_;
		
		///<summary>
		/// 品牌地址
		/// @sampleValue brand_url http://brand.vip.com/mulinsen/
		///</summary>
		
		private string brand_url_;
		
		///<summary>
		/// 商品市场价格
		/// @sampleValue market_price 1130
		///</summary>
		
		private double? market_price_;
		
		///<summary>
		/// 商品现卖价格
		/// @sampleValue sell_price 219
		///</summary>
		
		private double? sell_price_;
		
		///<summary>
		/// 商品折扣信息
		/// @sampleValue agio 1.9折
		///</summary>
		
		private string agio_;
		
		///<summary>
		/// 商品是否有库存  1=有货 0=没货
		/// @sampleValue has_stock 1
		///</summary>
		
		private int? has_stock_;
		
		///<summary>
		/// 商品详情页URL
		/// @sampleValue product_url http://www.vip.com/detail-221606-29698121.html
		///</summary>
		
		private string product_url_;
		
		///<summary>
		/// 商品详情页小图
		/// @sampleValue small_image http://a.vpimg1.com/upload/merchandise/221606/MULINSEN-2202293202-5.jpg
		///</summary>
		
		private string small_image_;
		
		///<summary>
		/// 商品详情页大图
		/// @sampleValue product_image 
		///</summary>
		
		private string product_image_;
		
		///<summary>
		/// 商品详细页展示图片集
		/// @sampleValue show_image [""]
		///</summary>
		
		private List<string> show_image_;
		
		///<summary>
		/// 商品详情页URL(移动端专用)
		/// @sampleValue product_mobile_url http://m.vip.com/product-221606-29698121.html
		///</summary>
		
		private string product_mobile_url_;
		
		///<summary>
		/// 商品详情页图片(移动端专用)
		/// @sampleValue product_mobile_image 
		///</summary>
		
		private string product_mobile_image_;
		
		///<summary>
		/// 商品分类ID
		/// @sampleValue category_id 11
		///</summary>
		
		private int? category_id_;
		
		///<summary>
		/// 商品导航分类id1
		/// @sampleValue nav_category_id1 ["3"]
		///</summary>
		
		private List<string> nav_category_id1_;
		
		///<summary>
		/// 商品导航分类id2
		/// @sampleValue nav_category_id2 ["14"]
		///</summary>
		
		private List<string> nav_category_id2_;
		
		///<summary>
		/// 商品导航分类id3
		/// @sampleValue nav_category_id3 ["505"]
		///</summary>
		
		private List<string> nav_category_id3_;
		
		///<summary>
		/// 商品导航分类名称1
		/// @sampleValue nav_first_name ["鞋类"]
		///</summary>
		
		private List<string> nav_first_name_;
		
		///<summary>
		/// 商品导航分类名称2
		/// @sampleValue nav_second_name ["男鞋"]
		///</summary>
		
		private List<string> nav_second_name_;
		
		///<summary>
		/// 商品分类名称3
		/// @sampleValue nav_third_name ["休闲鞋"]
		///</summary>
		
		private List<string> nav_third_name_;
		
		///<summary>
		/// 仓库名称
		/// @sampleValue warehouses ["VIP_NH","VIP_BJ"]
		///</summary>
		
		private List<string> warehouses_;
		
		///<summary>
		/// 开售时间
		/// @sampleValue sell_time_from 2014-11-08 10:00:00
		///</summary>
		
		private string sell_time_from_;
		
		///<summary>
		/// 下线时间
		/// @sampleValue sell_time_to 2014-11-15 23:59:59
		///</summary>
		
		private string sell_time_to_;
		
		///<summary>
		/// PC开售时间
		/// @sampleValue pc_show_from 2014-11-08 10:00:00
		///</summary>
		
		private string pc_show_from_;
		
		///<summary>
		/// PC下线时间
		/// @sampleValue pc_show_to 2014-11-15 23:59:59
		///</summary>
		
		private string pc_show_to_;
		
		///<summary>
		/// 移动端开售时间
		/// @sampleValue mobile_show_from 2014-11-08 10:00:00
		///</summary>
		
		private string mobile_show_from_;
		
		///<summary>
		/// 移动端下线时间
		/// @sampleValue mobile_show_to 2014-11-15 23:59:59
		///</summary>
		
		private string mobile_show_to_;
		
		///<summary>
		/// 频道ID
		/// @sampleValue channels ["4"]
		///</summary>
		
		private List<string> channels_;
		
		public int? GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(int? value){
			this.schedule_id_ = value;
		}
		public int? GetProduct_id(){
			return this.product_id_;
		}
		
		public void SetProduct_id(int? value){
			this.product_id_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetBrand_store_sn(){
			return this.brand_store_sn_;
		}
		
		public void SetBrand_store_sn(string value){
			this.brand_store_sn_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetBrand_name_eng(){
			return this.brand_name_eng_;
		}
		
		public void SetBrand_name_eng(string value){
			this.brand_name_eng_ = value;
		}
		public string GetBrand_url(){
			return this.brand_url_;
		}
		
		public void SetBrand_url(string value){
			this.brand_url_ = value;
		}
		public double? GetMarket_price(){
			return this.market_price_;
		}
		
		public void SetMarket_price(double? value){
			this.market_price_ = value;
		}
		public double? GetSell_price(){
			return this.sell_price_;
		}
		
		public void SetSell_price(double? value){
			this.sell_price_ = value;
		}
		public string GetAgio(){
			return this.agio_;
		}
		
		public void SetAgio(string value){
			this.agio_ = value;
		}
		public int? GetHas_stock(){
			return this.has_stock_;
		}
		
		public void SetHas_stock(int? value){
			this.has_stock_ = value;
		}
		public string GetProduct_url(){
			return this.product_url_;
		}
		
		public void SetProduct_url(string value){
			this.product_url_ = value;
		}
		public string GetSmall_image(){
			return this.small_image_;
		}
		
		public void SetSmall_image(string value){
			this.small_image_ = value;
		}
		public string GetProduct_image(){
			return this.product_image_;
		}
		
		public void SetProduct_image(string value){
			this.product_image_ = value;
		}
		public List<string> GetShow_image(){
			return this.show_image_;
		}
		
		public void SetShow_image(List<string> value){
			this.show_image_ = value;
		}
		public string GetProduct_mobile_url(){
			return this.product_mobile_url_;
		}
		
		public void SetProduct_mobile_url(string value){
			this.product_mobile_url_ = value;
		}
		public string GetProduct_mobile_image(){
			return this.product_mobile_image_;
		}
		
		public void SetProduct_mobile_image(string value){
			this.product_mobile_image_ = value;
		}
		public int? GetCategory_id(){
			return this.category_id_;
		}
		
		public void SetCategory_id(int? value){
			this.category_id_ = value;
		}
		public List<string> GetNav_category_id1(){
			return this.nav_category_id1_;
		}
		
		public void SetNav_category_id1(List<string> value){
			this.nav_category_id1_ = value;
		}
		public List<string> GetNav_category_id2(){
			return this.nav_category_id2_;
		}
		
		public void SetNav_category_id2(List<string> value){
			this.nav_category_id2_ = value;
		}
		public List<string> GetNav_category_id3(){
			return this.nav_category_id3_;
		}
		
		public void SetNav_category_id3(List<string> value){
			this.nav_category_id3_ = value;
		}
		public List<string> GetNav_first_name(){
			return this.nav_first_name_;
		}
		
		public void SetNav_first_name(List<string> value){
			this.nav_first_name_ = value;
		}
		public List<string> GetNav_second_name(){
			return this.nav_second_name_;
		}
		
		public void SetNav_second_name(List<string> value){
			this.nav_second_name_ = value;
		}
		public List<string> GetNav_third_name(){
			return this.nav_third_name_;
		}
		
		public void SetNav_third_name(List<string> value){
			this.nav_third_name_ = value;
		}
		public List<string> GetWarehouses(){
			return this.warehouses_;
		}
		
		public void SetWarehouses(List<string> value){
			this.warehouses_ = value;
		}
		public string GetSell_time_from(){
			return this.sell_time_from_;
		}
		
		public void SetSell_time_from(string value){
			this.sell_time_from_ = value;
		}
		public string GetSell_time_to(){
			return this.sell_time_to_;
		}
		
		public void SetSell_time_to(string value){
			this.sell_time_to_ = value;
		}
		public string GetPc_show_from(){
			return this.pc_show_from_;
		}
		
		public void SetPc_show_from(string value){
			this.pc_show_from_ = value;
		}
		public string GetPc_show_to(){
			return this.pc_show_to_;
		}
		
		public void SetPc_show_to(string value){
			this.pc_show_to_ = value;
		}
		public string GetMobile_show_from(){
			return this.mobile_show_from_;
		}
		
		public void SetMobile_show_from(string value){
			this.mobile_show_from_ = value;
		}
		public string GetMobile_show_to(){
			return this.mobile_show_to_;
		}
		
		public void SetMobile_show_to(string value){
			this.mobile_show_to_ = value;
		}
		public List<string> GetChannels(){
			return this.channels_;
		}
		
		public void SetChannels(List<string> value){
			this.channels_ = value;
		}
		
	}
	
}