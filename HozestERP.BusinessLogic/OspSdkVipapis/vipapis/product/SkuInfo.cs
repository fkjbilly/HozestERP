using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class SkuInfo {
		
		///<summary>
		/// 条形码
		/// @sampleValue barcode 113113302011245
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码。<font color='red'>如果为空，则通过款号+颜色生成</font>
		/// @sampleValue group_sn 1423424413
		///</summary>
		
		private string group_sn_;
		
		///<summary>
		/// 销售属性
		/// @sampleValue sale_props 格式：pid:vid;134:114
		///</summary>
		
		private Dictionary<string, string> sale_props_;
		
		///<summary>
		/// 市场价 （吊牌价）
		/// @sampleValue market_price 739
		///</summary>
		
		private double? market_price_;
		
		///<summary>
		/// 销售价（参考值）
		/// @sampleValue sell_price 259
		///</summary>
		
		private double? sell_price_;
		
		///<summary>
		/// 供货价
		/// @sampleValue supply_price 12
		///</summary>
		
		private double? supply_price_;
		
		///<summary>
		/// 尺码明细id
		/// @sampleValue size_detail_id 
		///</summary>
		
		private long? size_detail_id_;
		
		///<summary>
		/// 颜色图片列表
		/// @sampleValue color_image_list 
		///</summary>
		
		private List<vipapis.product.ProductImage> color_image_list_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetGroup_sn(){
			return this.group_sn_;
		}
		
		public void SetGroup_sn(string value){
			this.group_sn_ = value;
		}
		public Dictionary<string, string> GetSale_props(){
			return this.sale_props_;
		}
		
		public void SetSale_props(Dictionary<string, string> value){
			this.sale_props_ = value;
		}
		public double? GetMarket_price(){
			return this.market_price_;
		}
		
		public void SetMarket_price(double? value){
			this.market_price_ = value;
		}
		public double? GetSell_price(){
			return this.sell_price_;
		}
		
		public void SetSell_price(double? value){
			this.sell_price_ = value;
		}
		public double? GetSupply_price(){
			return this.supply_price_;
		}
		
		public void SetSupply_price(double? value){
			this.supply_price_ = value;
		}
		public long? GetSize_detail_id(){
			return this.size_detail_id_;
		}
		
		public void SetSize_detail_id(long? value){
			this.size_detail_id_ = value;
		}
		public List<vipapis.product.ProductImage> GetColor_image_list(){
			return this.color_image_list_;
		}
		
		public void SetColor_image_list(List<vipapis.product.ProductImage> value){
			this.color_image_list_ = value;
		}
		
	}
	
}