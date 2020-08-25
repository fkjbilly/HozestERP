using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vendor{
	
	
	
	
	
	public class VisVendorInfo {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendorName_;
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? ebsId_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendorCode_;
		
		///<summary>
		/// 税号
		///</summary>
		
		private string taxReference_;
		
		///<summary>
		/// 供应商类型(1:总公司,2:代理商,3:制造商,4:通用供应商，5：品牌商,6:品信供应商，99：其他
		///</summary>
		
		private int? vendorType_;
		
		///<summary>
		/// 供应商地址
		///</summary>
		
		private string vendorAddr_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private int? auditStatus_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetVendorName(){
			return this.vendorName_;
		}
		
		public void SetVendorName(string value){
			this.vendorName_ = value;
		}
		public int? GetEbsId(){
			return this.ebsId_;
		}
		
		public void SetEbsId(int? value){
			this.ebsId_ = value;
		}
		public string GetVendorCode(){
			return this.vendorCode_;
		}
		
		public void SetVendorCode(string value){
			this.vendorCode_ = value;
		}
		public string GetTaxReference(){
			return this.taxReference_;
		}
		
		public void SetTaxReference(string value){
			this.taxReference_ = value;
		}
		public int? GetVendorType(){
			return this.vendorType_;
		}
		
		public void SetVendorType(int? value){
			this.vendorType_ = value;
		}
		public string GetVendorAddr(){
			return this.vendorAddr_;
		}
		
		public void SetVendorAddr(string value){
			this.vendorAddr_ = value;
		}
		public int? GetAuditStatus(){
			return this.auditStatus_;
		}
		
		public void SetAuditStatus(int? value){
			this.auditStatus_ = value;
		}
		
	}
	
}