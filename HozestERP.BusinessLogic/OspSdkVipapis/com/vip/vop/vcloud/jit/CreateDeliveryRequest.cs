using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class CreateDeliveryRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// po号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string deliveryNo_;
		
		///<summary>
		/// 送货仓库编码
		///</summary>
		
		private string vipWarehouse_;
		
		///<summary>
		/// 配送方式 1：汽运,2：空运, 默认值：1
		///</summary>
		
		private int? deliveryMethod_;
		
		///<summary>
		/// 发货时间(配送批次)
		///</summary>
		
		private System.DateTime? deliveryTime_;
		
		///<summary>
		/// 要求到货时间
		///</summary>
		
		private System.DateTime? arrivalTime_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carrierCode_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carrierName_;
		
		///<summary>
		/// ERP送货仓库
		///</summary>
		
		private string erpWarehouse_;
		
		///<summary>
		/// 门店拣货号
		///</summary>
		
		private List<string> subPickNos_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public string GetDeliveryNo(){
			return this.deliveryNo_;
		}
		
		public void SetDeliveryNo(string value){
			this.deliveryNo_ = value;
		}
		public string GetVipWarehouse(){
			return this.vipWarehouse_;
		}
		
		public void SetVipWarehouse(string value){
			this.vipWarehouse_ = value;
		}
		public int? GetDeliveryMethod(){
			return this.deliveryMethod_;
		}
		
		public void SetDeliveryMethod(int? value){
			this.deliveryMethod_ = value;
		}
		public System.DateTime? GetDeliveryTime(){
			return this.deliveryTime_;
		}
		
		public void SetDeliveryTime(System.DateTime? value){
			this.deliveryTime_ = value;
		}
		public System.DateTime? GetArrivalTime(){
			return this.arrivalTime_;
		}
		
		public void SetArrivalTime(System.DateTime? value){
			this.arrivalTime_ = value;
		}
		public string GetCarrierCode(){
			return this.carrierCode_;
		}
		
		public void SetCarrierCode(string value){
			this.carrierCode_ = value;
		}
		public string GetCarrierName(){
			return this.carrierName_;
		}
		
		public void SetCarrierName(string value){
			this.carrierName_ = value;
		}
		public string GetErpWarehouse(){
			return this.erpWarehouse_;
		}
		
		public void SetErpWarehouse(string value){
			this.erpWarehouse_ = value;
		}
		public List<string> GetSubPickNos(){
			return this.subPickNos_;
		}
		
		public void SetSubPickNos(List<string> value){
			this.subPickNos_ = value;
		}
		
	}
	
}