using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class VendorSalesQueryReq {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private long? vendorId_;
		
		///<summary>
		/// 专场id
		///</summary>
		
		private long? salesNo_;
		
		///<summary>
		/// 开售时间（起）
		///</summary>
		
		private System.DateTime? timeFrom_;
		
		///<summary>
		/// 开售时间（至）
		///</summary>
		
		private System.DateTime? timeTo_;
		
		public long? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(long? value){
			this.vendorId_ = value;
		}
		public long? GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(long? value){
			this.salesNo_ = value;
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