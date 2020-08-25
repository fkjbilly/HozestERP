using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class Delivery {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendorName_;
		
		///<summary>
		/// po单号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 入库单号
		///</summary>
		
		private string storageNo_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string deliveryNo_;
		
		///<summary>
		/// 送货仓库编码
		///</summary>
		
		private string vipWarehouse_;
		
		///<summary>
		/// 配送方式
		///</summary>
		
		private int? deliveryMethod_;
		
		///<summary>
		/// 配送批次
		///</summary>
		
		private System.DateTime? deliveryTime_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carrierCode_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carrierName_;
		
		///<summary>
		/// 出仓时间
		///</summary>
		
		private System.DateTime? outTime_;
		
		///<summary>
		/// 出仓状态
		///</summary>
		
		private int? outFlag_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		///<summary>
		/// 预计到货时间
		///</summary>
		
		private System.DateTime? arrivalTime_;
		
		///<summary>
		/// 实际到货时间
		///</summary>
		
		private System.DateTime? realArrivalTime_;
		
		///<summary>
		/// 预计收货时间
		///</summary>
		
		private System.DateTime? raceTime_;
		
		///<summary>
		/// 实际收货时间
		///</summary>
		
		private System.DateTime? realRaceTime_;
		
		///<summary>
		/// 出仓状态
		///</summary>
		
		private string outFlagDesc_;
		
		///<summary>
		/// erp仓库编码
		///</summary>
		
		private string erpWarehouse_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brandName_;
		
		///<summary>
		/// 送货总数
		///</summary>
		
		private int? totalDeliveryNum_;
		
		///<summary>
		/// 总箱数
		///</summary>
		
		private int? totalBox_;
		
		///<summary>
		/// 配送方式
		///</summary>
		
		private string deliveryMethodDesc_;
		
		///<summary>
		/// ID
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 是否确认
		///</summary>
		
		private long? isSubmit_;
		
		///<summary>
		/// PO信息
		///</summary>
		
		private com.vip.vop.vcloud.jit.Po po_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetVendorName(){
			return this.vendorName_;
		}
		
		public void SetVendorName(string value){
			this.vendorName_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public string GetStorageNo(){
			return this.storageNo_;
		}
		
		public void SetStorageNo(string value){
			this.storageNo_ = value;
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
		public System.DateTime? GetOutTime(){
			return this.outTime_;
		}
		
		public void SetOutTime(System.DateTime? value){
			this.outTime_ = value;
		}
		public int? GetOutFlag(){
			return this.outFlag_;
		}
		
		public void SetOutFlag(int? value){
			this.outFlag_ = value;
		}
		public System.DateTime? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(System.DateTime? value){
			this.createTime_ = value;
		}
		public System.DateTime? GetArrivalTime(){
			return this.arrivalTime_;
		}
		
		public void SetArrivalTime(System.DateTime? value){
			this.arrivalTime_ = value;
		}
		public System.DateTime? GetRealArrivalTime(){
			return this.realArrivalTime_;
		}
		
		public void SetRealArrivalTime(System.DateTime? value){
			this.realArrivalTime_ = value;
		}
		public System.DateTime? GetRaceTime(){
			return this.raceTime_;
		}
		
		public void SetRaceTime(System.DateTime? value){
			this.raceTime_ = value;
		}
		public System.DateTime? GetRealRaceTime(){
			return this.realRaceTime_;
		}
		
		public void SetRealRaceTime(System.DateTime? value){
			this.realRaceTime_ = value;
		}
		public string GetOutFlagDesc(){
			return this.outFlagDesc_;
		}
		
		public void SetOutFlagDesc(string value){
			this.outFlagDesc_ = value;
		}
		public string GetErpWarehouse(){
			return this.erpWarehouse_;
		}
		
		public void SetErpWarehouse(string value){
			this.erpWarehouse_ = value;
		}
		public string GetBrandName(){
			return this.brandName_;
		}
		
		public void SetBrandName(string value){
			this.brandName_ = value;
		}
		public int? GetTotalDeliveryNum(){
			return this.totalDeliveryNum_;
		}
		
		public void SetTotalDeliveryNum(int? value){
			this.totalDeliveryNum_ = value;
		}
		public int? GetTotalBox(){
			return this.totalBox_;
		}
		
		public void SetTotalBox(int? value){
			this.totalBox_ = value;
		}
		public string GetDeliveryMethodDesc(){
			return this.deliveryMethodDesc_;
		}
		
		public void SetDeliveryMethodDesc(string value){
			this.deliveryMethodDesc_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public long? GetIsSubmit(){
			return this.isSubmit_;
		}
		
		public void SetIsSubmit(long? value){
			this.isSubmit_ = value;
		}
		public com.vip.vop.vcloud.jit.Po GetPo(){
			return this.po_;
		}
		
		public void SetPo(com.vip.vop.vcloud.jit.Po value){
			this.po_ = value;
		}
		
	}
	
}