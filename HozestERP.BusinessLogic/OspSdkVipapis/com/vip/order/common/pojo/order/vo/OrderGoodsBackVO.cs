using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderGoodsBackVO {
		
		///<summary>
		/// 
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? orderGoodsId_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? oldAmount_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? spoilNum_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? opType_;
		
		///<summary>
		/// 
		///</summary>
		
		private string reason_;
		
		///<summary>
		/// 
		///</summary>
		
		private string changeSize_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? addTime_;
		
		///<summary>
		/// 订单号（后来添加的字段，值可能为-99）
		///</summary>
		
		private string orderSn_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public long? GetOrderGoodsId(){
			return this.orderGoodsId_;
		}
		
		public void SetOrderGoodsId(long? value){
			this.orderGoodsId_ = value;
		}
		public int? GetOldAmount(){
			return this.oldAmount_;
		}
		
		public void SetOldAmount(int? value){
			this.oldAmount_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public int? GetSpoilNum(){
			return this.spoilNum_;
		}
		
		public void SetSpoilNum(int? value){
			this.spoilNum_ = value;
		}
		public int? GetOpType(){
			return this.opType_;
		}
		
		public void SetOpType(int? value){
			this.opType_ = value;
		}
		public string GetReason(){
			return this.reason_;
		}
		
		public void SetReason(string value){
			this.reason_ = value;
		}
		public string GetChangeSize(){
			return this.changeSize_;
		}
		
		public void SetChangeSize(string value){
			this.changeSize_ = value;
		}
		public long? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(long? value){
			this.addTime_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		
	}
	
}