using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.vreturn{
	
	
	
	
	
	public class DefectiveGoods {
		
		///<summary>
		/// 事务交易ID
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// po号码
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string receipt_no_;
		
		///<summary>
		/// 送货单号
		///</summary>
		
		private string reference_no_;
		
		///<summary>
		/// 立冲指令
		///</summary>
		
		private string edit_type_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string item_code_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string item_desc_;
		
		///<summary>
		/// 残次原因
		///</summary>
		
		private string reason_code_;
		
		///<summary>
		/// 库存类型
		///</summary>
		
		private string inventory_type_;
		
		///<summary>
		/// 供应商箱号
		///</summary>
		
		private string purchase_case_no_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? qty_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetReceipt_no(){
			return this.receipt_no_;
		}
		
		public void SetReceipt_no(string value){
			this.receipt_no_ = value;
		}
		public string GetReference_no(){
			return this.reference_no_;
		}
		
		public void SetReference_no(string value){
			this.reference_no_ = value;
		}
		public string GetEdit_type(){
			return this.edit_type_;
		}
		
		public void SetEdit_type(string value){
			this.edit_type_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetItem_code(){
			return this.item_code_;
		}
		
		public void SetItem_code(string value){
			this.item_code_ = value;
		}
		public string GetItem_desc(){
			return this.item_desc_;
		}
		
		public void SetItem_desc(string value){
			this.item_desc_ = value;
		}
		public string GetReason_code(){
			return this.reason_code_;
		}
		
		public void SetReason_code(string value){
			this.reason_code_ = value;
		}
		public string GetInventory_type(){
			return this.inventory_type_;
		}
		
		public void SetInventory_type(string value){
			this.inventory_type_ = value;
		}
		public string GetPurchase_case_no(){
			return this.purchase_case_no_;
		}
		
		public void SetPurchase_case_no(string value){
			this.purchase_case_no_ = value;
		}
		public int? GetQty(){
			return this.qty_;
		}
		
		public void SetQty(int? value){
			this.qty_ = value;
		}
		
	}
	
}