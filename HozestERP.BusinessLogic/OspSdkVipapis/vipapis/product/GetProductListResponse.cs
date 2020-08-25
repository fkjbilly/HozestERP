using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class GetProductListResponse {
		
		///<summary>
		/// 商品列表
		///</summary>
		
		private List<vipapis.product.Product> products_;
		
		///<summary>
		/// 总记录条数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 下一页记录的游标
		///</summary>
		
		private string nextCursorMark_;
		
		public List<vipapis.product.Product> GetProducts(){
			return this.products_;
		}
		
		public void SetProducts(List<vipapis.product.Product> value){
			this.products_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public string GetNextCursorMark(){
			return this.nextCursorMark_;
		}
		
		public void SetNextCursorMark(string value){
			this.nextCursorMark_ = value;
		}
		
	}
	
}