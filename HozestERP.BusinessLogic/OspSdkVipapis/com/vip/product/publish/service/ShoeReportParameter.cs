using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.product.publish.service{
	
	
	
	
	
	public class ShoeReportParameter {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 唯品会鞋码属性值ID和知足鞋码对应关系json
		///</summary>
		
		private string sizeRelationshipJson_;
		
		///<summary>
		/// 鞋品标记
		///</summary>
		
		private string shoeTags_;
		
		///<summary>
		/// 测鞋结果
		///</summary>
		
		private string result_;
		
		///<summary>
		/// 试穿体验报告
		///</summary>
		
		private string reportJson_;
		
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
		public string GetSizeRelationshipJson(){
			return this.sizeRelationshipJson_;
		}
		
		public void SetSizeRelationshipJson(string value){
			this.sizeRelationshipJson_ = value;
		}
		public string GetShoeTags(){
			return this.shoeTags_;
		}
		
		public void SetShoeTags(string value){
			this.shoeTags_ = value;
		}
		public string GetResult(){
			return this.result_;
		}
		
		public void SetResult(string value){
			this.result_ = value;
		}
		public string GetReportJson(){
			return this.reportJson_;
		}
		
		public void SetReportJson(string value){
			this.reportJson_ = value;
		}
		
	}
	
}