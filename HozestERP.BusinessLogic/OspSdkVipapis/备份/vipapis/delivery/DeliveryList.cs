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
		/// PO单号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 送货单号
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
		/// 送货时间
		///</summary>
		
		private string out_time_;
		
		///<summary>
		/// 预计到货时间
		///</summary>
		
		private string arrive_time_;
		
		///<summary>
		/// 实际到货时间
		///</summary>
		
		private string real_arrive_time_;
		
		///<summary>
		/// 预计收获时间
		///</summary>
		
		private string race_time_;
		
		///<summary>
		/// 实际收获时间
		///</summary>
		
		private string real_race_time_;
		
		///<summary>
		/// 送货状态
		///</summary>
		
		private string out_flag_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private string create_time_;
		
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
		
	}
	
}