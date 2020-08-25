using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.brand{
	
	
	
	
	
	public class BrandInfo {
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 品牌英文名
		///</summary>
		
		private string brand_name_eng_;
		
		///<summary>
		/// 品牌拼音
		///</summary>
		
		private string brand_name_pinyin_;
		
		///<summary>
		/// 品牌logo
		///</summary>
		
		private string brand_logo_;
		
		///<summary>
		/// 品牌描述
		///</summary>
		
		private string brand_description_;
		
		///<summary>
		/// 品牌链接
		///</summary>
		
		private string brand_url_;
		
		///<summary>
		/// 品牌level
		///</summary>
		
		private string brand_level_;
		
		///<summary>
		/// 最后更新时间:1416201884
		///</summary>
		
		private string last_modify_time_;
		
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
		public string GetBrand_name_pinyin(){
			return this.brand_name_pinyin_;
		}
		
		public void SetBrand_name_pinyin(string value){
			this.brand_name_pinyin_ = value;
		}
		public string GetBrand_logo(){
			return this.brand_logo_;
		}
		
		public void SetBrand_logo(string value){
			this.brand_logo_ = value;
		}
		public string GetBrand_description(){
			return this.brand_description_;
		}
		
		public void SetBrand_description(string value){
			this.brand_description_ = value;
		}
		public string GetBrand_url(){
			return this.brand_url_;
		}
		
		public void SetBrand_url(string value){
			this.brand_url_ = value;
		}
		public string GetBrand_level(){
			return this.brand_level_;
		}
		
		public void SetBrand_level(string value){
			this.brand_level_ = value;
		}
		public string GetLast_modify_time(){
			return this.last_modify_time_;
		}
		
		public void SetLast_modify_time(string value){
			this.last_modify_time_ = value;
		}
		
	}
	
}