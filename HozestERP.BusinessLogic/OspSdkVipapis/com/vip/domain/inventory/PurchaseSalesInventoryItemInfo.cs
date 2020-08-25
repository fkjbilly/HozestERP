using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class PurchaseSalesInventoryItemInfo {
		
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
		/// 收费品类
		///</summary>
		
		private string pay_category_;
		
		///<summary>
		/// 库存日期
		///</summary>
		
		private string inventory_date_;
		
		///<summary>
		/// 期初库存数量
		///</summary>
		
		private int? beginning_inventory_quantity_;
		
		///<summary>
		/// 入库数量量
		///</summary>
		
		private int? inventory_in_quantity_;
		
		///<summary>
		/// 出库数量
		///</summary>
		
		private int? inventory_out_quantity_;
		
		///<summary>
		/// 退供数量
		///</summary>
		
		private int? return_to_vendor_qunatity_;
		
		///<summary>
		/// 调拨入库数量
		///</summary>
		
		private int? allocated_inventory_in_qunatity_;
		
		///<summary>
		/// 调拨出库数量
		///</summary>
		
		private int? allocated_inventory_out_qunatity_;
		
		///<summary>
		/// 盘点盘盈数量
		///</summary>
		
		private int? inventory_profit_quantity_;
		
		///<summary>
		/// 盘点盘亏数量
		///</summary>
		
		private int? inventory_losses_quantity_;
		
		///<summary>
		/// 客退收货数量
		///</summary>
		
		private int? return_from_customer_received_quantity_;
		
		///<summary>
		/// 认购数量
		///</summary>
		
		private int? subscribed_quantity_;
		
		///<summary>
		/// 正品库存数量
		///</summary>
		
		private int? quality_inventory_quantity_;
		
		///<summary>
		/// 残次品库存数量
		///</summary>
		
		private int? defective_inventory_quantity_;
		
		///<summary>
		/// 期末库存数量
		///</summary>
		
		private int? ending_inventory_quantity_;
		
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
		public string GetPay_category(){
			return this.pay_category_;
		}
		
		public void SetPay_category(string value){
			this.pay_category_ = value;
		}
		public string GetInventory_date(){
			return this.inventory_date_;
		}
		
		public void SetInventory_date(string value){
			this.inventory_date_ = value;
		}
		public int? GetBeginning_inventory_quantity(){
			return this.beginning_inventory_quantity_;
		}
		
		public void SetBeginning_inventory_quantity(int? value){
			this.beginning_inventory_quantity_ = value;
		}
		public int? GetInventory_in_quantity(){
			return this.inventory_in_quantity_;
		}
		
		public void SetInventory_in_quantity(int? value){
			this.inventory_in_quantity_ = value;
		}
		public int? GetInventory_out_quantity(){
			return this.inventory_out_quantity_;
		}
		
		public void SetInventory_out_quantity(int? value){
			this.inventory_out_quantity_ = value;
		}
		public int? GetReturn_to_vendor_qunatity(){
			return this.return_to_vendor_qunatity_;
		}
		
		public void SetReturn_to_vendor_qunatity(int? value){
			this.return_to_vendor_qunatity_ = value;
		}
		public int? GetAllocated_inventory_in_qunatity(){
			return this.allocated_inventory_in_qunatity_;
		}
		
		public void SetAllocated_inventory_in_qunatity(int? value){
			this.allocated_inventory_in_qunatity_ = value;
		}
		public int? GetAllocated_inventory_out_qunatity(){
			return this.allocated_inventory_out_qunatity_;
		}
		
		public void SetAllocated_inventory_out_qunatity(int? value){
			this.allocated_inventory_out_qunatity_ = value;
		}
		public int? GetInventory_profit_quantity(){
			return this.inventory_profit_quantity_;
		}
		
		public void SetInventory_profit_quantity(int? value){
			this.inventory_profit_quantity_ = value;
		}
		public int? GetInventory_losses_quantity(){
			return this.inventory_losses_quantity_;
		}
		
		public void SetInventory_losses_quantity(int? value){
			this.inventory_losses_quantity_ = value;
		}
		public int? GetReturn_from_customer_received_quantity(){
			return this.return_from_customer_received_quantity_;
		}
		
		public void SetReturn_from_customer_received_quantity(int? value){
			this.return_from_customer_received_quantity_ = value;
		}
		public int? GetSubscribed_quantity(){
			return this.subscribed_quantity_;
		}
		
		public void SetSubscribed_quantity(int? value){
			this.subscribed_quantity_ = value;
		}
		public int? GetQuality_inventory_quantity(){
			return this.quality_inventory_quantity_;
		}
		
		public void SetQuality_inventory_quantity(int? value){
			this.quality_inventory_quantity_ = value;
		}
		public int? GetDefective_inventory_quantity(){
			return this.defective_inventory_quantity_;
		}
		
		public void SetDefective_inventory_quantity(int? value){
			this.defective_inventory_quantity_ = value;
		}
		public int? GetEnding_inventory_quantity(){
			return this.ending_inventory_quantity_;
		}
		
		public void SetEnding_inventory_quantity(int? value){
			this.ending_inventory_quantity_ = value;
		}
		
	}
	
}