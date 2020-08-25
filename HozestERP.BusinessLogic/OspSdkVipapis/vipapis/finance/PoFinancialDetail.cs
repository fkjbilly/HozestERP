using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class PoFinancialDetail {
		
		///<summary>
		/// 全局ID
		///</summary>
		
		private long? transaction_id_;
		
		///<summary>
		/// 库存事务指令
		///</summary>
		
		private string transaction_type_;
		
		///<summary>
		/// 库存事务类型名称
		///</summary>
		
		private string transaction_type_name_;
		
		///<summary>
		/// 出入库时间
		///</summary>
		
		private System.DateTime? transaction_time_;
		
		///<summary>
		/// 采购档期号
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// po号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 采购公司组织机构id
		///</summary>
		
		private string po_org_id_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? create_time_;
		
		///<summary>
		/// 事务处理总数量
		///</summary>
		
		private long? transaction_quantity_;
		
		///<summary>
		/// 来源仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 单据号（销售-SO单、客退-SO单)
		///</summary>
		
		private string order_no_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 销售金额
		///</summary>
		
		private double? sales_amount_;
		
		///<summary>
		/// 销售金额币种
		///</summary>
		
		private string order_currency_;
		
		///<summary>
		/// 结算单价（不含税）
		///</summary>
		
		private double? bill_price_;
		
		///<summary>
		/// 结算金额（不含税）
		///</summary>
		
		private double? bill_amount_;
		
		///<summary>
		/// 结算金额（含税）
		///</summary>
		
		private double? bill_amount_tax_;
		
		///<summary>
		/// 币种
		///</summary>
		
		private string currency_code_;
		
		///<summary>
		/// 税率
		///</summary>
		
		private double? tax_rate_;
		
		///<summary>
		/// 数据状态
		///</summary>
		
		private string source_status_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string comments_;
		
		public long? GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(long? value){
			this.transaction_id_ = value;
		}
		public string GetTransaction_type(){
			return this.transaction_type_;
		}
		
		public void SetTransaction_type(string value){
			this.transaction_type_ = value;
		}
		public string GetTransaction_type_name(){
			return this.transaction_type_name_;
		}
		
		public void SetTransaction_type_name(string value){
			this.transaction_type_name_ = value;
		}
		public System.DateTime? GetTransaction_time(){
			return this.transaction_time_;
		}
		
		public void SetTransaction_time(System.DateTime? value){
			this.transaction_time_ = value;
		}
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetPo_org_id(){
			return this.po_org_id_;
		}
		
		public void SetPo_org_id(string value){
			this.po_org_id_ = value;
		}
		public System.DateTime? GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(System.DateTime? value){
			this.create_time_ = value;
		}
		public long? GetTransaction_quantity(){
			return this.transaction_quantity_;
		}
		
		public void SetTransaction_quantity(long? value){
			this.transaction_quantity_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetOrder_no(){
			return this.order_no_;
		}
		
		public void SetOrder_no(string value){
			this.order_no_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public double? GetSales_amount(){
			return this.sales_amount_;
		}
		
		public void SetSales_amount(double? value){
			this.sales_amount_ = value;
		}
		public string GetOrder_currency(){
			return this.order_currency_;
		}
		
		public void SetOrder_currency(string value){
			this.order_currency_ = value;
		}
		public double? GetBill_price(){
			return this.bill_price_;
		}
		
		public void SetBill_price(double? value){
			this.bill_price_ = value;
		}
		public double? GetBill_amount(){
			return this.bill_amount_;
		}
		
		public void SetBill_amount(double? value){
			this.bill_amount_ = value;
		}
		public double? GetBill_amount_tax(){
			return this.bill_amount_tax_;
		}
		
		public void SetBill_amount_tax(double? value){
			this.bill_amount_tax_ = value;
		}
		public string GetCurrency_code(){
			return this.currency_code_;
		}
		
		public void SetCurrency_code(string value){
			this.currency_code_ = value;
		}
		public double? GetTax_rate(){
			return this.tax_rate_;
		}
		
		public void SetTax_rate(double? value){
			this.tax_rate_ = value;
		}
		public string GetSource_status(){
			return this.source_status_;
		}
		
		public void SetSource_status(string value){
			this.source_status_ = value;
		}
		public string GetComments(){
			return this.comments_;
		}
		
		public void SetComments(string value){
			this.comments_ = value;
		}
		
	}
	
}