using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.schema{
	
	
	
	
	
	public class SuccessSkuItem {
		
		///<summary>
		/// 款色号
		/// @sampleValue group_sn 1423424413
		///</summary>
		
		private string group_sn_;
		
		///<summary>
		/// 条形码
		/// @sampleValue barcode 113113302011245
		///</summary>
		
		private string barcode_;
		
		public string GetGroup_sn(){
			return this.group_sn_;
		}
		
		public void SetGroup_sn(string value){
			this.group_sn_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		
	}
	
}