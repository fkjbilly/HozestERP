using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class AppendSkusRequest {
		
		///<summary>
		/// 商品编码
		/// @sampleValue spu_id spu_id
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// sku列表
		///</summary>
		
		private List<vipapis.marketplace.product.AddSkuItem> skus_;
		
		///<summary>
		/// 色图列表，当sku的销售属性存在颜色（pid=134）是，色图必传，且必须覆盖所有颜色
		///</summary>
		
		private List<vipapis.marketplace.product.ColorImage> color_images_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public List<vipapis.marketplace.product.AddSkuItem> GetSkus(){
			return this.skus_;
		}
		
		public void SetSkus(List<vipapis.marketplace.product.AddSkuItem> value){
			this.skus_ = value;
		}
		public List<vipapis.marketplace.product.ColorImage> GetColor_images(){
			return this.color_images_;
		}
		
		public void SetColor_images(List<vipapis.marketplace.product.ColorImage> value){
			this.color_images_ = value;
		}
		
	}
	
}