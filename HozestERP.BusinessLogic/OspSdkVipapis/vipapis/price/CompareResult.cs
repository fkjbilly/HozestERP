using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class CompareResult {
		
		///<summary>
		/// 外网最低市场价
		///</summary>
		
		private double? ext_market_price_;
		
		///<summary>
		/// 外网最低售卖价
		///</summary>
		
		private double? ext_sale_price_;
		
		///<summary>
		/// VIP最低活动价
		///</summary>
		
		private double? vip_discount_price_;
		
		///<summary>
		/// 外网最低活动价
		///</summary>
		
		private double? c_discount_price_;
		
		///<summary>
		/// 对手url
		///</summary>
		
		private string c_url_;
		
		///<summary>
		/// 对手商品名称
		///</summary>
		
		private string c_product_name_;
		
		///<summary>
		/// 商城
		///</summary>
		
		private string c_mall_name_;
		
		///<summary>
		/// 店铺名称
		///</summary>
		
		private string c_store_name_;
		
		///<summary>
		/// 站内最低售价
		///</summary>
		
		private double? vip_lowest_price_;
		
		///<summary>
		/// 同款售卖价
		///</summary>
		
		private double? same_style_price_;
		
		///<summary>
		/// 上期市场价
		///</summary>
		
		private double? pre_market_price_;
		
		///<summary>
		/// 上期售卖价
		///</summary>
		
		private double? pre_sale_price_;
		
		///<summary>
		/// 上期结算价
		///</summary>
		
		private double? pre_bill_price_;
		
		///<summary>
		/// 上期专场ID
		///</summary>
		
		private string pre_brand_id_;
		
		///<summary>
		/// 上期专场名称
		///</summary>
		
		private string pre_schedule_name_;
		
		///<summary>
		/// 上期档期开始时间
		///</summary>
		
		private System.DateTime? pre_schedule_start_time_;
		
		///<summary>
		/// 上期档期结束时间
		///</summary>
		
		private System.DateTime? pre_schedule_end_time_;
		
		public double? GetExt_market_price(){
			return this.ext_market_price_;
		}
		
		public void SetExt_market_price(double? value){
			this.ext_market_price_ = value;
		}
		public double? GetExt_sale_price(){
			return this.ext_sale_price_;
		}
		
		public void SetExt_sale_price(double? value){
			this.ext_sale_price_ = value;
		}
		public double? GetVip_discount_price(){
			return this.vip_discount_price_;
		}
		
		public void SetVip_discount_price(double? value){
			this.vip_discount_price_ = value;
		}
		public double? GetC_discount_price(){
			return this.c_discount_price_;
		}
		
		public void SetC_discount_price(double? value){
			this.c_discount_price_ = value;
		}
		public string GetC_url(){
			return this.c_url_;
		}
		
		public void SetC_url(string value){
			this.c_url_ = value;
		}
		public string GetC_product_name(){
			return this.c_product_name_;
		}
		
		public void SetC_product_name(string value){
			this.c_product_name_ = value;
		}
		public string GetC_mall_name(){
			return this.c_mall_name_;
		}
		
		public void SetC_mall_name(string value){
			this.c_mall_name_ = value;
		}
		public string GetC_store_name(){
			return this.c_store_name_;
		}
		
		public void SetC_store_name(string value){
			this.c_store_name_ = value;
		}
		public double? GetVip_lowest_price(){
			return this.vip_lowest_price_;
		}
		
		public void SetVip_lowest_price(double? value){
			this.vip_lowest_price_ = value;
		}
		public double? GetSame_style_price(){
			return this.same_style_price_;
		}
		
		public void SetSame_style_price(double? value){
			this.same_style_price_ = value;
		}
		public double? GetPre_market_price(){
			return this.pre_market_price_;
		}
		
		public void SetPre_market_price(double? value){
			this.pre_market_price_ = value;
		}
		public double? GetPre_sale_price(){
			return this.pre_sale_price_;
		}
		
		public void SetPre_sale_price(double? value){
			this.pre_sale_price_ = value;
		}
		public double? GetPre_bill_price(){
			return this.pre_bill_price_;
		}
		
		public void SetPre_bill_price(double? value){
			this.pre_bill_price_ = value;
		}
		public string GetPre_brand_id(){
			return this.pre_brand_id_;
		}
		
		public void SetPre_brand_id(string value){
			this.pre_brand_id_ = value;
		}
		public string GetPre_schedule_name(){
			return this.pre_schedule_name_;
		}
		
		public void SetPre_schedule_name(string value){
			this.pre_schedule_name_ = value;
		}
		public System.DateTime? GetPre_schedule_start_time(){
			return this.pre_schedule_start_time_;
		}
		
		public void SetPre_schedule_start_time(System.DateTime? value){
			this.pre_schedule_start_time_ = value;
		}
		public System.DateTime? GetPre_schedule_end_time(){
			return this.pre_schedule_end_time_;
		}
		
		public void SetPre_schedule_end_time(System.DateTime? value){
			this.pre_schedule_end_time_ = value;
		}
		
	}
	
}