using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OrderBatchInfo {
		
		///<summary>
		/// 状态类型
		///</summary>
		
		private string statusType_;
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private string vendorId_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 明细信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfo> details_;
		
		///<summary>
		/// 批次订单数 
		///</summary>
		
		private string totalShipments_;
		
		///<summary>
		/// 批次sku数
		///</summary>
		
		private string totalSku_;
		
		///<summary>
		/// 批次库区数
		///</summary>
		
		private string pickZone_;
		
		public string GetStatusType(){
			return this.statusType_;
		}
		
		public void SetStatusType(string value){
			this.statusType_ = value;
		}
		public string GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(string value){
			this.vendorId_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfo> GetDetails(){
			return this.details_;
		}
		
		public void SetDetails(List<com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfo> value){
			this.details_ = value;
		}
		public string GetTotalShipments(){
			return this.totalShipments_;
		}
		
		public void SetTotalShipments(string value){
			this.totalShipments_ = value;
		}
		public string GetTotalSku(){
			return this.totalSku_;
		}
		
		public void SetTotalSku(string value){
			this.totalSku_ = value;
		}
		public string GetPickZone(){
			return this.pickZone_;
		}
		
		public void SetPickZone(string value){
			this.pickZone_ = value;
		}
		
	}
	
}