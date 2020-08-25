using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class OrderIsAllowModel {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private bool? isAllow_;
		
		public bool? GetIsAllow(){
			return this.isAllow_;
		}
		
		public void SetIsAllow(bool? value){
			this.isAllow_ = value;
		}
		
	}
	
}