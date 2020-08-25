using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class Merchandise {
		
		///<summary>
		/// 商品ID
		///</summary>
		
		private long? merchandise_no_;
		
		///<summary>
		/// 售卖开始时间 （Epoch格式秒）
		///</summary>
		
		private long? start_sell_time_;
		
		///<summary>
		/// 售卖结束时间 （Epoch格式秒） 
		///</summary>
		
		private long? end_sell_time_;
		
		///<summary>
		/// 专场ID
		///</summary>
		
		private long? sales_no_;
		
		///<summary>
		/// 站点，中文
		///</summary>
		
		private List<string> sales_sites_;
		
		///<summary>
		/// 是否在销售： 0、是 1、否
		///</summary>
		
		private int? is_on_sale_;
		
		public long? GetMerchandise_no(){
			return this.merchandise_no_;
		}
		
		public void SetMerchandise_no(long? value){
			this.merchandise_no_ = value;
		}
		public long? GetStart_sell_time(){
			return this.start_sell_time_;
		}
		
		public void SetStart_sell_time(long? value){
			this.start_sell_time_ = value;
		}
		public long? GetEnd_sell_time(){
			return this.end_sell_time_;
		}
		
		public void SetEnd_sell_time(long? value){
			this.end_sell_time_ = value;
		}
		public long? GetSales_no(){
			return this.sales_no_;
		}
		
		public void SetSales_no(long? value){
			this.sales_no_ = value;
		}
		public List<string> GetSales_sites(){
			return this.sales_sites_;
		}
		
		public void SetSales_sites(List<string> value){
			this.sales_sites_ = value;
		}
		public int? GetIs_on_sale(){
			return this.is_on_sale_;
		}
		
		public void SetIs_on_sale(int? value){
			this.is_on_sale_ = value;
		}
		
	}
	
}