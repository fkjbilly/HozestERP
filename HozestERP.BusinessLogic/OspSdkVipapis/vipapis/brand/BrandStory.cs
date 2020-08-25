using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.brand{
	
	
	
	
	
	public class BrandStory {
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 品牌中文名
		///</summary>
		
		private string cn_name_;
		
		///<summary>
		/// 品牌英文名
		///</summary>
		
		private string en_name_;
		
		///<summary>
		/// 品牌logo链接
		///</summary>
		
		private string logo_url_;
		
		///<summary>
		/// 品牌故事链接
		///</summary>
		
		private string brand_url_;
		
		///<summary>
		/// 品牌故事背景图片(banner)
		///</summary>
		
		private string bg_path_;
		
		///<summary>
		/// 品牌故事背景图片(移动端banner)
		///</summary>
		
		private string bg_path_mobile_;
		
		///<summary>
		/// 品牌故事介绍图片
		///</summary>
		
		private string store_url_path_;
		
		///<summary>
		/// 品牌描述
		///</summary>
		
		private string description_;
		
		///<summary>
		/// 品牌索引
		///</summary>
		
		private string brand_index_;
		
		///<summary>
		/// 品牌故事介绍
		///</summary>
		
		private string brand_story_content_;
		
		///<summary>
		/// 品牌橱窗图片（最多返回3张图片）相关链接列表
		/// @sampleValue showcase_pic_urls http://a.vpimg2.com/upload/brand/news/p/2013-08-21/f1acf87dbd4999a7013e4a1c8fa2d4dc.jpg,http://a.vpimg2.com/upload/brand/news/p/2013-08-21/29388ab5c6648a47cdb5fac273f0e980.jpg
		///</summary>
		
		private List<string> showcase_pic_urls_;
		
		///<summary>
		/// 品牌展区图片相关链接列表
		/// @sampleValue exhibition_pic_urls http://b.vpimg1.com/upload/actpics/brand/0/2014/01/23/107/843aad9f4f01390457093.5767.jpg,http://b.vpimg1.com/upload/actpics/brand/0/2014/01/23/199/2e5ceb298f61390457085.6636.jpg
		///</summary>
		
		private List<string> exhibition_pic_urls_;
		
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetCn_name(){
			return this.cn_name_;
		}
		
		public void SetCn_name(string value){
			this.cn_name_ = value;
		}
		public string GetEn_name(){
			return this.en_name_;
		}
		
		public void SetEn_name(string value){
			this.en_name_ = value;
		}
		public string GetLogo_url(){
			return this.logo_url_;
		}
		
		public void SetLogo_url(string value){
			this.logo_url_ = value;
		}
		public string GetBrand_url(){
			return this.brand_url_;
		}
		
		public void SetBrand_url(string value){
			this.brand_url_ = value;
		}
		public string GetBg_path(){
			return this.bg_path_;
		}
		
		public void SetBg_path(string value){
			this.bg_path_ = value;
		}
		public string GetBg_path_mobile(){
			return this.bg_path_mobile_;
		}
		
		public void SetBg_path_mobile(string value){
			this.bg_path_mobile_ = value;
		}
		public string GetStore_url_path(){
			return this.store_url_path_;
		}
		
		public void SetStore_url_path(string value){
			this.store_url_path_ = value;
		}
		public string GetDescription(){
			return this.description_;
		}
		
		public void SetDescription(string value){
			this.description_ = value;
		}
		public string GetBrand_index(){
			return this.brand_index_;
		}
		
		public void SetBrand_index(string value){
			this.brand_index_ = value;
		}
		public string GetBrand_story_content(){
			return this.brand_story_content_;
		}
		
		public void SetBrand_story_content(string value){
			this.brand_story_content_ = value;
		}
		public List<string> GetShowcase_pic_urls(){
			return this.showcase_pic_urls_;
		}
		
		public void SetShowcase_pic_urls(List<string> value){
			this.showcase_pic_urls_ = value;
		}
		public List<string> GetExhibition_pic_urls(){
			return this.exhibition_pic_urls_;
		}
		
		public void SetExhibition_pic_urls(List<string> value){
			this.exhibition_pic_urls_ = value;
		}
		
	}
	
}