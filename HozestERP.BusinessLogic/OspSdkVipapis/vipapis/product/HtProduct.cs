using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class HtProduct {
		
		///<summary>
		/// 商品详情页url
		///</summary>
		
		private string url_;
		
		///<summary>
		/// 长标题 
		///</summary>
		
		private string long_title_;
		
		///<summary>
		/// 短标题
		///</summary>
		
		private string short_title_;
		
		///<summary>
		/// 商品id
		///</summary>
		
		private string identify_;
		
		///<summary>
		/// 商品详情页wap地址
		///</summary>
		
		private string wapurl_;
		
		///<summary>
		/// 商品图片地址
		///</summary>
		
		private string img_url_;
		
		///<summary>
		/// 商品图片地址
		///</summary>
		
		private string big_img_url_;
		
		///<summary>
		/// 商品图片地址
		///</summary>
		
		private string long_img_url_;
		
		///<summary>
		/// 现价
		///</summary>
		
		private double? price_;
		
		///<summary>
		/// 国内参考价
		///</summary>
		
		private double? reference_price_;
		
		///<summary>
		/// 原价
		///</summary>
		
		private double? former_price_;
		
		///<summary>
		/// 折扣
		///</summary>
		
		private string discount_;
		
		///<summary>
		/// 销量
		///</summary>
		
		private long? deal_sale_;
		
		///<summary>
		/// 保税/直邮
		///</summary>
		
		private string type_;
		
		///<summary>
		/// 所属国家
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 国旗logo地址
		///</summary>
		
		private string country_logo_;
		
		///<summary>
		/// XXXX保税仓
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 所属网站
		///</summary>
		
		private string site_;
		
		///<summary>
		/// 网站主页url
		///</summary>
		
		private string site_url_;
		
		///<summary>
		/// 大类id
		///</summary>
		
		private string tagid_;
		
		///<summary>
		/// 大类名称
		///</summary>
		
		private string tag_;
		
		///<summary>
		/// 小类id
		///</summary>
		
		private string categoryid_;
		
		///<summary>
		/// 小类名称
		///</summary>
		
		private string category_;
		
		///<summary>
		/// 是否包邮
		///</summary>
		
		private string post_;
		
		///<summary>
		/// 描述
		///</summary>
		
		private string description_;
		
		///<summary>
		/// 开始时间
		///</summary>
		
		private long? starttime_;
		
		///<summary>
		/// 结束时间
		///</summary>
		
		private long? endtime_;
		
		///<summary>
		/// 新品
		///</summary>
		
		private string is_new_;
		
		///<summary>
		/// 品牌id
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string friendly_name_;
		
		///<summary>
		/// 品牌图片url
		///</summary>
		
		private string logo_small_;
		
		public string GetUrl(){
			return this.url_;
		}
		
		public void SetUrl(string value){
			this.url_ = value;
		}
		public string GetLong_title(){
			return this.long_title_;
		}
		
		public void SetLong_title(string value){
			this.long_title_ = value;
		}
		public string GetShort_title(){
			return this.short_title_;
		}
		
		public void SetShort_title(string value){
			this.short_title_ = value;
		}
		public string GetIdentify(){
			return this.identify_;
		}
		
		public void SetIdentify(string value){
			this.identify_ = value;
		}
		public string GetWapurl(){
			return this.wapurl_;
		}
		
		public void SetWapurl(string value){
			this.wapurl_ = value;
		}
		public string GetImg_url(){
			return this.img_url_;
		}
		
		public void SetImg_url(string value){
			this.img_url_ = value;
		}
		public string GetBig_img_url(){
			return this.big_img_url_;
		}
		
		public void SetBig_img_url(string value){
			this.big_img_url_ = value;
		}
		public string GetLong_img_url(){
			return this.long_img_url_;
		}
		
		public void SetLong_img_url(string value){
			this.long_img_url_ = value;
		}
		public double? GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(double? value){
			this.price_ = value;
		}
		public double? GetReference_price(){
			return this.reference_price_;
		}
		
		public void SetReference_price(double? value){
			this.reference_price_ = value;
		}
		public double? GetFormer_price(){
			return this.former_price_;
		}
		
		public void SetFormer_price(double? value){
			this.former_price_ = value;
		}
		public string GetDiscount(){
			return this.discount_;
		}
		
		public void SetDiscount(string value){
			this.discount_ = value;
		}
		public long? GetDeal_sale(){
			return this.deal_sale_;
		}
		
		public void SetDeal_sale(long? value){
			this.deal_sale_ = value;
		}
		public string GetType(){
			return this.type_;
		}
		
		public void SetType(string value){
			this.type_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public string GetCountry_logo(){
			return this.country_logo_;
		}
		
		public void SetCountry_logo(string value){
			this.country_logo_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetSite(){
			return this.site_;
		}
		
		public void SetSite(string value){
			this.site_ = value;
		}
		public string GetSite_url(){
			return this.site_url_;
		}
		
		public void SetSite_url(string value){
			this.site_url_ = value;
		}
		public string GetTagid(){
			return this.tagid_;
		}
		
		public void SetTagid(string value){
			this.tagid_ = value;
		}
		public string GetTag(){
			return this.tag_;
		}
		
		public void SetTag(string value){
			this.tag_ = value;
		}
		public string GetCategoryid(){
			return this.categoryid_;
		}
		
		public void SetCategoryid(string value){
			this.categoryid_ = value;
		}
		public string GetCategory(){
			return this.category_;
		}
		
		public void SetCategory(string value){
			this.category_ = value;
		}
		public string GetPost(){
			return this.post_;
		}
		
		public void SetPost(string value){
			this.post_ = value;
		}
		public string GetDescription(){
			return this.description_;
		}
		
		public void SetDescription(string value){
			this.description_ = value;
		}
		public long? GetStarttime(){
			return this.starttime_;
		}
		
		public void SetStarttime(long? value){
			this.starttime_ = value;
		}
		public long? GetEndtime(){
			return this.endtime_;
		}
		
		public void SetEndtime(long? value){
			this.endtime_ = value;
		}
		public string GetIs_new(){
			return this.is_new_;
		}
		
		public void SetIs_new(string value){
			this.is_new_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetFriendly_name(){
			return this.friendly_name_;
		}
		
		public void SetFriendly_name(string value){
			this.friendly_name_ = value;
		}
		public string GetLogo_small(){
			return this.logo_small_;
		}
		
		public void SetLogo_small(string value){
			this.logo_small_ = value;
		}
		
	}
	
}