using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DvdReturnProduct {
		
		///<summary>
		/// 商品名称
		/// @sampleValue product_name 
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 订单编号
		/// @sampleValue order_id 
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// PO单号
		/// @sampleValue po_no 
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 条形码
		/// @sampleValue barcode 
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 退货商品数量
		/// @sampleValue amount 
		///</summary>
		
		private int? amount_;
		
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
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
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		
	}
	
}