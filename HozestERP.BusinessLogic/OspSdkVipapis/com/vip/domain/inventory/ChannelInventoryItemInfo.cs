using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class ChannelInventoryItemInfo {
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_code_;
		
		///<summary>
		/// 销售渠道
		///</summary>
		
		private string channel_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string vendor_item_;
		
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
		/// 一级分类编码
		///</summary>
		
		private string first_categoryid_;
		
		///<summary>
		/// 二级分类编码
		///</summary>
		
		private string second_categoryid_;
		
		///<summary>
		/// 三级分类编码
		///</summary>
		
		private string third_categoryid_;
		
		///<summary>
		/// 货品等级
		///</summary>
		
		private string grade_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 档期号
		///</summary>
		
		private string sales_plan_no_;
		
		///<summary>
		/// 订单占用数
		///</summary>
		
		private int? ordered_qty_;
		
		///<summary>
		/// 档期冻结数
		///</summary>
		
		private int? frozen_qty_;
		
		///<summary>
		/// 退供/预调拨占用之和
		///</summary>
		
		private int? return_held_qty_;
		
		///<summary>
		/// 库存数量
		///</summary>
		
		private int? quantity_;
		
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
		public string GetChannel(){
			return this.channel_;
		}
		
		public void SetChannel(string value){
			this.channel_ = value;
		}
		public string GetVendor_item(){
			return this.vendor_item_;
		}
		
		public void SetVendor_item(string value){
			this.vendor_item_ = value;
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
		public string GetFirst_categoryid(){
			return this.first_categoryid_;
		}
		
		public void SetFirst_categoryid(string value){
			this.first_categoryid_ = value;
		}
		public string GetSecond_categoryid(){
			return this.second_categoryid_;
		}
		
		public void SetSecond_categoryid(string value){
			this.second_categoryid_ = value;
		}
		public string GetThird_categoryid(){
			return this.third_categoryid_;
		}
		
		public void SetThird_categoryid(string value){
			this.third_categoryid_ = value;
		}
		public string GetGrade(){
			return this.grade_;
		}
		
		public void SetGrade(string value){
			this.grade_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetSales_plan_no(){
			return this.sales_plan_no_;
		}
		
		public void SetSales_plan_no(string value){
			this.sales_plan_no_ = value;
		}
		public int? GetOrdered_qty(){
			return this.ordered_qty_;
		}
		
		public void SetOrdered_qty(int? value){
			this.ordered_qty_ = value;
		}
		public int? GetFrozen_qty(){
			return this.frozen_qty_;
		}
		
		public void SetFrozen_qty(int? value){
			this.frozen_qty_ = value;
		}
		public int? GetReturn_held_qty(){
			return this.return_held_qty_;
		}
		
		public void SetReturn_held_qty(int? value){
			this.return_held_qty_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		
	}
	
}