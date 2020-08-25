using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class RefundMoneyUnit {
		
		///<summary>
		/// 在线支付部分退款路径： 1-原路退, 2-退钱包
		///</summary>
		
		private int? refundType_;
		
		///<summary>
		/// 支付类型
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 在线部分退款金额
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 零钱退款金额
		///</summary>
		
		private string surplus_;
		
		///<summary>
		/// 唯品币退款金额
		///</summary>
		
		private string virtualMoney_;
		
		///<summary>
		/// 唯品卡退款金额
		///</summary>
		
		private string couponMoney_;
		
		///<summary>
		/// 唯品卡ID
		///</summary>
		
		private int? couponId_;
		
		///<summary>
		/// 红包金额
		///</summary>
		
		private string totalPacketMoney_;
		
		///<summary>
		/// 退款总金额
		///</summary>
		
		private string total_;
		
		///<summary>
		/// 退款备注
		///</summary>
		
		private string remark_;
		
		public int? GetRefundType(){
			return this.refundType_;
		}
		
		public void SetRefundType(int? value){
			this.refundType_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public string GetSurplus(){
			return this.surplus_;
		}
		
		public void SetSurplus(string value){
			this.surplus_ = value;
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
		public int? GetCouponId(){
			return this.couponId_;
		}
		
		public void SetCouponId(int? value){
			this.couponId_ = value;
		}
		public string GetTotalPacketMoney(){
			return this.totalPacketMoney_;
		}
		
		public void SetTotalPacketMoney(string value){
			this.totalPacketMoney_ = value;
		}
		public string GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(string value){
			this.total_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}