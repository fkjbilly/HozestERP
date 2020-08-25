using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class VendorInventoryLogRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.VendorInventoryLogDo> vendorInventoryLogDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.VendorInventoryLogDo> GetVendorInventoryLogDos(){
			return this.vendorInventoryLogDos_;
		}
		
		public void SetVendorInventoryLogDos(List<com.vip.isv.tools.VendorInventoryLogDo> value){
			this.vendorInventoryLogDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}