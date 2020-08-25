using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class ReturnOrderStatus {
		
		///<summary>
		/// 流水号
		/// @sampleValue id 每个退供单或者调拨单的唯一标识？
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 出库单号（退供单返回return_sn值；调拨单返回transfer_sn值）
		///</summary>
		
		private string shipment_no_;
		
		///<summary>
		/// ERP单号
		/// @sampleValue erp_order_sn 是退供单的时候才有的吗？有什么用？找贤林？
		///</summary>
		
		private string erp_order_sn_;
		
		///<summary>
		/// 关联单号（退供单返回po_no；调拨单返回空）
		/// @sampleValue reference_no 这个是做什么用的？找贤琳
		///</summary>
		
		private string reference_no_;
		
		///<summary>
		/// 出库单类型
		/// @sampleValue order_type TRANS PO
		///</summary>
		
		private string order_type_;
		
		///<summary>
		/// 状态码
		/// @sampleValue status_code W101
		///</summary>
		
		private string status_code_;
		
		///<summary>
		/// 操作时间
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 备注信息
		///</summary>
		
		private string memo_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public string GetShipment_no(){
			return this.shipment_no_;
		}
		
		public void SetShipment_no(string value){
			this.shipment_no_ = value;
		}
		public string GetErp_order_sn(){
			return this.erp_order_sn_;
		}
		
		public void SetErp_order_sn(string value){
			this.erp_order_sn_ = value;
		}
		public string GetReference_no(){
			return this.reference_no_;
		}
		
		public void SetReference_no(string value){
			this.reference_no_ = value;
		}
		public string GetOrder_type(){
			return this.order_type_;
		}
		
		public void SetOrder_type(string value){
			this.order_type_ = value;
		}
		public string GetStatus_code(){
			return this.status_code_;
		}
		
		public void SetStatus_code(string value){
			this.status_code_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public string GetMemo(){
			return this.memo_;
		}
		
		public void SetMemo(string value){
			this.memo_ = value;
		}
		
	}
	
}