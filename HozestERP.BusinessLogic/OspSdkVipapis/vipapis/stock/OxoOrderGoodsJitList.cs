using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class OxoOrderGoodsJitList {
		
		///<summary>
		/// 仓库编码/门店编号
		///</summary>
		
		private string vendor_warehouse_id_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 尺码
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 订单商品单价
		///</summary>
		
		private string market_price_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string num_;
		
		public string GetVendor_warehouse_id(){
			return this.vendor_warehouse_id_;
		}
		
		public void SetVendor_warehouse_id(string value){
			this.vendor_warehouse_id_ = value;
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
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public string GetMarket_price(){
			return this.market_price_;
		}
		
		public void SetMarket_price(string value){
			this.market_price_ = value;
		}
		public string GetNum(){
			return this.num_;
		}
		
		public void SetNum(string value){
			this.num_ = value;
		}
		
	}
	
}