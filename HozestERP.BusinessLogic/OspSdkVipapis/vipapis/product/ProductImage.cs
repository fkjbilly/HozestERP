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
		/// 图片类型索引号,图片类型索引号取值如下：<br>展示图：1、2、3、4、15、16、17、18、19、20、21、22<br>销售图（列表图）：5、7<br>详情图：601、602……650<br>透明底图：30<br>
		///</summary>
		
		private int? image_index_;
		
		///<summary>
		/// 图片说明
		///</summary>
		
		private string image_description_;
		
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
		public string GetImage_description(){
			return this.image_description_;
		}
		
		public void SetImage_description(string value){
			this.image_description_ = value;
		}
		
	}
	
}