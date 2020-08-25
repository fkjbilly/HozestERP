using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class PrepayOrderUnpayMsg {
		
		///<summary>
		/// 父订单号
		///</summary>
		
		private string parentSn_;
		
		///<summary>
		/// 预付订单流水号
		///</summary>
		
		private string orderCode_;
		
		///<summary>
		/// 销售频道
		///</summary>
		
		private string vipclub_;
		
		///<summary>
		/// 支付结束时间
		///</summary>
		
		private long? endPayTime_;
		
		///<summary>
		/// 支付开始时间
		///</summary>
		
		private long? startPayTime_;
		
		///<summary>
		/// 添加时间
		///</summary>
		
		private string addTime_;
		
		///<summary>
		/// 销售模式
		///</summary>
		
		private string saleType_;
		
		///<summary>
		/// 档期、专场的SKU id(对应：size_id)
		///</summary>
		
		private List<string> merItemNoList_;
		
		///<summary>
		/// 档期、专场的id(对应：brand_id)
		///</summary>
		
		private List<string> salesNoList_;
		
		///<summary>
		/// 商品id(对应:merchandise_id)
		///</summary>
		
		private List<string> merchandiseNoList_;
		
		public string GetParentSn(){
			return this.parentSn_;
		}
		
		public void SetParentSn(string value){
			this.parentSn_ = value;
		}
		public string GetOrderCode(){
			return this.orderCode_;
		}
		
		public void SetOrderCode(string value){
			this.orderCode_ = value;
		}
		public string GetVipclub(){
			return this.vipclub_;
		}
		
		public void SetVipclub(string value){
			this.vipclub_ = value;
		}
		public long? GetEndPayTime(){
			return this.endPayTime_;
		}
		
		public void SetEndPayTime(long? value){
			this.endPayTime_ = value;
		}
		public long? GetStartPayTime(){
			return this.startPayTime_;
		}
		
		public void SetStartPayTime(long? value){
			this.startPayTime_ = value;
		}
		public string GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(string value){
			this.addTime_ = value;
		}
		public string GetSaleType(){
			return this.saleType_;
		}
		
		public void SetSaleType(string value){
			this.saleType_ = value;
		}
		public List<string> GetMerItemNoList(){
			return this.merItemNoList_;
		}
		
		public void SetMerItemNoList(List<string> value){
			this.merItemNoList_ = value;
		}
		public List<string> GetSalesNoList(){
			return this.salesNoList_;
		}
		
		public void SetSalesNoList(List<string> value){
			this.salesNoList_ = value;
		}
		public List<string> GetMerchandiseNoList(){
			return this.merchandiseNoList_;
		}
		
		public void SetMerchandiseNoList(List<string> value){
			this.merchandiseNoList_ = value;
		}
		
	}
	
}