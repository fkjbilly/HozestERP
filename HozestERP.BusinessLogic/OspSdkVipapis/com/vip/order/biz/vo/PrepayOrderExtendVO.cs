using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class PrepayOrderExtendVO {
		
		///<summary>
		/// 父订单号
		///</summary>
		
		private string parentSn_;
		
		///<summary>
		/// 预付订单流水号
		///</summary>
		
		private string orderCode_;
		
		///<summary>
		/// 预付款支付期数
		///</summary>
		
		private int? periods_;
		
		///<summary>
		/// 是否首单
		///</summary>
		
		private int? isFirst_;
		
		///<summary>
		/// 是否尾单
		///</summary>
		
		private int? isLast_;
		
		///<summary>
		/// 是否锁住
		///</summary>
		
		private int? isLock_;
		
		///<summary>
		/// 支付ID
		///</summary>
		
		private long? payId_;
		
		///<summary>
		/// 预付订单总应付金额
		///</summary>
		
		private string totalMoney_;
		
		///<summary>
		/// 支付开始时间
		///</summary>
		
		private long? startPayTime_;
		
		///<summary>
		/// 支付结束时间
		///</summary>
		
		private long? endPayTime_;
		
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
		public int? GetPeriods(){
			return this.periods_;
		}
		
		public void SetPeriods(int? value){
			this.periods_ = value;
		}
		public int? GetIsFirst(){
			return this.isFirst_;
		}
		
		public void SetIsFirst(int? value){
			this.isFirst_ = value;
		}
		public int? GetIsLast(){
			return this.isLast_;
		}
		
		public void SetIsLast(int? value){
			this.isLast_ = value;
		}
		public int? GetIsLock(){
			return this.isLock_;
		}
		
		public void SetIsLock(int? value){
			this.isLock_ = value;
		}
		public long? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(long? value){
			this.payId_ = value;
		}
		public string GetTotalMoney(){
			return this.totalMoney_;
		}
		
		public void SetTotalMoney(string value){
			this.totalMoney_ = value;
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