using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vendor{
	
	
	
	
	
	public class CooperationNoConfigInfo {
		
		///<summary>
		/// 供应商Id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		///<summary>
		/// 是否禁用:0正常,1禁用
		///</summary>
		
		private int? forbidden_;
		
		///<summary>
		/// 上线阶段(0:内测阶段，1:正式上线)
		///</summary>
		
		private int? stage_;
		
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
		public int? GetForbidden(){
			return this.forbidden_;
		}
		
		public void SetForbidden(int? value){
			this.forbidden_ = value;
		}
		public int? GetStage(){
			return this.stage_;
		}
		
		public void SetStage(int? value){
			this.stage_ = value;
		}
		
	}
	
}