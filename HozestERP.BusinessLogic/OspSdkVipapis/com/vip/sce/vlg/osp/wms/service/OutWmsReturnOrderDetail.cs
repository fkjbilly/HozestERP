using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsReturnOrderDetail {
		
		///<summary>
		/// 明细行ID
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 行号
		///</summary>
		
		private string line_number_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string item_code_;
		
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
		/// 数量
		///</summary>
		
		private double? qty_;
		
		///<summary>
		/// 可售状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 档期号
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 是否绑定po：0，必须绑定po;1，不需要绑定po;vis/portal下发数字0;erp下发数字1;
		///</summary>
		
		private string no_po_;
		
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
		public string GetLine_number(){
			return this.line_number_;
		}
		
		public void SetLine_number(string value){
			this.line_number_ = value;
		}
		public string GetItem_code(){
			return this.item_code_;
		}
		
		public void SetItem_code(string value){
			this.item_code_ = value;
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
		public double? GetQty(){
			return this.qty_;
		}
		
		public void SetQty(double? value){
			this.qty_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetNo_po(){
			return this.no_po_;
		}
		
		public void SetNo_po(string value){
			this.no_po_ = value;
		}
		public string GetSerial_sn(){
			return this.serial_sn_;
		}
		
		public void SetSerial_sn(string value){
			this.serial_sn_ = value;
		}
		
	}
	
}