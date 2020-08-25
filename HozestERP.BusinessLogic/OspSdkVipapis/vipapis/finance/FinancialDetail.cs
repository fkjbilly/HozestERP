using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class FinancialDetail {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 订单的下单时间。格式为yyyy-mm-dd hh:mm:ss
		///</summary>
		
		private string trx_date_;
		
		///<summary>
		/// 订单类型，销售，退货，取消三种类型
		///</summary>
		
		private string order_type_;
		
		///<summary>
		/// 明细类型
		///</summary>
		
		private string detail_type_;
		
		///<summary>
		/// 明细说明
		///</summary>
		
		private string type_description_;
		
		///<summary>
		/// 创建时间创建时间。格式为yyyy-mm-dd hh:mm:ss
		///</summary>
		
		private string detail_create_time_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string sku_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private string quantity_;
		
		///<summary>
		/// 商品在明细类别下产生的金额。保留两位小数
		///</summary>
		
		private string amount_;
		
		///<summary>
		/// 佣金比例。显示扣点模式的供应商此SKU的扣点信息。保留两位小数
		///</summary>
		
		private string commission_rate_;
		
		///<summary>
		/// 供应商在优惠活动中产生的比例。保留两位小数
		///</summary>
		
		private string vendor_scale_;
		
		///<summary>
		/// 供应商应收金额。保留两位小数
		///</summary>
		
		private string vendor_total_receivable_fee_;
		
		///<summary>
		/// 结算日期。格式为yyyy-mm-dd hh:mm:ss
		///</summary>
		
		private string last_account_date_;
		
		///<summary>
		/// 唯品会已经结算给供应商的金额。保留两位小数
		///</summary>
		
		private string received_amount_;
		
		///<summary>
		/// 唯品会未结算给供应商的金额。保留两位小数
		///</summary>
		
		private string unpaid_amount_;
		
		///<summary>
		/// 优惠活动编号
		///</summary>
		
		private string promotion_no_;
		
		///<summary>
		/// 优惠活动说明
		///</summary>
		
		private string promotion_description_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetTrx_date(){
			return this.trx_date_;
		}
		
		public void SetTrx_date(string value){
			this.trx_date_ = value;
		}
		public string GetOrder_type(){
			return this.order_type_;
		}
		
		public void SetOrder_type(string value){
			this.order_type_ = value;
		}
		public string GetDetail_type(){
			return this.detail_type_;
		}
		
		public void SetDetail_type(string value){
			this.detail_type_ = value;
		}
		public string GetType_description(){
			return this.type_description_;
		}
		
		public void SetType_description(string value){
			this.type_description_ = value;
		}
		public string GetDetail_create_time(){
			return this.detail_create_time_;
		}
		
		public void SetDetail_create_time(string value){
			this.detail_create_time_ = value;
		}
		public string GetSku(){
			return this.sku_;
		}
		
		public void SetSku(string value){
			this.sku_ = value;
		}
		public string GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(string value){
			this.quantity_ = value;
		}
		public string GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(string value){
			this.amount_ = value;
		}
		public string GetCommission_rate(){
			return this.commission_rate_;
		}
		
		public void SetCommission_rate(string value){
			this.commission_rate_ = value;
		}
		public string GetVendor_scale(){
			return this.vendor_scale_;
		}
		
		public void SetVendor_scale(string value){
			this.vendor_scale_ = value;
		}
		public string GetVendor_total_receivable_fee(){
			return this.vendor_total_receivable_fee_;
		}
		
		public void SetVendor_total_receivable_fee(string value){
			this.vendor_total_receivable_fee_ = value;
		}
		public string GetLast_account_date(){
			return this.last_account_date_;
		}
		
		public void SetLast_account_date(string value){
			this.last_account_date_ = value;
		}
		public string GetReceived_amount(){
			return this.received_amount_;
		}
		
		public void SetReceived_amount(string value){
			this.received_amount_ = value;
		}
		public string GetUnpaid_amount(){
			return this.unpaid_amount_;
		}
		
		public void SetUnpaid_amount(string value){
			this.unpaid_amount_ = value;
		}
		public string GetPromotion_no(){
			return this.promotion_no_;
		}
		
		public void SetPromotion_no(string value){
			this.promotion_no_ = value;
		}
		public string GetPromotion_description(){
			return this.promotion_description_;
		}
		
		public void SetPromotion_description(string value){
			this.promotion_description_ = value;
		}
		
	}
	
}