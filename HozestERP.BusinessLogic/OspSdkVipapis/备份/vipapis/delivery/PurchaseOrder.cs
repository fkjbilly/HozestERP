using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class PurchaseOrder {
		
		///<summary>
		/// PO编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 合作模式编码
		///</summary>
		
		private string co_mode_;
		
		///<summary>
		/// 档期开始销售时间(格式yyyy-MM-dd HH:mm:ss)
		/// @sampleValue sell_st_time 2014-07-01 10:00:00
		///</summary>
		
		private string sell_st_time_;
		
		///<summary>
		/// 档期结束销售时间(格式yyyy-MM-dd HH:mm:ss)
		/// @sampleValue sell_et_time 2014-08-15 23:59:59
		///</summary>
		
		private string sell_et_time_;
		
		///<summary>
		/// 虚拟总库存
		///</summary>
		
		private string stock_;
		
		///<summary>
		/// 销售数
		///</summary>
		
		private string sales_volume_;
		
		///<summary>
		/// 未拣货数
		///</summary>
		
		private string not_pick_;
		
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetCo_mode(){
			return this.co_mode_;
		}
		
		public void SetCo_mode(string value){
			this.co_mode_ = value;
		}
		public string GetSell_st_time(){
			return this.sell_st_time_;
		}
		
		public void SetSell_st_time(string value){
			this.sell_st_time_ = value;
		}
		public string GetSell_et_time(){
			return this.sell_et_time_;
		}
		
		public void SetSell_et_time(string value){
			this.sell_et_time_ = value;
		}
		public string GetStock(){
			return this.stock_;
		}
		
		public void SetStock(string value){
			this.stock_ = value;
		}
		public string GetSales_volume(){
			return this.sales_volume_;
		}
		
		public void SetSales_volume(string value){
			this.sales_volume_ = value;
		}
		public string GetNot_pick(){
			return this.not_pick_;
		}
		
		public void SetNot_pick(string value){
			this.not_pick_ = value;
		}
		
	}
	
}