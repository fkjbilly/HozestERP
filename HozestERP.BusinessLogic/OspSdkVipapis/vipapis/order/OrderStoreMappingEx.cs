using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderStoreMappingEx {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 目标门店编码
		///</summary>
		
		private string store_sn_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(string value){
			this.store_sn_ = value;
		}
		
	}
	
}