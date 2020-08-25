using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.vreturn{
	
	
	
	
	
	public class ReturnOrder {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private long? order_id_;
		
		///<summary>
		/// po号码
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		public long? GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(long? value){
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
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		
	}
	
}