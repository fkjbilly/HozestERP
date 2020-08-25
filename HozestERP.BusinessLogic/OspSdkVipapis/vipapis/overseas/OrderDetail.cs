using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class OrderDetail {
		
		///<summary>
		/// 数量
		///</summary>
		
		private string order_no_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string v_goods_regist_no_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string num_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string HTS_line_money_;
		
		public string GetOrder_no(){
			return this.order_no_;
		}
		
		public void SetOrder_no(string value){
			this.order_no_ = value;
		}
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetV_goods_regist_no(){
			return this.v_goods_regist_no_;
		}
		
		public void SetV_goods_regist_no(string value){
			this.v_goods_regist_no_ = value;
		}
		public string GetNum(){
			return this.num_;
		}
		
		public void SetNum(string value){
			this.num_ = value;
		}
		public string GetHTS_line_money(){
			return this.HTS_line_money_;
		}
		
		public void SetHTS_line_money(string value){
			this.HTS_line_money_ = value;
		}
		
	}
	
}