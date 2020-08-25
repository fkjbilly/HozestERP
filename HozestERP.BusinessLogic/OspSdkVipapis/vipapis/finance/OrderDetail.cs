using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class OrderDetail {
		
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
		
		private string sales_or_schedule_id_;
		
		///<summary>
		/// 订单的下单时间
		/// @sampleValue date 2016-12-12 12:12:12
		///</summary>
		
		private string date_;
		
		///<summary>
		/// 商品的促销活动列表
		///</summary>
		
		private List<vipapis.finance.Promotion> promotions_;
		
		///<summary>
		/// 出错信息列表
		///</summary>
		
		private List<vipapis.finance.Error> errors_;
		
		///<summary>
		/// 订单总运费（订单维度的运费）
		///</summary>
		
		private double? carriage_;
		
		///<summary>
		/// 支付优惠(单件)
		///</summary>
		
		private string expay_sub_total_;
		
		///<summary>
		/// 活动优惠（单件)
		///</summary>
		
		private string exact_sub_total_;
		
		///<summary>
		/// 优惠券优惠(单件)
		///</summary>
		
		private string excoupon_sub_total_;
		
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
		public string GetSales_or_schedule_id(){
			return this.sales_or_schedule_id_;
		}
		
		public void SetSales_or_schedule_id(string value){
			this.sales_or_schedule_id_ = value;
		}
		public string GetDate(){
			return this.date_;
		}
		
		public void SetDate(string value){
			this.date_ = value;
		}
		public List<vipapis.finance.Promotion> GetPromotions(){
			return this.promotions_;
		}
		
		public void SetPromotions(List<vipapis.finance.Promotion> value){
			this.promotions_ = value;
		}
		public List<vipapis.finance.Error> GetErrors(){
			return this.errors_;
		}
		
		public void SetErrors(List<vipapis.finance.Error> value){
			this.errors_ = value;
		}
		public double? GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(double? value){
			this.carriage_ = value;
		}
		public string GetExpay_sub_total(){
			return this.expay_sub_total_;
		}
		
		public void SetExpay_sub_total(string value){
			this.expay_sub_total_ = value;
		}
		public string GetExact_sub_total(){
			return this.exact_sub_total_;
		}
		
		public void SetExact_sub_total(string value){
			this.exact_sub_total_ = value;
		}
		public string GetExcoupon_sub_total(){
			return this.excoupon_sub_total_;
		}
		
		public void SetExcoupon_sub_total(string value){
			this.excoupon_sub_total_ = value;
		}
		
	}
	
}