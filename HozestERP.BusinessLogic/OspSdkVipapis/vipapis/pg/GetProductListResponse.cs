using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.pg{
	
	
	
	
	
	public class GetProductListResponse {
		
		///<summary>
		/// products
		///</summary>
		
		private List<vipapis.pg.Product> goods_;
		
		///<summary>
		/// total
		///</summary>
		
		private int? total_;
		
		public List<vipapis.pg.Product> GetGoods(){
			return this.goods_;
		}
		
		public void SetGoods(List<vipapis.pg.Product> value){
			this.goods_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}