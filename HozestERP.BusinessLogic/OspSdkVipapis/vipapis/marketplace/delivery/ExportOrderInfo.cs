using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class ExportOrderInfo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 销售渠道
		///</summary>
		
		private string sales_channel_;
		
		///<summary>
		/// 下单时间
		///</summary>
		
		private string created_;
		
		///<summary>
		/// 订单变更时间
		///</summary>
		
		private string update_time_;
		
		///<summary>
		/// 供应商
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// 收货时间
		///</summary>
		
		private string transport_day_;
		
		///<summary>
		/// 收货人
		///</summary>
		
		private string receiver_name_;
		
		///<summary>
		/// 收货地址
		///</summary>
		
		private string receiver_address_;
		
		///<summary>
		/// 联系电话
		///</summary>
		
		private string receiver_mobile_;
		
		///<summary>
		/// 座机号
		///</summary>
		
		private string receiver_phone_;
		
		///<summary>
		/// 邮编
		///</summary>
		
		private string receiver_zip_;
		
		///<summary>
		/// 是否导出
		///</summary>
		
		private string is_export_;
		
		///<summary>
		/// 导出时间
		///</summary>
		
		private string export_time_;
		
		///<summary>
		/// 发票抬头
		///</summary>
		
		private string invoice_title_;
		
		///<summary>
		/// 纳税人识别号
		///</summary>
		
		private string tax_no_;
		
		///<summary>
		/// 发票金额
		///</summary>
		
		private string invoice_amount_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string memo_;
		
		///<summary>
		/// PO（采购单号）
		///</summary>
		
		private string po_;
		
		///<summary>
		/// 品牌
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string title_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? num_;
		
		///<summary>
		/// 尺寸
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string outer_spu_id_;
		
		///<summary>
		/// SKU（条码）
		///</summary>
		
		private string outer_sku_id_;
		
		///<summary>
		/// 单价
		///</summary>
		
		private string price_;
		
		///<summary>
		/// 定制信息
		///</summary>
		
		private string customization_;
		
		///<summary>
		/// 供应商备注
		///</summary>
		
		private string vendor_memo_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetSales_channel(){
			return this.sales_channel_;
		}
		
		public void SetSales_channel(string value){
			this.sales_channel_ = value;
		}
		public string GetCreated(){
			return this.created_;
		}
		
		public void SetCreated(string value){
			this.created_ = value;
		}
		public string GetUpdate_time(){
			return this.update_time_;
		}
		
		public void SetUpdate_time(string value){
			this.update_time_ = value;
		}
		public string GetVendor_name(){
			return this.vendor_name_;
		}
		
		public void SetVendor_name(string value){
			this.vendor_name_ = value;
		}
		public string GetTransport_day(){
			return this.transport_day_;
		}
		
		public void SetTransport_day(string value){
			this.transport_day_ = value;
		}
		public string GetReceiver_name(){
			return this.receiver_name_;
		}
		
		public void SetReceiver_name(string value){
			this.receiver_name_ = value;
		}
		public string GetReceiver_address(){
			return this.receiver_address_;
		}
		
		public void SetReceiver_address(string value){
			this.receiver_address_ = value;
		}
		public string GetReceiver_mobile(){
			return this.receiver_mobile_;
		}
		
		public void SetReceiver_mobile(string value){
			this.receiver_mobile_ = value;
		}
		public string GetReceiver_phone(){
			return this.receiver_phone_;
		}
		
		public void SetReceiver_phone(string value){
			this.receiver_phone_ = value;
		}
		public string GetReceiver_zip(){
			return this.receiver_zip_;
		}
		
		public void SetReceiver_zip(string value){
			this.receiver_zip_ = value;
		}
		public string GetIs_export(){
			return this.is_export_;
		}
		
		public void SetIs_export(string value){
			this.is_export_ = value;
		}
		public string GetExport_time(){
			return this.export_time_;
		}
		
		public void SetExport_time(string value){
			this.export_time_ = value;
		}
		public string GetInvoice_title(){
			return this.invoice_title_;
		}
		
		public void SetInvoice_title(string value){
			this.invoice_title_ = value;
		}
		public string GetTax_no(){
			return this.tax_no_;
		}
		
		public void SetTax_no(string value){
			this.tax_no_ = value;
		}
		public string GetInvoice_amount(){
			return this.invoice_amount_;
		}
		
		public void SetInvoice_amount(string value){
			this.invoice_amount_ = value;
		}
		public string GetMemo(){
			return this.memo_;
		}
		
		public void SetMemo(string value){
			this.memo_ = value;
		}
		public string GetPo(){
			return this.po_;
		}
		
		public void SetPo(string value){
			this.po_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public string GetOuter_spu_id(){
			return this.outer_spu_id_;
		}
		
		public void SetOuter_spu_id(string value){
			this.outer_spu_id_ = value;
		}
		public string GetOuter_sku_id(){
			return this.outer_sku_id_;
		}
		
		public void SetOuter_sku_id(string value){
			this.outer_sku_id_ = value;
		}
		public string GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(string value){
			this.price_ = value;
		}
		public string GetCustomization(){
			return this.customization_;
		}
		
		public void SetCustomization(string value){
			this.customization_ = value;
		}
		public string GetVendor_memo(){
			return this.vendor_memo_;
		}
		
		public void SetVendor_memo(string value){
			this.vendor_memo_ = value;
		}
		
	}
	
}