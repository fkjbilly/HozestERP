using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class SearchWithFeaturesResultModel {
		
		///<summary>
		/// 请求唯一token
		///</summary>
		
		private string token_;
		
		///<summary>
		/// 待识别图片90%相似图片10%融合图片url
		///</summary>
		
		private string image_src_mix_;
		
		///<summary>
		/// 待识别图片90%相似图片10%融合图片url
		///</summary>
		
		private string image_target_mix_;
		
		///<summary>
		/// 待识别图片90%相似图片10%融合图片url
		///</summary>
		
		private string image_url_;
		
		public string GetToken(){
			return this.token_;
		}
		
		public void SetToken(string value){
			this.token_ = value;
		}
		public string GetImage_src_mix(){
			return this.image_src_mix_;
		}
		
		public void SetImage_src_mix(string value){
			this.image_src_mix_ = value;
		}
		public string GetImage_target_mix(){
			return this.image_target_mix_;
		}
		
		public void SetImage_target_mix(string value){
			this.image_target_mix_ = value;
		}
		public string GetImage_url(){
			return this.image_url_;
		}
		
		public void SetImage_url(string value){
			this.image_url_ = value;
		}
		
	}
	
}