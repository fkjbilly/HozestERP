using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class SellCardResponse {
		
		///<summary>
		/// 唯品卡卡号
		/// @sampleValue card_code 12111211200095
		///</summary>
		
		private string card_code_;
		
		///<summary>
		/// 唯品卡卡额度
		/// @sampleValue money 100.00
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 唯品卡卡密
		/// @sampleValue activate_code XXXXXXXXXXXXXX
		///</summary>
		
		private string activate_code_;
		
		public string GetCard_code(){
			return this.card_code_;
		}
		
		public void SetCard_code(string value){
			this.card_code_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public string GetActivate_code(){
			return this.activate_code_;
		}
		
		public void SetActivate_code(string value){
			this.activate_code_ = value;
		}
		
	}
	
}