using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class SuccessSkuItem {
		
		///<summary>
		/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码
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