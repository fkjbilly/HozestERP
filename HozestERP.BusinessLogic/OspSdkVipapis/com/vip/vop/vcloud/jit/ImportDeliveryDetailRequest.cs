using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class ImportDeliveryDetailRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// po号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storageNo_;
		
		///<summary>
		/// 入库单导入商品列表
		///</summary>
		
		private List<com.vip.vop.vcloud.jit.DeliveryDetail> deliveryDetails_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public string GetStorageNo(){
			return this.storageNo_;
		}
		
		public void SetStorageNo(string value){
			this.storageNo_ = value;
		}
		public List<com.vip.vop.vcloud.jit.DeliveryDetail> GetDeliveryDetails(){
			return this.deliveryDetails_;
		}
		
		public void SetDeliveryDetails(List<com.vip.vop.vcloud.jit.DeliveryDetail> value){
			this.deliveryDetails_ = value;
		}
		
	}
	
}