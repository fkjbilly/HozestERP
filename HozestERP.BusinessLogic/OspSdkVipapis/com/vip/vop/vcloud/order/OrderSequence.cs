using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.order{
	
	
	
	
	
	public class OrderSequence {
		
		///<summary>
		/// nextId
		///</summary>
		
		private int? nextId_;
		
		///<summary>
		/// name
		///</summary>
		
		private string name_;
		
		///<summary>
		/// lastUpdateTime
		///</summary>
		
		private System.DateTime? lastUpdateTime_;
		
		public int? GetNextId(){
			return this.nextId_;
		}
		
		public void SetNextId(int? value){
			this.nextId_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public System.DateTime? GetLastUpdateTime(){
			return this.lastUpdateTime_;
		}
		
		public void SetLastUpdateTime(System.DateTime? value){
			this.lastUpdateTime_ = value;
		}
		
	}
	
}