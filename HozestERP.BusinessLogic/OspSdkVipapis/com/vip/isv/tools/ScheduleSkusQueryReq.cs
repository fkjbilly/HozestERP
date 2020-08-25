using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class ScheduleSkusQueryReq {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		///<summary>
		/// 档期id
		///</summary>
		
		private int? scheduleId_;
		
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
		public int? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(int? value){
			this.cooperationNo_ = value;
		}
		public int? GetScheduleId(){
			return this.scheduleId_;
		}
		
		public void SetScheduleId(int? value){
			this.scheduleId_ = value;
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