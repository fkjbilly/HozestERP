using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class SalesSkusDo {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private long? vendorId_;
		
		///<summary>
		/// 专场ID
		///</summary>
		
		private long? salesNo_;
		
		///<summary>
		/// 合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// m_size_id
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 删除状态
		///</summary>
		
		private int? isDeleted_;
		
		///<summary>
		/// 上下线状态
		///</summary>
		
		private int? skuState_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		public long? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(long? value){
			this.vendorId_ = value;
		}
		public long? GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(long? value){
			this.salesNo_ = value;
		}
		public int? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(int? value){
			this.cooperationNo_ = value;
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
		public System.DateTime? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(System.DateTime? value){
			this.createTime_ = value;
		}
		
	}
	
}