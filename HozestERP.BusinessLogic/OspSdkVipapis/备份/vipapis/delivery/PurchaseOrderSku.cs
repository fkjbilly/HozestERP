using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class PurchaseOrderSku {
		
		///<summary>
		/// 售卖站点
		///</summary>
		
		private string sell_site_;
		
		///<summary>
		/// 送货仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品售卖数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 订单类别（ single：单品 multiple：多品）
		///</summary>
		
		private string order_cate_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private string order_status_;
		
		///<summary>
		/// 下单时间
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 订单审核时间
		///</summary>
		
		private string audit_time_;
		
		///<summary>
		/// 供货价（不含税）
		///</summary>
		
		private string actual_unit_price_;
		
		///<summary>
		/// 供货价（含税）
		///</summary>
		
		private string actual_market_price_;
		
		public string GetSell_site(){
			return this.sell_site_;
		}
		
		public void SetSell_site(string value){
			this.sell_site_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
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
		public string GetOrder_cate(){
			return this.order_cate_;
		}
		
		public void SetOrder_cate(string value){
			this.order_cate_ = value;
		}
		public string GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(string value){
			this.order_status_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public string GetAudit_time(){
			return this.audit_time_;
		}
		
		public void SetAudit_time(string value){
			this.audit_time_ = value;
		}
		public string GetActual_unit_price(){
			return this.actual_unit_price_;
		}
		
		public void SetActual_unit_price(string value){
			this.actual_unit_price_ = value;
		}
		public string GetActual_market_price(){
			return this.actual_market_price_;
		}
		
		public void SetActual_market_price(string value){
			this.actual_market_price_ = value;
		}
		
	}
	
}