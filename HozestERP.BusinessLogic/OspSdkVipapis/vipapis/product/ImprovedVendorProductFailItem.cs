using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ImprovedVendorProductFailItem {
		
		///<summary>
		/// 条形码
		/// @sampleValue barcode 113113302011245
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 失败信息
		/// @sampleValue msg 供应商不存在
		///</summary>
		
		private string msg_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		
	}
	
}