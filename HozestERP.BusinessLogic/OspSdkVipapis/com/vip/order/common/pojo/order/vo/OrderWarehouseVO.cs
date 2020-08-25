using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderWarehouseVO {
		
		///<summary>
		/// sizeId
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 用户Id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单Id
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 销售仓
		///</summary>
		
		private string saleWarehouse_;
		
		///<summary>
		/// 采购档期号
		///</summary>
		
		private string scheduledSellingId_;
		
		///<summary>
		/// 发货仓
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 货源仓
		///</summary>
		
		private string sourceWarehouse_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 添加时间
		///</summary>
		
		private int? addTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private int? updateTime_;
		
		///<summary>
		/// ID
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 子仓
		///</summary>
		
		private string subWarehouse_;
		
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetSaleWarehouse(){
			return this.saleWarehouse_;
		}
		
		public void SetSaleWarehouse(string value){
			this.saleWarehouse_ = value;
		}
		public string GetScheduledSellingId(){
			return this.scheduledSellingId_;
		}
		
		public void SetScheduledSellingId(string value){
			this.scheduledSellingId_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetSourceWarehouse(){
			return this.sourceWarehouse_;
		}
		
		public void SetSourceWarehouse(string value){
			this.sourceWarehouse_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public int? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(int? value){
			this.addTime_ = value;
		}
		public int? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(int? value){
			this.updateTime_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public string GetSubWarehouse(){
			return this.subWarehouse_;
		}
		
		public void SetSubWarehouse(string value){
			this.subWarehouse_ = value;
		}
		
	}
	
}