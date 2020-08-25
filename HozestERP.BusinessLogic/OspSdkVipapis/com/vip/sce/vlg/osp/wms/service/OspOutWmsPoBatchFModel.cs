using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OspOutWmsPoBatchFModel {
		
		///<summary>
		/// 批次ID
		///</summary>
		
		private int? batchId_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// PO编号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 订单类型
		///</summary>
		
		private string poType_;
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendorCode_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendorName_;
		
		///<summary>
		/// 贸易模式（EXW，FOB，CIF）
		///</summary>
		
		private string tradeModel_;
		
		///<summary>
		/// 送货时间(单位：毫秒)
		///</summary>
		
		private System.DateTime? deliveryTime_;
		
		///<summary>
		/// 预计到货时间(单位：毫秒)
		///</summary>
		
		private System.DateTime? estimateArriveTime_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 库存类型
		///</summary>
		
		private string warehouseType_;
		
		///<summary>
		/// 明细
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModel> product_List_;
		
		public int? GetBatchId(){
			return this.batchId_;
		}
		
		public void SetBatchId(int? value){
			this.batchId_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public string GetPoType(){
			return this.poType_;
		}
		
		public void SetPoType(string value){
			this.poType_ = value;
		}
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetVendorCode(){
			return this.vendorCode_;
		}
		
		public void SetVendorCode(string value){
			this.vendorCode_ = value;
		}
		public string GetVendorName(){
			return this.vendorName_;
		}
		
		public void SetVendorName(string value){
			this.vendorName_ = value;
		}
		public string GetTradeModel(){
			return this.tradeModel_;
		}
		
		public void SetTradeModel(string value){
			this.tradeModel_ = value;
		}
		public System.DateTime? GetDeliveryTime(){
			return this.deliveryTime_;
		}
		
		public void SetDeliveryTime(System.DateTime? value){
			this.deliveryTime_ = value;
		}
		public System.DateTime? GetEstimateArriveTime(){
			return this.estimateArriveTime_;
		}
		
		public void SetEstimateArriveTime(System.DateTime? value){
			this.estimateArriveTime_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetWarehouseType(){
			return this.warehouseType_;
		}
		
		public void SetWarehouseType(string value){
			this.warehouseType_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModel> GetProduct_List(){
			return this.product_List_;
		}
		
		public void SetProduct_List(List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModel> value){
			this.product_List_ = value;
		}
		
	}
	
}