using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class OrderSplitVO {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 零钱支付流水号
		///</summary>
		
		private string walletPaySn_;
		
		///<summary>
		/// 唯品币支付流水号
		///</summary>
		
		private string pointPaySn_;
		
		///<summary>
		/// 唯品卡支付流水号
		///</summary>
		
		private string favourablePaySn_;
		
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
		public string GetWalletPaySn(){
			return this.walletPaySn_;
		}
		
		public void SetWalletPaySn(string value){
			this.walletPaySn_ = value;
		}
		public string GetPointPaySn(){
			return this.pointPaySn_;
		}
		
		public void SetPointPaySn(string value){
			this.pointPaySn_ = value;
		}
		public string GetFavourablePaySn(){
			return this.favourablePaySn_;
		}
		
		public void SetFavourablePaySn(string value){
			this.favourablePaySn_ = value;
		}
		
	}
	
}