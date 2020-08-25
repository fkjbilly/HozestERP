using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class SaleOrderInfo {
		
		///<summary>
		/// 商品明细订单的唯一值
		///</summary>
		
		private string id_;
		
		///<summary>
		/// 仓库+流水id(标识来源某个仓库)
		///</summary>
		
		private string source_id_;
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// PO编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 库存类型(3PL、Normal、VIP_3PL)
		///</summary>
		
		private string warehouse_type_;
		
		///<summary>
		/// 货品等级
		///</summary>
		
		private string grade_;
		
		///<summary>
		/// 状态(0-可用，1-不可用
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string num_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 档期号
		///</summary>
		
		private string schedule_id_;
		
		public string GetId(){
			return this.id_;
		}
		
		public void SetId(string value){
			this.id_ = value;
		}
		public string GetSource_id(){
			return this.source_id_;
		}
		
		public void SetSource_id(string value){
			this.source_id_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetWarehouse_type(){
			return this.warehouse_type_;
		}
		
		public void SetWarehouse_type(string value){
			this.warehouse_type_ = value;
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
		public string GetNum(){
			return this.num_;
		}
		
		public void SetNum(string value){
			this.num_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		
	}
	
}