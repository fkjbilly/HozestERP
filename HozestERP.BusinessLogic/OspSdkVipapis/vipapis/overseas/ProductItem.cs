using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class ProductItem {
		
		///<summary>
		/// 明细行id
		///</summary>
		
		private string transfer_detail_id_;
		
		///<summary>
		/// 行号
		///</summary>
		
		private string line_num_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 是否绑定po（0 绑定；1 不绑定）
		///</summary>
		
		private string no_po_;
		
		///<summary>
		/// 库存类型
		/// @sampleValue warehouse_type Normal
		///</summary>
		
		private string warehouse_type_;
		
		///<summary>
		/// 货品等级
		/// @sampleValue grade 100
		///</summary>
		
		private string grade_;
		
		///<summary>
		/// PO号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 调拨数量
		///</summary>
		
		private int? num_;
		
		public string GetTransfer_detail_id(){
			return this.transfer_detail_id_;
		}
		
		public void SetTransfer_detail_id(string value){
			this.transfer_detail_id_ = value;
		}
		public string GetLine_num(){
			return this.line_num_;
		}
		
		public void SetLine_num(string value){
			this.line_num_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetNo_po(){
			return this.no_po_;
		}
		
		public void SetNo_po(string value){
			this.no_po_ = value;
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
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		
	}
	
}