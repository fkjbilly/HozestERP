using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.inventory.admin{
	
	
	
	
	
	public class InvUpdateRetryRequest {
		
		///<summary>
		/// 流水号
		///</summary>
		
		private string transId_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 供应商传入库存
		///</summary>
		
		private int? vendorQuantity_;
		
		///<summary>
		/// 购物车占用
		///</summary>
		
		private int? cartQuantity_;
		
		///<summary>
		/// 未支付占用
		///</summary>
		
		private int? unpaidQuantity_;
		
		///<summary>
		/// 剩余库存
		///</summary>
		
		private int? sellableQuantity_;
		
		///<summary>
		/// 是否是pos
		///</summary>
		
		private int? isPos_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 重试次数
		///</summary>
		
		private int? retryTimes_;
		
		///<summary>
		/// 分区仓库代码
		///</summary>
		
		private string areaWarehouseId_;
		
		public string GetTransId(){
			return this.transId_;
		}
		
		public void SetTransId(string value){
			this.transId_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public int? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(int? value){
			this.cooperationNo_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetVendorQuantity(){
			return this.vendorQuantity_;
		}
		
		public void SetVendorQuantity(int? value){
			this.vendorQuantity_ = value;
		}
		public int? GetCartQuantity(){
			return this.cartQuantity_;
		}
		
		public void SetCartQuantity(int? value){
			this.cartQuantity_ = value;
		}
		public int? GetUnpaidQuantity(){
			return this.unpaidQuantity_;
		}
		
		public void SetUnpaidQuantity(int? value){
			this.unpaidQuantity_ = value;
		}
		public int? GetSellableQuantity(){
			return this.sellableQuantity_;
		}
		
		public void SetSellableQuantity(int? value){
			this.sellableQuantity_ = value;
		}
		public int? GetIsPos(){
			return this.isPos_;
		}
		
		public void SetIsPos(int? value){
			this.isPos_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public int? GetRetryTimes(){
			return this.retryTimes_;
		}
		
		public void SetRetryTimes(int? value){
			this.retryTimes_ = value;
		}
		public string GetAreaWarehouseId(){
			return this.areaWarehouseId_;
		}
		
		public void SetAreaWarehouseId(string value){
			this.areaWarehouseId_ = value;
		}
		
	}
	
}