using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DeleteDeliveryDetail {
		
		///<summary>
		/// 送货单编号
		///</summary>
		
		private string delivery_no_;
		
		///<summary>
		/// 条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 出仓明细Id
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