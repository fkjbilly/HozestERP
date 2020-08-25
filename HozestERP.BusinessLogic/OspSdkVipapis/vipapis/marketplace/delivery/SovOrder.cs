using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class SovOrder {
		
		///<summary>
		/// 订单编码
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 订单状态编码
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 销售渠道
		///</summary>
		
		private string sales_channel_;
		
		///<summary>
		/// 客户送货时间要求
		///</summary>
		
		private string transport_day_;
		
		///<summary>
		/// 收货人的姓名
		///</summary>
		
		private string receiver_name_;
		
		///<summary>
		/// 收货人的详细地址
		///</summary>
		
		private string receiver_address_;
		
		///<summary>
		/// 收货人的手机号码
		///</summary>
		
		private string receiver_mobile_;
		
		///<summary>
		/// 收货人的固定电话号码
		///</summary>
		
		private string receiver_phone_;
		
		///<summary>
		/// 邮政编码
		///</summary>
		
		private string receiver_zip_;
		
		///<summary>
		/// 收货人所在区/县
		///</summary>
		
		private string receiver_district_;
		
		///<summary>
		/// 收货人所在城市
		///</summary>
		
		private string receiver_city_;
		
		///<summary>
		/// 收货人的所在省份
		///</summary>
		
		private string receiver_state_;
		
		///<summary>
		/// 收货人国家id
		///</summary>
		
		private string country_id_;
		
		///<summary>
		/// 用户备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 发票抬头
		///</summary>
		
		private string invoice_title_;
		
		///<summary>
		/// 纳税人识别号
		///</summary>
		
		private string tax_pay_no_;
		
		///<summary>
		/// 开发票总额
		///</summary>
		
		private string invoice_amount_;
		
		///<summary>
		/// 整张出库单商品金额总和(正常单价之和，不计折扣，不包含运费)
		///</summary>
		
		private string total_fee_;
		
		///<summary>
		/// 快递费用
		///</summary>
		
		private string post_fee_;
		
		///<summary>
		/// 优惠金额
		///</summary>
		
		private string discount_fee_;
		
		///<summary>
		/// 促销优惠金额
		///</summary>
		
		private string ex_discount_fee_;
		
		///<summary>
		/// 订单下单时间（yyyy-MM-dd HH:mm:ss）
		///</summary>
		
		private string created_;
		
		///<summary>
		/// 订单流入店铺的时间
		///</summary>
		
		private string store_add_time_;
		
		///<summary>
		/// 原始订单号
		///</summary>
		
		private string old_order_id_;
		
		///<summary>
		/// B2C端仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 是否已导出,1：已导出,0：未导出
		///</summary>
		
		private string is_export_;
		
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
		public string GetReceiver_district(){
			return this.receiver_district_;
		}
		
		public void SetReceiver_district(string value){
			this.receiver_district_ = value;
		}
		public string GetReceiver_city(){
			return this.receiver_city_;
		}
		
		public void SetReceiver_city(string value){
			this.receiver_city_ = value;
		}
		public string GetReceiver_state(){
			return this.receiver_state_;
		}
		
		public void SetReceiver_state(string value){
			this.receiver_state_ = value;
		}
		public string GetCountry_id(){
			return this.country_id_;
		}
		
		public void SetCountry_id(string value){
			this.country_id_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetInvoice_title(){
			return this.invoice_title_;
		}
		
		public void SetInvoice_title(string value){
			this.invoice_title_ = value;
		}
		public string GetTax_pay_no(){
			return this.tax_pay_no_;
		}
		
		public void SetTax_pay_no(string value){
			this.tax_pay_no_ = value;
		}
		public string GetInvoice_amount(){
			return this.invoice_amount_;
		}
		
		public void SetInvoice_amount(string value){
			this.invoice_amount_ = value;
		}
		public string GetTotal_fee(){
			return this.total_fee_;
		}
		
		public void SetTotal_fee(string value){
			this.total_fee_ = value;
		}
		public string GetPost_fee(){
			return this.post_fee_;
		}
		
		public void SetPost_fee(string value){
			this.post_fee_ = value;
		}
		public string GetDiscount_fee(){
			return this.discount_fee_;
		}
		
		public void SetDiscount_fee(string value){
			this.discount_fee_ = value;
		}
		public string GetEx_discount_fee(){
			return this.ex_discount_fee_;
		}
		
		public void SetEx_discount_fee(string value){
			this.ex_discount_fee_ = value;
		}
		public string GetCreated(){
			return this.created_;
		}
		
		public void SetCreated(string value){
			this.created_ = value;
		}
		public string GetStore_add_time(){
			return this.store_add_time_;
		}
		
		public void SetStore_add_time(string value){
			this.store_add_time_ = value;
		}
		public string GetOld_order_id(){
			return this.old_order_id_;
		}
		
		public void SetOld_order_id(string value){
			this.old_order_id_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetIs_export(){
			return this.is_export_;
		}
		
		public void SetIs_export(string value){
			this.is_export_ = value;
		}
		
	}
	
}