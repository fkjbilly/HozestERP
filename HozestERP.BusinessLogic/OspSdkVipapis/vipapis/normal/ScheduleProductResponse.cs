using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class ScheduleProductResponse {
		
		///<summary>
		/// 档期商品信息列表
		///</summary>
		
		private List<vipapis.normal.Product> productList_;
		
		///<summary>
		/// 记录总条数
		/// @sampleValue total 0
		///</summary>
		
		private int? total_;
		
		public List<vipapis.normal.Product> GetProductList(){
			return this.productList_;
		}
		
		public void SetProductList(List<vipapis.normal.Product> value){
			this.productList_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}