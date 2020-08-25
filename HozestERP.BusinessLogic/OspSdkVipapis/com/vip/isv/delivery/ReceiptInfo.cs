using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.delivery{
	
	
	
	
	
	public class ReceiptInfo {
		
		///<summary>
		/// 主键id
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 事务交易流水号
		///</summary>
		
		private string transactionId_;
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 收货单号
		///</summary>
		
		private string receiptNo_;
		
		///<summary>
		/// 供应商的总发货数量
		///</summary>
		
		private double? totalShippingQty_;
		
		///<summary>
		/// 供应商发货箱数
		///</summary>
		
		private double? totalShipContCount_;
		
		///<summary>
		/// 实际入库总数量
		///</summary>
		
		private double? totalInbQty_;
		
		///<summary>
		/// 入库结束时间
		///</summary>
		
		private System.DateTime? receiveCompleteTime_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public string GetTransactionId(){
			return this.transactionId_;
		}
		
		public void SetTransactionId(string value){
			this.transactionId_ = value;
		}
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetReceiptNo(){
			return this.receiptNo_;
		}
		
		public void SetReceiptNo(string value){
			this.receiptNo_ = value;
		}
		public double? GetTotalShippingQty(){
			return this.totalShippingQty_;
		}
		
		public void SetTotalShippingQty(double? value){
			this.totalShippingQty_ = value;
		}
		public double? GetTotalShipContCount(){
			return this.totalShipContCount_;
		}
		
		public void SetTotalShipContCount(double? value){
			this.totalShipContCount_ = value;
		}
		public double? GetTotalInbQty(){
			return this.totalInbQty_;
		}
		
		public void SetTotalInbQty(double? value){
			this.totalInbQty_ = value;
		}
		public System.DateTime? GetReceiveCompleteTime(){
			return this.receiveCompleteTime_;
		}
		
		public void SetReceiveCompleteTime(System.DateTime? value){
			this.receiveCompleteTime_ = value;
		}
		
	}
	
}