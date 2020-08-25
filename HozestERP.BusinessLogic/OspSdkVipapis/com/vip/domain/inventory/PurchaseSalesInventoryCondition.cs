using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class PurchaseSalesInventoryCondition {
		
		///<summary>
		/// 查询类型
		///</summary>
		
		private com.vip.domain.inventory.PurchaseSalesInventoryQueryType? query_type_;
		
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
		/// 开始日期
		/// @sampleValue start_date 2016-05-01
		///</summary>
		
		private string start_date_;
		
		///<summary>
		/// 结束日期
		/// @sampleValue end_date 2016-05-31
		///</summary>
		
		private string end_date_;
		
		///<summary>
		/// 商品编码
		///</summary>
		
		private string item_code_;
		
		///<summary>
		/// 收费品类
		///</summary>
		
		private string pay_category_;
		
		public com.vip.domain.inventory.PurchaseSalesInventoryQueryType? GetQuery_type(){
			return this.query_type_;
		}
		
		public void SetQuery_type(com.vip.domain.inventory.PurchaseSalesInventoryQueryType? value){
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
		public string GetStart_date(){
			return this.start_date_;
		}
		
		public void SetStart_date(string value){
			this.start_date_ = value;
		}
		public string GetEnd_date(){
			return this.end_date_;
		}
		
		public void SetEnd_date(string value){
			this.end_date_ = value;
		}
		public string GetItem_code(){
			return this.item_code_;
		}
		
		public void SetItem_code(string value){
			this.item_code_ = value;
		}
		public string GetPay_category(){
			return this.pay_category_;
		}
		
		public void SetPay_category(string value){
			this.pay_category_ = value;
		}
		
	}
	
}