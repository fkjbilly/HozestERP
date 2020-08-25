using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.sales{
	
	
	
	
	
	public class UpcomingSalesSku {
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 商品上线售卖时间（Epoch格式）
		/// @sampleValue sales_st 1486458202
		///</summary>
		
		private long? sales_st_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public long? GetSales_st(){
			return this.sales_st_;
		}
		
		public void SetSales_st(long? value){
			this.sales_st_ = value;
		}
		
	}
	
}