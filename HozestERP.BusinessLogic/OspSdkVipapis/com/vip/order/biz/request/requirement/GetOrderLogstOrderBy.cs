using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request.requirement{
	
	
	
	
	
	public class GetOrderLogstOrderBy {
		
		///<summary>
		/// 排序字段
		///</summary>
		
		private com.vip.order.biz.request.requirement.GetOrderLogstOrderByField? field_;
		
		///<summary>
		/// 升降序
		///</summary>
		
		private com.vip.order.biz.request.requirement.OrderByDirection? direction_;
		
		public com.vip.order.biz.request.requirement.GetOrderLogstOrderByField? GetField(){
			return this.field_;
		}
		
		public void SetField(com.vip.order.biz.request.requirement.GetOrderLogstOrderByField? value){
			this.field_ = value;
		}
		public com.vip.order.biz.request.requirement.OrderByDirection? GetDirection(){
			return this.direction_;
		}
		
		public void SetDirection(com.vip.order.biz.request.requirement.OrderByDirection? value){
			this.direction_ = value;
		}
		
	}
	
}