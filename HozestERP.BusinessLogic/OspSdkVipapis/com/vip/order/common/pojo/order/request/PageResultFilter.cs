using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.request{
	
	
	
	
	
	public class PageResultFilter {
		
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
		
		private List<com.vip.order.common.pojo.order.request.OrderBy> orderby_;
		
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
		public List<com.vip.order.common.pojo.order.request.OrderBy> GetOrderby(){
			return this.orderby_;
		}
		
		public void SetOrderby(List<com.vip.order.common.pojo.order.request.OrderBy> value){
			this.orderby_ = value;
		}
		
	}
	
}