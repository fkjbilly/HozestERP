using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class VipCard {
		
		///<summary>
		/// 唯品卡卡号
		/// @sampleValue card_code 16090229100011
		///</summary>
		
		private string card_code_;
		
		///<summary>
		/// 金额
		/// @sampleValue money 200
		///</summary>
		
		private double? money_;
		
		///<summary>
		/// 状态,0:未售卖，1:已售，2:已激活，3:已作废 
		/// @sampleValue state 1
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