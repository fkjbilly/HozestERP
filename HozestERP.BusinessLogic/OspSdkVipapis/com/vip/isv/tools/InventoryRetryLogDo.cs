using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class InventoryRetryLogDo {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batchNo_;
		
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
		/// 重试库存数量
		///</summary>
		
		private int? vendorRetryQuantity_;
		
		///<summary>
		/// 实际更新库存
		///</summary>
		
		private int? realQuantity_;
		
		///<summary>
		/// 重试时购物车数量
		///</summary>
		
		private int? cartHold_;
		
		///<summary>
		/// 重试时剩余库存
		///</summary>
		
		private int? sellableQuantity_;
		
		///<summary>
		/// 重试次数
		///</summary>
		
		private int? retryTimes_;
		
		///<summary>
		/// 更新库存消息
		///</summary>
		
		private string errorMsg_;
		
		///<summary>
		/// 重试时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
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
		public int? GetVendorRetryQuantity(){
			return this.vendorRetryQuantity_;
		}
		
		public void SetVendorRetryQuantity(int? value){
			this.vendorRetryQuantity_ = value;
		}
		public int? GetRealQuantity(){
			return this.realQuantity_;
		}
		
		public void SetRealQuantity(int? value){
			this.realQuantity_ = value;
		}
		public int? GetCartHold(){
			return this.cartHold_;
		}
		
		public void SetCartHold(int? value){
			this.cartHold_ = value;
		}
		public int? GetSellableQuantity(){
			return this.sellableQuantity_;
		}
		
		public void SetSellableQuantity(int? value){
			this.sellableQuantity_ = value;
		}
		public int? GetRetryTimes(){
			return this.retryTimes_;
		}
		
		public void SetRetryTimes(int? value){
			this.retryTimes_ = value;
		}
		public string GetErrorMsg(){
			return this.errorMsg_;
		}
		
		public void SetErrorMsg(string value){
			this.errorMsg_ = value;
		}
		public System.DateTime? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(System.DateTime? value){
			this.createTime_ = value;
		}
		
	}
	
}