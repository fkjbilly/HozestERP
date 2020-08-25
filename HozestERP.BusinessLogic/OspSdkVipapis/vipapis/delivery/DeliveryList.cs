using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DeliveryList {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private string vendor_id_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// po单号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string delivery_no_;
		
		///<summary>
		/// 送货仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storage_no_;
		
		///<summary>
		/// 出仓时间
		/// @sampleValue out_time 2014-07-01 10:00:00
		///</summary>
		
		private string out_time_;
		
		///<summary>
		/// 预计到货时间
		/// @sampleValue arrive_time 2014-07-01 10:00:00
		///</summary>
		
		private string arrive_time_;
		
		///<summary>
		/// 实际到货时间
		/// @sampleValue real_arrive_time 2014-07-01 10:00:00
		///</summary>
		
		private string real_arrive_time_;
		
		///<summary>
		/// 预计收货时间
		/// @sampleValue race_time 2014-07-01 10:00:00
		///</summary>
		
		private string race_time_;
		
		///<summary>
		/// 实际收货时间
		/// @sampleValue real_race_time 2014-07-01 10:00:00
		///</summary>
		
		private string real_race_time_;
		
		///<summary>
		/// 送货状态, 1:已出仓，0
		///</summary>
		
		private string out_flag_;
		
		///<summary>
		/// 创建时间
		/// @sampleValue create_time 2014-07-01 10:00:00
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 门店编码
		///</summary>
		
		private string store_sn_;
		
		///<summary>
		/// 送货时间
		/// @sampleValue delivery_time 2015-12-02 00:00:00
		///</summary>
		
		private string delivery_time_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carrier_code_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 配送方式 0默认值,1:汽运,2:空运
		///</summary>
		
		private string delivery_method_;
		
		public string GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(string value){
			this.vendor_id_ = value;
		}
		public string GetVendor_name(){
			return this.vendor_name_;
		}
		
		public void SetVendor_name(string value){
			this.vendor_name_ = value;
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
		public string GetStorage_no(){
			return this.storage_no_;
		}
		
		public void SetStorage_no(string value){
			this.storage_no_ = value;
		}
		public string GetOut_time(){
			return this.out_time_;
		}
		
		public void SetOut_time(string value){
			this.out_time_ = value;
		}
		public string GetArrive_time(){
			return this.arrive_time_;
		}
		
		public void SetArrive_time(string value){
			this.arrive_time_ = value;
		}
		public string GetReal_arrive_time(){
			return this.real_arrive_time_;
		}
		
		public void SetReal_arrive_time(string value){
			this.real_arrive_time_ = value;
		}
		public string GetRace_time(){
			return this.race_time_;
		}
		
		public void SetRace_time(string value){
			this.race_time_ = value;
		}
		public string GetReal_race_time(){
			return this.real_race_time_;
		}
		
		public void SetReal_race_time(string value){
			this.real_race_time_ = value;
		}
		public string GetOut_flag(){
			return this.out_flag_;
		}
		
		public void SetOut_flag(string value){
			this.out_flag_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public string GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(string value){
			this.store_sn_ = value;
		}
		public string GetDelivery_time(){
			return this.delivery_time_;
		}
		
		public void SetDelivery_time(string value){
			this.delivery_time_ = value;
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
		
	}
	
}