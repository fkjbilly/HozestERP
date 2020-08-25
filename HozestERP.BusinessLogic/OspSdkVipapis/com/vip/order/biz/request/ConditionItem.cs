using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ConditionItem {
		
		///<summary>
		/// 字段名，格式为'TypeName.FieldName'，内部需要对字段名进行内部映射及类型判断
		///</summary>
		
		private string fieldName_;
		
		///<summary>
		/// 条件表达式，=, <, >, in, not in, <>, like等
		///</summary>
		
		private string expr_;
		
		///<summary>
		/// 过滤条件值，值的类型通用为string，具体的类型根据field_name内部确定，仅支持单个值的条件表达式只取第一个值
		///</summary>
		
		private List<string> values_;
		
		public string GetFieldName(){
			return this.fieldName_;
		}
		
		public void SetFieldName(string value){
			this.fieldName_ = value;
		}
		public string GetExpr(){
			return this.expr_;
		}
		
		public void SetExpr(string value){
			this.expr_ = value;
		}
		public List<string> GetValues(){
			return this.values_;
		}
		
		public void SetValues(List<string> value){
			this.values_ = value;
		}
		
	}
	
}