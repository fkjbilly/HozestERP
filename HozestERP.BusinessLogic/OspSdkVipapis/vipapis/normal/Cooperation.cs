using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class Cooperation {
		
		///<summary>
		/// 供应商id
		/// @sampleValue vendor_id 551
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 常态合作编码
		/// @sampleValue cooperation_no 
		///</summary>
		
		private int? cooperation_no_;
		
		///<summary>
		/// 供应商仓库
		/// @sampleValue warehouse_supplier 
		///</summary>
		
		private string warehouse_supplier_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
		}
		public string GetWarehouse_supplier(){
			return this.warehouse_supplier_;
		}
		
		public void SetWarehouse_supplier(string value){
			this.warehouse_supplier_ = value;
		}
		
	}
	
}