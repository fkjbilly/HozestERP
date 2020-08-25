using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class FlagVO {
		
		///<summary>
		/// 物流标识号
		///</summary>
		
		private string flagCode_;
		
		///<summary>
		/// 流程时间，格式为：“yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string time_;
		
		public string GetFlagCode(){
			return this.flagCode_;
		}
		
		public void SetFlagCode(string value){
			this.flagCode_ = value;
		}
		public string GetTime(){
			return this.time_;
		}
		
		public void SetTime(string value){
			this.time_ = value;
		}
		
	}
	
}