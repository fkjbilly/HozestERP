using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class ProductColorImageBindModel {
		
		///<summary>
		/// 商品spu_id
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 色图列表
		///</summary>
		
		private List<vipapis.marketplace.product.ColorImage> color_images_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public List<vipapis.marketplace.product.ColorImage> GetColor_images(){
			return this.color_images_;
		}
		
		public void SetColor_images(List<vipapis.marketplace.product.ColorImage> value){
			this.color_images_ = value;
		}
		
	}
	
}