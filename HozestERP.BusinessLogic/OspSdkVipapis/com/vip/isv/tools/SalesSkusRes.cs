using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class SalesSkusRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.SalesSkusDo> salesSkusDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.SalesSkusDo> GetSalesSkusDos(){
			return this.salesSkusDos_;
		}
		
		public void SetSalesSkusDos(List<com.vip.isv.tools.SalesSkusDo> value){
			this.salesSkusDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}