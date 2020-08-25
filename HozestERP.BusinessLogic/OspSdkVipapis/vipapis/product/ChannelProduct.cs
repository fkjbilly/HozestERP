using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ChannelProduct {
		
		///<summary>
		/// 商品库商品id
		/// @sampleValue vendor_spu_id 13092
		///</summary>
		
		private string vendor_spu_id_;
		
		///<summary>
		/// 档期ID
		/// @sampleValue schedule_id 13092
		///</summary>
		
		private long? schedule_id_;
		
		///<summary>
		/// PC开售时间
		/// @sampleValue sell_time_from 2014-11-08 10:00:00
		///</summary>
		
		private string sell_time_from_;
		
		///<summary>
		/// PC下线时间
		/// @sampleValue sell_time_to 2014-11-15 23:59:59
		///</summary>
		
		private string sell_time_to_;
		
		///<summary>
		/// 货号
		/// @sampleValue art_no 598955-K09768
		///</summary>
		
		private string art_no_;
		
		///<summary>
		/// 商品ID
		/// @sampleValue product_id 29698121
		///</summary>
		
		private long? product_id_;
		
		///<summary>
		/// 商品名称
		/// @sampleValue product_name 荔枝纹帅气桔黄色帆船鞋
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 唯品会售价
		/// @sampleValue sell_price 219
		///</summary>
		
		private double? sell_price_;
		
		///<summary>
		/// 市场价
		/// @sampleValue market_price 1130
		///</summary>
		
		private double? market_price_;
		
		///<summary>
		/// 商品折扣信息
		/// @sampleValue agio 1.9折
		///</summary>
		
		private string agio_;
		
		///<summary>
		/// 商品状态 0未发布，1发布
		/// @sampleValue status 1
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 规格分为 ：尺寸,尺码，大小
		/// @sampleValue standard 3
		///</summary>
		
		private string standard_;
		
		///<summary>
		/// 洗涤建议
		/// @sampleValue washing_instruct 可最高温度30度常规手洗，不可氯漂，不可转笼干燥，可低温熨烫，可缓和干洗
		///</summary>
		
		private string washing_instruct_;
		
		///<summary>
		/// 商品颜色
		/// @sampleValue color 黑色
		///</summary>
		
		private string color_;
		
		///<summary>
		/// 商品材质
		/// @sampleValue material 面材质:头层牛皮;里材质:猪皮;鞋底材料:橡胶底;
		///</summary>
		
		private string material_;
		
		///<summary>
		/// 商品备注
		/// @sampleValue accessory_info 商品备注
		///</summary>
		
		private string accessory_info_;
		
		///<summary>
		/// 商品描述
		/// @sampleValue product_description 描述或商品描述图
		///</summary>
		
		private string product_description_;
		
		///<summary>
		/// 商品重量属性(0:普通，1:小件;2:中件;3大件)
		/// @sampleValue weight_type 0
		///</summary>
		
		private string weight_type_;
		
		///<summary>
		/// 大标题
		/// @sampleValue title_big 69元，抢购原价298元的2NE1女款软木拖鞋
		///</summary>
		
		private string title_big_;
		
		///<summary>
		/// 小标题
		/// @sampleValue title_small [免邮]仅售69元，原价298元的2NE1女款软木拖鞋（三色选）
		///</summary>
		
		private string title_small_;
		
		///<summary>
		/// 售后说明
		/// @sampleValue sale_service 凭保修证1年保修
		///</summary>
		
		private string sale_service_;
		
		///<summary>
		/// 产地
		/// @sampleValue area_output 中国广东
		///</summary>
		
		private string area_output_;
		
		///<summary>
		/// 品牌编号
		/// @sampleValue brand_id 10010363
		///</summary>
		
		private string brand_id_;
		
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
		/// 仓库名称
		/// @sampleValue warehouses VIP_NH
		///</summary>
		
		private string warehouses_;
		
		///<summary>
		/// 尺码
		/// @sampleValue size 39;40;41;
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 尺码表id
		/// @sampleValue size_table_id 1123
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 一句话商品描述
		/// @sampleValue point_describe 一句话商品描述
		///</summary>
		
		private string point_describe_;
		
		///<summary>
		/// 商品详情页URL
		/// @sampleValue product_url http://www.vip.com/detail-221606-29698121.html
		///</summary>
		
		private string product_url_;
		
		public string GetVendor_spu_id(){
			return this.vendor_spu_id_;
		}
		
		public void SetVendor_spu_id(string value){
			this.vendor_spu_id_ = value;
		}
		public long? GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(long? value){
			this.schedule_id_ = value;
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
		public string GetArt_no(){
			return this.art_no_;
		}
		
		public void SetArt_no(string value){
			this.art_no_ = value;
		}
		public long? GetProduct_id(){
			return this.product_id_;
		}
		
		public void SetProduct_id(long? value){
			this.product_id_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public double? GetSell_price(){
			return this.sell_price_;
		}
		
		public void SetSell_price(double? value){
			this.sell_price_ = value;
		}
		public double? GetMarket_price(){
			return this.market_price_;
		}
		
		public void SetMarket_price(double? value){
			this.market_price_ = value;
		}
		public string GetAgio(){
			return this.agio_;
		}
		
		public void SetAgio(string value){
			this.agio_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetStandard(){
			return this.standard_;
		}
		
		public void SetStandard(string value){
			this.standard_ = value;
		}
		public string GetWashing_instruct(){
			return this.washing_instruct_;
		}
		
		public void SetWashing_instruct(string value){
			this.washing_instruct_ = value;
		}
		public string GetColor(){
			return this.color_;
		}
		
		public void SetColor(string value){
			this.color_ = value;
		}
		public string GetMaterial(){
			return this.material_;
		}
		
		public void SetMaterial(string value){
			this.material_ = value;
		}
		public string GetAccessory_info(){
			return this.accessory_info_;
		}
		
		public void SetAccessory_info(string value){
			this.accessory_info_ = value;
		}
		public string GetProduct_description(){
			return this.product_description_;
		}
		
		public void SetProduct_description(string value){
			this.product_description_ = value;
		}
		public string GetWeight_type(){
			return this.weight_type_;
		}
		
		public void SetWeight_type(string value){
			this.weight_type_ = value;
		}
		public string GetTitle_big(){
			return this.title_big_;
		}
		
		public void SetTitle_big(string value){
			this.title_big_ = value;
		}
		public string GetTitle_small(){
			return this.title_small_;
		}
		
		public void SetTitle_small(string value){
			this.title_small_ = value;
		}
		public string GetSale_service(){
			return this.sale_service_;
		}
		
		public void SetSale_service(string value){
			this.sale_service_ = value;
		}
		public string GetArea_output(){
			return this.area_output_;
		}
		
		public void SetArea_output(string value){
			this.area_output_ = value;
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
		public string GetWarehouses(){
			return this.warehouses_;
		}
		
		public void SetWarehouses(string value){
			this.warehouses_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public long? GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(long? value){
			this.size_table_id_ = value;
		}
		public string GetPoint_describe(){
			return this.point_describe_;
		}
		
		public void SetPoint_describe(string value){
			this.point_describe_ = value;
		}
		public string GetProduct_url(){
			return this.product_url_;
		}
		
		public void SetProduct_url(string value){
			this.product_url_ = value;
		}
		
	}
	
}