using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class CancelCardFailMessage {
		
		///<summary>
		/// 唯品卡卡号
		/// @sampleValue card_code 16035529100000
		///</summary>
		
		private string card_code_;
		
		///<summary>
		/// 失败原因
		/// @sampleValue reason 该卡不属于分销商
		///</summary>
		
		private string reason_;
		
		public string GetCard_code(){
			return this.card_code_;
		}
		
		public void SetCard_code(string value){
			this.card_code_ = value;
		}
		public string GetReason(){
			return this.reason_;
		}
		
		public void SetReason(string value){
			this.reason_ = value;
		}
		
	}
	
}