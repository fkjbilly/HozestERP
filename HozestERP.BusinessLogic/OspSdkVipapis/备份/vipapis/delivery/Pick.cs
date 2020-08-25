using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class Pick {
		
		///<summary>
		/// PO单编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 拣货单编号
		///</summary>
		
		private string pick_no_;
		
		///<summary>
		/// 合作模式
		///</summary>
		
		private string co_mode_;
		
		///<summary>
		/// 售卖站点
		///</summary>
		
		private string sell_site_;
		
		///<summary>
		/// 订单类别
		///</summary>
		
		private string order_cate_;
		
		///<summary>
		/// 拣货数量
		///</summary>
		
		private int? pick_num_;
		
		///<summary>
		/// 拣货单创建时间
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 首次导出时间
		///</summary>
		
		private string first_export_time_;
		
		///<summary>
		/// 导出次数
		///</summary>
		
		private int? export_num_;
		
		///<summary>
		/// 送货状态
		///</summary>
		
		private int? delivery_status_;
		
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetPick_no(){
			return this.pick_no_;
		}
		
		public void SetPick_no(string value){
			this.pick_no_ = value;
		}
		public string GetCo_mode(){
			return this.co_mode_;
		}
		
		public void SetCo_mode(string value){
			this.co_mode_ = value;
		}
		public string GetSell_site(){
			return this.sell_site_;
		}
		
		public void SetSell_site(string value){
			this.sell_site_ = value;
		}
		public string GetOrder_cate(){
			return this.order_cate_;
		}
		
		public void SetOrder_cate(string value){
			this.order_cate_ = value;
		}
		public int? GetPick_num(){
			return this.pick_num_;
		}
		
		public void SetPick_num(int? value){
			this.pick_num_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public string GetFirst_export_time(){
			return this.first_export_time_;
		}
		
		public void SetFirst_export_time(string value){
			this.first_export_time_ = value;
		}
		public int? GetExport_num(){
			return this.export_num_;
		}
		
		public void SetExport_num(int? value){
			this.export_num_ = value;
		}
		public int? GetDelivery_status(){
			return this.delivery_status_;
		}
		
		public void SetDelivery_status(int? value){
			this.delivery_status_ = value;
		}
		
	}
	
}