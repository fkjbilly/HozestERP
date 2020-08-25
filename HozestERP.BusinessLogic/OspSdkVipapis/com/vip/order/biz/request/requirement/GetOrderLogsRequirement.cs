using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request.requirement{
	
	
	
	
	
	public class GetOrderLogsRequirement {
		
		///<summary>
		/// order返回字段集
		///</summary>
		
		private string returnFields_;
		
		///<summary>
		/// 返回记录条数,不能>=500
		///</summary>
		
		private int? limit_;
		
		///<summary>
		/// 记录起始数
		///</summary>
		
		private int? offset_;
		
		///<summary>
		/// 排序方式
		///</summary>
		
		private List<com.vip.order.biz.request.requirement.GetOrderLogstOrderBy> orderbyList_;
		
		public string GetReturnFields(){
			return this.returnFields_;
		}
		
		public void SetReturnFields(string value){
			this.returnFields_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		public int? GetOffset(){
			return this.offset_;
		}
		
		public void SetOffset(int? value){
			this.offset_ = value;
		}
		public List<com.vip.order.biz.request.requirement.GetOrderLogstOrderBy> GetOrderbyList(){
			return this.orderbyList_;
		}
		
		public void SetOrderbyList(List<com.vip.order.biz.request.requirement.GetOrderLogstOrderBy> value){
			this.orderbyList_ = value;
		}
		
	}
	
}