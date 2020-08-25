using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class Pick {
		
		///<summary>
		/// po单编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 拣货单编号
		///</summary>
		
		private string pick_no_;
		
		///<summary>
		/// 合作模式<br>JIT分销：jit_4a<br>普通JIT：jit
		///</summary>
		
		private string co_mode_;
		
		///<summary>
		/// 送货仓库
		///</summary>
		
		private string sell_site_;
		
		///<summary>
		/// 订单类别<br>normal
		///</summary>
		
		private string order_cate_;
		
		///<summary>
		/// 拣货数量
		///</summary>
		
		private int? pick_num_;
		
		///<summary>
		/// 拣货单创建时间
		/// @sampleValue create_time 2014-07-01 10:00:00
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 首次导出时间
		/// @sampleValue first_export_time 2014-07-01 10:00:00
		///</summary>
		
		private string first_export_time_;
		
		///<summary>
		/// 导出次数
		///</summary>
		
		private int? export_num_;
		
		///<summary>
		/// 送货状态：0：未送货，1：已送货
		///</summary>
		
		private int? delivery_status_;
		
		///<summary>
		/// 门店编码
		///</summary>
		
		private string store_sn_;
		
		///<summary>
		/// 发货数
		///</summary>
		
		private int? delivery_num_;
		
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
		public string GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(string value){
			this.store_sn_ = value;
		}
		public int? GetDelivery_num(){
			return this.delivery_num_;
		}
		
		public void SetDelivery_num(int? value){
			this.delivery_num_ = value;
		}
		
	}
	
}