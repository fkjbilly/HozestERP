using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DvdOrderDetail {
		
		///<summary>
		/// 品牌中文名称
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 尺码
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string art_no_;
		
		///<summary>
		/// 条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 商品售卖价格
		///</summary>
		
		private double? sell_price_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 汽车频道-适用城市
		///</summary>
		
		private string fetch_address_;
		
		///<summary>
		/// 用户备注(商品维护的用户备注，订单维度的用户备注在字段”Remark”里)
		///</summary>
		
		private string customized_info_;
		
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
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
		public string GetArt_no(){
			return this.art_no_;
		}
		
		public void SetArt_no(string value){
			this.art_no_ = value;
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
		public double? GetSell_price(){
			return this.sell_price_;
		}
		
		public void SetSell_price(double? value){
			this.sell_price_ = value;
		}
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetFetch_address(){
			return this.fetch_address_;
		}
		
		public void SetFetch_address(string value){
			this.fetch_address_ = value;
		}
		public string GetCustomized_info(){
			return this.customized_info_;
		}
		
		public void SetCustomized_info(string value){
			this.customized_info_ = value;
		}
		
	}
	
}