using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class DeletedDeliveryDetail {
		
		///<summary>
		/// 入库单ID
		///</summary>
		
		private string deliveryId_;
		
		///<summary>
		/// 条码
		///</summary>
		
		private string barcode_;
		
		public string GetDeliveryId(){
			return this.deliveryId_;
		}
		
		public void SetDeliveryId(string value){
			this.deliveryId_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		
	}
	
}