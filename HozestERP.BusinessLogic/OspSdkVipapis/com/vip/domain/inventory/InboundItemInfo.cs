using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class InboundItemInfo {
		
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
		/// 状态
		///</summary>
		
		private string inbound_status_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private string created_date_;
		
		///<summary>
		/// 入库时间
		///</summary>
		
		private string inbound_date_;
		
		///<summary>
		/// 入库计划数
		///</summary>
		
		private int? poTotal_qty_;
		
		///<summary>
		/// 实际上架数
		///</summary>
		
		private int? check_qty_;
		
		///<summary>
		/// 差异数
		///</summary>
		
		private int? diff_qty_;
		
		///<summary>
		/// 残次/一退数
		///</summary>
		
		private int? defect_qty_;
		
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
		public string GetInbound_status(){
			return this.inbound_status_;
		}
		
		public void SetInbound_status(string value){
			this.inbound_status_ = value;
		}
		public string GetCreated_date(){
			return this.created_date_;
		}
		
		public void SetCreated_date(string value){
			this.created_date_ = value;
		}
		public string GetInbound_date(){
			return this.inbound_date_;
		}
		
		public void SetInbound_date(string value){
			this.inbound_date_ = value;
		}
		public int? GetPoTotal_qty(){
			return this.poTotal_qty_;
		}
		
		public void SetPoTotal_qty(int? value){
			this.poTotal_qty_ = value;
		}
		public int? GetCheck_qty(){
			return this.check_qty_;
		}
		
		public void SetCheck_qty(int? value){
			this.check_qty_ = value;
		}
		public int? GetDiff_qty(){
			return this.diff_qty_;
		}
		
		public void SetDiff_qty(int? value){
			this.diff_qty_ = value;
		}
		public int? GetDefect_qty(){
			return this.defect_qty_;
		}
		
		public void SetDefect_qty(int? value){
			this.defect_qty_ = value;
		}
		
	}
	
}