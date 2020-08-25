using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderBackBankVO {
		
		///<summary>
		/// 
		///</summary>
		
		private string bankName_;
		
		///<summary>
		/// 
		///</summary>
		
		private string bankBranch_;
		
		///<summary>
		/// 
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 
		///</summary>
		
		private string account_;
		
		///<summary>
		/// 
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? addTime_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单号（后来添加的字段，值可能为-99）
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		public string GetBankName(){
			return this.bankName_;
		}
		
		public void SetBankName(string value){
			this.bankName_ = value;
		}
		public string GetBankBranch(){
			return this.bankBranch_;
		}
		
		public void SetBankBranch(string value){
			this.bankBranch_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public string GetAccount(){
			return this.account_;
		}
		
		public void SetAccount(string value){
			this.account_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public long? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(long? value){
			this.addTime_ = value;
		}
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
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		
	}
	
}