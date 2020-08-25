using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderPosVO {
		
		///<summary>
		/// 
		///</summary>
		
		private int? flag_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? addTime_;
		
		public int? GetFlag(){
			return this.flag_;
		}
		
		public void SetFlag(int? value){
			this.flag_ = value;
		}
		public long? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(long? value){
			this.addTime_ = value;
		}
		
	}
	
}