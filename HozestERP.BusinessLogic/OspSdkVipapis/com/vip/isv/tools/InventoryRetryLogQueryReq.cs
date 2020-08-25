using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class InventoryRetryLogQueryReq {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 库存更新开始时间
		///</summary>
		
		private System.DateTime? timeFrom_;
		
		///<summary>
		/// 结束时间
		///</summary>
		
		private System.DateTime? timeTo_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public System.DateTime? GetTimeFrom(){
			return this.timeFrom_;
		}
		
		public void SetTimeFrom(System.DateTime? value){
			this.timeFrom_ = value;
		}
		public System.DateTime? GetTimeTo(){
			return this.timeTo_;
		}
		
		public void SetTimeTo(System.DateTime? value){
			this.timeTo_ = value;
		}
		
	}
	
}