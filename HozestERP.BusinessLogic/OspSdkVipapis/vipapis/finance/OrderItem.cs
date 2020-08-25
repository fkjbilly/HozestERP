using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class OrderItem {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 采购档期号
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// po号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 出入库时间，时间戳（Epoch格式）
		///</summary>
		
		private long? transaction_time_;
		
		///<summary>
		/// 销售明细创建时间，时间戳（Epoch格式）
		///</summary>
		
		private long? create_time_;
		
		///<summary>
		/// sku 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 单据类型
		///</summary>
		
		private string document_type_;
		
		///<summary>
		/// 销售数量
		///</summary>
		
		private long? quantity_;
		
		///<summary>
		/// 来源仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 销售单价
		///</summary>
		
		private double? sale_price_;
		
		///<summary>
		/// 结算价
		///</summary>
		
		private double? bill_amount_;
		
		///<summary>
		/// 总活动优惠
		///</summary>
		
		private double? total_promotion_amount_;
		
		///<summary>
		/// 商务类满减金额
		///</summary>
		
		private double? vendor_amount_;
		
		///<summary>
		/// 供应商扣点比例
		///</summary>
		
		private double? vendor_rate_;
		
		///<summary>
		/// 处理状态（S:成功 E:异常）
		///</summary>
		
		private string process_status_;
		
		///<summary>
		/// 异常原因说明
		///</summary>
		
		private string comments_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
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
		public long? GetTransaction_time(){
			return this.transaction_time_;
		}
		
		public void SetTransaction_time(long? value){
			this.transaction_time_ = value;
		}
		public long? GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(long? value){
			this.create_time_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetDocument_type(){
			return this.document_type_;
		}
		
		public void SetDocument_type(string value){
			this.document_type_ = value;
		}
		public long? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(long? value){
			this.quantity_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public double? GetSale_price(){
			return this.sale_price_;
		}
		
		public void SetSale_price(double? value){
			this.sale_price_ = value;
		}
		public double? GetBill_amount(){
			return this.bill_amount_;
		}
		
		public void SetBill_amount(double? value){
			this.bill_amount_ = value;
		}
		public double? GetTotal_promotion_amount(){
			return this.total_promotion_amount_;
		}
		
		public void SetTotal_promotion_amount(double? value){
			this.total_promotion_amount_ = value;
		}
		public double? GetVendor_amount(){
			return this.vendor_amount_;
		}
		
		public void SetVendor_amount(double? value){
			this.vendor_amount_ = value;
		}
		public double? GetVendor_rate(){
			return this.vendor_rate_;
		}
		
		public void SetVendor_rate(double? value){
			this.vendor_rate_ = value;
		}
		public string GetProcess_status(){
			return this.process_status_;
		}
		
		public void SetProcess_status(string value){
			this.process_status_ = value;
		}
		public string GetComments(){
			return this.comments_;
		}
		
		public void SetComments(string value){
			this.comments_ = value;
		}
		
	}
	
}