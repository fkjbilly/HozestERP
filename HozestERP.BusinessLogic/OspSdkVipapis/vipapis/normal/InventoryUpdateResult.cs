using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class InventoryUpdateResult {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 批次号（不支持负数,相同供应商ID不允许重复，否则忽略重复请求）
		///</summary>
		
		private string batch_no_;
		
		///<summary>
		/// 供应商仓库（预留）
		///</summary>
		
		private string warehouse_supplier_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 状态，0、未发送 1、推送成功 3、失败
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 请求库存调整量
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 实际库存调整量
		///</summary>
		
		private int? real_quantity_;
		
		///<summary>
		/// 修改时间
		///</summary>
		
		private long? modify_time_;
		
		///<summary>
		/// 库存调整方式 0：增量更新 1：全量更新
		///</summary>
		
		private int? stock_mode_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(string value){
			this.batch_no_ = value;
		}
		public string GetWarehouse_supplier(){
			return this.warehouse_supplier_;
		}
		
		public void SetWarehouse_supplier(string value){
			this.warehouse_supplier_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public int? GetReal_quantity(){
			return this.real_quantity_;
		}
		
		public void SetReal_quantity(int? value){
			this.real_quantity_ = value;
		}
		public long? GetModify_time(){
			return this.modify_time_;
		}
		
		public void SetModify_time(long? value){
			this.modify_time_ = value;
		}
		public int? GetStock_mode(){
			return this.stock_mode_;
		}
		
		public void SetStock_mode(int? value){
			this.stock_mode_ = value;
		}
		
	}
	
}