using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class CloudCooperationNoLogReq {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public int? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(int? value){
			this.cooperationNo_ = value;
		}
		
	}
	
}