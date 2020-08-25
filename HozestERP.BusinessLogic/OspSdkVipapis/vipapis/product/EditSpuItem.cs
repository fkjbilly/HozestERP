using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class EditSpuItem {
		
		///<summary>
		/// 分类ID(只可录入三级分类ID,<font color='red'>修改类目后，需要相应的根据类目维护好商品属性以及销售属性</font>)
		/// @sampleValue category_id 111
		///</summary>
		
		private int? category_id_;
		
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
		/// 产地
		/// @sampleValue area_output 中国广东
		///</summary>
		
		private string area_output_;
		
		///<summary>
		/// 商品属性（将逐步废弃，建议使用新的商品属性字段simple_product_props）
		/// @sampleValue product_props 583:5428
		///</summary>
		
		private Dictionary<string, string> product_props_;
		
		///<summary>
		/// 自定义商品属性
		/// @sampleValue vendor_product_props 材质：牛皮
		///</summary>
		
		private Dictionary<string, string> vendor_product_props_;
		
		///<summary>
		/// 增值税率
		/// @sampleValue tax_rate 0/13/17
		///</summary>
		
		private double? tax_rate_;
		
		///<summary>
		/// 售卖单位（台、双、本、支、片、个、套、件、副、束、盒 等）
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
		/// <s><font color='red'>是否消费税0否1是(已废弃，该属性不再支持编辑)</font></s>
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
		/// 毛重（g）
		/// @sampleValue gross_weight 1.0
		///</summary>
		
		private double? gross_weight_;
		
		///<summary>
		/// 重量（g）
		/// @sampleValue weight 1
		///</summary>
		
		private double? weight_;
		
		///<summary>
		/// 商品类型
		/// @sampleValue product_type 普通商品
		///</summary>
		
		private vipapis.product.ProductType? product_type_;
		
		///<summary>
		/// 货币单位
		/// @sampleValue currency USD，CNY，EUR，GBP
		///</summary>
		
		private vipapis.common.Currency? currency_;
		
		///<summary>
		/// sku列表
		/// @sampleValue sku_item_list 
		///</summary>
		
		private List<vipapis.product.EditSkuItem> sku_item_list_;
		
		///<summary>
		/// 简化版商品属性
		///</summary>
		
		private List<vipapis.product.SimpleProperty> simple_product_props_;
		
		public int? GetCategory_id(){
			return this.category_id_;
		}
		
		public void SetCategory_id(int? value){
			this.category_id_ = value;
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
		public string GetArea_output(){
			return this.area_output_;
		}
		
		public void SetArea_output(string value){
			this.area_output_ = value;
		}
		public Dictionary<string, string> GetProduct_props(){
			return this.product_props_;
		}
		
		public void SetProduct_props(Dictionary<string, string> value){
			this.product_props_ = value;
		}
		public Dictionary<string, string> GetVendor_product_props(){
			return this.vendor_product_props_;
		}
		
		public void SetVendor_product_props(Dictionary<string, string> value){
			this.vendor_product_props_ = value;
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
		public double? GetGross_weight(){
			return this.gross_weight_;
		}
		
		public void SetGross_weight(double? value){
			this.gross_weight_ = value;
		}
		public double? GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(double? value){
			this.weight_ = value;
		}
		public vipapis.product.ProductType? GetProduct_type(){
			return this.product_type_;
		}
		
		public void SetProduct_type(vipapis.product.ProductType? value){
			this.product_type_ = value;
		}
		public vipapis.common.Currency? GetCurrency(){
			return this.currency_;
		}
		
		public void SetCurrency(vipapis.common.Currency? value){
			this.currency_ = value;
		}
		public List<vipapis.product.EditSkuItem> GetSku_item_list(){
			return this.sku_item_list_;
		}
		
		public void SetSku_item_list(List<vipapis.product.EditSkuItem> value){
			this.sku_item_list_ = value;
		}
		public List<vipapis.product.SimpleProperty> GetSimple_product_props(){
			return this.simple_product_props_;
		}
		
		public void SetSimple_product_props(List<vipapis.product.SimpleProperty> value){
			this.simple_product_props_ = value;
		}
		
	}
	
}