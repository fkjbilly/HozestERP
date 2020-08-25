using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class PrepayOrderPeriodsInfoVO {
		
		///<summary>
		/// 分期序号
		///</summary>
		
		private int? seq_;
		
		///<summary>
		/// 订单支付金额
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 账户余额支付金额
		///</summary>
		
		private string walletMoney_;
		
		///<summary>
		/// 虚拟金额
		///</summary>
		
		private string virtualMoney_;
		
		///<summary>
		/// 代金券使用金额
		///</summary>
		
		private string couponMoney_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 支付ID
		///</summary>
		
		private long? payId_;
		
		///<summary>
		/// 支付开始时间
		///</summary>
		
		private long? startPayTime_;
		
		///<summary>
		/// 支付结束时间
		///</summary>
		
		private long? endPayTime_;
		
		public int? GetSeq(){
			return this.seq_;
		}
		
		public void SetSeq(int? value){
			this.seq_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public string GetWalletMoney(){
			return this.walletMoney_;
		}
		
		public void SetWalletMoney(string value){
			this.walletMoney_ = value;
		}
		public string GetVirtualMoney(){
			return this.virtualMoney_;
		}
		
		public void SetVirtualMoney(string value){
			this.virtualMoney_ = value;
		}
		public string GetCouponMoney(){
			return this.couponMoney_;
		}
		
		public void SetCouponMoney(string value){
			this.couponMoney_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public long? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(long? value){
			this.payId_ = value;
		}
		public long? GetStartPayTime(){
			return this.startPayTime_;
		}
		
		public void SetStartPayTime(long? value){
			this.startPayTime_ = value;
		}
		public long? GetEndPayTime(){
			return this.endPayTime_;
		}
		
		public void SetEndPayTime(long? value){
			this.endPayTime_ = value;
		}
		
	}
	
}