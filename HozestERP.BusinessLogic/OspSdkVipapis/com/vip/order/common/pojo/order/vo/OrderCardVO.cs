using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderCardVO {
		
		///<summary>
		/// 
		///</summary>
		
		private string cardType_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? addTime_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? stopTime_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? state_;
		
		///<summary>
		/// 
		///</summary>
		
		private string cardCode_;
		
		///<summary>
		/// 
		///</summary>
		
		private string money_;
		
		public string GetCardType(){
			return this.cardType_;
		}
		
		public void SetCardType(string value){
			this.cardType_ = value;
		}
		public long? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(long? value){
			this.addTime_ = value;
		}
		public long? GetStopTime(){
			return this.stopTime_;
		}
		
		public void SetStopTime(long? value){
			this.stopTime_ = value;
		}
		public int? GetState(){
			return this.state_;
		}
		
		public void SetState(int? value){
			this.state_ = value;
		}
		public string GetCardCode(){
			return this.cardCode_;
		}
		
		public void SetCardCode(string value){
			this.cardCode_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		
	}
	
}