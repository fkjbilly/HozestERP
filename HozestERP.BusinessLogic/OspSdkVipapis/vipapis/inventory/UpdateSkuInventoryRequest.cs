using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory{
	
	
	
	
	
	public class UpdateSkuInventoryRequest {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 550
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 常态合作编号
		///</summary>
		
		private int? cooperation_no_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 库存数量，全量更新时不能为负数，增量更新可以传负数，负数代表减库存
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 批次号，同一个供应商id需保证batch_no不重复，batch_no长度不超过40
		///</summary>
		
		private string batch_no_;
		
		///<summary>
		/// 熔断确认标记，不传或者传1，1：熔断确认，默认不传
		///</summary>
		
		private int? circuit_break_ack_flag_;
		
		///<summary>
		/// 同步方式，0：全量，1：增量，默认0
		///</summary>
		
		private int? sync_mode_;
		
		///<summary>
		/// 分区仓库代码，如果为分区销售模式，此字段必填
		///</summary>
		
		private string area_warehouse_id_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
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
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public string GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(string value){
			this.batch_no_ = value;
		}
		public int? GetCircuit_break_ack_flag(){
			return this.circuit_break_ack_flag_;
		}
		
		public void SetCircuit_break_ack_flag(int? value){
			this.circuit_break_ack_flag_ = value;
		}
		public int? GetSync_mode(){
			return this.sync_mode_;
		}
		
		public void SetSync_mode(int? value){
			this.sync_mode_ = value;
		}
		public string GetArea_warehouse_id(){
			return this.area_warehouse_id_;
		}
		
		public void SetArea_warehouse_id(string value){
			this.area_warehouse_id_ = value;
		}
		
	}
	
}