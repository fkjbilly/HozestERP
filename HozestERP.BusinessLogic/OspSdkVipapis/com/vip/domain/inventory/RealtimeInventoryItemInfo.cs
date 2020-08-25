using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class RealtimeInventoryItemInfo {
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_code_;
		
		///<summary>
		/// 入库凭证
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 商品编码
		///</summary>
		
		private string item_code_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string item_name_;
		
		///<summary>
		/// 品牌编码
		///</summary>
		
		private string brand_code_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 库位属性
		///</summary>
		
		private string inventory_location_parameter_;
		
		///<summary>
		/// 商品属性
		///</summary>
		
		private string commodity_parameter_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string vendor_item_;
		
		///<summary>
		/// 库存数量
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 订单占用数量
		///</summary>
		
		private int? occupancy_quantity_;
		
		///<summary>
		/// 调拨在途数量
		///</summary>
		
		private int? allocated_qunatity_;
		
		///<summary>
		/// 3PL属性库存数量
		///</summary>
		
		private int? available_quantity_;
		
		///<summary>
		/// 唯品会属性库存数量
		///</summary>
		
		private int? vip3pl_qty_;
		
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public string GetWarehouse_code(){
			return this.warehouse_code_;
		}
		
		public void SetWarehouse_code(string value){
			this.warehouse_code_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetItem_code(){
			return this.item_code_;
		}
		
		public void SetItem_code(string value){
			this.item_code_ = value;
		}
		public string GetItem_name(){
			return this.item_name_;
		}
		
		public void SetItem_name(string value){
			this.item_name_ = value;
		}
		public string GetBrand_code(){
			return this.brand_code_;
		}
		
		public void SetBrand_code(string value){
			this.brand_code_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetInventory_location_parameter(){
			return this.inventory_location_parameter_;
		}
		
		public void SetInventory_location_parameter(string value){
			this.inventory_location_parameter_ = value;
		}
		public string GetCommodity_parameter(){
			return this.commodity_parameter_;
		}
		
		public void SetCommodity_parameter(string value){
			this.commodity_parameter_ = value;
		}
		public string GetVendor_item(){
			return this.vendor_item_;
		}
		
		public void SetVendor_item(string value){
			this.vendor_item_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public int? GetOccupancy_quantity(){
			return this.occupancy_quantity_;
		}
		
		public void SetOccupancy_quantity(int? value){
			this.occupancy_quantity_ = value;
		}
		public int? GetAllocated_qunatity(){
			return this.allocated_qunatity_;
		}
		
		public void SetAllocated_qunatity(int? value){
			this.allocated_qunatity_ = value;
		}
		public int? GetAvailable_quantity(){
			return this.available_quantity_;
		}
		
		public void SetAvailable_quantity(int? value){
			this.available_quantity_ = value;
		}
		public int? GetVip3pl_qty(){
			return this.vip3pl_qty_;
		}
		
		public void SetVip3pl_qty(int? value){
			this.vip3pl_qty_ = value;
		}
		
	}
	
}