using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.schedule{
	
	
	
	
	
	public class VendorScheduleSku {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private long? vendorId_;
		
		///<summary>
		/// 档期id
		///</summary>
		
		private long? scheduleId_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// sku在pdc唯一id
		///</summary>
		
		private long? vendorSkuId_;
		
		///<summary>
		/// 库存导入状态
		///</summary>
		
		private int? stockPushStatus_;
		
		public long? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(long? value){
			this.vendorId_ = value;
		}
		public long? GetScheduleId(){
			return this.scheduleId_;
		}
		
		public void SetScheduleId(long? value){
			this.scheduleId_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public long? GetVendorSkuId(){
			return this.vendorSkuId_;
		}
		
		public void SetVendorSkuId(long? value){
			this.vendorSkuId_ = value;
		}
		public int? GetStockPushStatus(){
			return this.stockPushStatus_;
		}
		
		public void SetStockPushStatus(int? value){
			this.stockPushStatus_ = value;
		}
		
	}
	
}