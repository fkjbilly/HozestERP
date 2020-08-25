using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class SkuDetail {
		
		///<summary>
		/// 商品sku_id编码
		/// @sampleValue sku_id 525
		///</summary>
		
		private string sku_id_;
		
		///<summary>
		/// 外部商品sku编号（商家侧编码，由商家在系统中录入或同步)
		/// @sampleValue outer_sku_id 1212222
		///</summary>
		
		private string outer_sku_id_;
		
		///<summary>
		/// 销售属性
		///</summary>
		
		private Dictionary<string, string> sale_props_;
		
		///<summary>
		/// 尺码明细id
		/// @sampleValue size_detail_id 121
		///</summary>
		
		private long? size_detail_id_;
		
		///<summary>
		/// 颜色图片列表
		///</summary>
		
		private vipapis.marketplace.product.ColorImage color_images_;
		
		///<summary>
		/// 商品spu编号
		/// @sampleValue spu_id 122
		///</summary>
		
		private string spu_id_;
		
		public string GetSku_id(){
			return this.sku_id_;
		}
		
		public void SetSku_id(string value){
			this.sku_id_ = value;
		}
		public string GetOuter_sku_id(){
			return this.outer_sku_id_;
		}
		
		public void SetOuter_sku_id(string value){
			this.outer_sku_id_ = value;
		}
		public Dictionary<string, string> GetSale_props(){
			return this.sale_props_;
		}
		
		public void SetSale_props(Dictionary<string, string> value){
			this.sale_props_ = value;
		}
		public long? GetSize_detail_id(){
			return this.size_detail_id_;
		}
		
		public void SetSize_detail_id(long? value){
			this.size_detail_id_ = value;
		}
		public vipapis.marketplace.product.ColorImage GetColor_images(){
			return this.color_images_;
		}
		
		public void SetColor_images(vipapis.marketplace.product.ColorImage value){
			this.color_images_ = value;
		}
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		
	}
	
}