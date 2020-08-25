using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ImprovedVendorProductSuccessItem {
		
		///<summary>
		/// 条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 尺码id
		///</summary>
		
		private long? size_table_id_;
		
		///<summary>
		/// 尺码详情id
		///</summary>
		
		private long? size_detail_id_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public long? GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(long? value){
			this.size_table_id_ = value;
		}
		public long? GetSize_detail_id(){
			return this.size_detail_id_;
		}
		
		public void SetSize_detail_id(long? value){
			this.size_detail_id_ = value;
		}
		
	}
	
}