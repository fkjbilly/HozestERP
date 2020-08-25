using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ProductImage {
		
		///<summary>
		/// 图片URL
		///</summary>
		
		private string image_url_;
		
		///<summary>
		/// 图片类型索引号
		///</summary>
		
		private int? image_index_;
		
		///<summary>
		/// 图片说明
		///</summary>
		
		private string description_;
		
		public string GetImage_url(){
			return this.image_url_;
		}
		
		public void SetImage_url(string value){
			this.image_url_ = value;
		}
		public int? GetImage_index(){
			return this.image_index_;
		}
		
		public void SetImage_index(int? value){
			this.image_index_ = value;
		}
		public string GetDescription(){
			return this.description_;
		}
		
		public void SetDescription(string value){
			this.description_ = value;
		}
		
	}
	
}