using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class VendorScheduleDo {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		///<summary>
		/// 合作编码名称
		///</summary>
		
		private string cooperationName_;
		
		///<summary>
		/// 品牌
		///</summary>
		
		private string brandName_;
		
		///<summary>
		/// 档期ID
		///</summary>
		
		private int? scheduleId_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 主专场ID
		///</summary>
		
		private int? showId_;
		
		///<summary>
		/// 是否隐性专场
		///</summary>
		
		private int? isHidden_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private System.DateTime? updateTime_;
		
		///<summary>
		/// 删除状态
		///</summary>
		
		private int? isDeleted_;
		
		///<summary>
		/// 主键
		///</summary>
		
		private long? id_;
		
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
		public string GetCooperationName(){
			return this.cooperationName_;
		}
		
		public void SetCooperationName(string value){
			this.cooperationName_ = value;
		}
		public string GetBrandName(){
			return this.brandName_;
		}
		
		public void SetBrandName(string value){
			this.brandName_ = value;
		}
		public int? GetScheduleId(){
			return this.scheduleId_;
		}
		
		public void SetScheduleId(int? value){
			this.scheduleId_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetShowId(){
			return this.showId_;
		}
		
		public void SetShowId(int? value){
			this.showId_ = value;
		}
		public int? GetIsHidden(){
			return this.isHidden_;
		}
		
		public void SetIsHidden(int? value){
			this.isHidden_ = value;
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
		public int? GetIsDeleted(){
			return this.isDeleted_;
		}
		
		public void SetIsDeleted(int? value){
			this.isDeleted_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		
	}
	
}