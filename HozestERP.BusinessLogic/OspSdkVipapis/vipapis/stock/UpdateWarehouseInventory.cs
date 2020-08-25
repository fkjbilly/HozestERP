using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class UpdateWarehouseInventory {
		
		///<summary>
		/// 门店名称
		/// @sampleValue store_name 
		///</summary>
		
		private string store_name_;
		
		///<summary>
		/// 商品条码
		/// @sampleValue barcode 
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 库存数量
		/// @sampleValue inventory_qty 
		///</summary>
		
		private int? inventory_qty_;
		
		///<summary>
		/// 库存类型,462， JIT或者线上库存；463， OXO或者线下库存；
		/// @sampleValue inventory_type 462
		///</summary>
		
		private int? inventory_type_;
		
		///<summary>
		/// 流水号,需要保证唯一性
		/// @sampleValue transaction_id 
		///</summary>
		
		private string transaction_id_;
		
		public string GetStore_name(){
			return this.store_name_;
		}
		
		public void SetStore_name(string value){
			this.store_name_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetInventory_qty(){
			return this.inventory_qty_;
		}
		
		public void SetInventory_qty(int? value){
			this.inventory_qty_ = value;
		}
		public int? GetInventory_type(){
			return this.inventory_type_;
		}
		
		public void SetInventory_type(int? value){
			this.inventory_type_ = value;
		}
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		
	}
	
}