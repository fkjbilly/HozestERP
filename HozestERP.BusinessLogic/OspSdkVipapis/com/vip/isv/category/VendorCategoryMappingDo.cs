using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.category{
	
	
	
	
	
	public class VendorCategoryMappingDo {
		
		///<summary>
		/// 类目id
		///</summary>
		
		private int? id_;
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 类目匹配树id
		///</summary>
		
		private int? vendorCategoryTreeId_;
		
		///<summary>
		/// 类目匹配树名称
		/// @sampleValue vendorCategoryTreeName 天猫类目
		///</summary>
		
		private string vendorCategoryTreeName_;
		
		///<summary>
		/// 供应商类目树(完整树路径)
		/// @sampleValue vendorCategoryPath 女装>裙装>连衣裙
		///</summary>
		
		private string vendorCategoryPath_;
		
		///<summary>
		/// 供应商叶子类目名称
		///</summary>
		
		private string vendorCategoryName_;
		
		///<summary>
		/// 供应商叶子类目id
		///</summary>
		
		private string vendorCategoryId_;
		
		///<summary>
		/// 唯品会类目树名称(完整树路径)
		/// @sampleValue vipCategoryPath 女装>裙装>连衣裙
		///</summary>
		
		private string vipCategoryPath_;
		
		///<summary>
		/// 唯品会类目树id(完整树id)
		/// @sampleValue vipCategoryPathId 311>1095>334
		///</summary>
		
		private string vipCategoryPathId_;
		
		///<summary>
		/// 唯品会叶子类目名称
		/// @sampleValue vipCategoryName 连衣裙
		///</summary>
		
		private string vipCategoryName_;
		
		///<summary>
		/// 唯品会叶子类目id
		///</summary>
		
		private int? vipCategoryId_;
		
		///<summary>
		/// 匹配状态
		/// @sampleValue status 0-未匹配, 1-预匹配, 5-审核中, 6-审核通过, 7-审核拒绝, 9-已删除
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 匹配度
		///</summary>
		
		private double? similarPoint_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private System.DateTime? updateTime_;
		
		public int? GetId(){
			return this.id_;
		}
		
		public void SetId(int? value){
			this.id_ = value;
		}
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public int? GetVendorCategoryTreeId(){
			return this.vendorCategoryTreeId_;
		}
		
		public void SetVendorCategoryTreeId(int? value){
			this.vendorCategoryTreeId_ = value;
		}
		public string GetVendorCategoryTreeName(){
			return this.vendorCategoryTreeName_;
		}
		
		public void SetVendorCategoryTreeName(string value){
			this.vendorCategoryTreeName_ = value;
		}
		public string GetVendorCategoryPath(){
			return this.vendorCategoryPath_;
		}
		
		public void SetVendorCategoryPath(string value){
			this.vendorCategoryPath_ = value;
		}
		public string GetVendorCategoryName(){
			return this.vendorCategoryName_;
		}
		
		public void SetVendorCategoryName(string value){
			this.vendorCategoryName_ = value;
		}
		public string GetVendorCategoryId(){
			return this.vendorCategoryId_;
		}
		
		public void SetVendorCategoryId(string value){
			this.vendorCategoryId_ = value;
		}
		public string GetVipCategoryPath(){
			return this.vipCategoryPath_;
		}
		
		public void SetVipCategoryPath(string value){
			this.vipCategoryPath_ = value;
		}
		public string GetVipCategoryPathId(){
			return this.vipCategoryPathId_;
		}
		
		public void SetVipCategoryPathId(string value){
			this.vipCategoryPathId_ = value;
		}
		public string GetVipCategoryName(){
			return this.vipCategoryName_;
		}
		
		public void SetVipCategoryName(string value){
			this.vipCategoryName_ = value;
		}
		public int? GetVipCategoryId(){
			return this.vipCategoryId_;
		}
		
		public void SetVipCategoryId(int? value){
			this.vipCategoryId_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public double? GetSimilarPoint(){
			return this.similarPoint_;
		}
		
		public void SetSimilarPoint(double? value){
			this.similarPoint_ = value;
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