using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ImageUrl {
		
		///<summary>
		/// 商品详情页小图
		/// @sampleValue small_image http://a.vpimg2.com/upload/merchandise/vis/1675/80000006-139/5/877751-1_2.jpg;http://a.vpimg2.com/upload/merchandise/vis/1675/80000006-139/5/877751-2_2.jpg;
		///</summary>
		
		private string small_image_;
		
		///<summary>
		/// 商品详情页中图
		/// @sampleValue middle_image http://a.vpimg2.com/upload/merchandise/vis/1675/80000006-139/5/877751-1_1.jpg;http://a.vpimg2.com/upload/merchandise/vis/1675/80000006-139/5/877751-2_1.jpg;
		///</summary>
		
		private string middle_image_;
		
		///<summary>
		/// 商品详情页大图
		/// @sampleValue big_image http://a.vpimg2.com/upload/merchandise/vis/1675/80000006-139/5/877751-1_3.jpg;http://a.vpimg2.com/upload/merchandise/vis/1675/80000006-139/5/877751-2_3.jpg;
		///</summary>
		
		private string big_image_;
		
		///<summary>
		/// 列表图
		/// @sampleValue list_image http://a.vpimg2.com/upload/merchandise/vis/1675/80000006-139/5/877751-5.jpg;http://a.vpimg2.com/upload/merchandise/vis/1675/80000006-139/5/877751-7.jpg;
		///</summary>
		
		private string list_image_;
		
		public string GetSmall_image(){
			return this.small_image_;
		}
		
		public void SetSmall_image(string value){
			this.small_image_ = value;
		}
		public string GetMiddle_image(){
			return this.middle_image_;
		}
		
		public void SetMiddle_image(string value){
			this.middle_image_ = value;
		}
		public string GetBig_image(){
			return this.big_image_;
		}
		
		public void SetBig_image(string value){
			this.big_image_ = value;
		}
		public string GetList_image(){
			return this.list_image_;
		}
		
		public void SetList_image(string value){
			this.list_image_ = value;
		}
		
	}
	
}