using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ProductSpuInfo {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 525
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 产地
		/// @sampleValue area_output 中国广东
		///</summary>
		
		private string area_output_;
		
		///<summary>
		/// 品牌ID
		/// @sampleValue brand_id 123
		///</summary>
		
		private int? brand_id_;
		
		///<summary>
		/// 商品名称
		/// @sampleValue product_name 头层牛漆皮圆头甜美优雅浅口鞋
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 商品描述
		/// @sampleValue product_description 商品描述
		///</summary>
		
		private string product_description_;
		
		///<summary>
		/// 分类ID(只可录入三级分类ID)
		/// @sampleValue category_id 111
		///</summary>
		
		private int? category_id_;
		
		///<summary>
		/// 款号，同一款号商品不区分颜色、尺码
		/// @sampleValue sn 113113302011
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 商品列表图 (销售图)
		/// @sampleValue small_image http://a.vpimg2.com/upload/merchandise/268892/josiny-14427569401-5.jpg;http://a.vpimg2.com/upload/merchandise/268892/josiny-14427569401-7.jpg;
		///</summary>
		
		private string small_image_;
		
		///<summary>
		/// 商品详情页图 (展示图)
		/// @sampleValue product_image http://a.vpimg4.com/upload/merchandise/268892/josiny-14417742401-1_1.jpg;http://a.vpimg4.com/upload/merchandise/268892/josiny-14417742401-0.jpg;
		///</summary>
		
		private string product_image_;
		
		///<summary>
		/// 商品属性
		/// @sampleValue product_props 面材质：头层牛皮，里材质：猪皮，鞋底材料：橡胶底
		///</summary>
		
		private Dictionary<string, string> product_props_;
		
		///<summary>
		/// 市场价 （吊牌价）
		/// @sampleValue market_price 739
		///</summary>
		
		private double? market_price_;
		
		///<summary>
		/// 销售价（参考值）
		/// @sampleValue sell_price 259
		///</summary>
		
		private double? sell_price_;
		
		///<summary>
		/// 增值税率
		/// @sampleValue tax_rate 0/13/17
		///</summary>
		
		private double? tax_rate_;
		
		///<summary>
		/// 售卖单位（台、双、本、支、片、个、套、件、副、束、盒）
		/// @sampleValue unit 双
		///</summary>
		
		private vipapis.product.Unit? unit_;
		
		///<summary>
		/// 是否航空禁运品0否1是（已废弃）
		/// @sampleValue is_embargo 1
		///</summary>
		
		private int? is_embargo_;
		
		///<summary>
		/// 是否易碎品0否1是
		/// @sampleValue is_fragile 1
		///</summary>
		
		private int? is_fragile_;
		
		///<summary>
		/// 是否大件0否1是
		/// @sampleValue is_large 1
		///</summary>
		
		private int? is_large_;
		
		///<summary>
		/// 是否贵重品0否1是
		/// @sampleValue is_precious 1
		///</summary>
		
		private int? is_precious_;
		
		///<summary>
		/// 是否消费税0否1是
		/// @sampleValue is_consumption_tax 1
		///</summary>
		
		private int? is_consumption_tax_;
		
		///<summary>
		/// 是否美妆商品；0否1是
		/// @sampleValue is_makeup 1
		///</summary>
		
		private int? is_makeup_;
		
		///<summary>
		/// 是否3D试戴品；0否1是
		/// @sampleValue is_3d_try 1
		///</summary>
		
		private int? is_3d_try_;
		
		///<summary>
		/// 是否有效管理；0否1是
		/// @sampleValue is_need_valid 1
		///</summary>
		
		private int? is_need_valid_;
		
		///<summary>
		/// 洗涤说明/使用说明
		/// @sampleValue washing_instruct 不可机洗
		///</summary>
		
		private string washing_instruct_;
		
		///<summary>
		/// 售后说明
		/// @sampleValue sale_service 凭保修证1年保修
		///</summary>
		
		private string sale_service_;
		
		///<summary>
		/// 核心概述
		/// @sampleValue sub_title 正品保证
		///</summary>
		
		private string sub_title_;
		
		///<summary>
		/// 备注（其它信息）
		/// @sampleValue accessory_info 鞋跟跟高：10cm、防水台高：2cm、筒高：20cm、筒围：20cm
		///</summary>
		
		private string accessory_info_;
		
		///<summary>
		/// 图片视频
		/// @sampleValue video_url http://www.youku.com/
		///</summary>
		
		private string video_url_;
		
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
		/// @sampleValue weight 0.1
		///</summary>
		
		private double? weight_;
		
		///<summary>
		/// 商品状态
		/// @sampleValue status 待提交
		///</summary>
		
		private vipapis.product.ProductStatus? status_;
		
		///<summary>
		/// 商品类型
		/// @sampleValue product_type 普通商品
		///</summary>
		
		private vipapis.product.ProductType? product_type_;
		
		///<summary>
		/// 尺码表id
		/// @sampleValue size_table_id 
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 货币单位
		/// @sampleValue currency USD
		///</summary>
		
		private vipapis.common.Currency? currency_;
		
		///<summary>
		/// 供货价
		/// @sampleValue supply_price 1
		///</summary>
		
		private double? supply_price_;
		
		///<summary>
		/// 毛重（g）
		/// @sampleValue gross_weight 1
		///</summary>
		
		private int? gross_weight_;
		
		///<summary>
		/// 原始款号
		/// @sampleValue ogn 141324132
		///</summary>
		
		private string ogn_;
		
		///<summary>
		/// 自定义商品属性
		/// @sampleValue vendor_product_props 材质：牛皮
		///</summary>
		
		private Dictionary<string, string> vendor_product_props_;
		
		///<summary>
		/// 图片列表
		/// @sampleValue images 
		///</summary>
		
		private List<vipapis.product.ProductImage> images_;
		
		///<summary>
		/// sku列表
		/// @sampleValue sku_item_list 
		///</summary>
		
		private List<vipapis.product.SkuInfo> sku_item_list_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
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
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetProduct_description(){
			return this.product_description_;
		}
		
		public void SetProduct_description(string value){
			this.product_description_ = value;
		}
		public int? GetCategory_id(){
			return this.category_id_;
		}
		
		public void SetCategory_id(int? value){
			this.category_id_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
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
		public Dictionary<string, string> GetProduct_props(){
			return this.product_props_;
		}
		
		public void SetProduct_props(Dictionary<string, string> value){
			this.product_props_ = value;
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
		public double? GetTax_rate(){
			return this.tax_rate_;
		}
		
		public void SetTax_rate(double? value){
			this.tax_rate_ = value;
		}
		public vipapis.product.Unit? GetUnit(){
			return this.unit_;
		}
		
		public void SetUnit(vipapis.product.Unit? value){
			this.unit_ = value;
		}
		public int? GetIs_embargo(){
			return this.is_embargo_;
		}
		
		public void SetIs_embargo(int? value){
			this.is_embargo_ = value;
		}
		public int? GetIs_fragile(){
			return this.is_fragile_;
		}
		
		public void SetIs_fragile(int? value){
			this.is_fragile_ = value;
		}
		public int? GetIs_large(){
			return this.is_large_;
		}
		
		public void SetIs_large(int? value){
			this.is_large_ = value;
		}
		public int? GetIs_precious(){
			return this.is_precious_;
		}
		
		public void SetIs_precious(int? value){
			this.is_precious_ = value;
		}
		public int? GetIs_consumption_tax(){
			return this.is_consumption_tax_;
		}
		
		public void SetIs_consumption_tax(int? value){
			this.is_consumption_tax_ = value;
		}
		public int? GetIs_makeup(){
			return this.is_makeup_;
		}
		
		public void SetIs_makeup(int? value){
			this.is_makeup_ = value;
		}
		public int? GetIs_3d_try(){
			return this.is_3d_try_;
		}
		
		public void SetIs_3d_try(int? value){
			this.is_3d_try_ = value;
		}
		public int? GetIs_need_valid(){
			return this.is_need_valid_;
		}
		
		public void SetIs_need_valid(int? value){
			this.is_need_valid_ = value;
		}
		public string GetWashing_instruct(){
			return this.washing_instruct_;
		}
		
		public void SetWashing_instruct(string value){
			this.washing_instruct_ = value;
		}
		public string GetSale_service(){
			return this.sale_service_;
		}
		
		public void SetSale_service(string value){
			this.sale_service_ = value;
		}
		public string GetSub_title(){
			return this.sub_title_;
		}
		
		public void SetSub_title(string value){
			this.sub_title_ = value;
		}
		public string GetAccessory_info(){
			return this.accessory_info_;
		}
		
		public void SetAccessory_info(string value){
			this.accessory_info_ = value;
		}
		public string GetVideo_url(){
			return this.video_url_;
		}
		
		public void SetVideo_url(string value){
			this.video_url_ = value;
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
		public vipapis.product.ProductStatus? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(vipapis.product.ProductStatus? value){
			this.status_ = value;
		}
		public vipapis.product.ProductType? GetProduct_type(){
			return this.product_type_;
		}
		
		public void SetProduct_type(vipapis.product.ProductType? value){
			this.product_type_ = value;
		}
		public long? GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(long? value){
			this.size_table_id_ = value;
		}
		public vipapis.common.Currency? GetCurrency(){
			return this.currency_;
		}
		
		public void SetCurrency(vipapis.common.Currency? value){
			this.currency_ = value;
		}
		public double? GetSupply_price(){
			return this.supply_price_;
		}
		
		public void SetSupply_price(double? value){
			this.supply_price_ = value;
		}
		public int? GetGross_weight(){
			return this.gross_weight_;
		}
		
		public void SetGross_weight(int? value){
			this.gross_weight_ = value;
		}
		public string GetOgn(){
			return this.ogn_;
		}
		
		public void SetOgn(string value){
			this.ogn_ = value;
		}
		public Dictionary<string, string> GetVendor_product_props(){
			return this.vendor_product_props_;
		}
		
		public void SetVendor_product_props(Dictionary<string, string> value){
			this.vendor_product_props_ = value;
		}
		public List<vipapis.product.ProductImage> GetImages(){
			return this.images_;
		}
		
		public void SetImages(List<vipapis.product.ProductImage> value){
			this.images_ = value;
		}
		public List<vipapis.product.SkuInfo> GetSku_item_list(){
			return this.sku_item_list_;
		}
		
		public void SetSku_item_list(List<vipapis.product.SkuInfo> value){
			this.sku_item_list_ = value;
		}
		
	}
	
}