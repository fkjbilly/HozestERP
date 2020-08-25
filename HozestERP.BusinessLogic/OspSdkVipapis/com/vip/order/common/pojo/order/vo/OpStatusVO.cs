using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OpStatusVO {
		
		///<summary>
		/// 操作名
		///</summary>
		
		private string op_;
		
		///<summary>
		/// 是否可操作 0 不可以 1 可以
		///</summary>
		
		private int? opFlag_;
		
		public string GetOp(){
			return this.op_;
		}
		
		public void SetOp(string value){
			this.op_ = value;
		}
		public int? GetOpFlag(){
			return this.opFlag_;
		}
		
		public void SetOpFlag(int? value){
			this.opFlag_ = value;
		}
		
	}
	
}