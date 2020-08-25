using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.request{
	
	
	
	
	
	public class OrderBy {
		
		///<summary>
		/// 排序字段
		///</summary>
		
		private string field_;
		
		///<summary>
		/// 升降序
		///</summary>
		
		private com.vip.order.common.pojo.order.request.OrderByDirection? direction_;
		
		public string GetField(){
			return this.field_;
		}
		
		public void SetField(string value){
			this.field_ = value;
		}
		public com.vip.order.common.pojo.order.request.OrderByDirection? GetDirection(){
			return this.direction_;
		}
		
		public void SetDirection(com.vip.order.common.pojo.order.request.OrderByDirection? value){
			this.direction_ = value;
		}
		
	}
	
}