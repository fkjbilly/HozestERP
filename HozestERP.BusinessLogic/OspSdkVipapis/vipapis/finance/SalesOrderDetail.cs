using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class SalesOrderDetail {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 商品单价
		///</summary>
		
		private double? price_;
		
		///<summary>
		/// 商品品牌
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 档期/专场id<br>老特卖模式下为档期号<br>常态模式下为专场号
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 订单的下单时间
		/// @sampleValue date 2016-12-12 12:12:12
		///</summary>
		
		private string date_;
		
		///<summary>
		/// 订单类型:2:京东订单，1:预付订单，0：普通订单
		///</summary>
		
		private int? order_type_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
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
		public double? GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(double? value){
			this.price_ = value;
		}
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
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetDate(){
			return this.date_;
		}
		
		public void SetDate(string value){
			this.date_ = value;
		}
		public int? GetOrder_type(){
			return this.order_type_;
		}
		
		public void SetOrder_type(int? value){
			this.order_type_ = value;
		}
		
	}
	
}