using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class PoDetail {
		
		///<summary>
		/// PO单明细主键
		///</summary>
		
		private string item_id_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string amount_;
		
		///<summary>
		/// 箱数
		///</summary>
		
		private string box_num_;
		
		///<summary>
		/// 数据状态
		///</summary>
		
		private string data_status_;
		
		///<summary>
		/// 收货仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 吊牌价
		///</summary>
		
		private string price_;
		
		public string GetItem_id(){
			return this.item_id_;
		}
		
		public void SetItem_id(string value){
			this.item_id_ = value;
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
		public string GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(string value){
			this.amount_ = value;
		}
		public string GetBox_num(){
			return this.box_num_;
		}
		
		public void SetBox_num(string value){
			this.box_num_ = value;
		}
		public string GetData_status(){
			return this.data_status_;
		}
		
		public void SetData_status(string value){
			this.data_status_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(string value){
			this.price_ = value;
		}
		
	}
	
}