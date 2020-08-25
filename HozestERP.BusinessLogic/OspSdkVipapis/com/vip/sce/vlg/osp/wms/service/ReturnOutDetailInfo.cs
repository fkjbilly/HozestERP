using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class ReturnOutDetailInfo {
		
		///<summary>
		/// 传输ID
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string item_code_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string item_name_;
		
		///<summary>
		/// 库存类型
		///</summary>
		
		private string type_;
		
		///<summary>
		/// 商品等级
		///</summary>
		
		private string grade_;
		
		///<summary>
		/// 采购订单号
		///</summary>
		
		private string po_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string company_code_;
		
		///<summary>
		/// 货品状态
		///</summary>
		
		private string sales_status_;
		
		///<summary>
		/// 档期号
		///</summary>
		
		private string sales_no_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private double? qty_;
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string box_id_;
		
		///<summary>
		/// 序列号/（供应商）商品编号
		///</summary>
		
		private string serial_sn_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
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
		public string GetType(){
			return this.type_;
		}
		
		public void SetType(string value){
			this.type_ = value;
		}
		public string GetGrade(){
			return this.grade_;
		}
		
		public void SetGrade(string value){
			this.grade_ = value;
		}
		public string GetPo(){
			return this.po_;
		}
		
		public void SetPo(string value){
			this.po_ = value;
		}
		public string GetCompany_code(){
			return this.company_code_;
		}
		
		public void SetCompany_code(string value){
			this.company_code_ = value;
		}
		public string GetSales_status(){
			return this.sales_status_;
		}
		
		public void SetSales_status(string value){
			this.sales_status_ = value;
		}
		public string GetSales_no(){
			return this.sales_no_;
		}
		
		public void SetSales_no(string value){
			this.sales_no_ = value;
		}
		public double? GetQty(){
			return this.qty_;
		}
		
		public void SetQty(double? value){
			this.qty_ = value;
		}
		public string GetBox_id(){
			return this.box_id_;
		}
		
		public void SetBox_id(string value){
			this.box_id_ = value;
		}
		public string GetSerial_sn(){
			return this.serial_sn_;
		}
		
		public void SetSerial_sn(string value){
			this.serial_sn_ = value;
		}
		
	}
	
}