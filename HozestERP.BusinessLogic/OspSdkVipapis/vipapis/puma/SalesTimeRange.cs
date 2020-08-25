using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class SalesTimeRange {
		
		///<summary>
		/// 销售开始时间begin
		///</summary>
		
		private long? sales_time_from_begin_;
		
		///<summary>
		/// 销售开始时间end
		///</summary>
		
		private long? sales_time_from_end_;
		
		///<summary>
		/// 销售结束时间begin
		///</summary>
		
		private long? sales_time_to_begin_;
		
		///<summary>
		/// 销售结束时间end
		///</summary>
		
		private long? sales_time_to_end_;
		
		public long? GetSales_time_from_begin(){
			return this.sales_time_from_begin_;
		}
		
		public void SetSales_time_from_begin(long? value){
			this.sales_time_from_begin_ = value;
		}
		public long? GetSales_time_from_end(){
			return this.sales_time_from_end_;
		}
		
		public void SetSales_time_from_end(long? value){
			this.sales_time_from_end_ = value;
		}
		public long? GetSales_time_to_begin(){
			return this.sales_time_to_begin_;
		}
		
		public void SetSales_time_to_begin(long? value){
			this.sales_time_to_begin_ = value;
		}
		public long? GetSales_time_to_end(){
			return this.sales_time_to_end_;
		}
		
		public void SetSales_time_to_end(long? value){
			this.sales_time_to_end_ = value;
		}
		
	}
	
}