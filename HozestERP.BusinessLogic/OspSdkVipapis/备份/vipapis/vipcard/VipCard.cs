using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class VipCard {
		
		///<summary>
		/// 唯品卡卡号
		///</summary>
		
		private string card_code_;
		
		///<summary>
		/// 金额
		///</summary>
		
		private double? money_;
		
		///<summary>
		/// 状态,0:正常；1：已售出；
		///</summary>
		
		private int? state_;
		
		public string GetCard_code(){
			return this.card_code_;
		}
		
		public void SetCard_code(string value){
			this.card_code_ = value;
		}
		public double? GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(double? value){
			this.money_ = value;
		}
		public int? GetState(){
			return this.state_;
		}
		
		public void SetState(int? value){
			this.state_ = value;
		}
		
	}
	
}