using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class SpecialCondition {
		
		///<summary>
		/// 关联类型，and, or
		///</summary>
		
		private string relType_;
		
		///<summary>
		/// 过滤条件项
		///</summary>
		
		private List<com.vip.order.biz.request.ConditionItem> conditionItems_;
		
		///<summary>
		/// 第二层条件
		///</summary>
		
		private List<com.vip.order.biz.request.SubCondition> subConditions_;
		
		public string GetRelType(){
			return this.relType_;
		}
		
		public void SetRelType(string value){
			this.relType_ = value;
		}
		public List<com.vip.order.biz.request.ConditionItem> GetConditionItems(){
			return this.conditionItems_;
		}
		
		public void SetConditionItems(List<com.vip.order.biz.request.ConditionItem> value){
			this.conditionItems_ = value;
		}
		public List<com.vip.order.biz.request.SubCondition> GetSubConditions(){
			return this.subConditions_;
		}
		
		public void SetSubConditions(List<com.vip.order.biz.request.SubCondition> value){
			this.subConditions_ = value;
		}
		
	}
	
}