using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class ScheduleSkusDo {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string goodsName_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brandName_;
		
		///<summary>
		/// 合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 是否初始库存
		///</summary>
		
		private int? initStockState_;
		
		///<summary>
		/// m_size_id
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 删除状态
		///</summary>
		
		private int? isDeleted_;
		
		///<summary>
		/// 上线状态
		///</summary>
		
		private int? skuState_;
		
		///<summary>
		/// 档期id
		///</summary>
		
		private int? scheduleId_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private System.DateTime? updateTime_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetGoodsName(){
			return this.goodsName_;
		}
		
		public void SetGoodsName(string value){
			this.goodsName_ = value;
		}
		public string GetBrandName(){
			return this.brandName_;
		}
		
		public void SetBrandName(string value){
			this.brandName_ = value;
		}
		public int? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(int? value){
			this.cooperationNo_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public int? GetInitStockState(){
			return this.initStockState_;
		}
		
		public void SetInitStockState(int? value){
			this.initStockState_ = value;
		}
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public int? GetIsDeleted(){
			return this.isDeleted_;
		}
		
		public void SetIsDeleted(int? value){
			this.isDeleted_ = value;
		}
		public int? GetSkuState(){
			return this.skuState_;
		}
		
		public void SetSkuState(int? value){
			this.skuState_ = value;
		}
		public int? GetScheduleId(){
			return this.scheduleId_;
		}
		
		public void SetScheduleId(int? value){
			this.scheduleId_ = value;
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
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		
	}
	
}