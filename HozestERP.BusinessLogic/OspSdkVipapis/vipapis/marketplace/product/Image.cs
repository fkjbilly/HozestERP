using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class Image {
		
		///<summary>
		/// 描述信息
		/// @sampleValue description 商品列表图
		///</summary>
		
		private string description_;
		
		///<summary>
		/// 图片URI
		/// @sampleValue url http://a.vpimg2.com/
		///</summary>
		
		private string url_;
		
		///<summary>
		/// 图片类型，jpg/png/gif
		/// @sampleValue type jpg
		///</summary>
		
		private string type_;
		
		///<summary>
		/// 规格，如210x210, 100x100
		/// @sampleValue size 100x100
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 图片排序
		/// @sampleValue index 122
		///</summary>
		
		private int? index_;
		
		///<summary>
		/// 规格标记：0、方图(默认)；1、长图
		/// @sampleValue shape 0
		///</summary>
		
		private int? shape_;
		
		public string GetDescription(){
			return this.description_;
		}
		
		public void SetDescription(string value){
			this.description_ = value;
		}
		public string GetUrl(){
			return this.url_;
		}
		
		public void SetUrl(string value){
			this.url_ = value;
		}
		public string GetType(){
			return this.type_;
		}
		
		public void SetType(string value){
			this.type_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public int? GetIndex(){
			return this.index_;
		}
		
		public void SetIndex(int? value){
			this.index_ = value;
		}
		public int? GetShape(){
			return this.shape_;
		}
		
		public void SetShape(int? value){
			this.shape_ = value;
		}
		
	}
	
}