using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class InboundCondition {
		
		///<summary>
		/// 查询类型
		///</summary>
		
		private com.vip.domain.inventory.InboundQueryType? query_type_;
		
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
		/// 开始创建日期
		/// @sampleValue start_created_date 2016-05-01
		///</summary>
		
		private string start_created_date_;
		
		///<summary>
		/// 结束创建日期
		/// @sampleValue end_created_date 2016-05-31
		///</summary>
		
		private string end_created_date_;
		
		///<summary>
		/// 开始入库日期
		/// @sampleValue start_inbound_date 2016-05-01
		///</summary>
		
		private string start_inbound_date_;
		
		///<summary>
		/// 结束入库日期
		/// @sampleValue end_inbound_date 2016-05-31
		///</summary>
		
		private string end_inbound_date_;
		
		///<summary>
		/// 商品编码
		///</summary>
		
		private string item_code_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private com.vip.domain.inventory.InboundStatus? inbound_status_;
		
		public com.vip.domain.inventory.InboundQueryType? GetQuery_type(){
			return this.query_type_;
		}
		
		public void SetQuery_type(com.vip.domain.inventory.InboundQueryType? value){
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
		public string GetStart_created_date(){
			return this.start_created_date_;
		}
		
		public void SetStart_created_date(string value){
			this.start_created_date_ = value;
		}
		public string GetEnd_created_date(){
			return this.end_created_date_;
		}
		
		public void SetEnd_created_date(string value){
			this.end_created_date_ = value;
		}
		public string GetStart_inbound_date(){
			return this.start_inbound_date_;
		}
		
		public void SetStart_inbound_date(string value){
			this.start_inbound_date_ = value;
		}
		public string GetEnd_inbound_date(){
			return this.end_inbound_date_;
		}
		
		public void SetEnd_inbound_date(string value){
			this.end_inbound_date_ = value;
		}
		public string GetItem_code(){
			return this.item_code_;
		}
		
		public void SetItem_code(string value){
			this.item_code_ = value;
		}
		public com.vip.domain.inventory.InboundStatus? GetInbound_status(){
			return this.inbound_status_;
		}
		
		public void SetInbound_status(com.vip.domain.inventory.InboundStatus? value){
			this.inbound_status_ = value;
		}
		
	}
	
}