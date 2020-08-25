using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class VendorSalesRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.VendorSalesDo> vendorSalesDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.VendorSalesDo> GetVendorSalesDos(){
			return this.vendorSalesDos_;
		}
		
		public void SetVendorSalesDos(List<com.vip.isv.tools.VendorSalesDo> value){
			this.vendorSalesDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}