using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class ImageInfo {
		
		///<summary>
		/// 图片URL
		///</summary>
		
		private string url_;
		
		///<summary>
		/// 图片ID
		///</summary>
		
		private string id_;
		
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
		
	}
	
}