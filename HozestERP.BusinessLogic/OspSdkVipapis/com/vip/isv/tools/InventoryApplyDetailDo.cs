using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class InventoryApplyDetailDo {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 库存数量
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 购物车数量
		///</summary>
		
		private int? cartQuantity_;
		
		///<summary>
		/// 剩余库存
		///</summary>
		
		private int? sellableQuantity_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 更新库存消息
		///</summary>
		
		private string message_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		///<summary>
		/// 更新库存时间
		///</summary>
		
		private System.DateTime? updateTime_;
		
		///<summary>
		/// 是否增量更新:0、增量；1、全量
		///</summary>
		
		private int? isIncrement_;
		
		///<summary>
		/// 实际更新库存
		///</summary>
		
		private int? realQuantity_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperationNo_;
		
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
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public int? GetCartQuantity(){
			return this.cartQuantity_;
		}
		
		public void SetCartQuantity(int? value){
			this.cartQuantity_ = value;
		}
		public int? GetSellableQuantity(){
			return this.sellableQuantity_;
		}
		
		public void SetSellableQuantity(int? value){
			this.sellableQuantity_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		public System.DateTime? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(System.DateTime? value){
			this.createTime_ = value;
		}
		public System.DateTime? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(System.DateTime? value){
			this.updateTime_ = value;
		}
		public int? GetIsIncrement(){
			return this.isIncrement_;
		}
		
		public void SetIsIncrement(int? value){
			this.isIncrement_ = value;
		}
		public int? GetRealQuantity(){
			return this.realQuantity_;
		}
		
		public void SetRealQuantity(int? value){
			this.realQuantity_ = value;
		}
		public int? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(int? value){
			this.cooperationNo_ = value;
		}
		
	}
	
}