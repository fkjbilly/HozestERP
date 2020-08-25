using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class CreateSkuItem {
		
		///<summary>
		/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码。<font color='red'>如果色号为空，则按商品款号+颜色属性值id或值进行拼接</font>
		/// @sampleValue group_sn 1423424413
		///</summary>
		
		private string group_sn_;
		
		///<summary>
		/// 条形码
		/// @sampleValue barcode 113113302011245
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 销售属性(将逐步废弃，建议使用新的销售属性字段simple_sale_props)
		/// @sampleValue flat_sale_props 格式：pid:vid;134:114
		///</summary>
		
		private Dictionary<string, string> flat_sale_props_;
		
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
		/// 简化版销售属性
		///</summary>
		
		private List<vipapis.product.SimpleProperty> simple_sale_props_;
		
		public string GetGroup_sn(){
			return this.group_sn_;
		}
		
		public void SetGroup_sn(string value){
			this.group_sn_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public Dictionary<string, string> GetFlat_sale_props(){
			return this.flat_sale_props_;
		}
		
		public void SetFlat_sale_props(Dictionary<string, string> value){
			this.flat_sale_props_ = value;
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
		public List<vipapis.product.SimpleProperty> GetSimple_sale_props(){
			return this.simple_sale_props_;
		}
		
		public void SetSimple_sale_props(List<vipapis.product.SimpleProperty> value){
			this.simple_sale_props_ = value;
		}
		
	}
	
}