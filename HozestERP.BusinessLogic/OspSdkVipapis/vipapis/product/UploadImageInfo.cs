using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class UploadImageInfo {
		
		///<summary>
		/// 图片内容
		///</summary>
		
		private string img_content_;
		
		///<summary>
		/// 补白的左边距
		/// @sampleValue padding_left 20
		///</summary>
		
		private int? padding_left_;
		
		///<summary>
		/// 补白的上边距
		/// @sampleValue padding_top 20
		///</summary>
		
		private int? padding_top_;
		
		public string GetImg_content(){
			return this.img_content_;
		}
		
		public void SetImg_content(string value){
			this.img_content_ = value;
		}
		public int? GetPadding_left(){
			return this.padding_left_;
		}
		
		public void SetPadding_left(int? value){
			this.padding_left_ = value;
		}
		public int? GetPadding_top(){
			return this.padding_top_;
		}
		
		public void SetPadding_top(int? value){
			this.padding_top_ = value;
		}
		
	}
	
}