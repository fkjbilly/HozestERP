using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class GetDeliveryDetailRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 出仓单号(送货单号)
		///</summary>
		
		private string storageNo_;
		
		///<summary>
		/// 导入明细分页
		///</summary>
		
		private com.vip.vop.vcloud.common.api.Pagination pagination_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetStorageNo(){
			return this.storageNo_;
		}
		
		public void SetStorageNo(string value){
			this.storageNo_ = value;
		}
		public com.vip.vop.vcloud.common.api.Pagination GetPagination(){
			return this.pagination_;
		}
		
		public void SetPagination(com.vip.vop.vcloud.common.api.Pagination value){
			this.pagination_ = value;
		}
		
	}
	
}