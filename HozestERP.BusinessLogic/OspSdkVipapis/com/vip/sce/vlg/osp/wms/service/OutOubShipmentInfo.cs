using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutOubShipmentInfo {
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouseId_;
		
		///<summary>
		/// 申报版本
		///</summary>
		
		private string version_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 出仓时间(yyyy-MM-dd HH:mm:ss)
		///</summary>
		
		private string outTime_;
		
		///<summary>
		/// 订单真知码
		///</summary>
		
		private string orderZCode_;
		
		///<summary>
		/// 库存类型
		///</summary>
		
		private string inventoryType_;
		
		///<summary>
		/// 入仓批次明细信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfo> detail_;
		
		public string GetWarehouseId(){
			return this.warehouseId_;
		}
		
		public void SetWarehouseId(string value){
			this.warehouseId_ = value;
		}
		public string GetVersion(){
			return this.version_;
		}
		
		public void SetVersion(string value){
			this.version_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetOutTime(){
			return this.outTime_;
		}
		
		public void SetOutTime(string value){
			this.outTime_ = value;
		}
		public string GetOrderZCode(){
			return this.orderZCode_;
		}
		
		public void SetOrderZCode(string value){
			this.orderZCode_ = value;
		}
		public string GetInventoryType(){
			return this.inventoryType_;
		}
		
		public void SetInventoryType(string value){
			this.inventoryType_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfo> GetDetail(){
			return this.detail_;
		}
		
		public void SetDetail(List<com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfo> value){
			this.detail_ = value;
		}
		
	}
	
}