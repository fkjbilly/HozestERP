using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class OccupiedOrderQueryReq {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 开始时间
		///</summary>
		
		private System.DateTime? startTime_;
		
		///<summary>
		/// 结束时间
		///</summary>
		
		private System.DateTime? endTime_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public System.DateTime? GetStartTime(){
			return this.startTime_;
		}
		
		public void SetStartTime(System.DateTime? value){
			this.startTime_ = value;
		}
		public System.DateTime? GetEndTime(){
			return this.endTime_;
		}
		
		public void SetEndTime(System.DateTime? value){
			this.endTime_ = value;
		}
		
	}
	
}