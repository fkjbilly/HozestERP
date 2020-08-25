using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class Promotion {
		
		///<summary>
		/// 促销活动类型
		///</summary>
		
		private string promotion_type_;
		
		///<summary>
		/// 促销活动名称
		///</summary>
		
		private string promotion_name_;
		
		///<summary>
		/// 促销活动描述
		///</summary>
		
		private string promotion_description_;
		
		///<summary>
		/// 供应商承担的促销比例,比如，供应商承担20%，将会返回0.2
		///</summary>
		
		private double? vendor_ratio_;
		
		///<summary>
		/// 该促销的总金额(供应商承担金额+唯品会承担的金额)
		///</summary>
		
		private double? discount_total_amount_;
		
		///<summary>
		/// 供应商在该促销所承担的金额
		///</summary>
		
		private double? discount_vendor_amount_;
		
		public string GetPromotion_type(){
			return this.promotion_type_;
		}
		
		public void SetPromotion_type(string value){
			this.promotion_type_ = value;
		}
		public string GetPromotion_name(){
			return this.promotion_name_;
		}
		
		public void SetPromotion_name(string value){
			this.promotion_name_ = value;
		}
		public string GetPromotion_description(){
			return this.promotion_description_;
		}
		
		public void SetPromotion_description(string value){
			this.promotion_description_ = value;
		}
		public double? GetVendor_ratio(){
			return this.vendor_ratio_;
		}
		
		public void SetVendor_ratio(double? value){
			this.vendor_ratio_ = value;
		}
		public double? GetDiscount_total_amount(){
			return this.discount_total_amount_;
		}
		
		public void SetDiscount_total_amount(double? value){
			this.discount_total_amount_ = value;
		}
		public double? GetDiscount_vendor_amount(){
			return this.discount_vendor_amount_;
		}
		
		public void SetDiscount_vendor_amount(double? value){
			this.discount_vendor_amount_ = value;
		}
		
	}
	
}