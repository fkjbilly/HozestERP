using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.sales{
	
	
	
	
	
	public class Sales {
		
		///<summary>
		/// 专场id
		///</summary>
		
		private long? sales_no_;
		
		///<summary>
		/// 专场名称
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 专场开售时间，以秒为单位（Epoch格式）
		/// @sampleValue sale_st 1486458202
		///</summary>
		
		private long? sale_st_;
		
		///<summary>
		/// 专场结束时间，以秒为单位（Epoch格式）
		/// @sampleValue sale_et 1486458202
		///</summary>
		
		private long? sale_et_;
		
		///<summary>
		/// 唯品会仓库
		/// @sampleValue warehouse VIP_NH
		///</summary>
		
		private string warehouse_;
		
		public long? GetSales_no(){
			return this.sales_no_;
		}
		
		public void SetSales_no(long? value){
			this.sales_no_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public long? GetSale_st(){
			return this.sale_st_;
		}
		
		public void SetSale_st(long? value){
			this.sale_st_ = value;
		}
		public long? GetSale_et(){
			return this.sale_et_;
		}
		
		public void SetSale_et(long? value){
			this.sale_et_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		
	}
	
}