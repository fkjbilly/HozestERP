using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DeliveryGoodsList {
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storage_no_;
		
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
		/// 送货时间
		///</summary>
		
		private string out_time_;
		
		///<summary>
		/// 预计到货时间
		///</summary>
		
		private string arrive_time_;
		
		///<summary>
		/// 预计收获时间
		///</summary>
		
		private string race_time_;
		
		///<summary>
		/// 承运商公司名称
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 联系电话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 司机姓名
		///</summary>
		
		private string driver_;
		
		///<summary>
		/// 司机联系电话
		///</summary>
		
		private string driver_tel_;
		
		///<summary>
		/// 车牌
		///</summary>
		
		private string plate_number_;
		
		///<summary>
		/// 商品编号(条形码)
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private string amount_;
		
		public string GetStorage_no(){
			return this.storage_no_;
		}
		
		public void SetStorage_no(string value){
			this.storage_no_ = value;
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
		public string GetRace_time(){
			return this.race_time_;
		}
		
		public void SetRace_time(string value){
			this.race_time_ = value;
		}
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public string GetDriver(){
			return this.driver_;
		}
		
		public void SetDriver(string value){
			this.driver_ = value;
		}
		public string GetDriver_tel(){
			return this.driver_tel_;
		}
		
		public void SetDriver_tel(string value){
			this.driver_tel_ = value;
		}
		public string GetPlate_number(){
			return this.plate_number_;
		}
		
		public void SetPlate_number(string value){
			this.plate_number_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(string value){
			this.amount_ = value;
		}
		
	}
	
}