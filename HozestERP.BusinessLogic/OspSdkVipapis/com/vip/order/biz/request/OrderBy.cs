using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class OrderBy {
		
		///<summary>
		/// 排序字段
		///</summary>
		
		private string field_;
		
		///<summary>
		/// 升降序
		///</summary>
		
		private string direction_;
		
		public string GetField(){
			return this.field_;
		}
		
		public void SetField(string value){
			this.field_ = value;
		}
		public string GetDirection(){
			return this.direction_;
		}
		
		public void SetDirection(string value){
			this.direction_ = value;
		}
		
	}
	
}