using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class CardNumber {
		
		///<summary>
		/// 唯品卡卡号
		/// @sampleValue card_code 16090229100011
		///</summary>
		
		private string card_code_;
		
		public string GetCard_code(){
			return this.card_code_;
		}
		
		public void SetCard_code(string value){
			this.card_code_ = value;
		}
		
	}
	
}