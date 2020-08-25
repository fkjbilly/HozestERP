using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class SkuBaseInfo {
		
		///<summary>
		/// 色号
		/// @sampleValue greoup_sn 13212121432
		///</summary>
		
		private string greoup_sn_;
		
		///<summary>
		/// 条码
		/// @sampleValue barcode 4123413241
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 销售属性
		/// @sampleValue sale_props_list 113113302011
		///</summary>
		
		private List<vipapis.product.SaleProps> sale_props_list_;
		
		public string GetGreoup_sn(){
			return this.greoup_sn_;
		}
		
		public void SetGreoup_sn(string value){
			this.greoup_sn_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public List<vipapis.product.SaleProps> GetSale_props_list(){
			return this.sale_props_list_;
		}
		
		public void SetSale_props_list(List<vipapis.product.SaleProps> value){
			this.sale_props_list_ = value;
		}
		
	}
	
}