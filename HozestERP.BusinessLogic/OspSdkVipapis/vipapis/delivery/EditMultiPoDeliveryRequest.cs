using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class EditMultiPoDeliveryRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storage_no_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string delivery_no_;
		
		///<summary>
		/// 送货仓库
		///</summary>
		
		private vipapis.common.Warehouse? warehouse_;
		
		///<summary>
		/// 送货时间
		/// @sampleValue delivery_time 2014-07-01 10:00:00
		///</summary>
		
		private string delivery_time_;
		
		///<summary>
		/// 要求到货时间,空运(delivery_method=2)可选的时间段：9:00:00,16:00:00,18:00:00,23:59:00,20:00:00 ；<br>汽运（delivery_method=1)可选的时间段：9:00:00,16:00:00,20:00:00,22:00:00,23:59:00,10:00:00
		/// @sampleValue arrival_time 2014-07-01 10:00:00
		///</summary>
		
		private string arrival_time_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carrier_code_;
		
		///<summary>
		/// 配送方式
		/// @sampleValue delivery_method 1-汽运,2-空运
		///</summary>
		
		private string delivery_method_;
		
		///<summary>
		/// 门店信息
		///</summary>
		
		private string store_sn_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetStorage_no(){
			return this.storage_no_;
		}
		
		public void SetStorage_no(string value){
			this.storage_no_ = value;
		}
		public string GetDelivery_no(){
			return this.delivery_no_;
		}
		
		public void SetDelivery_no(string value){
			this.delivery_no_ = value;
		}
		public vipapis.common.Warehouse? GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(vipapis.common.Warehouse? value){
			this.warehouse_ = value;
		}
		public string GetDelivery_time(){
			return this.delivery_time_;
		}
		
		public void SetDelivery_time(string value){
			this.delivery_time_ = value;
		}
		public string GetArrival_time(){
			return this.arrival_time_;
		}
		
		public void SetArrival_time(string value){
			this.arrival_time_ = value;
		}
		public string GetCarrier_code(){
			return this.carrier_code_;
		}
		
		public void SetCarrier_code(string value){
			this.carrier_code_ = value;
		}
		public string GetDelivery_method(){
			return this.delivery_method_;
		}
		
		public void SetDelivery_method(string value){
			this.delivery_method_ = value;
		}
		public string GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(string value){
			this.store_sn_ = value;
		}
		
	}
	
}