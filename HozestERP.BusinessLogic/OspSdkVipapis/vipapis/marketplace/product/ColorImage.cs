using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class ColorImage {
		
		///<summary>
		/// 颜色，匹配销售属性中的alias,若销售属性中不包含alias，则匹配属性值
		/// @sampleValue color 红色
		///</summary>
		
		private string color_;
		
		///<summary>
		/// 图片列表
		///</summary>
		
		private List<vipapis.marketplace.product.Image> images_;
		
		public string GetColor(){
			return this.color_;
		}
		
		public void SetColor(string value){
			this.color_ = value;
		}
		public List<vipapis.marketplace.product.Image> GetImages(){
			return this.images_;
		}
		
		public void SetImages(List<vipapis.marketplace.product.Image> value){
			this.images_ = value;
		}
		
	}
	
}