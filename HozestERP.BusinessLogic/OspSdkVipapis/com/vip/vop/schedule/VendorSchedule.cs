using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.schedule{
	
	
	
	
	
	public class VendorSchedule {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private long? vendorId_;
		
		///<summary>
		/// 档期id
		///</summary>
		
		private long? scheduleId_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private long? cooperationNo_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 业务类型，1：oxo
		///</summary>
		
		private int? businessType_;
		
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
		public long? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(long? value){
			this.cooperationNo_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetBusinessType(){
			return this.businessType_;
		}
		
		public void SetBusinessType(int? value){
			this.businessType_ = value;
		}
		
	}
	
}