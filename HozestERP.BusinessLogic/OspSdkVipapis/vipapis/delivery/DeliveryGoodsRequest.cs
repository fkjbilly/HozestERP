using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DeliveryGoodsRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// po号,多个po请用英文逗号隔开
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string delivery_no_;
		
		///<summary>
		/// 送货仓库
		/// @sampleValue warehouse VIP_NH
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 要求到货时间；空运(delivery_method=2)可选的时间段：9:00:00,16:00:00,18:00:00，23:59:00,20:00:00<br>汽运（delivery_method=1)可选的时间段：9:00:00,16:00:00,20:00:00，22:00:00，23:59:00,10:00:00
		/// @sampleValue arrival_time 2014-07-01 09:00:00
		///</summary>
		
		private string arrival_time_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carrier_code_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 配送方式，1：汽运,2：空运
		/// @sampleValue delivery_method 1
		///</summary>
		
		private string delivery_method_;
		
		///<summary>
		/// 送货批次;时间格式：yyyy-MM-dd HH:mm:ss
		/// @sampleValue delivery_time 2014-07-01 09:00:00
		///</summary>
		
		private string delivery_time_;
		
		///<summary>
		/// 门店编码
		///</summary>
		
		private string store_sn_;
		
		///<summary>
		/// 1. OXO 2. 仓中仓;不填，则为普通JIT类型
		///</summary>
		
		private int? jit_type_;
		
		///<summary>
		/// 送货单列表
		///</summary>
		
		private List<vipapis.delivery.DeliveryGoods> delivery_list_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetDelivery_no(){
			return this.delivery_no_;
		}
		
		public void SetDelivery_no(string value){
			this.delivery_no_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
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
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		public string GetDelivery_method(){
			return this.delivery_method_;
		}
		
		public void SetDelivery_method(string value){
			this.delivery_method_ = value;
		}
		public string GetDelivery_time(){
			return this.delivery_time_;
		}
		
		public void SetDelivery_time(string value){
			this.delivery_time_ = value;
		}
		public string GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(string value){
			this.store_sn_ = value;
		}
		public int? GetJit_type(){
			return this.jit_type_;
		}
		
		public void SetJit_type(int? value){
			this.jit_type_ = value;
		}
		public List<vipapis.delivery.DeliveryGoods> GetDelivery_list(){
			return this.delivery_list_;
		}
		
		public void SetDelivery_list(List<vipapis.delivery.DeliveryGoods> value){
			this.delivery_list_ = value;
		}
		
	}
	
}