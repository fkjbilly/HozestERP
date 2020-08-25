using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class OrderPayDetailVO {
		
		///<summary>
		/// 支付明细状态，0：未支付；1：已支付；2：支付中
		///</summary>
		
		private int? payStatus_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 支付时间
		///</summary>
		
		private long? payTime_;
		
		///<summary>
		/// 支付号或退款号
		///</summary>
		
		private string paySn_;
		
		///<summary>
		/// 支付操作
		///</summary>
		
		private int? payOperation_;
		
		///<summary>
		/// 支付金额
		///</summary>
		
		private string payMoney_;
		
		///<summary>
		/// 支付ID
		///</summary>
		
		private int? payId_;
		
		///<summary>
		/// 支付账号
		///</summary>
		
		private string payAccount_;
		
		///<summary>
		/// 订单操作场景
		///</summary>
		
		private int? orderScenario_;
		
		///<summary>
		/// 货币类型
		///</summary>
		
		private string currency_;
		
		public int? GetPayStatus(){
			return this.payStatus_;
		}
		
		public void SetPayStatus(int? value){
			this.payStatus_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public long? GetPayTime(){
			return this.payTime_;
		}
		
		public void SetPayTime(long? value){
			this.payTime_ = value;
		}
		public string GetPaySn(){
			return this.paySn_;
		}
		
		public void SetPaySn(string value){
			this.paySn_ = value;
		}
		public int? GetPayOperation(){
			return this.payOperation_;
		}
		
		public void SetPayOperation(int? value){
			this.payOperation_ = value;
		}
		public string GetPayMoney(){
			return this.payMoney_;
		}
		
		public void SetPayMoney(string value){
			this.payMoney_ = value;
		}
		public int? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(int? value){
			this.payId_ = value;
		}
		public string GetPayAccount(){
			return this.payAccount_;
		}
		
		public void SetPayAccount(string value){
			this.payAccount_ = value;
		}
		public int? GetOrderScenario(){
			return this.orderScenario_;
		}
		
		public void SetOrderScenario(int? value){
			this.orderScenario_ = value;
		}
		public string GetCurrency(){
			return this.currency_;
		}
		
		public void SetCurrency(string value){
			this.currency_ = value;
		}
		
	}
	
}