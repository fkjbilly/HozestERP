using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class VendorSalesDo {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private long? vendorId_;
		
		///<summary>
		/// 专场ID
		///</summary>
		
		private long? salesNo_;
		
		///<summary>
		/// 专场名称
		///</summary>
		
		private string salesName_;
		
		///<summary>
		/// 开售时间
		///</summary>
		
		private System.DateTime? sellTimeFrom_;
		
		///<summary>
		/// 停售时间
		///</summary>
		
		private System.DateTime? sellTimeTo_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private System.DateTime? updateTime_;
		
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
		public string GetSalesName(){
			return this.salesName_;
		}
		
		public void SetSalesName(string value){
			this.salesName_ = value;
		}
		public System.DateTime? GetSellTimeFrom(){
			return this.sellTimeFrom_;
		}
		
		public void SetSellTimeFrom(System.DateTime? value){
			this.sellTimeFrom_ = value;
		}
		public System.DateTime? GetSellTimeTo(){
			return this.sellTimeTo_;
		}
		
		public void SetSellTimeTo(System.DateTime? value){
			this.sellTimeTo_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
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
		
	}
	
}