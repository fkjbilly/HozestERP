using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DeleteDeliveryDetail {
		
		///<summary>
		/// <font color='red'>入库单号,对应创建出仓单返回的编码storage_no</font>
		///</summary>
		
		private string delivery_no_;
		
		///<summary>
		/// 条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// <s><font color='red'>出仓明细Id(作废)</font></s>
		///</summary>
		
		private string delivery_detail_id_;
		
		public string GetDelivery_no(){
			return this.delivery_no_;
		}
		
		public void SetDelivery_no(string value){
			this.delivery_no_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetDelivery_detail_id(){
			return this.delivery_detail_id_;
		}
		
		public void SetDelivery_detail_id(string value){
			this.delivery_detail_id_ = value;
		}
		
	}
	
}