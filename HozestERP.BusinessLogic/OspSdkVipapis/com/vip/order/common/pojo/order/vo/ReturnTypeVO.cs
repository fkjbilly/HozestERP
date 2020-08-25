using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ReturnTypeVO {
		
		///<summary>
		/// 退款类型
		///</summary>
		
		private string type_;
		
		///<summary>
		/// 退回零钱
		///</summary>
		
		private string wallet_;
		
		///<summary>
		/// 礼品卡/代金券
		///</summary>
		
		private string giftMoney_;
		
		///<summary>
		/// 退回代金券金额
		///</summary>
		
		private string favMoney_;
		
		///<summary>
		/// 退信用卡金额
		///</summary>
		
		private string creditCardMoney_;
		
		public string GetType(){
			return this.type_;
		}
		
		public void SetType(string value){
			this.type_ = value;
		}
		public string GetWallet(){
			return this.wallet_;
		}
		
		public void SetWallet(string value){
			this.wallet_ = value;
		}
		public string GetGiftMoney(){
			return this.giftMoney_;
		}
		
		public void SetGiftMoney(string value){
			this.giftMoney_ = value;
		}
		public string GetFavMoney(){
			return this.favMoney_;
		}
		
		public void SetFavMoney(string value){
			this.favMoney_ = value;
		}
		public string GetCreditCardMoney(){
			return this.creditCardMoney_;
		}
		
		public void SetCreditCardMoney(string value){
			this.creditCardMoney_ = value;
		}
		
	}
	
}