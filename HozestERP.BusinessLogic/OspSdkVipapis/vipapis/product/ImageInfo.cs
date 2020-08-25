using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ImageInfo {
		
		///<summary>
		/// 图片原始URL
		///</summary>
		
		private string url_;
		
		///<summary>
		/// 图片ID
		///</summary>
		
		private string id_;
		
		///<summary>
		/// 绑定到商品的图片url
		///</summary>
		
		private string bind_url_;
		
		public string GetUrl(){
			return this.url_;
		}
		
		public void SetUrl(string value){
			this.url_ = value;
		}
		public string GetId(){
			return this.id_;
		}
		
		public void SetId(string value){
			this.id_ = value;
		}
		public string GetBind_url(){
			return this.bind_url_;
		}
		
		public void SetBind_url(string value){
			this.bind_url_ = value;
		}
		
	}
	
}