using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class ChannelInventoryQueryCondition {
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private com.vip.domain.inventory.WarehouseCode? warehouse_code_;
		
		///<summary>
		/// 销售渠道
		///</summary>
		
		private com.vip.domain.inventory.ChannelInventoryChannel? channel_;
		
		///<summary>
		/// 货品等级
		///</summary>
		
		private List<com.vip.domain.inventory.ChannelInventoryGrade?> grade_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private com.vip.domain.inventory.ChannelInventoryStatus? status_;
		
		///<summary>
		/// 商品编码
		///</summary>
		
		private string item_code_;
		
		///<summary>
		/// 品牌编码
		///</summary>
		
		private string brand_code_;
		
		///<summary>
		/// 档期占用
		///</summary>
		
		private com.vip.domain.inventory.ChannelInventoryInVipSalesPlan? in_vip_sales_plan_;
		
		///<summary>
		/// 翻页方向,0：表示下一页，1:表示上一页，超过10页必填
		///</summary>
		
		private int? pageToward_;
		
		///<summary>
		/// 向上翻页时第一条记录的记录ID，该记录由结果返回，下次翻页带上，超过10页必填
		///</summary>
		
		private string backwardId_;
		
		///<summary>
		/// 向下翻页时最后一条记录的记录ID，该记录由结果返回，下次翻页带上，超过10页必填
		///</summary>
		
		private string forwardId_;
		
		public com.vip.domain.inventory.WarehouseCode? GetWarehouse_code(){
			return this.warehouse_code_;
		}
		
		public void SetWarehouse_code(com.vip.domain.inventory.WarehouseCode? value){
			this.warehouse_code_ = value;
		}
		public com.vip.domain.inventory.ChannelInventoryChannel? GetChannel(){
			return this.channel_;
		}
		
		public void SetChannel(com.vip.domain.inventory.ChannelInventoryChannel? value){
			this.channel_ = value;
		}
		public List<com.vip.domain.inventory.ChannelInventoryGrade?> GetGrade(){
			return this.grade_;
		}
		
		public void SetGrade(List<com.vip.domain.inventory.ChannelInventoryGrade?> value){
			this.grade_ = value;
		}
		public com.vip.domain.inventory.ChannelInventoryStatus? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(com.vip.domain.inventory.ChannelInventoryStatus? value){
			this.status_ = value;
		}
		public string GetItem_code(){
			return this.item_code_;
		}
		
		public void SetItem_code(string value){
			this.item_code_ = value;
		}
		public string GetBrand_code(){
			return this.brand_code_;
		}
		
		public void SetBrand_code(string value){
			this.brand_code_ = value;
		}
		public com.vip.domain.inventory.ChannelInventoryInVipSalesPlan? GetIn_vip_sales_plan(){
			return this.in_vip_sales_plan_;
		}
		
		public void SetIn_vip_sales_plan(com.vip.domain.inventory.ChannelInventoryInVipSalesPlan? value){
			this.in_vip_sales_plan_ = value;
		}
		public int? GetPageToward(){
			return this.pageToward_;
		}
		
		public void SetPageToward(int? value){
			this.pageToward_ = value;
		}
		public string GetBackwardId(){
			return this.backwardId_;
		}
		
		public void SetBackwardId(string value){
			this.backwardId_ = value;
		}
		public string GetForwardId(){
			return this.forwardId_;
		}
		
		public void SetForwardId(string value){
			this.forwardId_ = value;
		}
		
	}
	
}