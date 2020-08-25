using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderPaySnVO {
		
		///<summary>
		/// id序号
		///</summary>
		
		private int? id_;
		
		///<summary>
		/// 支付产生的支付号
		///</summary>
		
		private string paySn_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单id
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 创建时间 yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string createTime_;
		
		///<summary>
		/// 订单流水号
		///</summary>
		
		private string orderCode_;
		
		///<summary>
		/// 长整型的ID
		///</summary>
		
		private long? longId_;
		
		public int? GetId(){
			return this.id_;
		}
		
		public void SetId(int? value){
			this.id_ = value;
		}
		public string GetPaySn(){
			return this.paySn_;
		}
		
		public void SetPaySn(string value){
			this.paySn_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(string value){
			this.createTime_ = value;
		}
		public string GetOrderCode(){
			return this.orderCode_;
		}
		
		public void SetOrderCode(string value){
			this.orderCode_ = value;
		}
		public long? GetLongId(){
			return this.longId_;
		}
		
		public void SetLongId(long? value){
			this.longId_ = value;
		}
		
	}
	
}