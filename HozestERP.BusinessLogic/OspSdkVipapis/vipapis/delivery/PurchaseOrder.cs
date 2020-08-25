using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class PurchaseOrder {
		
		///<summary>
		/// po编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 合作模式，JIT分销：jit_4a；普通jit：jit
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
		
		///<summary>
		/// 海淘档期新增贸易模式
		/// @sampleValue trade_mode FOB/CIF/EXW
		///</summary>
		
		private string trade_mode_;
		
		///<summary>
		/// 档期号
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 档期名称
		///</summary>
		
		private string schedule_name_;
		
		///<summary>
		/// po开始时间；格式:yyyy-MM-dd hh:MM:ss
		/// @sampleValue po_start_time 2016-10-31 16:00:52
		///</summary>
		
		private string po_start_time_;
		
		///<summary>
		/// 分仓未拣货信息
		///</summary>
		
		private List<vipapis.delivery.UnpickInfo> unpick_list_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private string cooperation_no_;
		
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
		public string GetTrade_mode(){
			return this.trade_mode_;
		}
		
		public void SetTrade_mode(string value){
			this.trade_mode_ = value;
		}
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		public string GetVendor_name(){
			return this.vendor_name_;
		}
		
		public void SetVendor_name(string value){
			this.vendor_name_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetSchedule_name(){
			return this.schedule_name_;
		}
		
		public void SetSchedule_name(string value){
			this.schedule_name_ = value;
		}
		public string GetPo_start_time(){
			return this.po_start_time_;
		}
		
		public void SetPo_start_time(string value){
			this.po_start_time_ = value;
		}
		public List<vipapis.delivery.UnpickInfo> GetUnpick_list(){
			return this.unpick_list_;
		}
		
		public void SetUnpick_list(List<vipapis.delivery.UnpickInfo> value){
			this.unpick_list_ = value;
		}
		public string GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(string value){
			this.cooperation_no_ = value;
		}
		
	}
	
}