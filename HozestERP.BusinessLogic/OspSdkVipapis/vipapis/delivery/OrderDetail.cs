using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
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
		/// 档期/专场id<br>老特卖模式下为档期号<br>常态模式下为专场号
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 商品的促销活动列表
		///</summary>
		
		private List<vipapis.delivery.PromotionInfo> promotions_;
		
		///<summary>
		/// 该商品获取失败的促销活动列表
		///</summary>
		
		private List<vipapis.delivery.FailedPromotionInfo> failed_promotions_;
		
		///<summary>
		/// 订单的下单时间
		/// @sampleValue date 2016-12-12 12:12:12
		///</summary>
		
		private string date_;
		
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
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public List<vipapis.delivery.PromotionInfo> GetPromotions(){
			return this.promotions_;
		}
		
		public void SetPromotions(List<vipapis.delivery.PromotionInfo> value){
			this.promotions_ = value;
		}
		public List<vipapis.delivery.FailedPromotionInfo> GetFailed_promotions(){
			return this.failed_promotions_;
		}
		
		public void SetFailed_promotions(List<vipapis.delivery.FailedPromotionInfo> value){
			this.failed_promotions_ = value;
		}
		public string GetDate(){
			return this.date_;
		}
		
		public void SetDate(string value){
			this.date_ = value;
		}
		
	}
	
}