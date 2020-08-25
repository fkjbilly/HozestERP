using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class PayAndDiscount {
		
		///<summary>
		/// 优惠劵ID（包含礼品卡、唯品卡），不传默认不变，不支持原来传0（原PHP“0”代表取消使用,请使用isCancelCoupon），“其它数字”代表待使用的优惠劵ID
		///</summary>
		
		private long? couponId_;
		
		///<summary>
		/// 扣减指定优惠劵的金额（暂不使用，请勿传递此值
		///</summary>
		
		private string couponMoney_;
		
		///<summary>
		/// 是否取消使用优惠劵（唯品卡）
		///</summary>
		
		private bool? isCancelCoupon_;
		
		///<summary>
		/// 是否强制使用优惠劵（唯品卡）
		///</summary>
		
		private bool? isForceUseCoupon_;
		
		///<summary>
		/// 零钱使用金额，为0或者不传代表不变
		///</summary>
		
		private int? useWalletMoney_;
		
		///<summary>
		/// 折扣
		///</summary>
		
		private string discountRate_;
		
		public long? GetCouponId(){
			return this.couponId_;
		}
		
		public void SetCouponId(long? value){
			this.couponId_ = value;
		}
		public string GetCouponMoney(){
			return this.couponMoney_;
		}
		
		public void SetCouponMoney(string value){
			this.couponMoney_ = value;
		}
		public bool? GetIsCancelCoupon(){
			return this.isCancelCoupon_;
		}
		
		public void SetIsCancelCoupon(bool? value){
			this.isCancelCoupon_ = value;
		}
		public bool? GetIsForceUseCoupon(){
			return this.isForceUseCoupon_;
		}
		
		public void SetIsForceUseCoupon(bool? value){
			this.isForceUseCoupon_ = value;
		}
		public int? GetUseWalletMoney(){
			return this.useWalletMoney_;
		}
		
		public void SetUseWalletMoney(int? value){
			this.useWalletMoney_ = value;
		}
		public string GetDiscountRate(){
			return this.discountRate_;
		}
		
		public void SetDiscountRate(string value){
			this.discountRate_ = value;
		}
		
	}
	
}