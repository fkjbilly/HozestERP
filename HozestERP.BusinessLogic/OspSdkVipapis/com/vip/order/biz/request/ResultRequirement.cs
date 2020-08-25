using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ResultRequirement {
		
		///<summary>
		/// 返回字段
		///</summary>
		
		private List<string> returnFieldList_;
		
		///<summary>
		/// 返回记录条数，默认500条
		///</summary>
		
		private int? limit_;
		
		///<summary>
		/// 记录起始数
		///</summary>
		
		private int? offset_;
		
		///<summary>
		/// 排序方式
		///</summary>
		
		private List<com.vip.order.biz.request.OrderBy> orderbyList_;
		
		public List<string> GetReturnFieldList(){
			return this.returnFieldList_;
		}
		
		public void SetReturnFieldList(List<string> value){
			this.returnFieldList_ = value;
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
		public List<com.vip.order.biz.request.OrderBy> GetOrderbyList(){
			return this.orderbyList_;
		}
		
		public void SetOrderbyList(List<com.vip.order.biz.request.OrderBy> value){
			this.orderbyList_ = value;
		}
		
	}
	
}