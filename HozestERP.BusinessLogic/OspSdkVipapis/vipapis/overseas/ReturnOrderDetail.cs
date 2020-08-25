using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class ReturnOrderDetail {
		
		///<summary>
		/// 明细行id
		/// @sampleValue transaction_detail_id 1234567890
		///</summary>
		
		private string transaction_detail_id_;
		
		///<summary>
		/// 行号
		///</summary>
		
		private string line_number_;
		
		///<summary>
		/// 商品条形码
		/// @sampleValue barcode 1082999569
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 是否绑定PO
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
		/// 库存状态(0 可用；1 不可用)
		/// @sampleValue status 0
		///</summary>
		
		private string status_;
		
		///<summary>
		/// PO号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 档期号
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// 应退数量
		///</summary>
		
		private int? num_;
		
		public string GetTransaction_detail_id(){
			return this.transaction_detail_id_;
		}
		
		public void SetTransaction_detail_id(string value){
			this.transaction_detail_id_ = value;
		}
		public string GetLine_number(){
			return this.line_number_;
		}
		
		public void SetLine_number(string value){
			this.line_number_ = value;
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
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		
	}
	
}