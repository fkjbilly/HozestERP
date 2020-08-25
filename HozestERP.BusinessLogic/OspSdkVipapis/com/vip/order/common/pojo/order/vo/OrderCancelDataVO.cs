using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderCancelDataVO {
		
		///<summary>
		/// 
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 
		///</summary>
		
		private string walletMoney_;
		
		///<summary>
		/// 
		///</summary>
		
		private string virtualMoney_;
		
		///<summary>
		/// 
		///</summary>
		
		private string totalMoney_;
		
		///<summary>
		/// 
		///</summary>
		
		private string couponMoney_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? returnCouponType_;
		
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
		public string GetTotalMoney(){
			return this.totalMoney_;
		}
		
		public void SetTotalMoney(string value){
			this.totalMoney_ = value;
		}
		public string GetCouponMoney(){
			return this.couponMoney_;
		}
		
		public void SetCouponMoney(string value){
			this.couponMoney_ = value;
		}
		public int? GetReturnCouponType(){
			return this.returnCouponType_;
		}
		
		public void SetReturnCouponType(int? value){
			this.returnCouponType_ = value;
		}
		
	}
	
}