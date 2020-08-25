using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class RealtimeInventoryCondition {
		
		///<summary>
		/// 查询类型
		///</summary>
		
		private com.vip.domain.inventory.RealtimeInventoryQueryType? query_type_;
		
		///<summary>
		/// 经销模式
		///</summary>
		
		private com.vip.domain.inventory.DistributionModel? distribution_model_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private com.vip.domain.inventory.WarehouseCode? warehouse_code_;
		
		///<summary>
		/// 入库凭证
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 品牌编码
		///</summary>
		
		private string brand_code_;
		
		///<summary>
		/// 库位属性
		///</summary>
		
		private com.vip.domain.inventory.RealtimeInventoryLocationParameter? inventory_location_parameter_;
		
		///<summary>
		/// 商品属性
		///</summary>
		
		private com.vip.domain.inventory.RealtimeInventoryCommodityParameter? commodity_parameter_;
		
		///<summary>
		/// 商品编码
		///</summary>
		
		private string item_code_;
		
		public com.vip.domain.inventory.RealtimeInventoryQueryType? GetQuery_type(){
			return this.query_type_;
		}
		
		public void SetQuery_type(com.vip.domain.inventory.RealtimeInventoryQueryType? value){
			this.query_type_ = value;
		}
		public com.vip.domain.inventory.DistributionModel? GetDistribution_model(){
			return this.distribution_model_;
		}
		
		public void SetDistribution_model(com.vip.domain.inventory.DistributionModel? value){
			this.distribution_model_ = value;
		}
		public com.vip.domain.inventory.WarehouseCode? GetWarehouse_code(){
			return this.warehouse_code_;
		}
		
		public void SetWarehouse_code(com.vip.domain.inventory.WarehouseCode? value){
			this.warehouse_code_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetBrand_code(){
			return this.brand_code_;
		}
		
		public void SetBrand_code(string value){
			this.brand_code_ = value;
		}
		public com.vip.domain.inventory.RealtimeInventoryLocationParameter? GetInventory_location_parameter(){
			return this.inventory_location_parameter_;
		}
		
		public void SetInventory_location_parameter(com.vip.domain.inventory.RealtimeInventoryLocationParameter? value){
			this.inventory_location_parameter_ = value;
		}
		public com.vip.domain.inventory.RealtimeInventoryCommodityParameter? GetCommodity_parameter(){
			return this.commodity_parameter_;
		}
		
		public void SetCommodity_parameter(com.vip.domain.inventory.RealtimeInventoryCommodityParameter? value){
			this.commodity_parameter_ = value;
		}
		public string GetItem_code(){
			return this.item_code_;
		}
		
		public void SetItem_code(string value){
			this.item_code_ = value;
		}
		
	}
	
}