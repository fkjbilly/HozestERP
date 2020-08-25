using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class OrderPayAndDiscountVO {
		
		///<summary>
		/// 支付ID
		///</summary>
		
		private int? payId_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 支付状态
		///</summary>
		
		private int? payStatus_;
		
		///<summary>
		/// 标识订单的货币种类
		///</summary>
		
		private string currency_;
		
		///<summary>
		/// 订单支付金额
		///</summary>
		
		private string moneyPaid_;
		
		///<summary>
		/// 订单支付金额剩余额
		///</summary>
		
		private string moneyRemaining_;
		
		///<summary>
		/// 账户余额支付金额
		///</summary>
		
		private string walletMoneyPaid_;
		
		///<summary>
		/// 账户余额支付金额剩余额
		///</summary>
		
		private string walletMoneyRemaining_;
		
		///<summary>
		/// 虚拟金额
		///</summary>
		
		private string virtualMoneyPaid_;
		
		///<summary>
		/// 虚拟金额剩余额
		///</summary>
		
		private string virtualMoneyRemaining_;
		
		///<summary>
		/// 折扣率
		///</summary>
		
		private string discountRate_;
		
		///<summary>
		/// 代金券ID
		///</summary>
		
		private int? couponId_;
		
		///<summary>
		/// 代金券使用金额
		///</summary>
		
		private string couponMoneyPaid_;
		
		///<summary>
		/// 代金券使用金额剩余额
		///</summary>
		
		private string couponMoneyRemaining_;
		
		///<summary>
		/// 额外优惠
		///</summary>
		
		private string exDiscountType_;
		
		///<summary>
		/// 额外优惠金额
		///</summary>
		
		private string exDiscountMoneyPaid_;
		
		///<summary>
		/// 额外优惠金额剩余额
		///</summary>
		
		private string exDiscountMoneyRemaining_;
		
		///<summary>
		/// 退款方式
		///</summary>
		
		private int? returnType_;
		
		///<summary>
		/// 是否删除
		///</summary>
		
		private int? isDelete_;
		
		///<summary>
		/// 支付时间
		///</summary>
		
		private long? payTime_;
		
		public int? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(int? value){
			this.payId_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public int? GetPayStatus(){
			return this.payStatus_;
		}
		
		public void SetPayStatus(int? value){
			this.payStatus_ = value;
		}
		public string GetCurrency(){
			return this.currency_;
		}
		
		public void SetCurrency(string value){
			this.currency_ = value;
		}
		public string GetMoneyPaid(){
			return this.moneyPaid_;
		}
		
		public void SetMoneyPaid(string value){
			this.moneyPaid_ = value;
		}
		public string GetMoneyRemaining(){
			return this.moneyRemaining_;
		}
		
		public void SetMoneyRemaining(string value){
			this.moneyRemaining_ = value;
		}
		public string GetWalletMoneyPaid(){
			return this.walletMoneyPaid_;
		}
		
		public void SetWalletMoneyPaid(string value){
			this.walletMoneyPaid_ = value;
		}
		public string GetWalletMoneyRemaining(){
			return this.walletMoneyRemaining_;
		}
		
		public void SetWalletMoneyRemaining(string value){
			this.walletMoneyRemaining_ = value;
		}
		public string GetVirtualMoneyPaid(){
			return this.virtualMoneyPaid_;
		}
		
		public void SetVirtualMoneyPaid(string value){
			this.virtualMoneyPaid_ = value;
		}
		public string GetVirtualMoneyRemaining(){
			return this.virtualMoneyRemaining_;
		}
		
		public void SetVirtualMoneyRemaining(string value){
			this.virtualMoneyRemaining_ = value;
		}
		public string GetDiscountRate(){
			return this.discountRate_;
		}
		
		public void SetDiscountRate(string value){
			this.discountRate_ = value;
		}
		public int? GetCouponId(){
			return this.couponId_;
		}
		
		public void SetCouponId(int? value){
			this.couponId_ = value;
		}
		public string GetCouponMoneyPaid(){
			return this.couponMoneyPaid_;
		}
		
		public void SetCouponMoneyPaid(string value){
			this.couponMoneyPaid_ = value;
		}
		public string GetCouponMoneyRemaining(){
			return this.couponMoneyRemaining_;
		}
		
		public void SetCouponMoneyRemaining(string value){
			this.couponMoneyRemaining_ = value;
		}
		public string GetExDiscountType(){
			return this.exDiscountType_;
		}
		
		public void SetExDiscountType(string value){
			this.exDiscountType_ = value;
		}
		public string GetExDiscountMoneyPaid(){
			return this.exDiscountMoneyPaid_;
		}
		
		public void SetExDiscountMoneyPaid(string value){
			this.exDiscountMoneyPaid_ = value;
		}
		public string GetExDiscountMoneyRemaining(){
			return this.exDiscountMoneyRemaining_;
		}
		
		public void SetExDiscountMoneyRemaining(string value){
			this.exDiscountMoneyRemaining_ = value;
		}
		public int? GetReturnType(){
			return this.returnType_;
		}
		
		public void SetReturnType(int? value){
			this.returnType_ = value;
		}
		public int? GetIsDelete(){
			return this.isDelete_;
		}
		
		public void SetIsDelete(int? value){
			this.isDelete_ = value;
		}
		public long? GetPayTime(){
			return this.payTime_;
		}
		
		public void SetPayTime(long? value){
			this.payTime_ = value;
		}
		
	}
	
}