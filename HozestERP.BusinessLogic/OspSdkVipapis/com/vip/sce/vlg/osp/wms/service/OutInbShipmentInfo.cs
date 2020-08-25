using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutInbShipmentInfo {
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouseId_;
		
		///<summary>
		/// 企业入仓编号
		///</summary>
		
		private string entInboundId_;
		
		///<summary>
		/// 理货单ID
		///</summary>
		
		private string asnNo_;
		
		///<summary>
		/// 入仓批次号
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 入仓时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string inTime_;
		
		///<summary>
		/// 申报时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string confirmationTime_;
		
		///<summary>
		/// 海关入仓编号
		///</summary>
		
		private string custInboundno_;
		
		///<summary>
		/// 国检入仓编号
		///</summary>
		
		private string icipInboundno_;
		
		///<summary>
		/// 提单号
		///</summary>
		
		private string blNo_;
		
		///<summary>
		/// 入仓批次明细信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfo> detail_;
		
		public string GetWarehouseId(){
			return this.warehouseId_;
		}
		
		public void SetWarehouseId(string value){
			this.warehouseId_ = value;
		}
		public string GetEntInboundId(){
			return this.entInboundId_;
		}
		
		public void SetEntInboundId(string value){
			this.entInboundId_ = value;
		}
		public string GetAsnNo(){
			return this.asnNo_;
		}
		
		public void SetAsnNo(string value){
			this.asnNo_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public string GetInTime(){
			return this.inTime_;
		}
		
		public void SetInTime(string value){
			this.inTime_ = value;
		}
		public string GetConfirmationTime(){
			return this.confirmationTime_;
		}
		
		public void SetConfirmationTime(string value){
			this.confirmationTime_ = value;
		}
		public string GetCustInboundno(){
			return this.custInboundno_;
		}
		
		public void SetCustInboundno(string value){
			this.custInboundno_ = value;
		}
		public string GetIcipInboundno(){
			return this.icipInboundno_;
		}
		
		public void SetIcipInboundno(string value){
			this.icipInboundno_ = value;
		}
		public string GetBlNo(){
			return this.blNo_;
		}
		
		public void SetBlNo(string value){
			this.blNo_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfo> GetDetail(){
			return this.detail_;
		}
		
		public void SetDetail(List<com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfo> value){
			this.detail_ = value;
		}
		
	}
	
}