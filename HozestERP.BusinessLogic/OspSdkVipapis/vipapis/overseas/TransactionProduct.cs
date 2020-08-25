using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class TransactionProduct {
		
		///<summary>
		/// 明细行id
		///</summary>
		
		private string transaction_detail_id_;
		
		///<summary>
		/// 商品条形码
		/// @sampleValue barcode 1082999569
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 商品类型
		///</summary>
		
		private string warehouse_type_;
		
		///<summary>
		/// 货品等级
		///</summary>
		
		private string grade_;
		
		///<summary>
		/// 采购订单号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// VO号
		///</summary>
		
		private string sales_no_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 货品状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 实际调拨数量
		///</summary>
		
		private int? num_;
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string box_id_;
		
		public string GetTransaction_detail_id(){
			return this.transaction_detail_id_;
		}
		
		public void SetTransaction_detail_id(string value){
			this.transaction_detail_id_ = value;
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
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetSales_no(){
			return this.sales_no_;
		}
		
		public void SetSales_no(string value){
			this.sales_no_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		public string GetBox_id(){
			return this.box_id_;
		}
		
		public void SetBox_id(string value){
			this.box_id_ = value;
		}
		
	}
	
}