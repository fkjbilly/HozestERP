using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.vreceipt{
	
	
	
	
	
	public class Revinfo {
		
		///<summary>
		/// 事务交易流水号
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 收货单号
		///</summary>
		
		private string receipt_no_;
		
		///<summary>
		/// 收货单类型
		///</summary>
		
		private string receipt_type_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 仓库标识
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// PO总数量
		///</summary>
		
		private double? total_po_qty_;
		
		///<summary>
		/// 供应商的总发货数量
		///</summary>
		
		private double? total_shipping_qty_;
		
		///<summary>
		/// 供应商发货箱数
		///</summary>
		
		private double? total_ship_cont_count_;
		
		///<summary>
		/// 实际入库总数量
		///</summary>
		
		private double? total_inb_qty_;
		
		///<summary>
		/// 入库结束时间
		///</summary>
		
		private System.DateTime? receive_complete_time_;
		
		///<summary>
		/// 收货记录详细信息
		///</summary>
		
		private List<com.vip.isv.vreceipt.RevinfoDetail> details_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetReceipt_no(){
			return this.receipt_no_;
		}
		
		public void SetReceipt_no(string value){
			this.receipt_no_ = value;
		}
		public string GetReceipt_type(){
			return this.receipt_type_;
		}
		
		public void SetReceipt_type(string value){
			this.receipt_type_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public double? GetTotal_po_qty(){
			return this.total_po_qty_;
		}
		
		public void SetTotal_po_qty(double? value){
			this.total_po_qty_ = value;
		}
		public double? GetTotal_shipping_qty(){
			return this.total_shipping_qty_;
		}
		
		public void SetTotal_shipping_qty(double? value){
			this.total_shipping_qty_ = value;
		}
		public double? GetTotal_ship_cont_count(){
			return this.total_ship_cont_count_;
		}
		
		public void SetTotal_ship_cont_count(double? value){
			this.total_ship_cont_count_ = value;
		}
		public double? GetTotal_inb_qty(){
			return this.total_inb_qty_;
		}
		
		public void SetTotal_inb_qty(double? value){
			this.total_inb_qty_ = value;
		}
		public System.DateTime? GetReceive_complete_time(){
			return this.receive_complete_time_;
		}
		
		public void SetReceive_complete_time(System.DateTime? value){
			this.receive_complete_time_ = value;
		}
		public List<com.vip.isv.vreceipt.RevinfoDetail> GetDetails(){
			return this.details_;
		}
		
		public void SetDetails(List<com.vip.isv.vreceipt.RevinfoDetail> value){
			this.details_ = value;
		}
		
	}
	
}