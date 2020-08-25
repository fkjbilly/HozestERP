using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OccupiedOrderDetail {
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private long? brand_id_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperation_no_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 销售来源，-1：未知来源，0：运营专场，1：旗舰店
		///</summary>
		
		private int? sales_source_indicator_;
		
		///<summary>
		/// 旗舰店/运营专场编号
		///</summary>
		
		private long? sales_no_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public long? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(long? value){
			this.brand_id_ = value;
		}
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetSales_source_indicator(){
			return this.sales_source_indicator_;
		}
		
		public void SetSales_source_indicator(int? value){
			this.sales_source_indicator_ = value;
		}
		public long? GetSales_no(){
			return this.sales_no_;
		}
		
		public void SetSales_no(long? value){
			this.sales_no_ = value;
		}
		
	}
	
}